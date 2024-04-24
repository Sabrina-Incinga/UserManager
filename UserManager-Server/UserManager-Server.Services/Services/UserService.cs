using System;
using System.Collections.Generic;
using System.Linq;
using UserManager.DataAccess.Services;
using UserManager.DataAccess.Services.Repositories;
using UserManager.Model;
using UserManager.Services.Exceptions;
using UserManager.Services.Model;

namespace UserManager.Services;

public class UserService : IUserService
{
    private readonly IUMUnitOfWork _unitOfWork;
    private readonly IRepository<User> _userRepository;

    public UserService(IUMUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRepository = _unitOfWork.GetRepository<User>();
    }

    public User AddUser(UserCreateRequest entity)
    {
        var newUser = new User()
        {
            Name = entity.Name,
            BirthDate = entity.BirthDate,
            Active = true,
        };

        var createdUser = _userRepository.Add(newUser);

        _userRepository.SaveChanges();

        return createdUser;
    }

    public void DeleteUser(int userId)
    {
        var user = _userRepository.GetAll().Where(u => u.Id == userId).FirstOrDefault() ?? throw new NotFoundException("User not found");

        _userRepository.Delete(user);
        _userRepository.SaveChanges();
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAll().Where(u => u.Active);
    }

    public User? GetUserById(int userId)
    {
        return _userRepository.GetById(userId);
    }

    public User UpdateUser(int userId, UserUpdateRequest entity)
    {
        var userToUpdate = _userRepository.GetById(userId) ?? throw new NotFoundException("User not found");

        userToUpdate.Name = entity.Name;
        userToUpdate.BirthDate = entity.BirthDate;
        userToUpdate.Active = entity.Active;
        userToUpdate.Version = entity.Version;

        var updatedUser = _userRepository.Update(userToUpdate);
        _userRepository.SaveChanges();

        return updatedUser;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using UserManager.DataAccess.Services;
using UserManager.DataAccess.Services.Repositories;
using UserManager.Model;

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

    public User AddUser(User entity)
    {
        entity.Active = true;
        var createdUser = _userRepository.Add(entity);

        _userRepository.SaveChanges();

        return createdUser;
    }

    public void DeleteUser(int userId)
    {
        var user = _userRepository.GetAll().Where(u => u.Id == userId).FirstOrDefault() ?? throw new Exception("User not found");

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

    public User UpdateUser(User entity)
    {
        var updatedUser = _userRepository.Update(entity);
        _userRepository.SaveChanges();

        return updatedUser;
    }
}


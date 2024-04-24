using System.Collections.Generic;
using UserManager.Model;
using UserManager.Services.Model;

namespace UserManager.Services;

public interface IUserService
{
    IEnumerable<User> GetAllUsers();
    User AddUser(UserCreateRequest entity);
    User UpdateUser(int userId, UserUpdateRequest entity);
    void DeleteUser(int userId);
    User? GetUserById(int userId);
}

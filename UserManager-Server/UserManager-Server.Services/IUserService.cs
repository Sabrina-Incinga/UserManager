using System.Collections.Generic;
using UserManager.Model;

namespace UserManager.Services;

public interface IUserService
{
    IEnumerable<User> GetAllUsers();
    User AddUser(User entity);
    User UpdateUser(User entity);
    void DeleteUser(int userId);
    User? GetUserById(int userId);
}

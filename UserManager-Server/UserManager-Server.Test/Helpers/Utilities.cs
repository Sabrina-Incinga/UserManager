using System;
using UserManager.DataAccess.Services;
using UserManager.Model;

namespace UserManager.Test.Helpers;
public static class Utilities
{
    public static void InitializeUser(IUMUnitOfWork unitOfWork)
    {
        var user1 = new User()
        {
            Name = "John Doe",
            BirthDate = new DateTime(2000, 05, 10),
            Active = true,
            Version = Array.Empty<byte>()
        };

        var user2 = new User()
        {
            Name = "Jane Doe",
            BirthDate = new DateTime(1995, 05, 02),
            Active = true,
            Version = Array.Empty<byte>()
        };

        var userRepository = unitOfWork.GetRepository<User>();

        userRepository.Add(user1);
        userRepository.Add(user2);
        userRepository.SaveChanges();
    }
}
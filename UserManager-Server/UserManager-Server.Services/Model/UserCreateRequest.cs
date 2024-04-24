using System;

namespace UserManager.Services.Model;
public class UserCreateRequest
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
}
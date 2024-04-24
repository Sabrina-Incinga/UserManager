using System;

namespace UserManager.Services.Model;
public class UserUpdateRequest
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
    public byte[] Version { get; set; }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserManager.Model;
using UserManager.Services;
using UserManager.Services.Model;

namespace UserManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("")]
    public ActionResult<IEnumerable<User>> GetActiveUsers()
    {
        var list = _userService.GetAllUsers();
        return Ok(list);
    }

    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] UserCreateRequest entity)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var newUser = _userService.AddUser(entity);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{key:int}")]
    public ActionResult<User> UpdateUser([FromRoute] int key, [FromBody] UserUpdateRequest entity)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(_userService.UpdateUser(key, entity));
    }

    [HttpDelete("{key:int}")]
    public IActionResult DeleteUser([FromRoute] int key)
    {
        _userService.DeleteUser(key);
        return NoContent();
    }

    [HttpGet("{id}")]
    public ActionResult<User?> GetUserById(int id)
    {
        return _userService.GetUserById(id);
    }
}

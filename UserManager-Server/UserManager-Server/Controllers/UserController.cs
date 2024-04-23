using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserManager.Model;
using UserManager.Services;

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
    public ActionResult<User> CreteUser([FromBody] User entity)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var newUser = _userService.AddUser(entity);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }
        catch (Exception e)
        {
            return Problem(
                title: "Exception",
                detail: e.Message,
                statusCode: StatusCodes.Status400BadRequest);
        }
    }

    [HttpPut]
    public ActionResult<User> UpdateUser([FromBody] User entity)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            return Ok(_userService.UpdateUser(entity));
        }
        catch (Exception e)
        {
            return Problem(
                title: "Exception",
                detail: e.Message,
                statusCode: StatusCodes.Status400BadRequest);
        }
    }

    [HttpDelete("{key:int}")]
    public IActionResult DeleteUser([FromRoute] int key)
    {
        try
        {
            _userService.DeleteUser(key);
            return NoContent();
        }
        catch (Exception e)
        {
            return Problem(
                title: "Exception",
                detail: e.Message,
                statusCode: StatusCodes.Status400BadRequest);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<User?> GetUserById(int id)
    {
        return _userService.GetUserById(id);
    }
}

using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("users")]
[ApiController]
public class UserController : Controller
{
    private readonly IService<User> _service;

    public UserController(IService<User> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var user = _service.Get(id);
        if (user is null) return NotFound("User not found");
        return Ok(user);
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok(_service.List());
    }

    [HttpPost("login")]
    public IActionResult Login(String email, String password)
    {
        var user = _service.List().FirstOrDefault(u => u.Email.Equals(email));
        if (user == null) return BadRequest("user not found");
        if (!user.Password.Equals(password))
            return BadRequest("wrong password");
        return Ok(user);
    }

    [HttpPost("register")]
    public IActionResult Create(User user)
    {
        if (_service.List().Any(u => u.Email.Equals(user.Email)))
            return BadRequest("email already used");
        _service.Create(user);
        return Ok(user);
    }

    [HttpPut("update")]
    public IActionResult Update(User user)
    {
        User? newU = _service.Update(user);
        if (newU is null)
            return BadRequest("email already used");
        return Ok(newU);
    }
    
    [HttpPut("changepass")]
    public IActionResult ChangePassword(String email, String newPassword)
    {
        var user = _service.List().FirstOrDefault(u => u.Email.Equals(email));
        if (user is null) return NotFound("User not found");
        var newUser = new User(user.Id, user.FirstName, user.LastName, user.Email, newPassword,
            user.PhoneNumber, user.Address, user.IsAdmin);
        _service.Update(newUser);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result) return NotFound("User not found");
        return Ok(result);
    }
}
using Microsoft.AspNetCore.Identity;
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

    [HttpPut]
    public IActionResult Update(User user)
    {
        User? newU = _service.Update(user);
        return Ok(newU);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result) return NotFound("User not found");
        return Ok(result);
    }
}
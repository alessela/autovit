using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("users")]
public class UserController : BaseController<User>
{
    public UserController(BaseService<User> service) : base(service)
    {
    }
    
    [HttpPost("login")]
    public IActionResult Login(string email, string password)
    {
        var user = Service.List().FirstOrDefault(u => u.Email.Equals(email));
        if (user == null) return BadRequest("user not found");
        if (!user.Password.Equals(password))
            return BadRequest("wrong password");
        return Ok(user);
    }
}
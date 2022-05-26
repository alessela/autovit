using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("messages")]
public class MessageController : BaseController<Message>
{
    public MessageController(BaseService<Message> service) : base(service)
    {
    }
    
    [HttpGet("user/{id1:int}/user/{id2:int}")]
    public IActionResult GetByBrand(int id1,int id2)
    {
        return Ok(Service.List().FindAll(m => m.SenderId == id1 && m.ReceiverId == id2
                                                || m.SenderId == id2 && m.ReceiverId == id1));
    }
}
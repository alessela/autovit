using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("cars")]
public class CarController : BaseController<Car>
{
    public CarController(BaseService<Car> service) : base(service)
    {
    }
    
    [HttpGet("seller/{id:int}")]
    public IActionResult GetBySeller(int id)
    {
        return Ok(Service.List().FindAll(o => o.SellerId == id));
    }
}
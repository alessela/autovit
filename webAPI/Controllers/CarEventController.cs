using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("car_events")]
public class CarEventController : BaseController<CarEvent>
{
    public CarEventController(BaseService<CarEvent> service) : base(service)
    {
    }
    
    [HttpGet("car/{id:int}")]
    public IActionResult GetByCar(int id)
    {
        return Ok(Service.List().FindAll(o => o.CarId == id));
    }
}
using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("cities")]
public class CityController : BaseController<City>
{
    public CityController(BaseService<City> service) : base(service)
    {
    }

    [HttpGet("county/{id:int}")]
    public IActionResult GetByCounty(int id)
    {
        return Ok(Service.List().FindAll(o => o.CountyId == id));
    }

}
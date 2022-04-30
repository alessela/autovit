using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("fuels")]
[ApiController]
public class FuelController : Controller
{
    private readonly IService<Fuel> _service;

    public FuelController(IService<Fuel> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var fuel = _service.Get(id);
        if (fuel is null) return NotFound("Body style not found");
        return Ok(fuel);
    }

    [HttpPost]
    public IActionResult Create(Fuel fuel)
    {
        _service.Create(fuel);
        return Ok(fuel);
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok(_service.List());
    }

    [HttpPut]
    public IActionResult Update(Fuel fuel)
    {
        return Ok(_service.Update(fuel));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result) return NotFound("Fuel not found");
        return Ok(result);
    }
}
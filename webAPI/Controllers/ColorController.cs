using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("colors")]
[ApiController]
public class ColorController : Controller
{
    private readonly IService<Color> _service;

    public ColorController(IService<Color> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var color = _service.Get(id);
        if (color is null) return NotFound("Color not found");
        return Ok(color);
    }
    
    [HttpPost]
    public IActionResult Create(Color color)
    {
        _service.Create(color);
        return Ok(color);
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok(_service.List());
    }

    [HttpPut]
    public IActionResult Update(Color color)
    {
        return Ok(_service.Update(color));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result) return NotFound("Color not found");
        return Ok(result);
    }
}
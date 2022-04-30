using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("bodystyles")]
[ApiController]
public class BodyStyleController : Controller
{
    private readonly IService<BodyStyle> _service;

    public BodyStyleController(IService<BodyStyle> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var bodystyle = _service.Get(id);
        if (bodystyle is null) return NotFound("Body style not found");
        return Ok(bodystyle);
    }

    [HttpPost]
    public IActionResult Create(BodyStyle bodyStyle)
    {
        _service.Create(bodyStyle);
        return Ok(bodyStyle);
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok(_service.List());
    }

    [HttpPut]
    public IActionResult Update(BodyStyle bodyStyle)
    {
        return Ok(_service.Update(bodyStyle));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result) return NotFound("Body style not found");
        return Ok(result);
    }
}
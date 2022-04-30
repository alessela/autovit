using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("transmissions")]
[ApiController]
public class TransmissionController : Controller
{
    private readonly IService<Transmission> _service;

    public TransmissionController(IService<Transmission> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var t = _service.Get(id);
        if (t is null) return NotFound("Transmission not found");
        return Ok(t);
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok(_service.List());
    }

    [HttpPost]
    public IActionResult Create(Transmission transmission)
    {
        _service.Create(transmission);
        return Ok(transmission);
    }

    [HttpPut]
    public IActionResult Update(Transmission transmission)
    {
        return Ok(_service.Update(transmission));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result) return NotFound("Transmission not found");
        return Ok(result);
    }
}
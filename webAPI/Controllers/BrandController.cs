using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("brands")]
[ApiController]  
public class BrandController : Controller
{
    private readonly IService<Brand> _service;

    public BrandController(IService<Brand> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var brand = _service.Get(id);
        if (brand is null) return NotFound("Brand not found");
        return Ok(brand);
    }

    [HttpPost]
    public IActionResult Create(Brand brand)
    {
        _service.Create(brand);
        return Ok(brand);
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok(_service.List());
    }

    [HttpPut]
    public IActionResult Update(Brand brand)
    {
        return Ok(_service.Update(brand));
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result) return NotFound("Brand not found");
        return Ok(result);
    }
}
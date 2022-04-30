using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("models")]
[ApiController]
public class ModelController : Controller
{
    private readonly IService<Model> _service;

    public ModelController(IService<Model> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var model = _service.Get(id);
        if (model is null) return NotFound("Model not found");
        return Ok(model);
    }

    [HttpGet("brand/{id}")]
    public IActionResult GetByBrand(int id)
    {
        return Ok(_service.List().FindAll(o => o.BrandId == id));
    }

    [HttpPost]
    public IActionResult Create(Model model)
    {
        _service.Create(model);
        return Ok(model);
    }

    [HttpPut]
    public IActionResult Update(Model model)
    {
        return Ok(_service.Update(model));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result) return NotFound("Brand not found");
        return Ok(result);
    }

}
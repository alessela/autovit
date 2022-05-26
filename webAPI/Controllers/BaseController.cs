using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[ApiController]
public class BaseController<T> : Controller where T : Base
{
    private protected readonly BaseService<T> Service;

    public BaseController(BaseService<T> service)
    {
        Service = service;
    }
    
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var item = Service.Get(id);
        if (item is null) return NotFound("Item not found");
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(T item)
    {
        if (Service.Create(item) is null) return BadRequest("Cannot create a new item");
        return Ok(item);
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok(Service.List());
    }

    [HttpPut]
    public IActionResult Update(T item)
    {
        if (Service.Update(item) is null) return NotFound("Item not found");
        return Ok(item);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (!Service.Delete(id)) return NotFound("Item not found");
        return Ok("Item deleted");
    }
}
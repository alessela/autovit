using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("models")]
public class ModelController : BaseController<Model>
{
    public ModelController(BaseService<Model> service) : base(service)
    {
    }
    
    [HttpGet("brand/{id:int}")]
    public IActionResult GetByBrand(int id)
    {
        return Ok(Service.List().FindAll(o => o.BrandId == id));
    }
}
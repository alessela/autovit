using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("brands")]
public class BrandController : BaseController<Brand>
{
    public BrandController(BaseService<Brand> service) : base(service)
    {
    }
}
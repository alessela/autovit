using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("colors")]
public class ColorController : BaseController<Color>
{
    public ColorController(BaseService<Color> service) : base(service)
    {
    }
}
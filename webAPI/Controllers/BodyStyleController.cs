using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("body_styles")]
public class BodyStyleController : BaseController<BodyStyle>
{
    public BodyStyleController(BaseService<BodyStyle> service) : base(service)
    {
    }
}
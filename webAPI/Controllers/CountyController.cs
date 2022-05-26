using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("counties")]
public class CountyController : BaseController<County>
{
    public CountyController(BaseService<County> service) : base(service)
    {
    }
}
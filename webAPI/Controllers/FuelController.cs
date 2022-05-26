using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("fuels")]
public class FuelController : BaseController<Fuel>
{
    public FuelController(BaseService<Fuel> service) : base(service)
    {
    }
}
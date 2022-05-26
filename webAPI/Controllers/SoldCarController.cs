using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("sold_cars")]
public class SoldCarController : BaseController<SoldCar>
{
    public SoldCarController(BaseService<SoldCar> service) : base(service)
    {
    }
}
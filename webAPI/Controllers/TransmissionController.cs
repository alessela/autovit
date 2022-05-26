using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("transmissions")]
public class TransmissionController : BaseController<Transmission>
{
    public TransmissionController(BaseService<Transmission> service) : base(service)
    {
    }
}
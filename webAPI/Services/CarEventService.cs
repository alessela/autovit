using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class CarEventService : BaseService<CarEvent>
{
    public CarEventService(BaseContext<CarEvent> context) : base(context)
    {
    }
}
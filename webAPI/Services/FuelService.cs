using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class FuelService : BaseService<Fuel>
{
    public FuelService(BaseContext<Fuel> context) : base(context)
    {
    }
}
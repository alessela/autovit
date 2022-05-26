using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class SoldCarService : BaseService<SoldCar>
{
    public SoldCarService(BaseContext<SoldCar> context) : base(context)
    {
    }
}
using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class CarService : BaseService<Car>
{
    public CarService(BaseContext<Car> context) : base(context)
    {
    }
}
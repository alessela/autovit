using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class CityService : BaseService<City>
{
    public CityService(BaseContext<City> context) : base(context)
    {
    }
}
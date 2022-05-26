using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class CountyService : BaseService<County>
{
    public CountyService(BaseContext<County> context) : base(context)
    {
    }
}
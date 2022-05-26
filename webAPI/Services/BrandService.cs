using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class BrandService : BaseService<Brand>
{
    public BrandService(BaseContext<Brand> context) : base(context)
    {
    }
}
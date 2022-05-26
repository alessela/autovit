using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class BrandContext : BaseContext<Brand>
{
    public BrandContext(DbContextOptions<BaseContext<Brand>> options) : base(options)
    {
    }
}
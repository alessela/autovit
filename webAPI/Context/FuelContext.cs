using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class FuelContext : BaseContext<Fuel>
{
    public FuelContext(DbContextOptions<BaseContext<Fuel>> options) : base(options)
    {
    }
}
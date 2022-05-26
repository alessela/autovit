using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class CountyContext : BaseContext<County>
{
    public CountyContext(DbContextOptions<BaseContext<County>> options) : base(options)
    {
    }
}
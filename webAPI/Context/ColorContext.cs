using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class ColorContext : BaseContext<Color>
{
    public ColorContext(DbContextOptions<BaseContext<Color>> options) : base(options)
    {
    }
}
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class BodyStyleContext : BaseContext<BodyStyle>
{
    public BodyStyleContext(DbContextOptions<BaseContext<BodyStyle>> options) : base(options)
    {
    }
}
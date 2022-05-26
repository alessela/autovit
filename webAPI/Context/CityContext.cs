using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class CityContext : BaseContext<City>
{
    public CityContext(DbContextOptions<BaseContext<City>> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<City>().HasOne<County>().WithMany().HasPrincipalKey(c => c.Id).HasForeignKey(c => c.CountyId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class CarEventContext : BaseContext<CarEvent>
{
    public CarEventContext(DbContextOptions<BaseContext<CarEvent>> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CarEvent>().HasOne<Car>().WithMany().HasPrincipalKey(c => c.Id).HasForeignKey(ce => ce.CarId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
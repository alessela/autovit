using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class SoldCarContext : BaseContext<SoldCar>
{
    public SoldCarContext(DbContextOptions<BaseContext<SoldCar>> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<SoldCar>().HasOne<Car>().WithMany().HasPrincipalKey(c => c.Id).HasForeignKey(s => s.CarId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<SoldCar>().HasOne<User>().WithMany().HasPrincipalKey(u => u.Id).HasForeignKey(s => s.BuyerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class CarContext : BaseContext<Car>
{
    public CarContext(DbContextOptions<BaseContext<Car>> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Car>().HasOne<Model>().WithMany().HasPrincipalKey(m => m.Id).HasForeignKey(c => c.ModelId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Car>().HasOne<BodyStyle>().WithMany().HasPrincipalKey(b => b.Id)
            .HasForeignKey(c => c.BodyStyleId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Car>().HasOne<Fuel>().WithMany().HasPrincipalKey(f => f.Id).HasForeignKey(c => c.FuelId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Car>().HasOne<Transmission>().WithMany().HasPrincipalKey(t => t.Id)
            .HasForeignKey(c => c.TransmissionId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Car>().HasOne<Color>().WithMany().HasPrincipalKey(c => c.Id).HasForeignKey(c => c.ColorId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Car>().HasOne<User>().WithMany().HasPrincipalKey(u => u.Id).HasForeignKey(s => s.SellerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
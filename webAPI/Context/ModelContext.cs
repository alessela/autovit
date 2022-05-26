using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class ModelContext : BaseContext<Model>
{
    public ModelContext(DbContextOptions<BaseContext<Model>> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Model>().HasOne<Brand>().WithMany().HasPrincipalKey(b => b.Id).HasForeignKey(m => m.BrandId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class UserContext : BaseContext<User>
{
    public UserContext(DbContextOptions<BaseContext<User>> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasOne<City>().WithMany().HasPrincipalKey(c => c.Id).HasForeignKey(u => u.CityId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
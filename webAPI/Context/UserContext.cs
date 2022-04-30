using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using webAPI.Models;

namespace webAPI.Context;

public class UserContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_User");
        modelBuilder.Entity<User>().Property(u => u.Id).UseMySQLAutoIncrementColumn("id").HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnName("first_name").HasColumnType("varchar(64)")
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.LastName).HasColumnName("last_name").HasColumnType("varchar(64)")
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("email").HasColumnType("varchar(64)")
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("password").HasColumnType("varchar(32)")
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Address).HasColumnName("address").HasColumnType("varchar(128)")
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.IsAdmin).HasColumnName("is_admin").HasColumnType("tinyint")
            .IsRequired();
    }
}
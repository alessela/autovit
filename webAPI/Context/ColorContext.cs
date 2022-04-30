using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using webAPI.Models;

namespace webAPI.Context;

public class ColorContext : DbContext
{
    public DbSet<Color> Colors => Set<Color>();

    public ColorContext(DbContextOptions<ColorContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>().ToTable("Color");
        modelBuilder.Entity<Color>().HasKey(c => c.Id).HasName("PK_Color");
        modelBuilder.Entity<Color>().Property(c => c.Id).UseMySQLAutoIncrementColumn("id").HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<Color>().Property(c => c.Name).HasColumnName("name").HasColumnType("varchar(32)")
            .IsRequired();
    }
}
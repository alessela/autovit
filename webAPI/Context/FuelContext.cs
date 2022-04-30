using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using webAPI.Models;

namespace webAPI.Context;

public class FuelContext : DbContext
{
    public DbSet<Fuel> Fuels => Set<Fuel>();

    public FuelContext(DbContextOptions<FuelContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fuel>().ToTable("Fuel");
        modelBuilder.Entity<Fuel>().HasKey(f => f.Id).HasName("PK_Fuel");

        modelBuilder.Entity<Fuel>().Property(f => f.Id).UseMySQLAutoIncrementColumn("id").HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<Fuel>().Property(f => f.Name).HasColumnName("name").HasColumnType("varchar(32)")
            .IsRequired();
    }
}
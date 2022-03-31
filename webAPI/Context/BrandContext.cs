using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using webAPI.Models;

namespace webAPI.Context;

public class BrandContext : DbContext
{
    public DbSet<Brand> Brands { get; set; }

    public BrandContext(DbContextOptions<BrandContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // mapare entitate la tabela
        modelBuilder.Entity<Brand>().ToTable("Brand");
        
        //cheie primara
        modelBuilder.Entity<Brand>().HasKey(u => u.Id).HasName("PK_Brand");
        
        //coloane
        modelBuilder.Entity<Brand>().Property(o => o.Id).UseMySQLAutoIncrementColumn("id").HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<Brand>().Property(o => o.Name).HasColumnName("name").HasColumnType("varchar(32)")
            .IsRequired();
        modelBuilder.Entity<Brand>().Property(o => o.Logo).HasColumnName("logo").HasColumnType("varchar(256)")
            .IsRequired();
    }
}
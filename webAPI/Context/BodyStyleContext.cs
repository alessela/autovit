using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using webAPI.Models;

namespace webAPI.Context;

public class BodyStyleContext : DbContext
{
    public DbSet<BodyStyle> BodyStyles => Set<BodyStyle>();

    public BodyStyleContext(DbContextOptions<BodyStyleContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BodyStyle>().ToTable("BodyStyle");

        modelBuilder.Entity<BodyStyle>().HasKey(b => b.Id).HasName("PK_BodyStyle");

        modelBuilder.Entity<BodyStyle>().Property(b => b.Id).UseMySQLAutoIncrementColumn("id").HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<BodyStyle>().Property(b => b.Name).HasColumnName("name").HasColumnType("varchar(32)")
            .IsRequired();
    }
}
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using webAPI.Models;

namespace webAPI.Context;

public class ModelContext : DbContext
{
    public DbSet<Model> Models => Set<Model>();

    public ModelContext(DbContextOptions<ModelContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Model>().ToTable("Model");
        modelBuilder.Entity<Model>().HasKey(u => u.Id).HasName("PK_Model");
        modelBuilder.Entity<Model>().Property(o => o.Id).UseMySQLAutoIncrementColumn("id").HasColumnName("int")
            .IsRequired();
        modelBuilder.Entity<Model>().Property(o => o.BrandId).HasColumnName("brand_id").HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<Model>().Property(o => o.Name).HasColumnName("name").HasColumnType("varchar(32)")
            .IsRequired();

        modelBuilder.Entity<Model>().HasOne<Brand>().WithMany().HasPrincipalKey(b => b.Id).HasForeignKey(m => m.BrandId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
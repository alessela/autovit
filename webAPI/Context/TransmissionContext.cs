using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using webAPI.Models;

namespace webAPI.Context;

public class TransmissionContext : DbContext
{
    public DbSet<Transmission> Transmissions => Set<Transmission>();

    public TransmissionContext(DbContextOptions<TransmissionContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transmission>().ToTable("Transmission");
        modelBuilder.Entity<Transmission>().HasKey(t => t.Id).HasName("PK_Transmission");
        modelBuilder.Entity<Transmission>().Property(t => t.Id).UseMySQLAutoIncrementColumn("id").HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<Transmission>().Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(32)")
            .IsRequired();
    }
}
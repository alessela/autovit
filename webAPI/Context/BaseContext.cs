using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using webAPI.Models;

namespace webAPI.Context;

public class BaseContext<T> : DbContext where T : Base
{
    public DbSet<T> Items => Set<T>();

    public BaseContext(DbContextOptions<BaseContext<T>> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<T>().ToTable(typeof(T).Name);
        modelBuilder.Entity<T>().HasKey(o => o.Id).HasName("PK_"+typeof(T).Name);
        modelBuilder.Entity<T>().Property(o => o.Id).UseMySQLAutoIncrementColumn("id").HasColumnType("int")
            .IsRequired();
        
        foreach (var field in typeof(T).GetFields())
        {
            string sqlType;
            if (field.FieldType == typeof(int)) sqlType = "int";
            else if (field.FieldType == typeof(string)) sqlType = "varchar(32)";
            else if (field.FieldType == typeof(bool)) sqlType = "tinyint";
            else sqlType = "date";
            modelBuilder.Entity<T>().Property(o => field.GetValue(o)).HasColumnName(field.Name).HasColumnType(sqlType)
                .IsRequired();
            
        }
    }
}
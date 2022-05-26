using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class MessageContext : BaseContext<Message>
{
    public MessageContext(DbContextOptions<BaseContext<Message>> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Message>().HasOne<User>().WithMany().HasPrincipalKey(u => u.Id).HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Message>().HasOne<User>().WithMany().HasPrincipalKey(u => u.Id).HasForeignKey(m => m.ReceiverId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
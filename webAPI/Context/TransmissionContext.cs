using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context;

public class TransmissionContext : BaseContext<Transmission>
{
    public TransmissionContext(DbContextOptions<BaseContext<Transmission>> options) : base(options)
    {
    }
}
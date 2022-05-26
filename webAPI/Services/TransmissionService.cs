using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class TransmissionService : BaseService<Transmission>
{
    public TransmissionService(BaseContext<Transmission> context) : base(context)
    {
    }
}
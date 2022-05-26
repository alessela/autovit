using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class ColorService : BaseService<Color>
{
    public ColorService(BaseContext<Color> context) : base(context)
    {
    }
}
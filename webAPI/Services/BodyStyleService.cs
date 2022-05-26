using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class BodyStyleService : BaseService<BodyStyle>
{
    public BodyStyleService(BaseContext<BodyStyle> context) : base(context)
    {
    }
}
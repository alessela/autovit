using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class ModelService : BaseService<Model>
{
    public ModelService(BaseContext<Model> context) : base(context)
    {
    }
}
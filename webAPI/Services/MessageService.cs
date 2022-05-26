using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class MessageService : BaseService<Message>
{
    public MessageService(BaseContext<Message> context) : base(context)
    {
    }
}
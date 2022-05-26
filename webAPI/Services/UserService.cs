using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class UserService : BaseService<User>
{
    public UserService(BaseContext<User> context) : base(context)
    {
    }

    public override User? Create(User o)
    {
        if (Context.Items.Any(u => u.Email.Equals(o.Email)))
            return null;
        if (!Context.Items.Any()) o.Id = 1;
        else o.Id = List()[Context.Items.Count() - 1].Id + 1;
        Context.Items.Add(o);
        Context.SaveChanges();
        return o;
    }

    public override User? Update(User newO)
    {
        var oldO = Get(newO.Id);
        if (oldO is null) return null;
        var anotherUser = Context.Items.FirstOrDefault(o => o.Email.Equals(newO.Email));
        if (anotherUser is not null)
            if (anotherUser.Id != oldO.Id)
                return null;
        oldO.Address = newO.Address;
        oldO.Email = newO.Email;
        oldO.Password = newO.Password;
        oldO.FirstName = newO.FirstName;
        oldO.LastName = newO.LastName;
        oldO.PhoneNumber = newO.PhoneNumber;
        oldO.CityId = newO.CityId;
        Context.SaveChanges();
        return newO;
    }
}
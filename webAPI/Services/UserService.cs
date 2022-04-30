using System.Runtime.CompilerServices;
using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class UserService : IService<User>
{
    private readonly UserContext _context;

    public UserService(UserContext context)
    {
        _context = context;
    }

    public User? Get(int id)
    {
        return _context.Users.FirstOrDefault(o => o.Id == id);
    }
    
    public List<User> List()
    {
        return _context.Users.ToList();
    }

    public User Create(User o)
    {
        if (!_context.Users.Any()) o.Id = 1;
        else o.Id = _context.Users.ToList()[_context.Users.Count() - 1].Id + 1;
        _context.Users.Add(o);
        _context.SaveChanges();
        return o;
    }

    public User? Update(User newO)
    {
        var oldO = Get(newO.Id);
        if (oldO is null) return null;
        var anotherUser = _context.Users.FirstOrDefault(o => o.Email.Equals(newO.Email));
        if (anotherUser is not null)
            if (anotherUser.Id != oldO.Id)
                return null;
        oldO.Address = newO.Address;
        oldO.Email = newO.Email;
        oldO.Password = newO.Password;
        oldO.FirstName = newO.FirstName;
        oldO.LastName = newO.LastName;
        oldO.PhoneNumber = newO.PhoneNumber;
        _context.SaveChanges();
        return newO;
    }

    public bool Delete(int id)
    {
        User? oldUser = Get(id);
        if (oldUser is null) return false;
        _context.Users.Remove(oldUser);
        _context.SaveChanges();
        return true;
    }
}
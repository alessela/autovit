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
        o.Id = _context.Users.Count() + 1;
        _context.Users.Add(o);
        _context.SaveChanges();
        return o;
    }

    public User? Update(User newO)
    {
        var oldO = _context.Users.FirstOrDefault(o => o.Id == newO.Id);
        if (oldO is null) return null;
        oldO.FirstName = newO.FirstName;
        oldO.LastName = newO.LastName;
        oldO.Email = newO.Email;
        oldO.Password = newO.Password;
        oldO.PhoneNumber = newO.PhoneNumber;
        oldO.Address = newO.Address;
        _context.SaveChanges();
        return newO;
    }

    public bool Delete(int id)
    {
        User? oldUser = _context.Users.FirstOrDefault(o => o.Id == id);
        if (oldUser is null) return false;
        _context.Users.Remove(oldUser);
        _context.SaveChanges();
        return true;
    }
}
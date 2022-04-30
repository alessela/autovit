using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class ColorService : IService<Color>
{
    private readonly ColorContext _context;

    public ColorService(ColorContext context)
    {
        _context = context;
    }

    public Color? Get(int id)
    {
        return _context.Colors.FirstOrDefault(c => c.Id == id);
    }

    public List<Color> List()
    {
        return _context.Colors.ToList();
    }

    public Color Create(Color o)
    {
        if (!_context.Colors.Any()) o.Id = 1;
        else o.Id = List()[_context.Colors.Count() - 1].Id + 1;
        _context.Colors.Add(o);
        _context.SaveChanges();
        return o;
    }

    public Color? Update(Color newO)
    {
        var oldO = Get(newO.Id);
        if (oldO is null) return null;
        oldO.Name = newO.Name;
        _context.SaveChanges();
        return newO;
    }

    public bool Delete(int id)
    {
        var oldC = Get(id);
        if (oldC is null) return false;
        _context.Colors.Remove(oldC);
        _context.SaveChanges();
        return true;
    }
}
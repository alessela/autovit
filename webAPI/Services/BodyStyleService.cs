using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class BodyStyleService : IService<BodyStyle>
{
    private readonly BodyStyleContext _context;

    public BodyStyleService(BodyStyleContext context)
    {
        _context = context;
    }

    public BodyStyle? Get(int id)
    {
        return _context.BodyStyles.FirstOrDefault(o => o.Id == id);
    }

    public List<BodyStyle> List()
    {
        return _context.BodyStyles.ToList();
    }

    public BodyStyle Create(BodyStyle o)
    {
        if (!_context.BodyStyles.Any()) o.Id = 1;
        else o.Id = List()[_context.BodyStyles.Count() - 1].Id + 1;
        _context.BodyStyles.Add(o);
        _context.SaveChanges();
        return o;
    }

    public BodyStyle? Update(BodyStyle newO)
    {
        var oldO = Get(newO.Id);
        if (oldO is null) return null;
        oldO.Name = newO.Name;
        _context.SaveChanges();
        return newO;
    }

    public bool Delete(int id)
    {
        var oldB = Get(id);
        if (oldB is null) return false;
        _context.BodyStyles.Remove(oldB);
        _context.SaveChanges();
        return true;
    }
}
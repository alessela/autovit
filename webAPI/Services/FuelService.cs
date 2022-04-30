using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class FuelService : IService<Fuel>
{
    private readonly FuelContext _context;

    public FuelService(FuelContext context)
    {
        _context = context;
    }

    public Fuel? Get(int id)
    {
        return _context.Fuels.FirstOrDefault(o => o.Id == id);
    }

    public List<Fuel> List()
    {
        return _context.Fuels.ToList();
    }

    public Fuel Create(Fuel o)
    {
        if (!_context.Fuels.Any()) o.Id = 1;
        else o.Id = List()[_context.Fuels.Count() - 1].Id + 1;
        _context.Fuels.Add(o);
        _context.SaveChanges();
        return o;
    }

    public Fuel? Update(Fuel newO)
    {
        var oldO = Get(newO.Id);
        if (oldO is null) return null;
        oldO.Name = newO.Name;
        _context.SaveChanges();
        return newO;
    }

    public bool Delete(int id)
    {
        var oldF = Get(id);
        if (oldF is null) return false;
        _context.Fuels.Remove(oldF);
        _context.SaveChanges();
        return true;
    }
}
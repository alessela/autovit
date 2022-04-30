using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class TransmissionService : IService<Transmission>
{
    private readonly TransmissionContext _context;

    public TransmissionService(TransmissionContext context)
    {
        _context = context;
    }

    public Transmission? Get(int id)
    {
        return _context.Transmissions.FirstOrDefault(t => t.Id == id);
    }

    public List<Transmission> List()
    {
        return _context.Transmissions.ToList();
    }

    public Transmission Create(Transmission o)
    {
        if (!_context.Transmissions.Any()) o.Id = 1;
        else o.Id = _context.Transmissions.ToList()[_context.Transmissions.Count() - 1].Id + 1;
        _context.Transmissions.Add(o);
        _context.SaveChanges();
        return o;
    }

    public Transmission? Update(Transmission newO)
    {
        var oldO = Get(newO.Id);
        if (oldO is null) return null;
        oldO.Name = newO.Name;
        _context.SaveChanges();
        return newO;
    }

    public bool Delete(int id)
    {
        var oldT = Get(id);
        if (oldT is null) return false;
        _context.Transmissions.Remove(oldT);
        _context.SaveChanges();
        return true;
    }
}
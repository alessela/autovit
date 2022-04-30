using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class ModelService : IService<Model>
{
    private readonly ModelContext _context;

    public ModelService(ModelContext context)
    {
        _context = context;
    }

    public Model? Get(int id)
    {
        return _context.Models.FirstOrDefault(o => o.Id == id);
    }

    public List<Model> List()
    {
        return _context.Models.ToList();
    }

    public Model Create(Model o)
    {
        if (!_context.Models.Any()) o.Id = 1; 
        else o.Id = List()[_context.Models.Count() - 1].Id + 1;
        _context.Models.Add(o);
        _context.SaveChanges();
        return o;
    }

    public Model? Update(Model newO)
    {
        var oldO = Get(newO.Id);
        if (oldO is null) return null;
        oldO.Name = newO.Name;
        oldO.BrandId = newO.BrandId;
        _context.SaveChanges();
        return newO;
    }

    public bool Delete(int id)
    {
        var oldO = Get(id);
        if (oldO is null) return false;
        _context.Models.Remove(oldO);
        _context.SaveChanges();
        return true;
    }
}
using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class BrandService : IService<Brand>
{
    private readonly BrandContext _dbContext;

    public BrandService(BrandContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Brand? Get(int id)
    {
        return _dbContext.Brands.FirstOrDefault(o => o.Id == id);
    }

    public List<Brand> List()
    {
        return _dbContext.Brands.ToList();
    }

    public Brand Create(Brand o)
    {
        if (!_dbContext.Brands.Any()) o.Id = 1;
        else o.Id = List()[_dbContext.Brands.Count() - 1].Id + 1;
        _dbContext.Brands.Add(o);
        _dbContext.SaveChanges();
        return o;
    }

    public Brand? Update(Brand newO)
    {
        var oldO = Get(newO.Id);
        if (oldO is null) return null;
        oldO.Name = newO.Name;
        _dbContext.SaveChanges();
        return newO;
    }

    public bool Delete(int id)
    {
        var oldBrand = Get(id);
        if (oldBrand is null) return false;
        _dbContext.Brands.Remove(oldBrand);
        _dbContext.SaveChanges();
        return true;
    }
}
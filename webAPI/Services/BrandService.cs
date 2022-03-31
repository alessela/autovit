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
        o.Id = _dbContext.Brands.Count() + 1;
        _dbContext.Brands.Add(o);
        _dbContext.SaveChanges();
        return o;
    }

    public Brand? Update(Brand newO)
    {
        var oldO = _dbContext.Brands.FirstOrDefault(o => o.Id == newO.Id);
        if (oldO is null) return null;
        oldO.Name = newO.Name;
        oldO.Logo = newO.Logo;
        _dbContext.SaveChanges();
        return newO;
    }

    public bool Delete(int id)
    {
        Brand? oldBrand = _dbContext.Brands.FirstOrDefault(o => o.Id == id);
        if (oldBrand is null) return false;
        _dbContext.Brands.Remove(oldBrand);
        _dbContext.SaveChanges();
        return true;
    }
}
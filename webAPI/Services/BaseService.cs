using System.Diagnostics.CodeAnalysis;
using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class BaseService<T> where T : Base
{
    private protected readonly BaseContext<T> Context;

    public BaseService(BaseContext<T> context)
    {
        Context = context;
    }

    public T? Get(int id)
    {
        return Context.Items.FirstOrDefault(o => o.Id == id);
    }

    [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
    public List<T> List()
    {
        return Context.Items.ToList();
    }

    public virtual T? Create(T o)
    {
        if (!Context.Items.Any()) o.Id = 1;
        else o.Id = List()[Context.Items.Count() - 1].Id + 1;
        Context.Items.Add(o);
        Context.SaveChanges();
        return o;
    }

    public virtual T? Update(T newO)
    {
        var oldO = Get(newO.Id);
        if (oldO is null) return null;
        foreach (var field in typeof(T).GetProperties())
            field.SetValue(oldO, field.GetValue(newO));
        Context.SaveChanges();
        return newO;
    }

    public bool Delete(int id)
    {
        var oldC = Get(id);
        if (oldC is null) return false;
        Context.Items.Remove(oldC);
        Context.SaveChanges();
        return true;
    }
}
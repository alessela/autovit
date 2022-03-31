namespace webAPI.Services;

public interface IService<T>
{
    public T? Get(int id);
    public List<T> List();
    public T Create(T o);
    public T? Update(T newO);
    public bool Delete(int id);
}
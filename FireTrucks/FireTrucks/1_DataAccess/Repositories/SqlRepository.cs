using FireTrucks._1_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FireTrucks._1_DataAccess.Repositories;

public class SqlRepository<T> : IRepository<T>
    where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly FireTrucksDbContext _dbContext;

    public SqlRepository(FireTrucksDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbContext.Database.EnsureCreated();
        _dbSet = _dbContext.Set<T>();
    }

    public event EventHandler<T>? ItemAdded;

    public event EventHandler<T>? ItemRemoved;

    public void Add(T item)
    {
        _dbSet.Add(item);
        ItemAdded?.Invoke(this, item);
        Save();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.OrderBy(item => item.Id).ToList();
    }

    public T GetById(int id) => _dbSet.Find(id);

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        Save();
        ItemRemoved?.Invoke(this, item);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public IEnumerable<T> Read()
    {
        return _dbSet.ToList();
    }

    public int GetListCount()
    {
        return Read().ToList().Count;
    }
}
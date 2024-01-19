using FireTrucks._1_DataAccess.Entities;

namespace FireTrucks._1_DataAccess.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
      where T : class, IEntity
{
    public event EventHandler<T> ItemAdded;

    public event EventHandler<T> ItemRemoved;
}
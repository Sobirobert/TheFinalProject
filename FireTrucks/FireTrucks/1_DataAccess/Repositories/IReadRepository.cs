using FireTrucks._1_DataAccess.Entities;

namespace FireTrucks._1_DataAccess.Repositories;

public interface IReadRepository<out T> where T : class, IEntity
{
    IEnumerable<T> GetAll();

    T? GetById(int id);

    IEnumerable<T> Read();

    int GetListCount();
}
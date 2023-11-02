using ModStoreApi.Models;

namespace ModStoreApi.Repository;
public interface IRepository<T>
{
  Task<List<T>> GetAll();
  Task<T?> GetById(int id);
  Task Insert(T entity);
  Task Update(T entity);
  Task Delete(int id);
}

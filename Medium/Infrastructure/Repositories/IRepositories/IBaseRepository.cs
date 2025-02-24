namespace Infrastructore.Repositories.IRepositories;

public interface IBaseRepository<T>
{
  Task<List<T>> GetAll();
  Task<bool> Create(T identity);
  Task<bool> Update(T identity);
  Task<bool> Delete(int id);
  Task<T?> GetById(int id);
}

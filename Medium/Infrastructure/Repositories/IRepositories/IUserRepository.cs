namespace Infrastructore.Repositories.IRepositories;

public interface IUserRepository<T>
{
    Task<List<T>> GetAll();
    Task<bool> Update(T identity);
    Task<bool> Delete(int id);
    Task<T> GetById(int id);
}

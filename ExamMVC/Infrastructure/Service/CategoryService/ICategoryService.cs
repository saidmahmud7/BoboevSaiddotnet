using Domain;

namespace Infrastructure.Service.CategoryService;

public interface ICategoryService
{
    public Task<List<Category>> GetAllCategory();
    public Task<Category> GetById(int id);
    public Task<string> Create(Category category);
    public Task<string> Update(Category category);
    public Task<string> Delete(int id);
}
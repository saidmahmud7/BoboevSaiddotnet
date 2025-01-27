using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.CategoryService;

public class CategoryService(DataContext context) : ICategoryService
{
    public async Task<List<Category>> GetAllCategory()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category> GetById(int id)
    {
        var res = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (res == null) return null;
        return res;
    }

    public async Task<string> Create(Category category)
    {
        await context.Categories.AddAsync(category);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Created Successfully";
    }

    public async Task<string> Update(Category category)
    {
        var existing = await context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
        if (existing == null)
            return "Category not found";
        existing.Id = category.Id;
        existing.Name = category.Name;
        existing.Description = category.Description;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Updated Successfully";
    }

    public async Task<string> Delete(int id)
    {
        var existing = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return "Category not found";
        context.Categories.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Deleted Successfully";
    }
}
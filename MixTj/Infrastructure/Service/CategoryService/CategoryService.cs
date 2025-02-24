using System.Net;
using AutoMapper;
using Domain.Dtos.CategoryDto;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.CategoryService;

public class CategoryService(DataContext context,IMapper mapper) : ICategoryService
{
    public async Task<PaginationResponse<List<GetCategoryDto>>> GetAll(CategoryFilter filter)
    {
        IQueryable<Category> categories = context.Categories;
        if (!string.IsNullOrEmpty(filter.Name))
            categories = categories.Where(x=>x.Name.ToLower().Contains(filter.Name.ToLower()));
        int total = await categories.CountAsync();
        var result = await categories.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => mapper.Map<GetCategoryDto>(x))
            .ToListAsync();
        return new PaginationResponse<List<GetCategoryDto>>(filter.PageSize, filter.PageNumber, total, result);

    }

    public async Task<ApiResponse<GetCategoryDto>> GetById(int id)
    {
        var category = await context.Categories.FirstOrDefaultAsync(x=>x.Id == id);
        if (category == null)
            return new ApiResponse<GetCategoryDto>(HttpStatusCode.NotFound, "Category Not Found");
        var categoryDto = mapper.Map<GetCategoryDto>(category);
        return new ApiResponse<GetCategoryDto>(categoryDto);
    }

    public async Task<ApiResponse<string>> Create(AddCategoryDto category)
    {
        var categories = mapper.Map<Category>(category);
        await context.Categories.AddAsync(categories);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Category created");
    }

    public async Task<ApiResponse<string>> Update(UpdateCategoryDto category)
    {
        var existing = await context.Categories.FirstOrDefaultAsync(x=>x.Id == category.Id);
        if (existing == null)
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Category Not Found");
        existing.Name = category.Name;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Category updated");
    }

    public async Task<ApiResponse<string>> Delete(int id)
    {
        var existing = await context.Categories.FirstOrDefaultAsync(x=>x.Id == id);
        if (existing == null)
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Category Not Found");
        context.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Category deleted");
    }
}
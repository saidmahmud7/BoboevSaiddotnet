using System.Net;
using AutoMapper;
using Domain.Dtos.CategoryDto;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Responses;

namespace Infrastructure.Service.CategoryService;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<PaginationResponse<List<GetCategoryDto>>> GetAll(CategoryFilter filter)
    {
        var categories = await categoryRepository.GetAll(filter);

        var totalRecords = categories.Count;
        var data = categories
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToList();

        var result = data.Select(c => new GetCategoryDto()
        {
            Id = c.Id,
            Name = c.Name,
        }).ToList();

        return new PaginationResponse<List<GetCategoryDto>>(result, totalRecords, filter.PageNumber, filter.PageSize);
    }



    public async Task<ApiResponse<string>> Create(AddCategoryDto request)
    {
        var category = new Category()
        {
            Name = request.Name,
        };

        var result = await categoryRepository.CreateCategory(category);

        return result == 1
            ? new ApiResponse<string>("Success")
            : new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed");
    }

    public async Task<ApiResponse<string>> Update(UpdateCategoryDto request)
    {
        var category = await categoryRepository.GetCategory(c => c.Id == request.Id);

        if (category == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Category not found");
        }

        category.Name = request.Name;

        var result = await categoryRepository.UpdateCategory(category);
        return result == 1
            ? new ApiResponse<string>("Success")
            : new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed");
    }

    public async Task<ApiResponse<string>> Delete(int id)
    {
        var category = await categoryRepository.GetCategory(c => c.Id == id);
        if (category == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Category not found");
        }

        var result = await categoryRepository.DeleteCategory(category);
        return result == 1
            ? new ApiResponse<string>("Success")
            : new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed");
    }
}
using Domain.Dtos.CategoryDto;
using Domain.Filter;
using Infrastructure.Responses;

namespace Infrastructure.Service.CategoryService;

public interface ICategoryService
{
    Task<PaginationResponse<List<GetCategoryDto>>> GetAll(CategoryFilter filter);
    Task<ApiResponse<string>> Create(AddCategoryDto request);
    Task<ApiResponse<string>> Update(UpdateCategoryDto request);
    Task<ApiResponse<string>> Delete(int id);

}
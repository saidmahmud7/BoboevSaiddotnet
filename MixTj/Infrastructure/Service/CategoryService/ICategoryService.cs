using Domain.Dtos.CategoryDto;
using Domain.Filter;
using Infrastructure.Responses;

namespace Infrastructure.Service.CategoryService;

public interface ICategoryService
{
    Task<PaginationResponse<List<GetCategoryDto>>> GetAll(CategoryFilter filter);
    Task<ApiResponse<GetCategoryDto>> GetById(int id );
    Task<ApiResponse<string>> Create(AddCategoryDto category);
    Task<ApiResponse<string>> Update(UpdateCategoryDto category);
    Task<ApiResponse<string>> Delete(int id);

}
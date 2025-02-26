// using Domain.Dtos.CategoryDto;
// using Domain.Filter;
// using Infrastructure.Responses;
// using Infrastructure.Seed;
// using Infrastructure.Service.CategoryService;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Web.Controller;
//
// [ApiController]
// [Route("api/[controller]")]
// [Authorize(Roles = Roles.Admin)]
// public class CategoryController(ICategoryService service)
// {
//     [HttpGet]
//     public async Task<PaginationResponse<List<GetCategoryDto>>> GetCategory([FromQuery] CategoryFilter filter) =>
//         await service.GetAll(filter);
//
//     [HttpGet("{id}")]
//     public async Task<ApiResponse<GetCategoryDto>> GetById([FromRoute] int id) => await service.GetById(id);
//
//     [HttpPost]
//     public async Task<ApiResponse<string>> Create([FromBody] AddCategoryDto category) => await service.Create(category);
//
//     [HttpPut]
//     public async Task<ApiResponse<string>> Update([FromBody] UpdateCategoryDto category) =>
//         await service.Update(category);
//     [HttpDelete]
//     public async Task<ApiResponse<string>> Delete( int id) => await service.Delete(id);
// }
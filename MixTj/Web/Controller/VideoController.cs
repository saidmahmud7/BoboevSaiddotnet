// using Domain.Dtos.CommentDto;
// using Domain.Dtos.VideoDto;
// using Domain.Filter;
// using Infrastructure.Responses;
// using Infrastructure.Seed;
// using Infrastructure.Service.VideoService;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Web.Controller;
//
// [ApiController]
// [Route("api/[controller]")]
// [Authorize(Roles = Roles.Admin)]
// public class VideoController(IVideoService service)
// {
//     [HttpGet]
//     public async Task<PaginationResponse<List<GetVideoDto>>> GetCategory([FromQuery] BaseFilter filter) =>
//         await service.GetAll(filter);
//
//     [HttpGet("{id}")]
//     public async Task<ApiResponse<GetVideoDto>> GetById([FromRoute] int id) => await service.GetById(id);
//
//     [HttpPost]
//     public async Task<ApiResponse<string>> Create([FromBody] AddVideoDto video) => await service.Create(video);
//
//     [HttpPut]
//     public async Task<ApiResponse<string>> Update([FromBody] UpdateVideoDto video) =>
//         await service.Update(video);
//
//     [HttpDelete]
//     public async Task<ApiResponse<string>> Delete(int id) => await service.Delete(id);
// }
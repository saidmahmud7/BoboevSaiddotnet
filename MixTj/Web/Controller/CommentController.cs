using Domain.Dtos.ChannelDto;
using Domain.Dtos.CommentDto;
using Domain.Filter;
using Infrastructure.Responses;
using Infrastructure.Seed;
using Infrastructure.Service.CommentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = Roles.Admin)]
public class CommentController(ICommentService service)
{
    [HttpGet]
    public async Task<PaginationResponse<List<GetCommentDto>>> GetCategory([FromQuery] BaseFilter filter) =>
        await service.GetAll(filter);

    [HttpGet("{id}")]
    public async Task<ApiResponse<GetCommentDto>> GetById([FromRoute] int id) => await service.GetById(id);

    [HttpPost]
    public async Task<ApiResponse<string>> Create([FromBody] AddCommentDto comment) => await service.Create(comment);

    [HttpPut]
    public async Task<ApiResponse<string>> Update([FromBody] UpdateCommentDto comment) =>
        await service.Update(comment);
    [HttpDelete]
    public async Task<ApiResponse<string>> Delete( int id) => await service.Delete(id);
}
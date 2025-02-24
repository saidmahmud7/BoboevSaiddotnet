using Domain.Dtos.CategoryDto;
using Domain.Dtos.ChannelDto;
using Domain.Filter;
using Infrastructure.Responses;
using Infrastructure.Seed;
using Infrastructure.Service.ChannelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = Roles.Admin)]
public class ChannelController(IChannelService service) 
{
    [HttpGet]
    public async Task<PaginationResponse<List<GetChannelDto>>> GetCategory([FromQuery] BaseFilter filter) =>
        await service.GetAll(filter);

    [HttpGet("{id}")]
    public async Task<ApiResponse<GetChannelDto>> GetById([FromRoute] int id) => await service.GetById(id);

    [HttpPost]
    public async Task<ApiResponse<string>> Create([FromBody] AddChannelDto channel) => await service.Create(channel);

    [HttpPut]
    public async Task<ApiResponse<string>> Update([FromBody] UpdateChannelDto channel) =>
        await service.Update(channel);
    [HttpDelete]
    public async Task<ApiResponse<string>> Delete( int id) => await service.Delete(id);
}
// using Domain.Dtos.CommentDto;
// using Domain.Dtos.SubscriptionDto;
// using Domain.Filter;
// using Infrastructure.Responses;
// using Infrastructure.Service.SubscriptionService;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Web.Controller;
//
// [ApiController]
// [Route("api/[controller]")]
// public class SubscriptionController(ISubscriptionService service)
// {
//     [HttpGet]
//     public async Task<PaginationResponse<List<GetSubscriptionDto>>> GetSubscription([FromQuery] BaseFilter filter) =>
//         await service.GetAll(filter);
//
//     [HttpGet("{id}")]
//     public async Task<ApiResponse<GetSubscriptionDto>> GetById([FromRoute] int id) => await service.GetById(id);
//
//     [HttpPost]
//     public async Task<ApiResponse<string>> Create([FromBody] AddSubscriptionDto subscription) => await service.Create(subscription);
//
//     [HttpPut]
//     public async Task<ApiResponse<string>> Update([FromBody] UpdateSubscriptionDto subscription) =>
//         await service.Update(subscription);
//     [HttpDelete]
//     public async Task<ApiResponse<string>> Delete( int id) => await service.Delete(id);
// }
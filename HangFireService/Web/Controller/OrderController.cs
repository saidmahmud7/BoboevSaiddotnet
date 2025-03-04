using Domain.Entities;
using Domain.Filter;
using Infrastructure.Response;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller;
[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService service): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]BaseFilter filter)
    {
        var orders = await service.GetAll(filter);
        return StatusCode(orders.StatusCode, orders);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory(Order request)
    {
        var response = await service.Create(request);
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(Order request)
    {
        var response = await service.Update(request);
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var response = await service.Delete(id);
        return StatusCode(response.StatusCode, response);
    }
}
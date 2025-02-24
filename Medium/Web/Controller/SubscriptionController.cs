using Domain.DTOs.SubscriptionDTOs;
using Domain.DTOs.AuthDTOS;
using Infrastructore.Services.SubscriptionServices;
using Infrastructure.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/subscription")]
[ApiController]
public class SubscriptionController(ISubscriptionService servcie) : ControllerBase
{
    [HttpPost]
    public async Task<ApiResponse<string>> Create(CreateSubscriptionDTO Subscription) => await servcie.CreateSubscription(Subscription);
    [HttpGet("{id}")]
    public async Task<ApiResponse<GetSubscriptionDTO>> GetById(int id) => await servcie.GetSubscriptionById(id);
    [HttpGet]
    public async Task<ApiResponse<List<GetSubscriptionDTO>>> GetAll() => await servcie.GetSubscriptions();
    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await servcie.DeleteSubscription(id);
}

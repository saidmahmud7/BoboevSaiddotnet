using Domain.DTOs.ReactionDTOs;
using Domain.DTOs.AuthDTOS;
using Infrastructore.Services.ReactionServices;
using Infrastructure.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/reaction")]
[ApiController]
public class ReactionController(IReactionService servcie) : ControllerBase
{
    [HttpPost]
    public async Task<ApiResponse<string>> Create(CreateReactionDTO Reaction) => await servcie.CreateReaction(Reaction);
    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await servcie.DeleteReaction(id);
}

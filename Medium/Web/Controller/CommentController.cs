using Domain.DTOs.CommentDTOs;
using Domain.DTOs.AuthDTOS;
using Infrastructore.Services.CommentServices;
using Infrastructure.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController(ICommentService servcie) : ControllerBase
{
    [HttpPost]
    public async Task<ApiResponse<string>> Create(CreateCommentDTO Comment) => await servcie.CreateComment(Comment);
    [HttpPut]
    public async Task<ApiResponse<string>> Update(int id,UpdateCommentDTO Comment) => await servcie.UpdateComment(id,Comment);
    [HttpGet("{id}")]
    public async Task<ApiResponse<GetCommentDTO>> GetById(int id) => await servcie.GetCommentById(id);
    [HttpGet]
    public async Task<ApiResponse<List<GetCommentDTO>>> GetAll() => await servcie.GetComments();
    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await servcie.DeleteComment(id);
}

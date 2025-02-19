using Domain.DTOs.ArticleDTOs;
using Domain.DTOs.AuthDTOS;
using Domain.Enums;
using Infrastructore.Services.ArticleServices;
using Infrastructure.Response;
using Infrastructure.Seed;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/article")]
[ApiController]
public class ArticleController(IArticleService servcie) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles =nameof(UserRole.Admin))]
    [Authorize(Roles =nameof(UserRole.Author))]
    public async Task<ApiResponse<string>> Create(CreateArticleDTO article) => await servcie.CreateArticle(article);
    [HttpPut]
    [Authorize(Roles =nameof(UserRole.Admin))]
    [Authorize(Roles =nameof(UserRole.Author))]
    public async Task<ApiResponse<string>> Update(int id,UpdateArticleDTO article) => await servcie.UpdateArticle(id,article);
    [HttpGet("{id}")]
    [Authorize(Roles =nameof(UserRole.Admin))]
    [Authorize(Roles =nameof(UserRole.PremiumUser))]
    public async Task<ApiResponse<GetArticleDTO>> GetById(int id) => await servcie.GetArticleById(id);
    [HttpGet]
    public async Task<ApiResponse<List<GetArticleDTO>>> GetAll() => await servcie.GetArticles();
    [HttpDelete]
    [Authorize(Roles =nameof(UserRole.Admin))]
    [Authorize(Roles =nameof(UserRole.PremiumUser))]
    public async Task<ApiResponse<string>> Delete(int id) => await servcie.DeleteArticle(id);
}

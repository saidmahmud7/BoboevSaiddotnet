using Domain.DTOs.ArticleDTOs;
using Domain.DTOs.AuthDTOS;
using Infrastructure.Response;

namespace Infrastructore.Services.ArticleServices;

public interface IArticleService
{
    Task<ApiResponse<string>> CreateArticle(CreateArticleDTO Article);
    Task<ApiResponse<string>> UpdateArticle(int id,UpdateArticleDTO Article);
    Task<ApiResponse<string>> DeleteArticle(int id);
    Task<ApiResponse<GetArticleDTO>> GetArticleById(int id);
    Task<ApiResponse<List<GetArticleDTO>>> GetArticles();
}

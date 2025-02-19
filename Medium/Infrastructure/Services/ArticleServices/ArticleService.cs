using System.Net;
using AutoMapper;
using Domain.DTOs.ArticleDTOs;
using Domain.DTOs.AuthDTOS;
using Domain.Entities;
using Infrastructore.Repositories.IRepositories;
using Infrastructure.Response;

namespace Infrastructore.Services.ArticleServices;

public class ArticleService(IArticleRepository repository,IMapper mapper) : IArticleService
{
    public async Task<ApiResponse<string>> CreateArticle(CreateArticleDTO Article)
    {
        var Articlet = mapper.Map<Article>(Article);
        var res =await repository.Create(Articlet);
        return res
        ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Not created!")
        : new ApiResponse<string>("Created successfully!");
    }

    public async Task<ApiResponse<string>> DeleteArticle(int id)
    {
        var res = await repository.Delete(id);
        return res
        ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Not deleted!")
        : new ApiResponse<string>("Deleted successfully!");
    }

    public async Task<ApiResponse<GetArticleDTO>> GetArticleById(int id)
    {
       var Articlet =await repository.GetById(id);
       if(Articlet == null) return new ApiResponse<GetArticleDTO>(HttpStatusCode.NotFound,"Not found");
       var Article = mapper.Map<GetArticleDTO>(Articlet);
       return new ApiResponse<GetArticleDTO>(Article);
    }

    public async Task<ApiResponse<List<GetArticleDTO>>> GetArticles()
    {
       var Articles =mapper.Map<List<GetArticleDTO>>(await repository.GetAll());
       return new ApiResponse<List<GetArticleDTO>>(Articles);
       
    }

    public async Task<ApiResponse<string>> UpdateArticle(int id,UpdateArticleDTO Article)
    {
        var coment = mapper.Map<Article>(repository.GetById(id));
        var res =await repository.Update(coment);
        return res
        ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Not updated!")
        : new ApiResponse<string>("Updated successfully!");
    }

}

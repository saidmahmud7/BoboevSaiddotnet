using System.Net;
using AutoMapper;
using Domain.DTOs.CommentDTOs;
using Domain.Entities;
using Infrastructore.Repositories.IRepositories;
using Infrastructure.Response;

namespace Infrastructore.Services.CommentServices;

public class CommentService(ICommentRepository repository,IMapper mapper) : ICommentService
{
    public async Task<ApiResponse<string>> CreateComment(CreateCommentDTO comment)
    {
        var commentt = mapper.Map<Comment>(comment);
        var res =await repository.Create(commentt);
        return res
        ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Not created!")
        : new ApiResponse<string>("Created successfully!");
    }

    public async Task<ApiResponse<string>> DeleteComment(int id)
    {
        var res = await repository.Delete(id);
        return res
        ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Not deleted!")
        : new ApiResponse<string>("Deleted successfully!");
    }

    public async Task<ApiResponse<GetCommentDTO>> GetCommentById(int id)
    {
       var commentt =await repository.GetById(id);
       if(commentt == null) return new ApiResponse<GetCommentDTO>(HttpStatusCode.NotFound,"Not found");
       var comment = mapper.Map<GetCommentDTO>(commentt);
       return new ApiResponse<GetCommentDTO>(comment);
    }

    public async Task<ApiResponse<List<GetCommentDTO>>> GetComments()
    {
       var comments =mapper.Map<List<GetCommentDTO>>(await repository.GetAll());
       return new ApiResponse<List<GetCommentDTO>>(comments);
       
    }

    public async Task<ApiResponse<string>> UpdateComment(int id,UpdateCommentDTO comment)
    {
        var coment = mapper.Map<Comment>(repository.GetById(id));
        var res =await repository.Update(coment);
        return res
        ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Not updated!")
        : new ApiResponse<string>("Updated successfully!");
    }

}

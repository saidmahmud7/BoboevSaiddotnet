using Domain;

namespace Infrastructure.Service.CommentService;

public interface ICommentService
{
    public Task<List<Comment>> GetAll();
    public Task<Comment> GetById(int id);
    public Task<string> Create(Comment comment);
    public Task<string> Update(Comment comment);
    public Task<string> Delete(int id);
}
using Domain;

namespace Infrastructure.Service.PostService;

public interface IPostService
{
    public Task<List<Post>> GetAll();
    public Task<Post> GetById(int id);
    public Task<string> Create(Post post);
    public Task<string> Update(Post post);
    public Task<string> Delete(int id);
}
using Domain;

namespace Infrastructure.Service.PostImageService;

public interface IPostImage
{
    public Task<List<PostImage>> GetAll();
    public Task<PostImage> GetById(int id);
    public Task<string> Create(PostImage image);
    public Task<string> Update(PostImage image);
    public Task<string> Delete(int id);
}
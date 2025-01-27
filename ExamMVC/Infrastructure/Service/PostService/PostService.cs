using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.PostService;

public class PostService(DataContext context) : IPostService
{
    public async Task<List<Post>> GetAll()
    {
        return await context.Posts.Include(p => p.Category)
                             .Include(p => p.Comments)
                             .Include(p => p.PostImages)
                             .ToListAsync();
    }

    public async Task<Post> GetById(int id)
    {
        var res = await context.Posts.Include(p => p.Category)
                             .Include(p => p.Comments)
                             .Include(p => p.PostImages)
                             .FirstOrDefaultAsync(p => p.Id == id);
        if (res == null) return null;
        return res;
    }

    public async Task<string> Create(Post post)
    {
        await context.Posts.AddAsync(post);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Created Successfully";
    }

    public async Task<string> Update(Post post)
    {
        var existing = await context.Posts.FirstOrDefaultAsync(x => x.Id == post.Id);
        if (existing == null) return "Post not found";
        existing.Title = post.Title;
        existing.Content = post.Content;
        existing.PublishedDate = post.PublishedDate;
        existing.CategoryId = post.CategoryId;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Updated Successfully";
    }

    public async Task<string> Delete(int id)
    {
        var existing = await context.Posts.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return "Post not found";
        context.Posts.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Deleted Successfully";
    }
}
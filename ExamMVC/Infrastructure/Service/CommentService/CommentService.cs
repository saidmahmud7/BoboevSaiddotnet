using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.CommentService;

public class CommentService(DataContext context) : ICommentService
{
    public async Task<List<Comment>> GetAll()
    {
        return await context.Comments.ToListAsync();
    }

    public async Task<Comment> GetById(int id)
    {
        var res = await context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        if (res == null) return null;
        return res;
    }

    public async Task<string> Create(Comment comment)
    {
        await context.Comments.AddAsync(comment);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Created Successfully";
    }

    public async Task<string> Update(Comment comment)
    {
        var existing = await context.Comments.FirstOrDefaultAsync(x => x.Id == comment.Id);
        if (existing == null) return "Comment not found";
        existing.Content = comment.Content;
        existing.CreatedDate = comment.CreatedDate;
        existing.AuthorName = comment.AuthorName;
        existing.PostId = comment.PostId;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Updated Successfully";
    }

    public async Task<string> Delete(int id)
    {
        var existing = await context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return "Comment not found";
        context.Comments.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Deleted Successfully";
    }
}
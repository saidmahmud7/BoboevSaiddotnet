using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Repositories.RepositoryServices;

public class CommentRepository(DataContext context) : ICommentRepository
{
    public async Task<bool> Create(Comment identity)
    {
        await context.Comments.AddAsync(identity);
        var res = await context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var exist =await context.Comments.FirstOrDefaultAsync(x=>x.Id == id);
        if(exist == null) return false;
        context.Comments.Remove(exist);
        var res =await context.SaveChangesAsync();
        return res > 0;      
    }

    public async Task<List<Comment>> GetAll()
    {
        return await context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetById(int id)
    {
        var exist =await context.Comments.FirstOrDefaultAsync(x=>x.Id == id);
        if(exist == null) return null;
        return exist;
    }

    public async Task<bool> Update(Comment identity)
    {
        var exist =await context.Comments.FirstOrDefaultAsync(x=>x.Id == identity.Id);
        if(exist == null) return false;
        exist.ArticleId = identity.ArticleId;
        exist.Content = identity.Content;
        exist.CreatedAt = identity.CreatedAt;
        exist.UserId = identity.UserId;
        var res =await context.SaveChangesAsync();
        return res > 0;
    }

}

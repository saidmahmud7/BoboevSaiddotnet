using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Repositories.RepositoryServices;

public class ArticleRepository(DataContext context) : IArticleRepository
{
    public async Task<bool> Create(Article identity)
    {
        await context.Articles.AddAsync(identity);
        var res =await context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var exist =await context.Articles.FirstOrDefaultAsync(x=>x.Id == id);
        if(exist == null) return false;
        context.Articles.Remove(exist);
        var res =await context.SaveChangesAsync();
        return res > 0;      
    }

    public async Task<List<Article>> GetAll()
    {
        return await context.Articles.ToListAsync();
    }

    public async Task<Article?> GetById(int id)
    {
        var exist =await context.Articles.FirstOrDefaultAsync(x=>x.Id == id);
        if(exist == null) return null;
        return exist;
    }

    public async Task<bool> Update(Article identity)
    {
        var exist =await context.Articles.FirstOrDefaultAsync(x=>x.Id == identity.Id);
        if(exist == null) return false;
        exist.AuthorId = identity.AuthorId;
        exist.Content = identity.Content;
        exist.CreatedAt = identity.CreatedAt;
        exist.IsDraft = identity.IsDraft;
        exist.IsPremium = identity.IsPremium;
        exist.PublishedAt = identity.PublishedAt;
        exist.Title = identity.Title;
        exist.Tags = identity.Tags;
        var res =await context.SaveChangesAsync();
        return res > 0;
    }

}

using Domain;
using Infrastructure.Data;
using Infrastructure.Service.PostImageService;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.PostImageService;

public class PostImageService(DataContext context) : IPostImage
{
    public async Task<List<PostImage>> GetAll()
    {
        return await context.PostImages.ToListAsync();
    }

    public async Task<PostImage> GetById(int id)
    {
        var res = await context.PostImages.FirstOrDefaultAsync(x => x.Id == id);
        if (res == null) return null;
        return res;
    }

    public async Task<string> Create(PostImage image)
    {
        await context.PostImages.AddAsync(image);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Created Successfully";
    }

    public async Task<string> Update(PostImage image)
    {
        var existing = await context.PostImages.FirstOrDefaultAsync(x => x.Id == image.Id);
        if (existing == null) return "PostImage not found";
        existing.ImagePath = image.ImagePath;
        existing.Description = image.Description;
        existing.UploadDate = image.UploadDate;
        existing.PostId = image.PostId;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Updated Successfully";
    }

    public async Task<string> Delete(int id)
    {
        var existing = await context.PostImages.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return "PostImage not found";
        context.PostImages.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Deleted Successfully";
    }
}
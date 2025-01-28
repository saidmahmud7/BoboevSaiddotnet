using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Service.GroupService;
using Microsoft.EntityFrameworkCore;


public class GroupService(DataContext context) : IGroupService
{
    public async Task<List<Group>> GetGroups()
    {
        return await context.Groups
            .Include(s => s.Students)
            .ToListAsync();
    }

    public async Task<Group> GetGroupById(int id)
    {
        var res = await context.Groups.FirstOrDefaultAsync(x => x.Id == id);
        if (res == null) return null;
        return res;
    }


    public async Task<string> CreateGroup(Group group)
    {
        await context.Groups.AddAsync(group);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Created Successfully";
    }

    public async Task<string> UpdateGroup(Group group)
    {
        var existing = await context.Groups.FirstOrDefaultAsync(x => x.Id == group.Id);
        if (existing == null)
            return "Group not found";
        existing.Id = group.Id;
        existing.Name = group.Name;
        existing.Description = group.Description;
        existing.CreatedAt = group.CreatedAt;
        existing.UpdatedAt = group.UpdatedAt;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Updated Successfully";
    }

    public async Task<string> DeleteGroup(int id)
    {
        var existing = await context.Groups.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return "Group not found";
        context.Groups.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Deleted Successfully";
    }
}


using Domain.Entities;

namespace Infrastructure.Service.GroupService;

public interface IGroupService
{
    public Task<List<Group>> GetGroups();
    public Task<Group> GetGroupById(int id);
    public Task<string> CreateGroup(Group group);
    public Task<string> UpdateGroup(Group group);
    public Task<string> DeleteGroup(int id);
}
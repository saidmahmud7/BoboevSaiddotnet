using System.Linq.Expressions;
using Domain.Entities;
using Domain.Filter;

namespace Infrastructure.Service.ChannelService;

public interface IChannelRepository
{
    Task<List<Channel>> GetAll(BaseFilter filter);
    Task<Channel?> Channel(Expression<Func<Channel, bool>>? filter = null);
    Task<int> AddChannel(Channel request);
    Task<int> UpdateChannel(Channel request);
    Task<int> DeleteChannel(Channel request);
}
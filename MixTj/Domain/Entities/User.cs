using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
    public List<Video> Videos { get; set; } 
    public List<Comment> Comments { get; set; } 
    public List<Reaction> Reactions { get; set; } 
    public List<Subscription> Subscriptions { get; set; } 
}
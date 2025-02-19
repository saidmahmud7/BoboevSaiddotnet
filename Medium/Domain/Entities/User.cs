using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string UserName { get; set; }
    [Required,MaxLength(60)]
    public string Email { get; set; }
    [Required,MaxLength(20)]
    public string PhoneNumber { get; set; }
    [Required,MaxLength(20)]
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
    public Subscription Subscription { get; set; }
    public List<Article> Articles { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
    public List<Reaction> Reactions { get; set; } = [];
    public List<Subscription> Subscriptions { get; set; } = [];
}
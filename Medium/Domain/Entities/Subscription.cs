using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Subscription
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime ExpiryDate { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class OrderDetail
{
    public int Id { get; set; }
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string SpecialInstructions { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
    [ForeignKey("MenuItemId")]
    public Menu Menu { get; set; }
}
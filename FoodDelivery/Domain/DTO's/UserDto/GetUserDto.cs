using Domain.Entities;
using Domain.Enum;

namespace Domain.DTO_s.UserDto;

public class GetUserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public DateTime RegistrationDate { get; set; }
    public UserRole Role { get; set; }
    List<Order> Orders { get; set; }
}
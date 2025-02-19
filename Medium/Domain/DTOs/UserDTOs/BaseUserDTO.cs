using Domain.Enums;

namespace Domain.DTOs.UserDTOs;

public class BaseUserDTO
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
}

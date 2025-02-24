using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.DTOs;

public class RegisterDTO
{
    public string UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
    // public Role UserRole { get; set; }
}

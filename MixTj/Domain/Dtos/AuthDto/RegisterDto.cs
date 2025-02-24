using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.AuthDto;

public class RegisterDto
{
    public string UserName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
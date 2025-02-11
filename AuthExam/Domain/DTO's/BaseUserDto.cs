using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.DTO_s;

public class BaseUserDto
{
    public string Username { get; set; } 
    public string PasswordHash { get; set; } 
    public Role Role { get; set; }
}

public class LoginAccountDto : BaseUserDto;
public class RegisterAccountDto : BaseUserDto;

public class GetUsersDto : BaseUserDto
{
    public int Id { get; set; }
}

public class UpdateUserDto : BaseUserDto
{
    public int Id { get; set; }
}
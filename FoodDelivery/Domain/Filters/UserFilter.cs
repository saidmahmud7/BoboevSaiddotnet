using Domain.Enum;

namespace Domain.Filters;

public record UserFilter : BaseFilter
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public UserRole? Role { get; set; }
}
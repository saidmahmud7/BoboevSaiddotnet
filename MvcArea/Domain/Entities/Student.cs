using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Student
{
    public int Id { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    public int Age { get; set; }
    [EmailAddress] public string Email { get; set; }
    [Phone] public string Phone { get; set; }
    public string Address { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
}
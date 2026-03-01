using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementService.Models;

public class Employee
{
    public Guid Id { get; init; }
    
    [MaxLength(255)]
    public required string FirstName { get; set; }
    
    [MaxLength(255)]
    public required string LastName { get; set; }
    
    [MaxLength(127)]
    public required string Email { get; set; }
    
    public required DateTime DateOfBirth { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";
}

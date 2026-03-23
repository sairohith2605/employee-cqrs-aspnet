using EmployeeManagementService.Features.Responses;
using MediatR;

namespace EmployeeManagementService.Features.Commands;

/// <summary>Command to create a new employee. Returns the created employee's details on success.</summary>
public class CreateEmployeeCommand : IRequest<CreateEmployeeResult>
{
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required string Email { get; set; }
    
    public required DateTime DateOfBirth { get; set; }
}

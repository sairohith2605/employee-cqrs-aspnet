using MediatR;

namespace EmployeeManagementService.Features.Commands;

public class CreateEmployeeCommand : IRequest<Guid>
{
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required string Email { get; set; }
    
    public required DateTime DateOfBirth { get; set; }
}

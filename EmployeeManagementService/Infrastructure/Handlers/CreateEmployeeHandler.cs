using EmployeeManagementService.Features.Commands;
using EmployeeManagementService.Features.Responses;
using EmployeeManagementService.Infrastructure.Repository;
using EmployeeManagementService.Models;
using MediatR;

namespace EmployeeManagementService.Infrastructure.Handlers;

/// <summary>MediatR handler that processes <see cref="CreateEmployeeCommand"/> requests.</summary>
public class CreateEmployeeHandler(IEmployeeRepository employeeRepository) : IRequestHandler<CreateEmployeeCommand, CreateEmployeeResult>
{
    /// <summary>Handles a <see cref="CreateEmployeeCommand"/> by creating a new employee record.</summary>
    /// <param name="request">The command containing the new employee's details.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>A <see cref="CreateEmployeeResult"/> containing the new employee's details.</returns>
    public async Task<CreateEmployeeResult> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth
        };
        var id = await employeeRepository.CreateAsync(employee);
        return new CreateEmployeeResult
        {
            Id = id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            DateOfBirth = employee.DateOfBirth
        };
    }
}

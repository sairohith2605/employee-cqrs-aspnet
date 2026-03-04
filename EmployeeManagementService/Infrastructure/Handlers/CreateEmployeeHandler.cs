using EmployeeManagementService.Features.Commands;
using EmployeeManagementService.Infrastructure.Repository;
using EmployeeManagementService.Models;
using MediatR;

namespace EmployeeManagementService.Infrastructure.Handlers;

public class CreateEmployeeHandler(IEmployeeRepository employeeRepository) : IRequestHandler<CreateEmployeeCommand, Guid>
{
    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth
        };
        var registeredEmployeeId = await employeeRepository.CreateAsync(employee);
        return registeredEmployeeId;
    }
}

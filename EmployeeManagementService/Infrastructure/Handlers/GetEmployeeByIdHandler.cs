using EmployeeManagementService.Features.Queries;
using EmployeeManagementService.Infrastructure.Repository;
using EmployeeManagementService.Models;
using MediatR;

namespace EmployeeManagementService.Infrastructure.Handlers;

/// <summary>MediatR handler that processes <see cref="GetEmployeeByIdQuery"/> requests.</summary>
public class GetEmployeeByIdHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeeByIdQuery, Employee?>
{
    /// <summary>Handles a <see cref="GetEmployeeByIdQuery"/> by fetching the employee with the given ID.</summary>
    /// <param name="request">The query containing the employee's ID.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The matching <see cref="Employee"/>, or <c>null</c> if not found.</returns>
    public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var existingEmployee = await employeeRepository.GetByIdAsync(request.Id);
        return existingEmployee;
    }
}

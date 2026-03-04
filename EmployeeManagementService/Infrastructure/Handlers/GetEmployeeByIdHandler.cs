using EmployeeManagementService.Features.Queries;
using EmployeeManagementService.Infrastructure.Repository;
using EmployeeManagementService.Models;
using MediatR;

namespace EmployeeManagementService.Infrastructure.Handlers;

public class GetEmployeeByIdHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeeByIdQuery, Employee?>
{
    public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var existingEmployee = await employeeRepository.GetByIdAsync(request.Id);
        return existingEmployee;
    }
}

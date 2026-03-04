using EmployeeManagementService.Models;
using MediatR;

namespace EmployeeManagementService.Features.Queries;

public class GetEmployeeByIdQuery : IRequest<Employee>
{
    public required Guid Id { get; set; }
}

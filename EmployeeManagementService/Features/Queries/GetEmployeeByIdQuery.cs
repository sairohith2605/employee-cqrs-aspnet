using EmployeeManagementService.Models;
using MediatR;

namespace EmployeeManagementService.Features.Queries;

/// <summary>Query to retrieve a single employee by their unique identifier.</summary>
public class GetEmployeeByIdQuery : IRequest<Employee>
{
    public required Guid Id { get; set; }
}

using EmployeeManagementService.Models;

namespace EmployeeManagementService.Infrastructure.Repository;

public interface IEmployeeRepository
{
    Task<Guid> CreateAsync(Employee employee);
    Task<Employee?> GetByIdAsync(Guid id);
}

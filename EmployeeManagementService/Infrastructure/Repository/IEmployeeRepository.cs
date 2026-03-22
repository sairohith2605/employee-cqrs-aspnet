using EmployeeManagementService.Models;

namespace EmployeeManagementService.Infrastructure.Repository;

/// <summary>Defines data access operations for the <see cref="Employee"/> entity.</summary>
public interface IEmployeeRepository
{
    /// <summary>Persists a new employee and returns its generated ID.</summary>
    /// <param name="employee">The employee entity to create.</param>
    /// <returns>The <see cref="Guid"/> assigned to the new employee.</returns>
    Task<Guid> CreateAsync(Employee employee);

    /// <summary>Retrieves an employee by their unique identifier.</summary>
    /// <param name="id">The employee's unique identifier.</param>
    /// <returns>The matching <see cref="Employee"/>, or <c>null</c> if not found.</returns>
    Task<Employee?> GetByIdAsync(Guid id);
}

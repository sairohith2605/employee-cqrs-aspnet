using EmployeeManagementService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementService.Infrastructure.Repository;

/// <summary>EF Core implementation of <see cref="IEmployeeRepository"/>.</summary>
public class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
{
    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(Employee employee)
    {
        var newEmployee = await context.Employees.AddAsync(employee);
        await context.SaveChangesAsync();
        return newEmployee.Entity.Id;
    }

    /// <inheritdoc/>
    public async Task<Employee?> GetByIdAsync(Guid id)
    {
        return await context.Employees.AsNoTracking()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
    }
}

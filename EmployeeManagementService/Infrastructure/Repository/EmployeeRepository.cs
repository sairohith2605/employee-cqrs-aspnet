using EmployeeManagementService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementService.Infrastructure.Repository;

public class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
{
    public async Task<Guid> CreateAsync(Employee employee)
    {
        var newEmployee = await context.Employees.AddAsync(employee);
        await context.SaveChangesAsync();
        return newEmployee.Entity.Id;
    }

    public async Task<Employee?> GetByIdAsync(Guid id)
    {
        return await context.Employees.AsNoTracking()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
    }
}

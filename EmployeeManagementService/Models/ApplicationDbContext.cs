using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementService.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
}

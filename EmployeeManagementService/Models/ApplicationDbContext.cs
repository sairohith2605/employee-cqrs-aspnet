using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementService.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__sqldb"));
    }
    
    public DbSet<Employee> Employees { get; set; }
}

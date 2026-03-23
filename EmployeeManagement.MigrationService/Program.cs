using EmployeeManagement.MigrationService;
using EmployeeManagementService.Models;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.AddSqlServerDbContext<ApplicationDbContext>("sqldb");

var host = builder.Build();
host.Run();

using EmployeeManagementService.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddOpenApi();

builder.Services.AddAuthentication()
    .AddKeycloakJwtBearer(serviceName: "keycloak", realm: "employee-management", options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.RequireHttpsMetadata = false;
        }
    });

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqldb"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapDefaultEndpoints();

app.Run();

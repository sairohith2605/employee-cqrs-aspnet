var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("database");
var sqldb = sql.AddDatabase("sqldb", "Employees");

var keycloak = builder.AddKeycloak("keycloak", 8080)
    .WithRealmImport("KeycloakConfiguration/employee-management-realm.json")
    .WithDataVolume();

builder.AddProject<Projects.EmployeeManagementService>("employeemanagementservice")
    .WithReference(sqldb)
    .WaitFor(sqldb)
    .WithReference(keycloak)
    .WaitFor(keycloak);

builder.Build().Run();

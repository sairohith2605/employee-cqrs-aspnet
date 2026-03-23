using Aspire.Hosting;
using Aspire.Hosting.Testing;

namespace EmployeeManagement.IntegrationTest;

public class ApplicationBaseTextFixture : IAsyncLifetime
{
    private DistributedApplication? _employeeManagementApp;

    public DistributedApplication EmployeeManagementApp => _employeeManagementApp ?? throw new Exception("Invalid application state");

    protected HttpClient HttpClient { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.EmployeeManagement_AppHost>();
        _employeeManagementApp = await appHost.BuildAsync();
        await _employeeManagementApp.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _employeeManagementApp!.DisposeAsync();
    }
}

[CollectionDefinition("EmployeeManagement")]
public class EmployeeManagementCollection : ICollectionFixture<ApplicationBaseTextFixture>
{
}

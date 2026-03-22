using Aspire.Hosting;
using Aspire.Hosting.Testing;

namespace EmployeeManagement.IntegrationTest;

public abstract class BaseAbstractIntegrationTest : IAsyncLifetime
{
    private DistributedApplication? _employeeManagementApp;

    protected HttpClient HttpClient { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.EmployeeManagement_AppHost>();
        _employeeManagementApp = await appHost.BuildAsync();
        await _employeeManagementApp.StartAsync();
        HttpClient = _employeeManagementApp.CreateHttpClient("employeemanagementservice");
    }

    public async Task DisposeAsync()
    {
        await _employeeManagementApp!.DisposeAsync();
    }
}

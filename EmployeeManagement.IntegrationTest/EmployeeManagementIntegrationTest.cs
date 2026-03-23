using System.Net;
using System.Net.Http.Json;
using Aspire.Hosting.Testing;
using EmployeeManagementService.Features.Commands;
using EmployeeManagementService.Features.Responses;
using EmployeeManagementService.Models;

namespace EmployeeManagement.IntegrationTest;

[Collection("EmployeeManagement")]
public class EmployeeManagementIntegrationTest(ApplicationBaseTextFixture textFixture)
{
    private readonly HttpClient _httpClient = textFixture.EmployeeManagementApp.CreateHttpClient("employeemanagementservice");

    [Fact]
    public async Task CreateEmployee_ReturnsCreated_WithEmployeeDetails()
    {
        var command = new CreateEmployeeCommand
        {
            FirstName = "Jane",
            LastName = "Doe",
            Email = "jane.doe@example.com",
            DateOfBirth = new DateTime(1990, 5, 15)
        };

        var response = await _httpClient.PostAsJsonAsync("/employees", command);
        var result = await response.Content.ReadFromJsonAsync<CreateEmployeeResult>();

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(result);
        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal(command.FirstName, result.FirstName);
        Assert.Equal(command.LastName, result.LastName);
        Assert.Equal(command.Email, result.Email);
        Assert.Equal(command.DateOfBirth, result.DateOfBirth);
    }

    [Fact]
    public async Task CreateEmployee_ReturnsLocationHeader_PointingToCreatedResource()
    {
        var command = new CreateEmployeeCommand
        {
            FirstName = "John",
            LastName = "Smith",
            Email = "john.smith@example.com",
            DateOfBirth = new DateTime(1985, 3, 20)
        };

        var response = await _httpClient.PostAsJsonAsync("/employees", command);
        var result = await response.Content.ReadFromJsonAsync<CreateEmployeeResult>();

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(response.Headers.Location);
        Assert.Contains(result!.Id.ToString(), response.Headers.Location.ToString());
    }

    [Fact]
    public async Task GetEmployeeById_ReturnsEmployee_WhenEmployeeExists()
    {
        var command = new CreateEmployeeCommand
        {
            FirstName = "Alice",
            LastName = "Johnson",
            Email = "alice.johnson@example.com",
            DateOfBirth = new DateTime(1992, 8, 10)
        };
        var createResponse = await _httpClient.PostAsJsonAsync("/employees", command);
        var created = await createResponse.Content.ReadFromJsonAsync<CreateEmployeeResult>();

        var getResponse = await _httpClient.GetAsync($"/employees/{created!.Id}");
        var employee = await getResponse.Content.ReadFromJsonAsync<Employee>();

        Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
        Assert.NotNull(employee);
        Assert.Equal(created.Id, employee.Id);
        Assert.Equal(command.FirstName, employee.FirstName);
        Assert.Equal(command.LastName, employee.LastName);
        Assert.Equal(command.Email, employee.Email);
    }

    [Fact]
    public async Task GetEmployeeById_ReturnsNotFound_WhenEmployeeDoesNotExist()
    {
        var nonExistentId = Guid.NewGuid();

        var response = await _httpClient.GetAsync($"/employees/{nonExistentId}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}

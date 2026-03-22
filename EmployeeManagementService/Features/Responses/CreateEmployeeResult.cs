namespace EmployeeManagementService.Features.Responses;

/// <summary>Result returned after successfully creating a new employee.</summary>
public class CreateEmployeeResult
{
    /// <summary>The unique identifier assigned to the new employee.</summary>
    public required Guid Id { get; init; }

    /// <summary>The employee's first name.</summary>
    public required string FirstName { get; init; }

    /// <summary>The employee's last name.</summary>
    public required string LastName { get; init; }

    /// <summary>The employee's email address.</summary>
    public required string Email { get; init; }

    /// <summary>The employee's date of birth.</summary>
    public required DateTime DateOfBirth { get; init; }
}

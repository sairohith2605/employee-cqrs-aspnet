using EmployeeManagementService.Features.Commands;
using EmployeeManagementService.Features.Queries;
using EmployeeManagementService.Features.Responses;
using EmployeeManagementService.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementService.API;

/// <summary>Exposes HTTP endpoints for creating and retrieving employees.</summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class EmployeesController(IMediator mediator) : ControllerBase
{
    /// <summary>Creates a new employee.</summary>
    /// <param name="command">Employee details.</param>
    /// <returns>The newly created employee's details.</returns>
    /// <response code="201">Employee created successfully.</response>
    /// <response code="400">Invalid request payload.</response>
    [HttpPost]
    [ProducesResponseType(typeof(CreateEmployeeResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
        var response = await mediator.Send(command);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = response.Id }, response);
    }

    /// <summary>Retrieves an employee by ID.</summary>
    /// <param name="id">The employee's unique identifier.</param>
    /// <returns>The matching employee.</returns>
    /// <response code="200">Employee found.</response>
    /// <response code="404">Employee not found.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        var employee = await mediator.Send(new GetEmployeeByIdQuery { Id = id });
        if (employee is null)
            return NotFound();

        return Ok(employee);
    }
}

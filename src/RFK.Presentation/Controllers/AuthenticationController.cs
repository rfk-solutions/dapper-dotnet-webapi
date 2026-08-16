using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace RFK.Presentation.Controllers;

/// <summary>
/// Handles user registration and authentication operations.
/// </summary>
[Route("api/authentication")]
[ApiController]
[Produces("application/json")]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service) => _service = service;

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="userForRegistration">The user registration details.</param>
    /// <returns>A 201 Created status code on success, or 400 Bad Request with validation errors.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    {
        var result = await _service.AuthenticationService
            .RegisterUser(userForRegistration);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        return StatusCode(201);
    }

    /// <summary>
    /// Authenticates a user and generates a JWT token.
    /// </summary>
    /// <param name="user">User credentials for logging in.</param>
    /// <returns>An object containing the bearer token if credentials are valid.</returns>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        if (!await _service.AuthenticationService.ValidateUser(user))
            return Unauthorized();

        return Ok(new
        {
            Token = await _service.AuthenticationService.CreateToken()
        });
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace RFK.Presentation.Controllers
{
    /// <summary>
    /// Manages employees tied to a specific company.
    /// </summary>
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    [Produces("application/json")]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service) => _service = service;

        /// <summary>
        /// Gets a paged list of employees for a specific company.
        /// </summary>
        /// <param name="companyId">The GUID of the company.</param>
        /// <param name="employeeParameters">Paging and filtering parameters.</param>
        /// <returns>A collection of employees matching the specified parameters.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeesForCompany(Guid companyId,
            [FromQuery] EmployeeParameters employeeParameters)
        {
            var pagedResult = await _service
                .EmployeeService.GetEmployees(companyId, employeeParameters);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.employees);
        }

        /// <summary>
        /// Gets a single employee for a specific company by employee ID.
        /// </summary>
        /// <param name="companyId">The GUID of the company.</param>
        /// <param name="id">The GUID of the employee.</param>
        /// <returns>The requested employee details.</returns>
        [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = await _service.EmployeeService.GetEmployee(companyId, id);

            return Ok(employee);
        }

        /// <summary>
        /// Creates a new employee for a specific company.
        /// </summary>
        /// <param name="companyId">The GUID of the company.</param>
        /// <param name="employee">The employee creation data transfer object.</param>
        /// <returns>The newly created employee object.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateEmployeeForCompany(Guid companyId,
            [FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");

            var employeeToReturn = await _service.EmployeeService
                .CreateEmployeeForCompany(companyId, employee);

            return CreatedAtRoute("GetEmployeeForCompany",
                new { companyId, id = employeeToReturn.EmployeeId },
                employeeToReturn);
        }

        /// <summary>
        /// Deletes an employee from a specific company.
        /// </summary>
        /// <param name="companyId">The GUID of the company.</param>
        /// <param name="id">The GUID of the employee to delete.</param>
        /// <returns>No content on successful deletion.</returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
            await _service.EmployeeService.DeleteEmployeeForCompany(companyId, id);

            return NoContent();
        }

        /// <summary>
        /// Updates an employee's details for a specific company.
        /// </summary>
        /// <param name="companyId">The GUID of the company.</param>
        /// <param name="id">The GUID of the employee to update.</param>
        /// <param name="employee">The updated employee information.</param>
        /// <returns>No content on successful update.</returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEmployeeForCompany(Guid companyId, Guid id,
            [FromBody] EmployeeForUpdateDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForUpdateDto object is null");

            await _service.EmployeeService
                .UpdateEmployeeForCompany(companyId, id, employee);

            return NoContent();
        }
    }
}
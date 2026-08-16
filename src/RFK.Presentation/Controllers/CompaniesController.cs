using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace RFK.Presentation.Controllers;

/// <summary>
/// Manages company records and operations.
/// </summary>
[Route("api/companies")]
[ApiController]
[Produces("application/json")]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CompaniesController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets all companies.
    /// </summary>
    /// <returns>A list of companies.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _service.CompanyService.GetAllCompanies();

        return Ok(companies);
    }

    /// <summary>
    /// Gets a single company by its unique identifier.
    /// </summary>
    /// <param name="id">The GUID of the company to retrieve.</param>
    /// <returns>The requested company details.</returns>
    [HttpGet("{id:guid}", Name = "CompanyById")]
    [TypeFilter(typeof(NotFoundExceptionFilter))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await _service.CompanyService.GetCompany(id);

        return Ok(company);
    }

    /// <summary>
    /// Gets companies along with their associated employees.
    /// </summary>
    /// <returns>A list of companies including employee records.</returns>
    [HttpGet("withEmployees")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCompaniesWithEmployees()
    {
        var companies = await _service.CompanyService.GetCompaniesWithEmployees();

        return Ok(companies);
    }

    /// <summary>
    /// Creates a new company.
    /// </summary>
    /// <param name="company">The company creation data transfer object.</param>
    /// <returns>The newly created company object.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
    {
        if (company is null)
            return BadRequest("CompanyForCreationDto object is null");

        var createdCompany = await _service.CompanyService.CreateCompany(company);

        return CreatedAtRoute("CompanyById",
            new { id = createdCompany.CompanyId }, createdCompany);
    }

    /// <summary>
    /// Gets a collection of companies by comma-separated GUID string.
    /// </summary>
    /// <param name="ids">Comma-separated list of company GUIDs (e.g., "id1,id2,id3").</param>
    /// <returns>A collection of companies matching the specified IDs.</returns>
    [HttpGet("collection/({ids})", Name = "CompanyCollection")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCompanyCollection([FromRoute] string ids)
    {
        if (string.IsNullOrWhiteSpace(ids))
            return BadRequest("Ids are required");
        try
        {
            var idList = ids.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(id => Guid.Parse(id.Trim()))
                .ToList();
            var companies = await _service.CompanyService.GetByIds(idList);

            return Ok(companies);
        }
        catch (FormatException)
        {
            return BadRequest("One or more ids are not valid guids");
        }
    }

    /// <summary>
    /// Creates multiple companies in a single request.
    /// </summary>
    /// <param name="companyCollection">List of companies to create.</param>
    /// <returns>The created companies and their generated IDs.</returns>
    [HttpPost("collection")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCompanyCollection([FromBody]
        IEnumerable<CompanyForCreationDto> companyCollection)
    {
        var result = await _service.CompanyService
            .CreateCompanyCollection(companyCollection);

        return CreatedAtRoute("CompanyCollection",
            new { result.ids }, result.companies);
    }

    /// <summary>
    /// Deletes a specific company by its ID.
    /// </summary>
    /// <param name="id">The GUID of the company to delete.</param>
    /// <returns>No content on successful deletion.</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        await _service.CompanyService.DeleteCompany(id);

        return NoContent();
    }

    /// <summary>
    /// Updates an existing company record.
    /// </summary>
    /// <param name="id">The GUID of the company to update.</param>
    /// <param name="company">The updated company information.</param>
    /// <returns>No content on successful update.</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
    {
        if (company is null)
            return BadRequest("CompanyForUpdateDto object is null");

        await _service.CompanyService.UpdateCompany(id, company);

        return NoContent();
    }

    /// <summary>
    /// Gets the company associated with a specific employee ID.
    /// </summary>
    /// <param name="id">The GUID of the employee.</param>
    /// <returns>The company details associated with the employee.</returns>
    [HttpGet("byemployeeid/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCompanyByEmployeeId(Guid id)
    {
        var company = await _service.CompanyService.GetCompanyByEmployeeId(id);

        return Ok(company);
    }
}
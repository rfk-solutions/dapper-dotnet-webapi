using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace RFK.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CompaniesController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _service.CompanyService.GetAllCompanies();

        return Ok(companies);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await _service.CompanyService.GetCompany(id);

        return Ok(company);
    }

    [HttpGet("withEmployees")]
    public async Task<IActionResult> GetCompaniesWithEmployees()
    {
        var companies = await _service.CompanyService.GetCompaniesWithEmployees();

        return Ok(companies);
    }
}

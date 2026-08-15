using Shared.DataTransferObjects;

namespace Contracts
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyDto>> GetAllCompanies();
        Task<CompanyDto> GetCompany(Guid id);
        Task<IEnumerable<CompanyWithEmployeesDto>> GetCompaniesWithEmployees();
    }
}

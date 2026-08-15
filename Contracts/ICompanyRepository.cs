using Shared.DataTransferObjects;

namespace Contracts
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyDto>> GetAllCompanies();
    }
}

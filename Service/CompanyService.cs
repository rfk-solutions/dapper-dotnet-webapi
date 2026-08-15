using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CompanyService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies()
        {
            var companies = await _repository.Company.GetAllCompanies();

            return companies;
        }

        public async Task<CompanyDto> GetCompany(Guid id)
        {
            var company = await _repository.Company.GetCompany(id);
            if (company is null)
                throw new CompanyNotFoundException(id);

            return company;
        }

        public async Task<IEnumerable<CompanyWithEmployeesDto>> GetCompaniesWithEmployees()
        {
            var companies = await _repository.Company.GetCompaniesWithEmployees();

            return companies;
        }
    }
}
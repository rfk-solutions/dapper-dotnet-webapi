using Contracts;
using Dapper;
using Repository.Queries;
using Shared.DataTransferObjects;

namespace Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;

        public CompanyRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies()
        {
            var query = CompanyQuery.SelectCompanyQuery;

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<CompanyDto>(query);

                return companies.ToList();
            }
        }

        public async Task<CompanyDto> GetCompany(Guid id)
        {
            var query = CompanyQuery.SelectCompanyByIdQuery;

            using (var connection = _context.CreateConnection())
            {
                var company = await connection
                    .QuerySingleOrDefaultAsync<CompanyDto>(query, new { companyId = id });

                return company;
            }
        }

        public async Task<IEnumerable<CompanyWithEmployeesDto>> GetCompaniesWithEmployees()
        {
            var query = CompanyQuery.SelectCompaniesWithEmployeesQuery;

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<Guid, CompanyWithEmployeesDto>();

                var companies = await connection.QueryAsync<CompanyWithEmployeesDto, EmployeeDto, CompanyWithEmployeesDto>(
                    query, (company, employee) =>
                    {
                        if (!companyDict.TryGetValue(company.CompanyId, out var currentCompany))
                        {
                            currentCompany = company;
                            companyDict.Add(currentCompany.CompanyId, currentCompany);
                        }

                        currentCompany.Employees.Add(employee);

                        return currentCompany;
                    }, splitOn: "CompanyId, EmployeeId"
                );

                return companies.Distinct().ToList();
            }
        }
    }
}

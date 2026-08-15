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

    }
}

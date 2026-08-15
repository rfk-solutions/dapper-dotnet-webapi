using Contracts;
using Dapper;
using Repository.Queries;
using Shared.DataTransferObjects;

namespace Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<EmployeeDto>> GetEmployees(Guid companyId)
        {
            var query = EmployeeQuery.SelectEmployeesQuery;

            using (var connection = _context.CreateConnection())
            {
                var employees = await connection
                    .QueryAsync<EmployeeDto>(query, new { companyId });

                return employees.ToList();
            }
        }

        public async Task<EmployeeDto> GetEmployee(Guid companyId, Guid id)
        {
            var query = EmployeeQuery.SelectEmployeeByIdAndCompanyIdQuery;

            using (var connection = _context.CreateConnection())
            {
                var param = new { companyId, id };
                var employee = await connection
                    .QuerySingleOrDefaultAsync<EmployeeDto>(query, param);

                return employee;
            }
        }
    }
}

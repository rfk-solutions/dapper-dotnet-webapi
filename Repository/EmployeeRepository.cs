using Contracts;
using Dapper;
using Repository.Queries;
using Shared.DataTransferObjects;
using System.Data;

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

        public async Task<EmployeeDto> CreateEmployeeForCompany(Guid companyId,
            EmployeeForCreationDto employeeDto)
        {
            var query = EmployeeQuery.InsertEmployeeWithOutputQuery;

            var param = new DynamicParameters(employeeDto);
            param.Add("id", companyId, DbType.Guid);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<Guid>(query, param);

                return new EmployeeDto(id, employeeDto.Name,
                    employeeDto.Age, employeeDto.Position);
            }
        }

        public async Task DeleteEmployee(Guid employeeId)
        {
            var query = EmployeeQuery.DeleteEmployeeQuery;

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { employeeId });
            }
        }

        public async Task UpdateEmployee(Guid employeeId, EmployeeForUpdateDto employee)
        {
            var query = EmployeeQuery.UpdateEmployeeQuery;

            var param = new DynamicParameters(employee);
            param.Add("employeeId", employeeId, DbType.Guid);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, param);
            }
        }
    }
}

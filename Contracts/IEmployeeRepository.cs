using Shared.DataTransferObjects;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees(Guid companyId);
        Task<EmployeeDto> GetEmployee(Guid companyId, Guid id);
        Task<EmployeeDto> CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeDto);
        Task DeleteEmployee(Guid employeeId);
        Task UpdateEmployee(Guid employeeId, EmployeeForUpdateDto employee);
    }
}

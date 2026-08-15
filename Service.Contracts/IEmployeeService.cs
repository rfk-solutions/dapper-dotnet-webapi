using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees(Guid companyId);
        Task<EmployeeDto> GetEmployee(Guid companyId, Guid id);
        Task<EmployeeDto> CreateEmployeeForCompany(Guid companyId,
            EmployeeForCreationDto employeeDto);
        Task DeleteEmployeeForCompany(Guid companyId, Guid employeeId);
        Task UpdateEmployeeForCompany(Guid companyId, Guid id,
            EmployeeForUpdateDto employee);
    }
}

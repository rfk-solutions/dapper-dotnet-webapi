using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees(Guid companyId);
        Task<EmployeeDto> GetEmployee(Guid companyId, Guid id);
    }
}
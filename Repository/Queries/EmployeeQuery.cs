namespace Repository.Queries
{
    public static class EmployeeQuery
    {
        public const string SelectEmployeesQuery =
            @"SELECT EmployeeId, [Name], Age, Position
              FROM Employees
              WHERE CompanyId = @companyId";

        public const string SelectEmployeeByIdAndCompanyIdQuery =
            @"SELECT EmployeeId, [Name], Age, Position
              FROM Employees
              WHERE EmployeeId = @id AND CompanyId = @companyId";
    }
}

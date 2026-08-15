namespace Repository.Queries
{
    public static class CompanyQuery
    {
        public const string SelectCompanyQuery =
            @"SELECT CompanyId, [Name], 
              CONCAT([Address], ', ', Country) AS FullAddress
              FROM Companies
              ORDER BY [Name]";

        public const string SelectCompanyByIdQuery =
            @"SELECT CompanyId, [Name], 
              CONCAT([Address], ', ', Country) AS FullAddress
              FROM Companies
              WHERE CompanyId = @companyId";

        public const string SelectCompaniesWithEmployeesQuery =
            @"SELECT c.CompanyId, c.[Name], 
              CONCAT(c.[Address], ', ', c.Country) AS FullAddress, 
              e.EmployeeId, e.[Name], e.Age, e.Position 
              FROM Companies c JOIN Employees e ON c.CompanyId = e.CompanyId";
    }
}

namespace Repository.Queries
{
    public static class CompanyQuery
    {
        public const string SelectCompanyQuery =
            @"SELECT CompanyId, [Name], 
              CONCAT([Address], ', ', Country) AS FullAddress
              FROM Companies
              ORDER BY [Name]";
    }
}

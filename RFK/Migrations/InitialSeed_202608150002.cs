using Entities.Models;
using FluentMigrator;

namespace CompanyEmployees.Migrations
{
    [Migration(202608150002)]
    public class InitialSeed_202608150002 : Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Insert.IntoTable("Companies")
                .Row(new Company
                {
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Eswatini Textile Ltd",
                    Address = "Plot 45, Matsapha Industrial Estate",
                    Country = "Eswatini"
                })
                .Row(new Company
                {
                    CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Royal Garments Eswatini",
                    Address = "102 King Mswati III Ave, Nhlangano",
                    Country = "Eswatini"
                });

            Insert.IntoTable("Employees")
                .Row(new Employee
                {
                    EmployeeId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Sibusiso Dlamini",
                    Age = 28,
                    Position = "QA Supervisor",
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                })
                .Row(new Employee
                {
                    EmployeeId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Name = "Nokuthula Zwane",
                    Age = 32,
                    Position = "Pattern Maker",
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                })
                .Row(new Employee
                {
                    EmployeeId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    Name = "Thabo Maseko",
                    Age = 39,
                    Position = "Production Manager",
                    CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                });
        }
    }
}
using Entities.Models;
using FluentMigrator;

namespace CompanyEmployees.Migrations
{
    [Migration(202608150002)]
    public class InitialSeed_202608150002 : Migration
    {
        // Company GUIDs
        private static readonly Guid Company1Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870");
        private static readonly Guid Company2Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3");
        private static readonly Guid Company3Id = new Guid("a1f8b212-654a-4d92-9e81-34a6e87f1082");
        private static readonly Guid Company4Id = new Guid("f2c90e44-8832-4e2b-b98a-7d1a23e59041");
        private static readonly Guid Company5Id = new Guid("5b7e9231-11d4-42bc-a2d9-e932b1029c73");

        public override void Down()
        {
            Delete.FromTable("Employees").AllRows();
            Delete.FromTable("Companies").AllRows();
        }

        public override void Up()
        {
            // Seed Companies
            Insert.IntoTable("Companies")
                .Row(new Company
                {
                    CompanyId = Company1Id,
                    Name = "Eswatini Textile Ltd",
                    Address = "Plot 45, Matsapha Industrial Estate",
                    Country = "Eswatini"
                })
                .Row(new Company
                {
                    CompanyId = Company2Id,
                    Name = "Royal Garments Eswatini",
                    Address = "102 King Mswati III Ave, Nhlangano",
                    Country = "Eswatini"
                })
                .Row(new Company
                {
                    CompanyId = Company3Id,
                    Name = "Mbabane Tech Solutions",
                    Address = "Suite 201, Corporate Place, Mbabane",
                    Country = "Eswatini"
                })
                .Row(new Company
                {
                    CompanyId = Company4Id,
                    Name = "Swazi Sugar Processors",
                    Address = "Mill Road, Simunye",
                    Country = "Eswatini"
                })
                .Row(new Company
                {
                    CompanyId = Company5Id,
                    Name = "Peak Timber Products",
                    Address = "Main Road, Pigg's Peak",
                    Country = "Eswatini"
                });

            // Seed Employees (10 per company)
            Insert.IntoTable("Employees")
                // --- Company 1: Eswatini Textile Ltd ---
                .Row(new Employee
                {
                    EmployeeId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Sibusiso Dlamini",
                    Age = 28,
                    Position = "QA Supervisor",
                    CompanyId = Company1Id
                })
                .Row(new Employee
                {
                    EmployeeId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Name = "Nokuthula Zwane",
                    Age = 32,
                    Position = "Pattern Maker",
                    CompanyId = Company1Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Bheki Nkambule",
                    Age = 41,
                    Position = "Plant Manager",
                    CompanyId = Company1Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Siphesihle Khumalo",
                    Age = 26,
                    Position = "Cutting Machine Operator",
                    CompanyId = Company1Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Lungelo Gamedze",
                    Age = 35,
                    Position = "Maintenance Specialist",
                    CompanyId = Company1Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Nomcebo Mamba",
                    Age = 29,
                    Position = "Inventory Controller",
                    CompanyId = Company1Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Mthobisi Vilakati",
                    Age = 30,
                    Position = "Fabric Inspector",
                    CompanyId = Company1Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Tengetile Shongwe",
                    Age = 24,
                    Position = "Junior Designer",
                    CompanyId = Company1Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Bandile Fakudze",
                    Age = 38,
                    Position = "Logistics Coordinator",
                    CompanyId = Company1Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Phiwayinkosi Ginindza",
                    Age = 45,
                    Position = "Health & Safety Officer",
                    CompanyId = Company1Id
                })

                // --- Company 2: Royal Garments Eswatini ---
                .Row(new Employee
                {
                    EmployeeId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    Name = "Thabo Maseko",
                    Age = 39,
                    Position = "Production Manager",
                    CompanyId = Company2Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Sikhumbuzo Nxumalo",
                    Age = 34,
                    Position = "Senior Tailor",
                    CompanyId = Company2Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Zodwa Magagula",
                    Age = 27,
                    Position = "Seamstress Supervisor",
                    CompanyId = Company2Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Mandla Tsabedze",
                    Age = 44,
                    Position = "Warehouse Supervisor",
                    CompanyId = Company2Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Nomathemba Nsibande",
                    Age = 31,
                    Position = "Quality Inspector",
                    CompanyId = Company2Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Musa Hlophe",
                    Age = 25,
                    Position = "Packing Technician",
                    CompanyId = Company2Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Simangele Kunene",
                    Age = 36,
                    Position = "HR Officer",
                    CompanyId = Company2Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Vusi Matsebula",
                    Age = 48,
                    Position = "Chief Mechanic",
                    CompanyId = Company2Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Nonhlanhla Mavuso",
                    Age = 29,
                    Position = "Accounts Clerk",
                    CompanyId = Company2Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Lindiwe Bhembe",
                    Age = 40,
                    Position = "Sourcing Specialist",
                    CompanyId = Company2Id
                })

                // --- Company 3: Mbabane Tech Solutions ---
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Melusi Simelane",
                    Age = 33,
                    Position = "Lead Software Engineer",
                    CompanyId = Company3Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Njabulo Myeni",
                    Age = 29,
                    Position = "Backend Developer",
                    CompanyId = Company3Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Temaswati Lukhele",
                    Age = 26,
                    Position = "Frontend Developer",
                    CompanyId = Company3Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Sandile Dube",
                    Age = 37,
                    Position = "DevOps Engineer",
                    CompanyId = Company3Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Khanyisile Ndzinisa",
                    Age = 31,
                    Position = "UI/UX Designer",
                    CompanyId = Company3Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Mcebo Mamba",
                    Age = 27,
                    Position = "QA Analyst",
                    CompanyId = Company3Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Tfobile Dlamini",
                    Age = 42,
                    Position = "Project Manager",
                    CompanyId = Company3Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Nkosinathi Shabangu",
                    Age = 35,
                    Position = "Database Administrator",
                    CompanyId = Company3Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Sabelo Adams",
                    Age = 24,
                    Position = "IT Support Specialist",
                    CompanyId = Company3Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Gcinile Mkhatshwa",
                    Age = 38,
                    Position = "Scrum Master",
                    CompanyId = Company3Id
                })

                // --- Company 4: Swazi Sugar Processors ---
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Thulani Masuku",
                    Age = 46,
                    Position = "Operations Director",
                    CompanyId = Company4Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Zanele Nlangamandla",
                    Age = 34,
                    Position = "Chemical Engineer",
                    CompanyId = Company4Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Nathi Ziyane",
                    Age = 39,
                    Position = "Refinery Engineer",
                    CompanyId = Company4Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Siphokazi Sithole",
                    Age = 28,
                    Position = "Lab Analyst",
                    CompanyId = Company4Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Bongani Cele",
                    Age = 51,
                    Position = "Safety Inspector",
                    CompanyId = Company4Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Phetsile Thwala",
                    Age = 30,
                    Position = "Supply Chain Planner",
                    CompanyId = Company4Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Mzwandile Ndlangamandla",
                    Age = 43,
                    Position = "Electrical Specialist",
                    CompanyId = Company4Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Ndumiso Nxumalo",
                    Age = 27,
                    Position = "Boiler Operator",
                    CompanyId = Company4Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Sebenele Dlamini",
                    Age = 32,
                    Position = "Procurement Officer",
                    CompanyId = Company4Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Ncamsile Dladla",
                    Age = 36,
                    Position = "Environmental Officer",
                    CompanyId = Company4Id
                })

                // --- Company 5: Peak Timber Products ---
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Kenneth Mkhonta",
                    Age = 50,
                    Position = "General Manager",
                    CompanyId = Company5Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Mbongeni Vilane",
                    Age = 37,
                    Position = "Forestry Supervisor",
                    CompanyId = Company5Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Thandeka Mkhwanazi",
                    Age = 29,
                    Position = "Mill Supervisor",
                    CompanyId = Company5Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Siyabonga Ndlovu",
                    Age = 41,
                    Position = "Logistics Manager",
                    CompanyId = Company5Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Anotida Maphosa",
                    Age = 33,
                    Position = "Timber Grader",
                    CompanyId = Company5Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Lindokuhle Zwane",
                    Age = 26,
                    Position = "Kiln Operator",
                    CompanyId = Company5Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Bonginkosi Mthembu",
                    Age = 44,
                    Position = "Heavy Equipment Mechanic",
                    CompanyId = Company5Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Nosipho Shabalala",
                    Age = 31,
                    Position = "Sales Representative",
                    CompanyId = Company5Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Sifiso Mdluli",
                    Age = 38,
                    Position = "Safety Coordinator",
                    CompanyId = Company5Id
                })
                .Row(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Lwazi Khumalo",
                    Age = 23,
                    Position = "Junior Accountant",
                    CompanyId = Company5Id
                });
        }
    }
}
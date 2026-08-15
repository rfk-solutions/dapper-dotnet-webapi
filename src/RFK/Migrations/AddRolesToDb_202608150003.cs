using AspNetCore.Identity.Dapper.Models;
using FluentMigrator;

namespace RFK.Migrations
{
    [Migration(202608150003)]
    public class AddRolesToDb_202608150003 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("AspNetRoles")
                .Row(new ApplicationRole
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                })
                .Row(new ApplicationRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });
        }

        public override void Up()
        {
            Insert.IntoTable("AspNetRoles")
                .Row(new ApplicationRole
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                })
                .Row(new ApplicationRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });
        }
    }
}

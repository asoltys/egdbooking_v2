using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using egdbooking_v2.Models;

namespace egdbooking_v2.Data.Migrations
{
    public partial class ConsolidateUsers : Migration
    {
        private readonly UserManager<ApplicationUser> _userManager;
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                WITH CTE AS(
                   SELECT [Email], [Id], RN = ROW_NUMBER()
                   OVER(PARTITION BY Email ORDER BY Id DESC)
                   FROM dbo.Users
                )
                DELETE FROM CTE WHERE RN > 1
            ");


            migrationBuilder.Sql(@"
              INSERT INTO AspNetUsers
              SELECT
                NEWID() AS Id,
                0 AS AccessFailedCount,
                0 AS ConcurrencyStamp,
                Email AS Email,
                'true' AS EmailConfirmed,
                'false' AS LockoutEnabled,
                NULL AS LockoutEnd,
                UPPER(Email) AS NormalizedEmail,
                UPPER(Email) AS NormalizedUserName,
                Password AS PasswordHash,
                NULL AS PhoneNumber,
                'false' AS PhoneNumberConfirmed,
                NULL AS SecurityStamp,
                'false' AS TwoFactorEnabled,
                Email AS UserName
              FROM Users
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}

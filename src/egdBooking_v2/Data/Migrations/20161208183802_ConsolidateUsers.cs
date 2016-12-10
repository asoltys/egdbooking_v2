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

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true
            );

            migrationBuilder.AddColumn<bool>(
                name: "ReadOnly",
                table: "AspNetUsers",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                nullable: true
            );

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
                  NEWID() AS SecurityStamp,
                  'false' AS TwoFactorEnabled,
                  Email AS UserName,
                  Id AS UserId,
                  FirstName AS FirstName,
                  LastName AS LastName,
                  ReadOnly AS ReadOnly,
                  Role AS Role
                FROM Users
                WHERE Deleted = 0
            ");

            migrationBuilder.Sql(@"
                INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'183ba0d1-312a-48f2-af6b-90cb99d7bae9', N'b03711ac-1398-4192-90f4-d6fefd265ecd', N'User', N'USER')
                INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'98716fbe-8127-4ea4-b2f2-0fa04378b998', N'03db0328-0107-437e-a8dc-4ad5653e72d9', N'Admin', N'ADMIN')

                SET IDENTITY_INSERT [dbo].[AspNetRoleClaims] ON 
                INSERT [dbo].[AspNetRoleClaims] ([Id], [ClaimType], [ClaimValue], [RoleId]) VALUES (1, N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'Admin', N'98716fbe-8127-4ea4-b2f2-0fa04378b998')
                INSERT [dbo].[AspNetRoleClaims] ([Id], [ClaimType], [ClaimValue], [RoleId]) VALUES (2, N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'User', N'183ba0d1-312a-48f2-af6b-90cb99d7bae9')
                SET IDENTITY_INSERT [dbo].[AspNetRoleClaims] OFF
            ");

            migrationBuilder.Sql(@"
                INSERT INTO AspNetUserRoles
                SELECT
                    Id AS UserId,
                    '98716fbe-8127-4ea4-b2f2-0fa04378b998' AS RoleId
                FROM AspNetUsers
                WHERE Role = 'Admin';

                INSERT INTO AspNetUserRoles
                SELECT
                    Id AS UserId,
                    '183ba0d1-312a-48f2-af6b-90cb99d7bae9' AS RoleId
                FROM AspNetUsers
                WHERE Role = 'User';
            ");

            migrationBuilder.DropForeignKey("FK_UserCompanies_Users_UserId", "UserCompanies");
            migrationBuilder.DropPrimaryKey("PK_UserCompanies", "UserCompanies");

            migrationBuilder.AlterColumn<string>(
                table: "UserCompanies",
                name: "UserId",
                type: "nvarchar(450)",
                oldType: "int"
            );

            migrationBuilder.Sql(@"
                DELETE FROM UserCompanies WHERE UserId NOT IN (SELECT Id FROM AspNetUsers);
                UPDATE UserCompanies SET UserCompanies.UserId = (
                    SELECT AspNetUsers.Id 
                    FROM AspNetUsers 
                    WHERE AspNetUsers.UserId = UserCompanies.UserId
                );
            ");

            migrationBuilder.AddPrimaryKey("PK_UserCompanies", "UserCompanies", new[] {"UserId", "CompanyId"});
            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Users_UserId", 
                table: "UserCompanies",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.DropColumn("UserId", "AspNetUsers");
            migrationBuilder.DropColumn("Role", "AspNetUsers");
            migrationBuilder.DropTable("Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql(@"
              DELETE FROM AspNetUsers;
              DELETE FROM AspNetUserRoles;
              DELETE FROM AspNetRoles;
              DELETE FROM AspNetRoleClaims;
          ");
        }
    }
}

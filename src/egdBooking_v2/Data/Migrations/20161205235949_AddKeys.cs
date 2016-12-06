using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace egdbooking_v2.Data.Migrations
{
    public partial class AddKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TariffForms", 
                newName: "Tariffs"
            );

            // Delete duplicates from UserCompanies
            migrationBuilder.Sql(@"
                WITH CTE AS(
                   SELECT [UserId], [CompanyId], [Deleted], [Approved], RN = ROW_NUMBER()
                   OVER(PARTITION BY UserId, CompanyId ORDER BY CompanyId)
                   FROM dbo.UserCompanies
                )
                DELETE FROM CTE WHERE RN > 1
            ");

            migrationBuilder.AddPrimaryKey("PK_Bookings", "Bookings", "Id");
            migrationBuilder.AddPrimaryKey("PK_Companies", "Companies", "Id");
            migrationBuilder.AddPrimaryKey("PK_UserCompanies", "UserCompanies", new[] {"UserId", "CompanyId"});
            migrationBuilder.AddPrimaryKey("PK_Users", "Users", "Id");
            migrationBuilder.AddPrimaryKey("PK_VesselCompanies", "VesselCompanies", new[] {"VesselId", "CompanyId"});
            migrationBuilder.AddPrimaryKey("PK_Vessels", "Vessels", "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Companies_CompanyId", 
                table: "UserCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Users_UserId", 
                table: "UserCompanies",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_VesselCompanies_Companies_CompanyId", 
                table: "VesselCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_VesselCompanies_Vessels_VesselId", 
                table: "VesselCompanies",
                column: "VesselId",
                principalTable: "Vessels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Vessels_VesselId", 
                table: "Bookings",
                column: "VesselId",
                principalTable: "Vessels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_Bookings_BookingId", 
                table: "Tariffs",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_UserCompanies_Companies_CompanyId", "UserCompanies");
            migrationBuilder.DropForeignKey("FK_UserCompanies_Users_UserId", "UserCompanies");
            migrationBuilder.DropForeignKey("FK_VesselCompanies_Companies_CompanyId", "VesselCompanies");
            migrationBuilder.DropForeignKey("FK_VesselCompanies_Vessels_VesselId", "VesselCompanies");
            migrationBuilder.DropForeignKey("FK_Bookings_Vessels_VesselId", "Bookings");
            migrationBuilder.DropForeignKey("FK_Vessels_Users_UserId", "Users");
            migrationBuilder.DropForeignKey("FK_UserCompanies_Users_UserId", "Users");
            migrationBuilder.DropForeignKey("FK_Tariffs_Bookings_BookingId", "Tariffs");

            migrationBuilder.DropPrimaryKey("PK_Vessels", "Vessels");
            migrationBuilder.DropPrimaryKey("PK_VesselCompanies", "VesselCompanies");
            migrationBuilder.DropPrimaryKey("PK_Users", "Users");
            migrationBuilder.DropPrimaryKey("PK_UserCompanies", "UserCompanies");
            migrationBuilder.DropPrimaryKey("PK_Tariffs", "Tariffs");
            migrationBuilder.DropPrimaryKey("PK_Companies", "Companies");
            migrationBuilder.DropPrimaryKey("PK_Bookings", "Bookings");

            migrationBuilder.RenameTable(
                name: "Tariffs", 
                newName: "TariffForms"
            );
        }
    }
}

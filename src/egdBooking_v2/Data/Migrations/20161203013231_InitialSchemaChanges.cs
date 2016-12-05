using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace egdbooking_v2.Data.Migrations
{
    public partial class InitialSchemaChangesFromCurrentProduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER SCHEMA dbo TRANSFER [egdbooking].[Administrators];
                ALTER SCHEMA dbo TRANSFER [egdbooking].[Bookings];
                ALTER SCHEMA dbo TRANSFER [egdbooking].[Companies];
                ALTER SCHEMA dbo TRANSFER [egdbooking].[Configuration];
                ALTER SCHEMA dbo TRANSFER [egdbooking].[Docks];
                ALTER SCHEMA dbo TRANSFER [egdbooking].[Jetties];
                ALTER SCHEMA dbo TRANSFER [egdbooking].[TariffFees];
                ALTER SCHEMA dbo TRANSFER [egdbooking].[TariffForms];
                ALTER SCHEMA dbo TRANSFER [egdbooking].[UserCompanies];
                ALTER SCHEMA dbo TRANSFER [egdbooking].[Users];
                ALTER SCHEMA dbo TRANSFER [egdbooking].[Vessels];");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                defaultValue: "User"
            );

            migrationBuilder.Sql(@"
                UPDATE Users SET Role = 'User';
                UPDATE Users SET Role = 'Admin' WHERE
                Users.UID IN (SELECT UID FROM Administrators);

            ");
                
            migrationBuilder.DropTable("Administrators");

            migrationBuilder.AddColumn<bool>(
                name: "Section1",
                table: "Bookings",
                nullable: true
            );

            migrationBuilder.AddColumn<bool>(
                name: "Section2",
                table: "Bookings",
                nullable: true
            );

            migrationBuilder.AddColumn<bool>(
                name: "Section3",
                table: "Bookings",
                nullable: true
            );

            migrationBuilder.AddColumn<bool>(
                name: "NorthJetty",
                table: "Bookings",
                nullable: true
            );

            migrationBuilder.AddColumn<bool>(
                name: "SouthJetty",
                table: "Bookings",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Bookings",
                defaultValue: "PT"
            );

            migrationBuilder.Sql(@"
                UPDATE Bookings SET Section1 = (
                  SELECT Section1 FROM Docks
                  WHERE Docks.BRID = Bookings.BRID
                );

                UPDATE Bookings SET Section2 = (
                  SELECT Section2 FROM Docks
                  WHERE Docks.BRID = Bookings.BRID
                );

                UPDATE Bookings SET Section3 = (
                  SELECT Section3 FROM Docks
                  WHERE Docks.BRID = Bookings.BRID
                );

                UPDATE Bookings SET NorthJetty = (
                  SELECT NorthJetty FROM Jetties 
                  WHERE Jetties.BRID = Bookings.BRID
                );

                UPDATE Bookings SET SouthJetty = (
                  SELECT SouthJetty FROM Jetties 
                  WHERE Jetties.BRID = Bookings.BRID
                );

                UPDATE Bookings SET Status = (
                  SELECT Status FROM Docks
                  WHERE Docks.BRID = Bookings.BRID
                )
                WHERE Bookings.BRID IN (
                  SELECT BRID FROM Docks
                );
                
                UPDATE Bookings SET Status = (
                  SELECT Status FROM Jetties
                  WHERE Jetties.BRID = Bookings.BRID
                  AND Status IS NOT NULL
                )
                WHERE Bookings.BRID IN (
                  SELECT BRID FROM Jetties
                );
            ");

            migrationBuilder.DropTable("Docks");
            migrationBuilder.DropTable("Jetties");
            migrationBuilder.DropTable("TariffFees");

            migrationBuilder.CreateTable(
                name: "VesselCompanies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    VesselId = table.Column<int>(nullable: false),
                    BlockSetupTime = table.Column<int>(nullable: false, defaultValue: 0),
                    BlockTeardownTime = table.Column<int>(nullable: false, defaultValue: 0)
                }
            );

            migrationBuilder.Sql(@"
                INSERT INTO VesselCompanies
                SELECT 
                  CID as CompanyId, 
                  VNID as VesselId, 
                  BlockSetupTime, 
                  BlockTeardownTime
                FROM Vessels
            ");

            migrationBuilder.DropColumn("CID", "Vessels");
            migrationBuilder.DropColumn("BlockSetupTime", "Vessels");
            migrationBuilder.DropColumn("BlockTeardownTime", "Vessels");

            migrationBuilder.RenameColumn(
                table: "Bookings",
                name: "BRID",
                newName: "Id"
            );

            migrationBuilder.RenameColumn(
                table: "Companies",
                name: "CID",
                newName: "Id"
            );

            migrationBuilder.RenameColumn(
                table: "Users",
                name: "UID",
                newName: "Id"
            );

            migrationBuilder.RenameColumn(
                table: "Vessels",
                name: "VNID",
                newName: "Id"
            );

            migrationBuilder.RenameColumn(
                table: "Bookings",
                name: "UID",
                newName: "UserId"
            );

            migrationBuilder.RenameColumn(
                table: "Bookings",
                name: "VNID",
                newName: "VesselId"
            );

            migrationBuilder.RenameColumn(
                table: "UserCompanies",
                name: "UID",
                newName: "UserId"
            );

            migrationBuilder.RenameColumn(
                table: "UserCompanies",
                name: "CID",
                newName: "CompanyId"
            );

            migrationBuilder.RenameColumn(
                table: "TariffForms",
                name: "BRID",
                newName: "BookingId"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}

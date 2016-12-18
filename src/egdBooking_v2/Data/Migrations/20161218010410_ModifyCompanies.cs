using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace egdbooking_v2.Data.Migrations
{
    public partial class ModifyCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("Address1", "Companies", "Address");
            migrationBuilder.DropColumn("Address2", "Companies");
            migrationBuilder.DropColumn("Name_f", "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name_f", 
                table: "Companies",
                nullable: true
            );
            migrationBuilder.AddColumn<string>(
                name: "Address2", 
                table: "Companies",
                nullable: true
            );
            migrationBuilder.RenameColumn("Address", "Companies", "Address1");
        }
    }
}

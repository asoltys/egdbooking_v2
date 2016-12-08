using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;

namespace egdbooking_v2.Data.Migrations
{
    public partial class RenameNotice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.RenameColumn(
              table: "Users",
              name: "notice_acknowledged", 
              newName: "SeenNotice"
          );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.RenameColumn(
              table: "Users",
              name: "SeenNotice",
              newName: "notice_acknowledged"
          );
        }
    }
}

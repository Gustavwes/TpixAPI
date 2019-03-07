using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TpixAPI.Migrations
{
    public partial class membersignupdateadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SignedUpAt",
                table: "Member",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignedUpAt",
                table: "Member");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TpixAPI.Migrations
{
    public partial class addedidentityguidcolumnformembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentGuid",
                table: "Member",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentGuid",
                table: "Member");
        }
    }
}

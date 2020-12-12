using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeMVC.Migrations
{
    public partial class userass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "EmployeeInformations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmployeeInformations");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFactoryMVC.Data.Migrations
{
    public partial class newIdentityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonFirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PersonLastName",
                table: "AspNetUsers");
        }
    }
}

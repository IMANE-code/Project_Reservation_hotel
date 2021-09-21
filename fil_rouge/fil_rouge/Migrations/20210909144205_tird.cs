using Microsoft.EntityFrameworkCore.Migrations;

namespace fil_rouge.Migrations
{
    public partial class tird : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "hotels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "hotels");
        }
    }
}

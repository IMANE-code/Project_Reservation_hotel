using Microsoft.EntityFrameworkCore.Migrations;

namespace fil_rouge.Migrations
{
    public partial class ii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Niveau",
                table: "reservation_Hotels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Niveau",
                table: "reservation_Hotels");
        }
    }
}

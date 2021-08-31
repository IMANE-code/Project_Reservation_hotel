using Microsoft.EntityFrameworkCore.Migrations;

namespace fil_rouge.Migrations
{
    public partial class goood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Niveau",
                table: "reservation_Hotels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "reservation_Hotels");

            migrationBuilder.AlterColumn<string>(
                name: "IsValid",
                table: "reservation_Hotels",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "IdClient",
                table: "reservation_Hotels",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsValid",
                table: "reservation_Hotels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdClient",
                table: "reservation_Hotels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Niveau",
                table: "reservation_Hotels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "reservation_Hotels",
                nullable: false,
                defaultValue: 0f);
        }
    }
}

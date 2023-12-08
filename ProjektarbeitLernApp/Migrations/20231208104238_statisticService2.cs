using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektarbeitLernApp.Migrations
{
    /// <inheritdoc />
    public partial class statisticService2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WasKnown",
                table: "LearnProgress");

            migrationBuilder.DropColumn(
                name: "WasNotKnown",
                table: "LearnProgress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WasKnown",
                table: "LearnProgress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WasNotKnown",
                table: "LearnProgress",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

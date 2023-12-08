using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektarbeitLernApp.Migrations
{
    /// <inheritdoc />
    public partial class updatedcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MultipleChoiceSet_Id",
                table: "LearnProgress",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MultipleChoiceSet_Id",
                table: "LearnProgress");
        }
    }
}

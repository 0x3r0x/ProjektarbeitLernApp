using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektarbeitLernApp.Migrations
{
    /// <inheritdoc />
    public partial class changedPropertyUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Student_Id",
                table: "Statistic",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "Student_Id",
                table: "LearnProgress",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "Sutdent_Id",
                table: "ExamSimulation",
                newName: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Statistic",
                newName: "Student_Id");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "LearnProgress",
                newName: "Student_Id");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "ExamSimulation",
                newName: "Sutdent_Id");
        }
    }
}

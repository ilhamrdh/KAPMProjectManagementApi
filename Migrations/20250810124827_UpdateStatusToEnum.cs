using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KAPMProjectManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatusToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_project_timeline",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "desc_project",
                table: "trn_project",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "desc_project",
                table: "trn_project");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_project_timeline",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KAPMProjectManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class changeTypeEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "trn_schedule_invoice",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_schedule_invoice",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_project_report_dtl",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "deviation",
                table: "trn_project_report",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_project_issue",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_project_adendum",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_project",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "progress_report",
                table: "trn_project",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "role_type",
                table: "mst_role_project",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "trn_schedule_invoice",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_schedule_invoice",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_project_report_dtl",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "deviation",
                table: "trn_project_report",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_project_issue",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_project_adendum",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "trn_project",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "progress_report",
                table: "trn_project",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "role_type",
                table: "mst_role_project",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");
        }
    }
}

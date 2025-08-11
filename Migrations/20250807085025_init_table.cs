using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KAPMProjectManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class init_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mst_project_manager",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nipp = table.Column<string>(type: "varchar(15)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(100)", nullable: true),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(100)", nullable: true),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_project_manager", x => new { x.id, x.nipp });
                    table.UniqueConstraint("AK_mst_project_manager_nipp", x => x.nipp);
                });

            migrationBuilder.CreateTable(
                name: "mst_unit_project",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    unit_project = table.Column<string>(type: "varchar(50)", nullable: false),
                    unit_desc = table.Column<string>(type: "varchar(100)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(100)", nullable: true),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(100)", nullable: true),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_unit_project", x => new { x.id, x.unit_project });
                    table.UniqueConstraint("AK_mst_unit_project_unit_project", x => x.unit_project);
                });

            migrationBuilder.CreateTable(
                name: "trn_project",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code_project = table.Column<string>(type: "varchar(50)", nullable: false),
                    no_spmk = table.Column<string>(type: "varchar(50)", nullable: false),
                    no_contract = table.Column<string>(type: "varchar(50)", nullable: false),
                    unit_project = table.Column<string>(type: "varchar(50)", nullable: false),
                    pm_project = table.Column<string>(type: "varchar(50)", nullable: false),
                    payment_method = table.Column<string>(type: "varchar(50)", nullable: false),
                    contract_value = table.Column<string>(type: "varchar(50)", nullable: false),
                    bank = table.Column<string>(type: "varchar(10)", nullable: false),
                    account_number = table.Column<string>(type: "varchar(50)", nullable: false),
                    account_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    working_method = table.Column<string>(type: "varchar(50)", nullable: false),
                    pph = table.Column<string>(type: "varchar(50)", nullable: false),
                    start_date_spmk = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    finish_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    plan_persentage = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    actual_persentage = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    progress_report = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "varchar(50)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_project", x => new { x.id, x.code_project });
                    table.ForeignKey(
                        name: "FK_trn_project_mst_project_manager_pm_project",
                        column: x => x.pm_project,
                        principalTable: "mst_project_manager",
                        principalColumn: "nipp",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trn_project_mst_unit_project_unit_project",
                        column: x => x.unit_project,
                        principalTable: "mst_unit_project",
                        principalColumn: "unit_project",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_pm_project",
                table: "trn_project",
                column: "pm_project",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_unit_project",
                table: "trn_project",
                column: "unit_project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trn_project");

            migrationBuilder.DropTable(
                name: "mst_project_manager");

            migrationBuilder.DropTable(
                name: "mst_unit_project");
        }
    }
}

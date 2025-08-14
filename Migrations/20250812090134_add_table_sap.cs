using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KAPMProjectManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class add_table_sap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrnSapWbsId",
                table: "trn_project_report_dtl",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrnSapWbsWBSElement",
                table: "trn_project_report_dtl",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrnSapWbsId",
                table: "trn_project_adendum",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrnSapWbsWBSElement",
                table: "trn_project_adendum",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "trn_sap_hrd",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    project_def = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_desc = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_profile = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_responsible = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_owner = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_location = table.Column<string>(type: "varchar(50)", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fiscal_year = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status_system = table.Column<string>(type: "varchar(50)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_sap_hrd", x => new { x.id, x.project_def });
                });

            migrationBuilder.CreateTable(
                name: "trn_sap_wbs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    wbs_element = table.Column<string>(type: "varchar(50)", nullable: false),
                    wbs_level = table.Column<string>(type: "varchar(50)", nullable: false),
                    wbs_desc = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_type = table.Column<string>(type: "varchar(100)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrnProjectId = table.Column<int>(type: "integer", nullable: true),
                    TrnProjectProjectDef = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_sap_wbs", x => new { x.id, x.wbs_element });
                    table.ForeignKey(
                        name: "FK_trn_sap_wbs_trn_project_TrnProjectId_TrnProjectProjectDef",
                        columns: x => new { x.TrnProjectId, x.TrnProjectProjectDef },
                        principalTable: "trn_project",
                        principalColumns: new[] { "id", "project_def" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_report_dtl_TrnSapWbsId_TrnSapWbsWBSElement",
                table: "trn_project_report_dtl",
                columns: new[] { "TrnSapWbsId", "TrnSapWbsWBSElement" });

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_adendum_TrnSapWbsId_TrnSapWbsWBSElement",
                table: "trn_project_adendum",
                columns: new[] { "TrnSapWbsId", "TrnSapWbsWBSElement" });

            migrationBuilder.CreateIndex(
                name: "IX_trn_sap_wbs_TrnProjectId_TrnProjectProjectDef",
                table: "trn_sap_wbs",
                columns: new[] { "TrnProjectId", "TrnProjectProjectDef" });

            migrationBuilder.AddForeignKey(
                name: "FK_trn_project_adendum_trn_sap_wbs_TrnSapWbsId_TrnSapWbsWBSEle~",
                table: "trn_project_adendum",
                columns: new[] { "TrnSapWbsId", "TrnSapWbsWBSElement" },
                principalTable: "trn_sap_wbs",
                principalColumns: new[] { "id", "wbs_element" });

            migrationBuilder.AddForeignKey(
                name: "FK_trn_project_report_dtl_trn_sap_wbs_TrnSapWbsId_TrnSapWbsWBS~",
                table: "trn_project_report_dtl",
                columns: new[] { "TrnSapWbsId", "TrnSapWbsWBSElement" },
                principalTable: "trn_sap_wbs",
                principalColumns: new[] { "id", "wbs_element" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trn_project_adendum_trn_sap_wbs_TrnSapWbsId_TrnSapWbsWBSEle~",
                table: "trn_project_adendum");

            migrationBuilder.DropForeignKey(
                name: "FK_trn_project_report_dtl_trn_sap_wbs_TrnSapWbsId_TrnSapWbsWBS~",
                table: "trn_project_report_dtl");

            migrationBuilder.DropTable(
                name: "trn_sap_hrd");

            migrationBuilder.DropTable(
                name: "trn_sap_wbs");

            migrationBuilder.DropIndex(
                name: "IX_trn_project_report_dtl_TrnSapWbsId_TrnSapWbsWBSElement",
                table: "trn_project_report_dtl");

            migrationBuilder.DropIndex(
                name: "IX_trn_project_adendum_TrnSapWbsId_TrnSapWbsWBSElement",
                table: "trn_project_adendum");

            migrationBuilder.DropColumn(
                name: "TrnSapWbsId",
                table: "trn_project_report_dtl");

            migrationBuilder.DropColumn(
                name: "TrnSapWbsWBSElement",
                table: "trn_project_report_dtl");

            migrationBuilder.DropColumn(
                name: "TrnSapWbsId",
                table: "trn_project_adendum");

            migrationBuilder.DropColumn(
                name: "TrnSapWbsWBSElement",
                table: "trn_project_adendum");
        }
    }
}

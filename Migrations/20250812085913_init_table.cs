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
                name: "mst_employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nipp = table.Column<string>(type: "varchar(15)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    grade = table.Column<string>(type: "varchar(5)", nullable: false),
                    plans = table.Column<string>(type: "varchar(50)", nullable: false),
                    orgeh = table.Column<string>(type: "varchar(100)", nullable: false),
                    persa = table.Column<string>(type: "varchar(100)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_employee", x => new { x.id, x.nipp });
                    table.UniqueConstraint("AK_mst_employee_nipp", x => x.nipp);
                });

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
                name: "mst_role_project",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(type: "varchar(50)", nullable: false),
                    role_type = table.Column<string>(type: "varchar(20)", nullable: false),
                    role_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_role_project", x => new { x.id, x.role_id });
                    table.UniqueConstraint("AK_mst_role_project_role_id", x => x.role_id);
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
                    user_add = table.Column<string>(type: "varchar(100)", nullable: false),
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
                    project_def = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_desc = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_profile = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_responsible = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_owner = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_location = table.Column<string>(type: "varchar(50)", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fiscal_year = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    no_spmk = table.Column<string>(type: "varchar(50)", nullable: false),
                    no_contract = table.Column<string>(type: "varchar(50)", nullable: false),
                    start_date_spmk = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    payment_method = table.Column<string>(type: "varchar(50)", nullable: false),
                    contract_value = table.Column<string>(type: "varchar(50)", nullable: false),
                    bank = table.Column<string>(type: "varchar(10)", nullable: false),
                    account_number = table.Column<string>(type: "varchar(50)", nullable: false),
                    account_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    working_method = table.Column<string>(type: "varchar(50)", nullable: false),
                    pph = table.Column<string>(type: "varchar(50)", nullable: false),
                    plan_persentage = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    actual_persentage = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    progress_report = table.Column<string>(type: "varchar(100)", nullable: false),
                    company_code = table.Column<string>(type: "varchar(50)", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_project", x => new { x.id, x.project_def });
                    table.UniqueConstraint("AK_trn_project_project_def", x => x.project_def);
                    table.ForeignKey(
                        name: "FK_trn_project_mst_project_manager_project_responsible",
                        column: x => x.project_responsible,
                        principalTable: "mst_project_manager",
                        principalColumn: "nipp",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trn_project_mst_unit_project_project_profile",
                        column: x => x.project_profile,
                        principalTable: "mst_unit_project",
                        principalColumn: "unit_project",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trn_project_report",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    week_no = table.Column<string>(type: "text", nullable: false),
                    project_def = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_report = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    plan_persentage = table.Column<double>(type: "double precision", nullable: false),
                    actual_persentage = table.Column<double>(type: "double precision", nullable: false),
                    deviation = table.Column<string>(type: "varchar(20)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_project_report", x => new { x.id, x.week_no });
                    table.UniqueConstraint("AK_trn_project_report_week_no", x => x.week_no);
                    table.ForeignKey(
                        name: "FK_trn_project_report_trn_project_project_def",
                        column: x => x.project_def,
                        principalTable: "trn_project",
                        principalColumn: "project_def",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trn_project_so",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    project_def = table.Column<string>(type: "varchar(50)", nullable: false),
                    role_id = table.Column<string>(type: "varchar(50)", nullable: false),
                    nipp = table.Column<string>(type: "varchar(15)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    finish_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_project_so", x => x.id);
                    table.ForeignKey(
                        name: "FK_trn_project_so_mst_employee_nipp",
                        column: x => x.nipp,
                        principalTable: "mst_employee",
                        principalColumn: "nipp",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trn_project_so_mst_role_project_role_id",
                        column: x => x.role_id,
                        principalTable: "mst_role_project",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trn_project_so_trn_project_project_def",
                        column: x => x.project_def,
                        principalTable: "trn_project",
                        principalColumn: "project_def",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trn_project_timeline",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    wbs_element = table.Column<string>(type: "varchar(50)", nullable: false),
                    wbs_level = table.Column<string>(type: "varchar(50)", nullable: false),
                    wbs_desc = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_def = table.Column<string>(type: "varchar(50)", nullable: false),
                    responsible = table.Column<string>(type: "varchar(100)", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_project_timeline", x => new { x.id, x.wbs_element });
                    table.UniqueConstraint("AK_trn_project_timeline_wbs_element", x => x.wbs_element);
                    table.ForeignKey(
                        name: "FK_trn_project_timeline_trn_project_project_def",
                        column: x => x.project_def,
                        principalTable: "trn_project",
                        principalColumn: "project_def",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trn_schedule_invoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    no = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_def = table.Column<string>(type: "varchar(50)", nullable: false),
                    type = table.Column<string>(type: "varchar(20)", nullable: false),
                    progress_report = table.Column<string>(type: "varchar(100)", nullable: false),
                    date_plan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_actual = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total_plan = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_schedule_invoice", x => new { x.id, x.no });
                    table.ForeignKey(
                        name: "FK_trn_schedule_invoice_trn_project_project_def",
                        column: x => x.project_def,
                        principalTable: "trn_project",
                        principalColumn: "project_def",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trn_project_adendum",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adendum_no = table.Column<string>(type: "varchar(50)", nullable: true),
                    type_adendum = table.Column<string>(type: "varchar(50)", nullable: false),
                    project_def = table.Column<string>(type: "varchar(50)", nullable: false),
                    wbs_element = table.Column<string>(type: "varchar(50)", nullable: false),
                    cost_before = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    cost_after = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    date_before = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_after = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    reason = table.Column<string>(type: "varchar(255)", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_project_adendum", x => x.id);
                    table.ForeignKey(
                        name: "FK_trn_project_adendum_trn_project_project_def",
                        column: x => x.project_def,
                        principalTable: "trn_project",
                        principalColumn: "project_def",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trn_project_adendum_trn_project_timeline_wbs_element",
                        column: x => x.wbs_element,
                        principalTable: "trn_project_timeline",
                        principalColumn: "wbs_element",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trn_project_report_dtl",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    no_sr = table.Column<string>(type: "text", nullable: false),
                    week_no = table.Column<string>(type: "text", nullable: false),
                    project_def = table.Column<string>(type: "varchar(50)", nullable: false),
                    wbs_element = table.Column<string>(type: "varchar(50)", nullable: false),
                    plan_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    actual_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    plan_persentage = table.Column<double>(type: "double precision", nullable: false),
                    actual_persentage = table.Column<double>(type: "double precision", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_project_report_dtl", x => new { x.id, x.no_sr });
                    table.UniqueConstraint("AK_trn_project_report_dtl_no_sr", x => x.no_sr);
                    table.ForeignKey(
                        name: "FK_trn_project_report_dtl_trn_project_project_def",
                        column: x => x.project_def,
                        principalTable: "trn_project",
                        principalColumn: "project_def",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trn_project_report_dtl_trn_project_report_week_no",
                        column: x => x.week_no,
                        principalTable: "trn_project_report",
                        principalColumn: "week_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trn_project_report_dtl_trn_project_timeline_wbs_element",
                        column: x => x.wbs_element,
                        principalTable: "trn_project_timeline",
                        principalColumn: "wbs_element",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trn_project_issue",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    no_issue = table.Column<string>(type: "text", nullable: false),
                    project_def = table.Column<string>(type: "varchar(50)", nullable: false),
                    week_no = table.Column<string>(type: "varchar(50)", nullable: false),
                    no_sr = table.Column<string>(type: "varchar(50)", nullable: false),
                    wbs_element = table.Column<string>(type: "varchar(50)", nullable: false),
                    problem = table.Column<string>(type: "varchar(255)", nullable: false),
                    action_plan = table.Column<string>(type: "varchar(255)", nullable: false),
                    action_problem = table.Column<string>(type: "varchar(255)", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    active = table.Column<string>(type: "varchar(1)", nullable: false),
                    user_add = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_update = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_project_issue", x => new { x.id, x.no_issue });
                    table.ForeignKey(
                        name: "FK_trn_project_issue_trn_project_project_def",
                        column: x => x.project_def,
                        principalTable: "trn_project",
                        principalColumn: "project_def",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trn_project_issue_trn_project_report_dtl_no_sr",
                        column: x => x.no_sr,
                        principalTable: "trn_project_report_dtl",
                        principalColumn: "no_sr",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trn_project_issue_trn_project_report_week_no",
                        column: x => x.week_no,
                        principalTable: "trn_project_report",
                        principalColumn: "week_no",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_project_profile",
                table: "trn_project",
                column: "project_profile");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_project_responsible",
                table: "trn_project",
                column: "project_responsible",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_adendum_project_def",
                table: "trn_project_adendum",
                column: "project_def");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_adendum_wbs_element",
                table: "trn_project_adendum",
                column: "wbs_element");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_issue_no_sr",
                table: "trn_project_issue",
                column: "no_sr");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_issue_project_def",
                table: "trn_project_issue",
                column: "project_def");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_issue_week_no",
                table: "trn_project_issue",
                column: "week_no");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_report_project_def",
                table: "trn_project_report",
                column: "project_def");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_report_dtl_project_def",
                table: "trn_project_report_dtl",
                column: "project_def");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_report_dtl_wbs_element",
                table: "trn_project_report_dtl",
                column: "wbs_element");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_report_dtl_week_no",
                table: "trn_project_report_dtl",
                column: "week_no");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_so_nipp",
                table: "trn_project_so",
                column: "nipp",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_so_project_def",
                table: "trn_project_so",
                column: "project_def");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_so_role_id",
                table: "trn_project_so",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_trn_project_timeline_project_def",
                table: "trn_project_timeline",
                column: "project_def");

            migrationBuilder.CreateIndex(
                name: "IX_trn_schedule_invoice_project_def",
                table: "trn_schedule_invoice",
                column: "project_def");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trn_project_adendum");

            migrationBuilder.DropTable(
                name: "trn_project_issue");

            migrationBuilder.DropTable(
                name: "trn_project_so");

            migrationBuilder.DropTable(
                name: "trn_schedule_invoice");

            migrationBuilder.DropTable(
                name: "trn_project_report_dtl");

            migrationBuilder.DropTable(
                name: "mst_employee");

            migrationBuilder.DropTable(
                name: "mst_role_project");

            migrationBuilder.DropTable(
                name: "trn_project_report");

            migrationBuilder.DropTable(
                name: "trn_project_timeline");

            migrationBuilder.DropTable(
                name: "trn_project");

            migrationBuilder.DropTable(
                name: "mst_project_manager");

            migrationBuilder.DropTable(
                name: "mst_unit_project");
        }
    }
}

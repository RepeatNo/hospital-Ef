using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class WardsHasEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WARDS",
                columns: table => new
                {
                    WARD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CARRYING_CAPACITY = table.Column<int>(type: "INT", nullable: false),
                    LeaderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WARDS", x => x.WARD_ID);
                    table.ForeignKey(
                        name: "FK_WARDS_PHYSICIANS_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "PHYSICIANS",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WARDS_HAS_EMPLOYEES",
                columns: table => new
                {
                    WARD_ID = table.Column<int>(type: "int", nullable: false),
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false),
                    WORKING_HOURS = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WARDS_HAS_EMPLOYEES", x => new { x.EMPLOYEE_ID, x.WARD_ID });
                    table.ForeignKey(
                        name: "FK_WARDS_HAS_EMPLOYEES_EMPLOYEES_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WARDS_HAS_EMPLOYEES_WARDS_WARD_ID",
                        column: x => x.WARD_ID,
                        principalTable: "WARDS",
                        principalColumn: "WARD_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WARDS_LeaderId",
                table: "WARDS",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_WARDS_HAS_EMPLOYEES_WARD_ID",
                table: "WARDS_HAS_EMPLOYEES",
                column: "WARD_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WARDS_HAS_EMPLOYEES");

            migrationBuilder.DropTable(
                name: "WARDS");
        }
    }
}

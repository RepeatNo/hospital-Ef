using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SVNR = table.Column<int>(type: "INT", nullable: false),
                    FIRST_NAME = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    LAST_NAME = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    SALARY = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.EMPLOYEE_ID);
                });

            migrationBuilder.CreateTable(
                name: "HOSPITAL_FACILITIES",
                columns: table => new
                {
                    FACILITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PHONE_NR = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOSPITAL_FACILITIES", x => x.FACILITY_ID);
                });

            migrationBuilder.CreateTable(
                name: "CARE_TAKERS",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SUPERVISOR = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARE_TAKERS", x => x.EMPLOYEE_ID);
                    table.ForeignKey(
                        name: "FK_CARE_TAKERS_CARE_TAKERS_SUPERVISOR",
                        column: x => x.SUPERVISOR,
                        principalTable: "CARE_TAKERS",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CARE_TAKERS_EMPLOYEES_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PHYSICIANS",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JOB_SPECIALISATION = table.Column<string>(type: "VARCHAR(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHYSICIANS", x => x.EMPLOYEE_ID);
                    table.ForeignKey(
                        name: "FK_PHYSICIANS_EMPLOYEES_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CARE_TAKERS_SUPERVISOR",
                table: "CARE_TAKERS",
                column: "SUPERVISOR");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_SVNR",
                table: "EMPLOYEES",
                column: "SVNR",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HOSPITAL_FACILITIES_NAME",
                table: "HOSPITAL_FACILITIES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HOSPITAL_FACILITIES_PHONE_NR",
                table: "HOSPITAL_FACILITIES",
                column: "PHONE_NR",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARE_TAKERS");

            migrationBuilder.DropTable(
                name: "HOSPITAL_FACILITIES");

            migrationBuilder.DropTable(
                name: "PHYSICIANS");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");
        }
    }
}

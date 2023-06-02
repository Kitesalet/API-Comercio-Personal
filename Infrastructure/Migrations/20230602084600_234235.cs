using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _234235 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTeam");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressGet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobGet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeGet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    TeamGetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeGet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeGet_AddressGet_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressGet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeGet_JobGet_JobId",
                        column: x => x.JobId,
                        principalTable: "JobGet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeGet_Teams_TeamGetId",
                        column: x => x.TeamGetId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_EmployeeId",
                table: "Teams",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeGet_AddressId",
                table: "EmployeeGet",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeGet_JobId",
                table: "EmployeeGet",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeGet_TeamGetId",
                table: "EmployeeGet",
                column: "TeamGetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Employees_EmployeeId",
                table: "Teams",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Employees_EmployeeId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "EmployeeGet");

            migrationBuilder.DropTable(
                name: "AddressGet");

            migrationBuilder.DropTable(
                name: "JobGet");

            migrationBuilder.DropIndex(
                name: "IX_Teams_EmployeeId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Teams");

            migrationBuilder.CreateTable(
                name: "EmployeeTeam",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTeam", x => new { x.EmployeesId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_EmployeeTeam_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTeam_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTeam_TeamsId",
                table: "EmployeeTeam",
                column: "TeamsId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _342 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeGet_Teams_TeamGetId",
                table: "EmployeeGet");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Employees_EmployeeId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_EmployeeId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamGet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamGet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamGet_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamId",
                table: "Employees",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGet_EmployeeId",
                table: "TeamGet",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeGet_TeamGet_TeamGetId",
                table: "EmployeeGet",
                column: "TeamGetId",
                principalTable: "TeamGet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Teams_TeamId",
                table: "Employees",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeGet_TeamGet_TeamGetId",
                table: "EmployeeGet");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Teams_TeamId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "TeamGet");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TeamId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_EmployeeId",
                table: "Teams",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeGet_Teams_TeamGetId",
                table: "EmployeeGet",
                column: "TeamGetId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Employees_EmployeeId",
                table: "Teams",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}

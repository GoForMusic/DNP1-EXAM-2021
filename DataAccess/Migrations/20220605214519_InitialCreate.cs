using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamName = table.Column<string>(type: "TEXT", nullable: false),
                    NameOfCoach = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Ranking = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamName);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ShirtNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Salary = table.Column<decimal>(type: "TEXT", nullable: false),
                    GoalsThisSeason = table.Column<int>(type: "INTEGER", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false),
                    TeamName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamName",
                        column: x => x.TeamName,
                        principalTable: "Teams",
                        principalColumn: "TeamName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamName",
                table: "Players",
                column: "TeamName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}

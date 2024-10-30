using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolioProject.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_statistic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    StatisticID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Project = table.Column<int>(type: "int", nullable: false),
                    CompletedProject = table.Column<int>(type: "int", nullable: false),
                    OngoingCourse = table.Column<int>(type: "int", nullable: false),
                    Certificate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}

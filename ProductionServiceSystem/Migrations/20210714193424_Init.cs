using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductionServiceSystem.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportCost = table.Column<double>(type: "float", nullable: false),
                    CostOfWorkingHour = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ModuleName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleName4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchHistory_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AssemblyTime = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<double>(type: "float", nullable: false),
                    SearchHistoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Module_SearchHistory_SearchHistoryId",
                        column: x => x.SearchHistoryId,
                        principalTable: "SearchHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Module_SearchHistoryId",
                table: "Module",
                column: "SearchHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistory_CityId",
                table: "SearchHistory",
                column: "CityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "SearchHistory");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}

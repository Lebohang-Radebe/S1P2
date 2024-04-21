using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S1P2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chickens",
                columns: table => new
                {
                    RFID = table.Column<string>(type: "TEXT", nullable: false),
                    FeatherColor = table.Column<string>(type: "TEXT", nullable: false),
                    EggsLaidPerDay = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chickens", x => x.RFID);
                });

            migrationBuilder.CreateTable(
                name: "Cows",
                columns: table => new
                {
                    RFID = table.Column<string>(type: "TEXT", nullable: false),
                    MilkProductionLitre = table.Column<decimal>(type: "TEXT", nullable: false),
                    BreedType = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cows", x => x.RFID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chickens");

            migrationBuilder.DropTable(
                name: "Cows");
        }
    }
}

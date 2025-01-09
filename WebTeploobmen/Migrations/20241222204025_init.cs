using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTeploobmen.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    height = table.Column<double>(type: "REAL", nullable: false),
                    mattemp = table.Column<double>(type: "REAL", nullable: false),
                    gaztemp = table.Column<double>(type: "REAL", nullable: false),
                    haste = table.Column<double>(type: "REAL", nullable: false),
                    gaztepl = table.Column<double>(type: "REAL", nullable: false),
                    rashod = table.Column<double>(type: "REAL", nullable: false),
                    mattepl = table.Column<double>(type: "REAL", nullable: false),
                    koef = table.Column<double>(type: "REAL", nullable: false),
                    diametr = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variants");
        }
    }
}

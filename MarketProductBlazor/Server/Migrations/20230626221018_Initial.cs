using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketProductBlazor.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketProducts_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Sim" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Não" });

            migrationBuilder.InsertData(
                table: "MarketProducts",
                columns: new[] { "Id", "Description", "Name", "OfferId" },
                values: new object[] { 1, "Fruta", "Maçã", 1 });

            migrationBuilder.InsertData(
                table: "MarketProducts",
                columns: new[] { "Id", "Description", "Name", "OfferId" },
                values: new object[] { 2, "Legume", "Batata", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_MarketProducts_OfferId",
                table: "MarketProducts",
                column: "OfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketProducts");

            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}

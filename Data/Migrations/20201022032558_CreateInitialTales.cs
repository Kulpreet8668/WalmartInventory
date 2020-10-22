using Microsoft.EntityFrameworkCore.Migrations;

namespace WalmartInventory.Data.Migrations
{
    public partial class CreateInitialTales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counts",
                columns: table => new
                {
                    CountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerId = table.Column<int>(nullable: false),
                    userNumber = table.Column<int>(nullable: false),
                    departName = table.Column<int>(nullable: false),
                    countTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counts", x => x.CountId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShelfName = table.Column<int>(nullable: false),
                    RetailPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "countInformations",
                columns: table => new
                {
                    CountInformationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    CountId = table.Column<int>(nullable: false),
                    Onhand = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countInformations", x => x.CountInformationId);
                    table.ForeignKey(
                        name: "FK_CountInformations_CountId",
                        column: x => x.CountId,
                        principalTable: "Counts",
                        principalColumn: "CountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountInformations_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_countInformations_CountId",
                table: "countInformations",
                column: "CountId");

            migrationBuilder.CreateIndex(
                name: "IX_countInformations_ProductId",
                table: "countInformations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_products_DepartmentId",
                table: "products",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "countInformations");

            migrationBuilder.DropTable(
                name: "Counts");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

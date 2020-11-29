using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalmartInventory.Data.Migrations
{
    public partial class createCartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Counts_DepartmentId",
            //    table: "Counts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            //migrationBuilder.DropIndex(
            //    name: "IX_Counts_DepartmentId",
            //    table: "Counts");

            //migrationBuilder.DropColumn(
            //    name: "DepartmentId",
            //    table: "Counts");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_products_DepartmentId",
                table: "Products",
                newName: "IX_Products_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    DateSelected = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_Products_DepartmentId",
                table: "products",
                newName: "IX_products_DepartmentId");

            //migrationBuilder.AddColumn<int>(
            //    name: "DepartmentId",
            //    table: "Counts",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Counts_DepartmentId",
            //    table: "Counts",
            //    column: "DepartmentId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Counts_DepartmentId",
            //    table: "Counts",
            //    column: "DepartmentId",
            //    principalTable: "Departments",
            //    principalColumn: "DepartmentId",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}

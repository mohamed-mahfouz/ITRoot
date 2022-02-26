using Microsoft.EntityFrameworkCore.Migrations;

namespace ITRoot.Migrations
{
    public partial class AddInvoiceProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceProduct_Invoices_InvoicesId",
                table: "InvoiceProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceProduct_Products_ProductsId",
                table: "InvoiceProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "InvoiceProduct",
                newName: "InvoiceId");

            migrationBuilder.RenameColumn(
                name: "InvoicesId",
                table: "InvoiceProduct",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceProduct_ProductsId",
                table: "InvoiceProduct",
                newName: "IX_InvoiceProduct_InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceProduct_Invoices_InvoiceId",
                table: "InvoiceProduct",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceProduct_Products_ProductId",
                table: "InvoiceProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceProduct_Invoices_InvoiceId",
                table: "InvoiceProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceProduct_Products_ProductId",
                table: "InvoiceProduct");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "InvoiceProduct",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "InvoiceProduct",
                newName: "InvoicesId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceProduct_InvoiceId",
                table: "InvoiceProduct",
                newName: "IX_InvoiceProduct_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceProduct_Invoices_InvoicesId",
                table: "InvoiceProduct",
                column: "InvoicesId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceProduct_Products_ProductsId",
                table: "InvoiceProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

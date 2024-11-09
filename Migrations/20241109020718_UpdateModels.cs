using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProduct.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_userId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_OrdersorderId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductsproductId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_userId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "birthdate",
                table: "Users",
                newName: "Birthdate");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Products",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Orders",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "idUSer",
                table: "Orders",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameColumn(
                name: "ProductsproductId",
                table: "OrderProduct",
                newName: "ProductsProductId");

            migrationBuilder.RenameColumn(
                name: "OrdersorderId",
                table: "OrderProduct",
                newName: "OrdersOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductsproductId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductsProductId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Contacts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Contacts",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Contacts",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "idUser",
                table: "Contacts",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "contactId",
                table: "Contacts",
                newName: "ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_userId",
                table: "Contacts",
                newName: "IX_Contacts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_OrdersOrderId",
                table: "OrderProduct",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductsProductId",
                table: "OrderProduct",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_OrdersOrderId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductsProductId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Users",
                newName: "birthdate");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Products",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Orders",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Orders",
                newName: "idUSer");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "orderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_userId");

            migrationBuilder.RenameColumn(
                name: "ProductsProductId",
                table: "OrderProduct",
                newName: "ProductsproductId");

            migrationBuilder.RenameColumn(
                name: "OrdersOrderId",
                table: "OrderProduct",
                newName: "OrdersorderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductsProductId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductsproductId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Contacts",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Contacts",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Contacts",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Contacts",
                newName: "idUser");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Contacts",
                newName: "contactId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                newName: "IX_Contacts_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_userId",
                table: "Contacts",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_OrdersorderId",
                table: "OrderProduct",
                column: "OrdersorderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductsproductId",
                table: "OrderProduct",
                column: "ProductsproductId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_userId",
                table: "Orders",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");
        }
    }
}

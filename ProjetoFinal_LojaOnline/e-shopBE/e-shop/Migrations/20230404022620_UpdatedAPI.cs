using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_shop.Migrations
{
    public partial class UpdatedAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersHistory");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Category");

            migrationBuilder.CreateTable(
                name: "OrdersHistory",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DateOfDelivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersHistory", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrdersHistory_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}

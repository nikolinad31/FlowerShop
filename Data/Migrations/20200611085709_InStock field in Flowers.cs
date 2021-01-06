using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.Data.Migrations
{
    public partial class InStockfieldinFlowers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InStock",
                table: "Flower",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Flower_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_FlowerId",
                table: "ShoppingCartItems",
                column: "FlowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Flower");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.Data.Migrations
{
    public partial class addfavoriteflower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavoriteFlower",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteFlower",
                table: "AspNetUsers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace GameOnlineShop.Migrations
{
    public partial class AddedUserIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechReq",
                table: "DbGame");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TechReq",
                table: "DbGame",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

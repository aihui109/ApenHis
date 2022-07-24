using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApenHis.Migrations
{
    public partial class identityUser_extend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InputCode",
                table: "AbpUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "输入码");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputCode",
                table: "AbpUsers");
        }
    }
}

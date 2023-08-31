using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApenHis.Migrations
{
    /// <inheritdoc />
    public partial class userext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InputCode",
                table: "AbpUsers",
                type: "nvarchar(16)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "输入码");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AbpUsers",
                type: "datetime2",
                nullable: true,
                comment: "生日");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "AbpUsers",
                type: "uniqueidentifier",
                nullable: true,
                comment: "部门");

            migrationBuilder.AddColumn<string>(
                name: "IDCard",
                table: "AbpUsers",
                type: "nvarchar(18)",
                nullable: true,
                comment: "身份证号码");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AbpUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nation",
                table: "AbpUsers",
                type: "nvarchar(20)",
                nullable: true,
                comment: "民族");

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "AbpUsers",
                type: "nvarchar(20)",
                nullable: true,
                comment: "性别");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AbpUsers",
                type: "nvarchar(50)",
                nullable: true,
                comment: "职称");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IDCard",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Nation",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AbpUsers");

            migrationBuilder.AlterColumn<string>(
                name: "InputCode",
                table: "AbpUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "输入码",
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldNullable: true);
        }
    }
}

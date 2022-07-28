using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApenHis.Migrations
{
    public partial class add_feature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsMenu = table.Column<bool>(type: "bit", nullable: false),
                    PicUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortNo = table.Column<int>(type: "int", nullable: true),
                    IsRoot = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLog = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsMobile = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFeatures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UIDXFeatureTenantIdTitle",
                table: "Features",
                columns: new[] { "TenantId", "Title" },
                unique: true,
                filter: "[TenantId] IS NOT NULL AND [Title] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "RoleFeatures");
        }
    }
}

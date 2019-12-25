using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HT.P1.Jwt_Swagger.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    HostName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Shape = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    BuyTime = table.Column<DateTime>(nullable: true),
                    HomeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desk_Home_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Home",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Home",
                columns: new[] { "Id", "Address", "Age", "CreateTime", "HostName", "Lat", "Lng" },
                values: new object[] { 1, "武汉市东湖高新区", 3, new DateTime(2019, 12, 24, 15, 40, 0, 999, DateTimeKind.Local).AddTicks(2940), "华天晓", 123.12, 31.234556000000001 });

            migrationBuilder.InsertData(
                table: "Desk",
                columns: new[] { "Id", "BuyTime", "Cost", "CreateTime", "HomeId", "Shape" },
                values: new object[] { 1, new DateTime(2016, 9, 7, 15, 40, 1, 6, DateTimeKind.Local).AddTicks(6531), 600.0, new DateTime(2019, 12, 24, 15, 40, 1, 5, DateTimeKind.Local).AddTicks(5938), 1, 1 });

            migrationBuilder.InsertData(
                table: "Desk",
                columns: new[] { "Id", "BuyTime", "Cost", "CreateTime", "HomeId", "Shape" },
                values: new object[] { 2, new DateTime(2018, 3, 17, 15, 40, 1, 7, DateTimeKind.Local).AddTicks(495), 123.5, new DateTime(2019, 12, 24, 15, 40, 1, 7, DateTimeKind.Local).AddTicks(347), 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Desk_HomeId",
                table: "Desk",
                column: "HomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desk");

            migrationBuilder.DropTable(
                name: "Home");
        }
    }
}

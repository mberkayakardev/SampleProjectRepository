using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AkarDataAccess.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublicOrPrivate = table.Column<bool>(type: "bit", nullable: false),
                    MaxUserCount = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GecerliFlg = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GecerliFlg = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    MembersListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.GroupsId, x.MembersListId });
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Users_MembersListId",
                        column: x => x.MembersListId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OneTimeUsableToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    GruoupId = table.Column<int>(type: "int", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GecerliFlg = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_Groups_GruoupId",
                        column: x => x.GruoupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "CreateUser", "GecerliFlg", "ModDate", "ModUser", "Password", "UserName", "UserPhoto" },
                values: new object[] { 1, new DateTime(2023, 4, 23, 1, 28, 31, 116, DateTimeKind.Local).AddTicks(3389), "BERKAY AKAR", true, new DateTime(2023, 4, 23, 1, 28, 31, 116, DateTimeKind.Local).AddTicks(5182), "BERKAY AKAR", "mberkayakar", "mberkayakar", "https://media.licdn.com/dms/image/C4D03AQH0lx3tESYC7w/profile-displayphoto-shrink_800_800/0/1607277130794?e=2147483647&v=beta&t=mWbd1TIxwSp7B_vA_RkHuJi2tvdrMqAj9EvAyIntub0" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "CreateUser", "GecerliFlg", "ModDate", "ModUser", "Password", "UserName", "UserPhoto" },
                values: new object[] { 2, new DateTime(2023, 4, 23, 1, 28, 31, 116, DateTimeKind.Local).AddTicks(6184), "BERKAY AKAR", true, new DateTime(2023, 4, 23, 1, 28, 31, 116, DateTimeKind.Local).AddTicks(6187), "BERKAY AKAR", "atelyon", "atelyon", "https://media.licdn.com/dms/image/C4D03AQH0lx3tESYC7w/profile-displayphoto-shrink_800_800/0/1607277130794?e=2147483647&v=beta&t=mWbd1TIxwSp7B_vA_RkHuJi2tvdrMqAj9EvAyIntub0" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_MembersListId",
                table: "GroupUser",
                column: "MembersListId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_GruoupId",
                table: "Tokens",
                column: "GruoupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_PersonId",
                table: "Tokens",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

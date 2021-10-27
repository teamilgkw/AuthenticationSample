using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationSample.BackEnd.Web.Migrations
{
    public partial class owner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OwnerMasters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginTypes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerMasterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginTypes", x => x.Code);
                    table.ForeignKey(
                        name: "FK_LoginTypes_OwnerMasters_OwnerMasterId",
                        column: x => x.OwnerMasterId,
                        principalTable: "OwnerMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OwnerLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerMasterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LoginTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerLogins_LoginTypes_LoginTypeCode",
                        column: x => x.LoginTypeCode,
                        principalTable: "LoginTypes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OwnerLogins_OwnerMasters_OwnerMasterId",
                        column: x => x.OwnerMasterId,
                        principalTable: "OwnerMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginTypes_OwnerMasterId",
                table: "LoginTypes",
                column: "OwnerMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLogins_LoginTypeCode",
                table: "OwnerLogins",
                column: "LoginTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLogins_OwnerMasterId",
                table: "OwnerLogins",
                column: "OwnerMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnerLogins");

            migrationBuilder.DropTable(
                name: "LoginTypes");

            migrationBuilder.DropTable(
                name: "OwnerMasters");
        }
    }
}

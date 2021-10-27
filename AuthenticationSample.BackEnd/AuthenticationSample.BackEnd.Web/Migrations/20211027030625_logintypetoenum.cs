using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationSample.BackEnd.Web.Migrations
{
    public partial class logintypetoenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnerLogin_LoginType_LoginTypeCode",
                table: "OwnerLogin");

            migrationBuilder.DropTable(
                name: "LoginType");

            migrationBuilder.DropIndex(
                name: "IX_OwnerLogin_LoginTypeCode",
                table: "OwnerLogin");

            migrationBuilder.DropColumn(
                name: "LoginTypeCode",
                table: "OwnerLogin");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "OwnerMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginType",
                table: "OwnerLogin",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginType",
                table: "OwnerLogin");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "OwnerMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LoginTypeCode",
                table: "OwnerLogin",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoginType",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginType", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLogin_LoginTypeCode",
                table: "OwnerLogin",
                column: "LoginTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerLogin_LoginType_LoginTypeCode",
                table: "OwnerLogin",
                column: "LoginTypeCode",
                principalTable: "LoginType",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

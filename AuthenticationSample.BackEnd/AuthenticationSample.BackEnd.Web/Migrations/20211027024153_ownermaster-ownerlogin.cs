using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationSample.BackEnd.Web.Migrations
{
    public partial class ownermasterownerlogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginType_OwnerMaster_OwnerMasterID",
                table: "LoginType");

            migrationBuilder.DropIndex(
                name: "IX_LoginType_OwnerMasterID",
                table: "LoginType");

            migrationBuilder.DropColumn(
                name: "OwnerMasterID",
                table: "LoginType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerMasterID",
                table: "LoginType",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoginType_OwnerMasterID",
                table: "LoginType",
                column: "OwnerMasterID");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginType_OwnerMaster_OwnerMasterID",
                table: "LoginType",
                column: "OwnerMasterID",
                principalTable: "OwnerMaster",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationSample.BackEnd.Web.Migrations
{
    public partial class idnaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginType_OwnerMaster_OwnerMasterId",
                table: "LoginType");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerLogin_OwnerMaster_OwnerMasterId",
                table: "OwnerLogin");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OwnerMaster",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "OwnerMasterId",
                table: "OwnerLogin",
                newName: "OwnerMasterID");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerLogin_OwnerMasterId",
                table: "OwnerLogin",
                newName: "IX_OwnerLogin_OwnerMasterID");

            migrationBuilder.RenameColumn(
                name: "OwnerMasterId",
                table: "LoginType",
                newName: "OwnerMasterID");

            migrationBuilder.RenameIndex(
                name: "IX_LoginType_OwnerMasterId",
                table: "LoginType",
                newName: "IX_LoginType_OwnerMasterID");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginType_OwnerMaster_OwnerMasterID",
                table: "LoginType",
                column: "OwnerMasterID",
                principalTable: "OwnerMaster",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerLogin_OwnerMaster_OwnerMasterID",
                table: "OwnerLogin",
                column: "OwnerMasterID",
                principalTable: "OwnerMaster",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginType_OwnerMaster_OwnerMasterID",
                table: "LoginType");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerLogin_OwnerMaster_OwnerMasterID",
                table: "OwnerLogin");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "OwnerMaster",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OwnerMasterID",
                table: "OwnerLogin",
                newName: "OwnerMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerLogin_OwnerMasterID",
                table: "OwnerLogin",
                newName: "IX_OwnerLogin_OwnerMasterId");

            migrationBuilder.RenameColumn(
                name: "OwnerMasterID",
                table: "LoginType",
                newName: "OwnerMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginType_OwnerMasterID",
                table: "LoginType",
                newName: "IX_LoginType_OwnerMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginType_OwnerMaster_OwnerMasterId",
                table: "LoginType",
                column: "OwnerMasterId",
                principalTable: "OwnerMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerLogin_OwnerMaster_OwnerMasterId",
                table: "OwnerLogin",
                column: "OwnerMasterId",
                principalTable: "OwnerMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

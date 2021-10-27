using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationSample.BackEnd.Web.Migrations
{
    public partial class naming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginTypes_OwnerMasters_OwnerMasterId",
                table: "LoginTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerLogins_LoginTypes_LoginTypeCode",
                table: "OwnerLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerLogins_OwnerMasters_OwnerMasterId",
                table: "OwnerLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerMasters",
                table: "OwnerMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerLogins",
                table: "OwnerLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginTypes",
                table: "LoginTypes");

            migrationBuilder.RenameTable(
                name: "OwnerMasters",
                newName: "OwnerMaster");

            migrationBuilder.RenameTable(
                name: "OwnerLogins",
                newName: "OwnerLogin");

            migrationBuilder.RenameTable(
                name: "LoginTypes",
                newName: "LoginType");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OwnerLogin",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerLogins_OwnerMasterId",
                table: "OwnerLogin",
                newName: "IX_OwnerLogin_OwnerMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerLogins_LoginTypeCode",
                table: "OwnerLogin",
                newName: "IX_OwnerLogin_LoginTypeCode");

            migrationBuilder.RenameIndex(
                name: "IX_LoginTypes_OwnerMasterId",
                table: "LoginType",
                newName: "IX_LoginType_OwnerMasterId");

            migrationBuilder.AddColumn<string>(
                name: "EmailOrMobileNumber",
                table: "OwnerLogin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerMaster",
                table: "OwnerMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerLogin",
                table: "OwnerLogin",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginType",
                table: "LoginType",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginType_OwnerMaster_OwnerMasterId",
                table: "LoginType",
                column: "OwnerMasterId",
                principalTable: "OwnerMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerLogin_LoginType_LoginTypeCode",
                table: "OwnerLogin",
                column: "LoginTypeCode",
                principalTable: "LoginType",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerLogin_OwnerMaster_OwnerMasterId",
                table: "OwnerLogin",
                column: "OwnerMasterId",
                principalTable: "OwnerMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginType_OwnerMaster_OwnerMasterId",
                table: "LoginType");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerLogin_LoginType_LoginTypeCode",
                table: "OwnerLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerLogin_OwnerMaster_OwnerMasterId",
                table: "OwnerLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerMaster",
                table: "OwnerMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerLogin",
                table: "OwnerLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginType",
                table: "LoginType");

            migrationBuilder.DropColumn(
                name: "EmailOrMobileNumber",
                table: "OwnerLogin");

            migrationBuilder.RenameTable(
                name: "OwnerMaster",
                newName: "OwnerMasters");

            migrationBuilder.RenameTable(
                name: "OwnerLogin",
                newName: "OwnerLogins");

            migrationBuilder.RenameTable(
                name: "LoginType",
                newName: "LoginTypes");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "OwnerLogins",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerLogin_OwnerMasterId",
                table: "OwnerLogins",
                newName: "IX_OwnerLogins_OwnerMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerLogin_LoginTypeCode",
                table: "OwnerLogins",
                newName: "IX_OwnerLogins_LoginTypeCode");

            migrationBuilder.RenameIndex(
                name: "IX_LoginType_OwnerMasterId",
                table: "LoginTypes",
                newName: "IX_LoginTypes_OwnerMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerMasters",
                table: "OwnerMasters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerLogins",
                table: "OwnerLogins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginTypes",
                table: "LoginTypes",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginTypes_OwnerMasters_OwnerMasterId",
                table: "LoginTypes",
                column: "OwnerMasterId",
                principalTable: "OwnerMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerLogins_LoginTypes_LoginTypeCode",
                table: "OwnerLogins",
                column: "LoginTypeCode",
                principalTable: "LoginTypes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerLogins_OwnerMasters_OwnerMasterId",
                table: "OwnerLogins",
                column: "OwnerMasterId",
                principalTable: "OwnerMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

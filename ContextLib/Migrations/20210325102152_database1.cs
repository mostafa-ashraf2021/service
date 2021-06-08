using Microsoft.EntityFrameworkCore.Migrations;

namespace ContextLib.Migrations
{
    public partial class database1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserServiceName",
                table: "UserServices");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "UserServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserServices_ServiceId",
                table: "UserServices",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserServices_Services_ServiceId",
                table: "UserServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserServices_Services_ServiceId",
                table: "UserServices");

            migrationBuilder.DropIndex(
                name: "IX_UserServices_ServiceId",
                table: "UserServices");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "UserServices");

            migrationBuilder.AddColumn<string>(
                name: "UserServiceName",
                table: "UserServices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusHandler.Migrations
{
    /// <inheritdoc />
    public partial class authfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Childrens_AspNetUsers_FamilyUserId",
                table: "Childrens");

            migrationBuilder.AlterColumn<string>(
                name: "FamilyUserId",
                table: "Childrens",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Childrens_AspNetUsers_FamilyUserId",
                table: "Childrens",
                column: "FamilyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Childrens_AspNetUsers_FamilyUserId",
                table: "Childrens");

            migrationBuilder.AlterColumn<string>(
                name: "FamilyUserId",
                table: "Childrens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Childrens_AspNetUsers_FamilyUserId",
                table: "Childrens",
                column: "FamilyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

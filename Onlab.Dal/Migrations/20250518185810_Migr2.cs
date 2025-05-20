using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onlab.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Migr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Bands_BandId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Bands_BandId",
                table: "Users",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Bands_BandId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Bands_BandId",
                table: "Users",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id");
        }
    }
}

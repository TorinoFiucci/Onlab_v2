using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onlab.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Migr6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Bands_BandId",
                table: "Concerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Setlists_Bands_BandId",
                table: "Setlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Setlists_SetlistId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_SetlistId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Setlists_BandId",
                table: "Setlists");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "BandId",
                table: "Setlists");

            migrationBuilder.RenameColumn(
                name: "SetlistId",
                table: "Tasks",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Setlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Concerts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "Concerts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserIds",
                table: "Bands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Bands_BandId",
                table: "Concerts",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Bands_BandId",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Setlists");

            migrationBuilder.DropColumn(
                name: "UserIds",
                table: "Bands");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "SetlistId");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BandId",
                table: "Setlists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Concerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "Concerts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SetlistId",
                table: "Tasks",
                column: "SetlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Setlists_BandId",
                table: "Setlists",
                column: "BandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Bands_BandId",
                table: "Concerts",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Setlists_Bands_BandId",
                table: "Setlists",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Setlists_SetlistId",
                table: "Tasks",
                column: "SetlistId",
                principalTable: "Setlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

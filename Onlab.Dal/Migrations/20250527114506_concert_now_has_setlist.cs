using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onlab.Dal.Migrations
{
    /// <inheritdoc />
    public partial class concert_now_has_setlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SetlistId",
                table: "Concerts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_SetlistId",
                table: "Concerts",
                column: "SetlistId",
                unique: true,
                filter: "[SetlistId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Setlists_SetlistId",
                table: "Concerts",
                column: "SetlistId",
                principalTable: "Setlists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Setlists_SetlistId",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_SetlistId",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "SetlistId",
                table: "Concerts");
        }
    }
}

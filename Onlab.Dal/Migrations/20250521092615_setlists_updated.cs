using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onlab.Dal.Migrations
{
    /// <inheritdoc />
    public partial class setlists_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BandId",
                table: "Setlists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Setlists_BandId",
                table: "Setlists",
                column: "BandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Setlists_Bands_BandId",
                table: "Setlists",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Setlists_Bands_BandId",
                table: "Setlists");

            migrationBuilder.DropIndex(
                name: "IX_Setlists_BandId",
                table: "Setlists");

            migrationBuilder.DropColumn(
                name: "BandId",
                table: "Setlists");
        }
    }
}

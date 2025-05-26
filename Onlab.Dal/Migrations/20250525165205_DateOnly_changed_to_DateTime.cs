using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onlab.Dal.Migrations
{
    /// <inheritdoc />
    public partial class DateOnly_changed_to_DateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Tasks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DueDate",
                table: "Tasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}

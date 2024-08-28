using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sabeco_Factsheet.Migrations
{
    /// <inheritdoc />
    public partial class AddDownloadCount_FileUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DownloadCount",
                table: "tbFileUpload_Temp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DownloadCount",
                table: "tbFileUpload",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownloadCount",
                table: "tbFileUpload_Temp");

            migrationBuilder.DropColumn(
                name: "DownloadCount",
                table: "tbFileUpload");
        }
    }
}

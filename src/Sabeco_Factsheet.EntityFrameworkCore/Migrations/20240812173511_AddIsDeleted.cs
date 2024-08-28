using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sabeco_Factsheet.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbPosition",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbPerson",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbInvestPerson",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbInvestDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbInvest",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbContact_Temp",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbContact",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbCompanyPerson_Temp",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbCompanyPerson",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbCompanyMajor_Temp",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbCompanyMajor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbCompanyInvest",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbCompanyBoard",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbCompany",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbAsset",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbPosition");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbPerson");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbInvestPerson");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbInvestDetail");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbInvest");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbContact_Temp");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbContact");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbCompanyPerson_Temp");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbCompanyPerson");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbCompanyMajor_Temp");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbCompanyMajor");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbCompanyInvest");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbCompanyBoard");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbCompany");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbAsset");
        }
    }
}

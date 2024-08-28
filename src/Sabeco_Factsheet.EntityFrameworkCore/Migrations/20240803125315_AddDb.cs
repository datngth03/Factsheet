using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sabeco_Factsheet.Migrations
{
    /// <inheritdoc />
    public partial class AddDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbAdditionInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    DocDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeOfGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TypeOfEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAdditionInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbAdditionInfo_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    DocDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeOfGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TypeOfEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAdditionInfo_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbAsset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    AssetType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AssetItem = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AssetAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DocNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAsset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BriefName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Crt_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBranch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbBrewery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreweryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BreweryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BreweryName_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BriefName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreweryAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CapacityVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeliveryVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBrewery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbBrewery_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idBrewery = table.Column<int>(type: "int", nullable: false),
                    BreweryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BreweryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BreweryName_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BriefName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreweryAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CapacityVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeliveryVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBrewery_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbBreweryDeliveryVolume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreweryId = table.Column<int>(type: "int", nullable: true),
                    BreweryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    DeliveryVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBreweryDeliveryVolume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbBreweryDeliveryVolume_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idBreweryDeliveryVolume = table.Column<int>(type: "int", nullable: true),
                    BreweryId = table.Column<int>(type: "int", nullable: true),
                    BreweryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    DeliveryVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBreweryDeliveryVolume_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbBreweryImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BreweryImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBreweryImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbBrewerySKU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: true),
                    BreweryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SKUCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ProductionVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    BreweryId = table.Column<int>(type: "int", nullable: true),
                    SKUId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBrewerySKU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbBrewerySKU_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idBrewerySKU = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    BreweryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SKUCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ProductionVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    BreweryId = table.Column<int>(type: "int", nullable: true),
                    SKUId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBrewerySKU_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    IsGroup = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BriefName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactInfo_01 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactInfo_02 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactInfo_03 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactInfo_04 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactInfo_05 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactInfo_06 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    StockCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    StockExchange = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StockRegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPublicCompany = table.Column<bool>(type: "bit", nullable: true),
                    LicenseNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    License = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegistrationOrder = table.Column<byte>(type: "tinyint", nullable: true),
                    RegistrationDate0 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LatestAmendment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LegalRepresent = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CharteredCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ListedShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ParValue = table.Column<int>(type: "int", nullable: true),
                    ContactName1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactDept1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactMail1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactPosition1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactPhone1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactName2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactDept2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactMail2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactPosition2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactPhone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    longtitude = table.Column<double>(type: "float", nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    DirectShareholding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConsolidatedShareholding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConsolidateNoted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VotingRightDirect = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VotingRightTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    BravoCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    LegacyCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    idCompanyType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompany_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCompany = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    IsGroup = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BriefName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactInfo_01 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactInfo_02 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactInfo_03 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactInfo_04 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactInfo_05 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactInfo_06 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    StockCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    StockExchange = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StockRegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPublicCompany = table.Column<bool>(type: "bit", nullable: true),
                    LicenseNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    License = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegistrationOrder = table.Column<byte>(type: "tinyint", nullable: true),
                    RegistrationDate0 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LatestAmendment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LegalRepresent = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CharteredCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ListedShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ParValue = table.Column<int>(type: "int", nullable: true),
                    ContactName1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactDept1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactMail1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactPosition1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactPhone1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactName2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactDept2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactMail2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactPosition2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactPhone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    longtitude = table.Column<double>(type: "float", nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    DirectShareholding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConsolidatedShareholding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConsolidateNoted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VotingRightDirect = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VotingRightTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    BravoCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    LegacyCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompany_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyBoard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PersonCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PositionCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PersonalValue = table.Column<int>(type: "int", nullable: true),
                    OwnerValue = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyBoard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyBranch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyBranch_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyBranch_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyBranchImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyBranchImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyBusiness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    License = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegistrationNo = table.Column<byte>(type: "tinyint", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LegalRepresent = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MajorBusiness = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OtherActivity = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    LatestAmendment = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyBusiness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyBusiness_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    License = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegistrationNo = table.Column<byte>(type: "tinyint", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LegalRepresent = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MajorBusiness = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OtherActivity = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    LatestAmendment = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyBusiness_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyBusinessDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    RegistrationCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RegistrationName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RegistrationName_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyBusinessDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyBusinessDetail_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    RegistrationCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RegistrationName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RegistrationName_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyBusinessDetail_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyInvest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shares = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Holding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyInvest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyInvest_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shares = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Holding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyInvest_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyMajor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ShareHolderMajor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShareHolderType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShareHolderValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShareHolderRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyMajor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyMajor_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ShareHolderMajor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShareHolderType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShareHolderValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShareHolderRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyMajor_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CompanyTypeShareholdingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyTypesCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    idCompanyTypeShareholdingCode = table.Column<int>(type: "int", nullable: true),
                    idCompanyTypesCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyMapping_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CompanyTypeShareholdingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyTypesCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    idCompanyTypeShareholdingCode = table.Column<int>(type: "int", nullable: true),
                    idCompanyTypesCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyMapping_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyMemberCouncilTerm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    TermFrom = table.Column<int>(type: "int", nullable: true),
                    TermEnd = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyMemberCouncilTerm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PositionCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PostionType = table.Column<byte>(type: "tinyint", nullable: true),
                    PersonalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PersonalSharePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OwnerValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RepresentativePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyPerson_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCompanyPerson = table.Column<int>(type: "int", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PositionType = table.Column<byte>(type: "tinyint", nullable: true),
                    PositionCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PersonalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PersonalSharePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OwnerValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RepresentativePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyPerson_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyStock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsPublicCompany = table.Column<bool>(type: "bit", nullable: false),
                    StockExchange = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CharteredCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ParValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalShare = table.Column<int>(type: "int", nullable: true),
                    ListedShare = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyStock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCompanyStock_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsPublicCompany = table.Column<bool>(type: "bit", nullable: false),
                    StockExchange = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CharteredCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ParValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalShare = table.Column<int>(type: "int", nullable: true),
                    ListedShare = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyStock_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbConfigRetirementTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearNumb = table.Column<int>(type: "int", nullable: true),
                    MonthNumb = table.Column<int>(type: "int", nullable: true),
                    DayNumb = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbConfigRetirementTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyid = table.Column<int>(type: "int", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactDept = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactPosition = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbContact_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyid = table.Column<int>(type: "int", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactDept = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactPosition = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbContact_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbFileUpload",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    personId = table.Column<int>(type: "int", nullable: true),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserUpload = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFileUpload", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbFileUpload_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    personId = table.Column<int>(type: "int", nullable: true),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserUpload = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFileUpload_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbHisBrewery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSendMail = table.Column<bool>(type: "bit", nullable: true),
                    DateSendMail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IdBrewery = table.Column<int>(type: "int", nullable: false),
                    BreweryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BreweryName_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BreweryAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BriefName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CapacityVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeliveryVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbHisBrewery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbHisBreweryDeliveryVolume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSendMail = table.Column<bool>(type: "bit", nullable: true),
                    DateSendMail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IdBreweryDeliveryVolume = table.Column<int>(type: "int", nullable: false),
                    BreweryId = table.Column<int>(type: "int", nullable: true),
                    BreweryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    DeliveryVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbHisBreweryDeliveryVolume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbHisBrewerySKU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSendMail = table.Column<bool>(type: "bit", nullable: true),
                    DateSendMail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IdBrewerySKU = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    BreweryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SKUCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ProductionVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    BreweryId = table.Column<int>(type: "int", nullable: true),
                    SKUId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbHisBrewerySKU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbHisCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSendMail = table.Column<bool>(type: "bit", nullable: true),
                    DateSendMail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    IsGroup = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BriefName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactInfo_01 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactInfo_02 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactInfo_03 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactInfo_04 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactInfo_05 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactInfo_06 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    StockCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    StockExchange = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StockRegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPublicCompany = table.Column<bool>(type: "bit", nullable: true),
                    LicenseNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    License = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegistrationOrder = table.Column<byte>(type: "tinyint", nullable: true),
                    RegistrationDate0 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LatestAmendment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LegalRepresent = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CharteredCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ListedShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ParValue = table.Column<int>(type: "int", nullable: true),
                    ContactName1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactDept1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactMail1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactPosition1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactPhone1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactName2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactDept2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactMail2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactPosition2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactPhone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    longtitude = table.Column<double>(type: "float", nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    DirectShareholding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConsolidatedShareholding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConsolidateNoted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VotingRightDirect = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VotingRightTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbHisCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbHisCompanyPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSendMail = table.Column<bool>(type: "bit", nullable: true),
                    DateSendMail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IdCompanyPerson = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    PositionCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PersonalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PersonalSharePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OwnerValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RepresentativePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbHisCompanyPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbHisLogPrinting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSendMail = table.Column<bool>(type: "bit", nullable: true),
                    DateSendMail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    FileLanguage = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsPrinting = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbHisLogPrinting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbHisPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSendMail = table.Column<bool>(type: "bit", nullable: true),
                    DateSendMail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IDCardNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IDCardDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCardIssuePlace = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Ethnicity = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NationalityCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsCheckRetirement = table.Column<bool>(type: "bit", nullable: true),
                    IsCheckTermEnd = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    OldCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbHisPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbInfoUpdate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColumnName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScreenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenId = table.Column<int>(type: "int", nullable: false),
                    RowId = table.Column<int>(type: "int", nullable: false),
                    Command = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastValue = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangeSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TimeAssessment = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbInfoUpdate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbInvest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShareNumTotal = table.Column<int>(type: "int", nullable: true),
                    ShareValueTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    InvestGroup = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbInvest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbInvestDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    DocDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvestType = table.Column<int>(type: "int", nullable: false),
                    ShareNum = table.Column<int>(type: "int", nullable: true),
                    ShareValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbInvestDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbInvestPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalValue = table.Column<int>(type: "int", nullable: true),
                    OwnerValue = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbInvestPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbLandInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfLand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SupportingDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Payment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLandInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbLandInfo_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfLand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SupportingDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Payment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLandInfo_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbLogError",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeLog = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserLog = table.Column<int>(type: "int", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassLog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionLog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonFailed = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLogError", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbLogExportData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeExport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    UserExport = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonExportFailed = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLogExportData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbLogLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPTracking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusLogin = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLogLogin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbLogPrinting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    companyCode = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    fileLanguage = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    isPrinting = table.Column<bool>(type: "bit", nullable: true),
                    printTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLogPrinting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbLogRefeshAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeRefesh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    UseRefesh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailedReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLogRefeshAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbLogSendEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    UserSend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailedReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLogSendEmail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbLogSendEmailRetirement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCompany = table.Column<int>(type: "int", nullable: true),
                    idPerson = table.Column<int>(type: "int", nullable: true),
                    IsSendEmail = table.Column<bool>(type: "bit", nullable: true),
                    DateSendEmail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLogSendEmailRetirement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbLogSyncUAT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeExport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    UserExport = table.Column<int>(type: "int", nullable: false),
                    ReasonExportFailed = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLogSyncUAT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    create_user = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbNationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Code2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name_vn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbNationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbNationality_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Code2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name_vn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbNationality_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IDCardNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IDCardDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCardIssuePlace = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Ethnicity = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NationalityCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsCheckRetirement = table.Column<bool>(type: "bit", nullable: true),
                    IsCheckTermEnd = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    OldCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbPerson_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPerson = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IDCardNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IDCardDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCardIssuePlace = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Ethnicity = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NationalityCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsCheckRetirement = table.Column<bool>(type: "bit", nullable: true),
                    IsCheckTermEnd = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    OldCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPerson_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PositionType = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    ctr_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderNumb = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbSKU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Name_EN = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BrandCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ItemBaseType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PackSize = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PackQuantity = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpiryDate = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbSKU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbStockPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StockDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LimitUpPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LimitDownPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReferencePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaleQty1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalePrice1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaleQty2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalePrice2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaleQty3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalePrice3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BuyQty1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BuyPrice1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BuyQty2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BuyPrice2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BuyQty3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BuyPrice3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransactionPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransactionQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbStockPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbTerm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    TermCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    FromYear = table.Column<int>(type: "int", nullable: true),
                    ToYear = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTerm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbTimeScript",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Hour = table.Column<int>(type: "int", nullable: true),
                    Minute = table.Column<int>(type: "int", nullable: true),
                    Second = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTimeScript", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUserInRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserInRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUserMappingBrewery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: true),
                    breweryid = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserMappingBrewery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUserMappingCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserMappingCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUserMappingPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: true),
                    personid = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserMappingPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPrincipalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    DocStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tsClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Name_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    Code_Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tsClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tsClass_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Name_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    crt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crt_user = table.Column<int>(type: "int", nullable: true),
                    mod_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mod_user = table.Column<int>(type: "int", nullable: true),
                    Code_Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tsClass_Temp", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbBreweryDeliveryVolume_BreweryId_Year",
                table: "tbBreweryDeliveryVolume",
                columns: new[] { "BreweryId", "Year" },
                unique: true,
                filter: "[BreweryId] IS NOT NULL AND [Year] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbBreweryDeliveryVolume_Temp_BreweryId_Year",
                table: "tbBreweryDeliveryVolume_Temp",
                columns: new[] { "BreweryId", "Year" },
                unique: true,
                filter: "[BreweryId] IS NOT NULL AND [Year] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbBrewerySKU_BreweryId_SKUId_Year",
                table: "tbBrewerySKU",
                columns: new[] { "BreweryId", "SKUId", "Year" },
                unique: true,
                filter: "[BreweryId] IS NOT NULL AND [SKUId] IS NOT NULL AND [Year] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbBrewerySKU_Temp_BreweryId_SKUId_Year",
                table: "tbBrewerySKU_Temp",
                columns: new[] { "BreweryId", "SKUId", "Year" },
                unique: true,
                filter: "[BreweryId] IS NOT NULL AND [SKUId] IS NOT NULL AND [Year] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbAdditionInfo");

            migrationBuilder.DropTable(
                name: "tbAdditionInfo_Temp");

            migrationBuilder.DropTable(
                name: "tbAsset");

            migrationBuilder.DropTable(
                name: "tbBranch");

            migrationBuilder.DropTable(
                name: "tbBrewery");

            migrationBuilder.DropTable(
                name: "tbBrewery_Temp");

            migrationBuilder.DropTable(
                name: "tbBreweryDeliveryVolume");

            migrationBuilder.DropTable(
                name: "tbBreweryDeliveryVolume_Temp");

            migrationBuilder.DropTable(
                name: "tbBreweryImage");

            migrationBuilder.DropTable(
                name: "tbBrewerySKU");

            migrationBuilder.DropTable(
                name: "tbBrewerySKU_Temp");

            migrationBuilder.DropTable(
                name: "tbCompany");

            migrationBuilder.DropTable(
                name: "tbCompany_Temp");

            migrationBuilder.DropTable(
                name: "tbCompanyBoard");

            migrationBuilder.DropTable(
                name: "tbCompanyBranch");

            migrationBuilder.DropTable(
                name: "tbCompanyBranch_Temp");

            migrationBuilder.DropTable(
                name: "tbCompanyBranchImage");

            migrationBuilder.DropTable(
                name: "tbCompanyBusiness");

            migrationBuilder.DropTable(
                name: "tbCompanyBusiness_Temp");

            migrationBuilder.DropTable(
                name: "tbCompanyBusinessDetail");

            migrationBuilder.DropTable(
                name: "tbCompanyBusinessDetail_Temp");

            migrationBuilder.DropTable(
                name: "tbCompanyInvest");

            migrationBuilder.DropTable(
                name: "tbCompanyInvest_Temp");

            migrationBuilder.DropTable(
                name: "tbCompanyMajor");

            migrationBuilder.DropTable(
                name: "tbCompanyMajor_Temp");

            migrationBuilder.DropTable(
                name: "tbCompanyMapping");

            migrationBuilder.DropTable(
                name: "tbCompanyMapping_Temp");

            migrationBuilder.DropTable(
                name: "tbCompanyMemberCouncilTerm");

            migrationBuilder.DropTable(
                name: "tbCompanyPerson");

            migrationBuilder.DropTable(
                name: "tbCompanyPerson_Temp");

            migrationBuilder.DropTable(
                name: "tbCompanyStock");

            migrationBuilder.DropTable(
                name: "tbCompanyStock_Temp");

            migrationBuilder.DropTable(
                name: "tbConfigRetirementTime");

            migrationBuilder.DropTable(
                name: "tbContact");

            migrationBuilder.DropTable(
                name: "tbContact_Temp");

            migrationBuilder.DropTable(
                name: "tbFileUpload");

            migrationBuilder.DropTable(
                name: "tbFileUpload_Temp");

            migrationBuilder.DropTable(
                name: "tbHisBrewery");

            migrationBuilder.DropTable(
                name: "tbHisBreweryDeliveryVolume");

            migrationBuilder.DropTable(
                name: "tbHisBrewerySKU");

            migrationBuilder.DropTable(
                name: "tbHisCompany");

            migrationBuilder.DropTable(
                name: "tbHisCompanyPerson");

            migrationBuilder.DropTable(
                name: "tbHisLogPrinting");

            migrationBuilder.DropTable(
                name: "tbHisPerson");

            migrationBuilder.DropTable(
                name: "tbInfoUpdate");

            migrationBuilder.DropTable(
                name: "tbInvest");

            migrationBuilder.DropTable(
                name: "tbInvestDetail");

            migrationBuilder.DropTable(
                name: "tbInvestPerson");

            migrationBuilder.DropTable(
                name: "tbLandInfo");

            migrationBuilder.DropTable(
                name: "tbLandInfo_Temp");

            migrationBuilder.DropTable(
                name: "tbLogError");

            migrationBuilder.DropTable(
                name: "tbLogExportData");

            migrationBuilder.DropTable(
                name: "tbLogLogin");

            migrationBuilder.DropTable(
                name: "tbLogPrinting");

            migrationBuilder.DropTable(
                name: "tbLogRefeshAccount");

            migrationBuilder.DropTable(
                name: "tbLogSendEmail");

            migrationBuilder.DropTable(
                name: "tbLogSendEmailRetirement");

            migrationBuilder.DropTable(
                name: "tbLogSyncUAT");

            migrationBuilder.DropTable(
                name: "tbMenu");

            migrationBuilder.DropTable(
                name: "tbNationality");

            migrationBuilder.DropTable(
                name: "tbNationality_Temp");

            migrationBuilder.DropTable(
                name: "tbPerson");

            migrationBuilder.DropTable(
                name: "tbPerson_Temp");

            migrationBuilder.DropTable(
                name: "tbPosition");

            migrationBuilder.DropTable(
                name: "tbRole");

            migrationBuilder.DropTable(
                name: "tbSKU");

            migrationBuilder.DropTable(
                name: "tbStockPrice");

            migrationBuilder.DropTable(
                name: "tbTerm");

            migrationBuilder.DropTable(
                name: "tbTimeScript");

            migrationBuilder.DropTable(
                name: "tbUserInRole");

            migrationBuilder.DropTable(
                name: "tbUserMappingBrewery");

            migrationBuilder.DropTable(
                name: "tbUserMappingCompany");

            migrationBuilder.DropTable(
                name: "tbUserMappingPerson");

            migrationBuilder.DropTable(
                name: "tbUsers");

            migrationBuilder.DropTable(
                name: "tsClass");

            migrationBuilder.DropTable(
                name: "tsClass_Temp");
        }
    }
}

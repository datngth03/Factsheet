using Sabeco_Factsheet.TbTimeScripts;
using Sabeco_Factsheet.TbUserInRoles;
using Sabeco_Factsheet.TbStockPrices;
using Sabeco_Factsheet.TbRoles;
using Sabeco_Factsheet.TbPositions;
using Sabeco_Factsheet.TbPersonTemps;
using Sabeco_Factsheet.TbPersons;
using Sabeco_Factsheet.TbMenus;
using Sabeco_Factsheet.TbLogSyncUats;
using Sabeco_Factsheet.TbLogSendEmailRetirements;
using Sabeco_Factsheet.TbLogSendEmails;
using Sabeco_Factsheet.TbLogRefeshAccounts;
using Sabeco_Factsheet.TbLogPrintings;
using Sabeco_Factsheet.TbLogLogins;
using Sabeco_Factsheet.TbLogExportDatas;
using Sabeco_Factsheet.TbLogErrors;
using Sabeco_Factsheet.TbInvestPersons;
using Sabeco_Factsheet.TbInvestDetails;
using Sabeco_Factsheet.TbInvests;
using Sabeco_Factsheet.TbHisPersons;
using Sabeco_Factsheet.TbHisLogPrintings;
using Sabeco_Factsheet.TbHisCompanyPersons;
using Sabeco_Factsheet.TbHisCompanies;
using Sabeco_Factsheet.TbHisBrewerySkus;
using Sabeco_Factsheet.TbHisBreweryDeliveryVolumes;
using Sabeco_Factsheet.TbHisBreweries;
using Sabeco_Factsheet.TbContacts;
using Sabeco_Factsheet.TbConfigRetirementTimes;
using Sabeco_Factsheet.TbCompanyTemps;
using Sabeco_Factsheet.TbCompanyStocks;
using Sabeco_Factsheet.TbCompanyPersonTemps;
using Sabeco_Factsheet.TbCompanyMappings;
using Sabeco_Factsheet.TbCompanyBusinessDetails;
using Sabeco_Factsheet.TbCompanyBusinesses;
using Sabeco_Factsheet.TbCompanyBranchImages;
using Sabeco_Factsheet.TbCompanyBranchs;
using Sabeco_Factsheet.TbCompanyBoards;
using Sabeco_Factsheet.TbBreweryTemps;
using Sabeco_Factsheet.TbBrewerySkuTemps;
using Sabeco_Factsheet.TbBrewerySkus;
using Sabeco_Factsheet.TbBreweryImages;
using Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps;
using Sabeco_Factsheet.TbBreweryDeliveryVolumes;
using Sabeco_Factsheet.TbBreweries;
using Sabeco_Factsheet.TbBranchs;
using Sabeco_Factsheet.TbAssets;
using Sabeco_Factsheet.TbTerms;
using Sabeco_Factsheet.TbSkus;
using Sabeco_Factsheet.TbLandInfos;
using Sabeco_Factsheet.TbFileUploads;
using Sabeco_Factsheet.TbCompanyPersons;
using Sabeco_Factsheet.TbCompanyMajors;
using Sabeco_Factsheet.TbCompanyInvests;
using Sabeco_Factsheet.TbCompanies;
using Sabeco_Factsheet.TbAdditionInfos;
using Sabeco_Factsheet.TbUsers;
using Sabeco_Factsheet.TbInfoUpdates;
using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Sabeco_Factsheet.TbCompanyBranchTemps;
using Sabeco_Factsheet.TbCompanyBusinessDetailTemps;
using Sabeco_Factsheet.TbCompanyBusinessTemps;
using Sabeco_Factsheet.TbCompanyMajorTemps;
using Sabeco_Factsheet.TbCompanyMappingTemps;
using Sabeco_Factsheet.TbCompanyStockTemps;
using Sabeco_Factsheet.TbContactTemps;
using Sabeco_Factsheet.TbFileUploadTemps;
using Sabeco_Factsheet.TbLandInfoTemps;
using Sabeco_Factsheet.TbNationalities;
using Sabeco_Factsheet.TbNationalityTemps;
using Sabeco_Factsheet.TbAdditionInfoTemps;
using Sabeco_Factsheet.TbCompanyInvestTemps;
using Sabeco_Factsheet.TbCompanyMemberCouncilTerms;
using Sabeco_Factsheet.TsClasses;
using Sabeco_Factsheet.TsClassTemps;
using Sabeco_Factsheet.TbUserMappingBreweries;
using Sabeco_Factsheet.TbUserMappingCompanies;
using Sabeco_Factsheet.TbUserMappingPersons;


namespace Sabeco_Factsheet.EntityFrameworkCore;

[DependsOn(
    typeof(Sabeco_FactsheetDomainModule),
    typeof(AbpIdentityProEntityFrameworkCoreModule),
    typeof(AbpOpenIddictProEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(LanguageManagementEntityFrameworkCoreModule),
    typeof(SaasEntityFrameworkCoreModule),
    typeof(TextTemplateManagementEntityFrameworkCoreModule),
    typeof(AbpGdprEntityFrameworkCoreModule),
    typeof(BlobStoringDatabaseEntityFrameworkCoreModule)
    )]
public class Sabeco_FactsheetEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        Sabeco_FactsheetEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<Sabeco_FactsheetDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */

            options.AddRepository<TbInfoUpdate, TbInfoUpdates.EfCoreTbInfoUpdateRepository>();

            options.AddRepository<TbUser, TbUsers.EfCoreTbUserRepository>();

            options.AddRepository<TbAdditionInfo, TbAdditionInfos.EfCoreTbAdditionInfoRepository>();

            options.AddRepository<TbCompany, TbCompanies.EfCoreTbCompanyRepository>();

            options.AddRepository<TbCompanyInvest, TbCompanyInvests.EfCoreTbCompanyInvestRepository>();

            options.AddRepository<TbCompanyMajor, TbCompanyMajors.EfCoreTbCompanyMajorRepository>();

            options.AddRepository<TbCompanyPerson, TbCompanyPersons.EfCoreTbCompanyPersonRepository>();

            options.AddRepository<TbFileUpload, TbFileUploads.EfCoreTbFileUploadRepository>();

            options.AddRepository<TbLandInfo, TbLandInfos.EfCoreTbLandInfoRepository>();

            options.AddRepository<TbSku, TbSkus.EfCoreTbSkuRepository>();

            options.AddRepository<TbTerm, TbTerms.EfCoreTbTermRepository>();

            options.AddRepository<TbAsset, TbAssets.EfCoreTbAssetRepository>();

            options.AddRepository<TbBranch, TbBranchs.EfCoreTbBranchRepository>();

            options.AddRepository<TbBrewery, TbBreweries.EfCoreTbBreweryRepository>();

            options.AddRepository<TbBreweryDeliveryVolume, TbBreweryDeliveryVolumes.EfCoreTbBreweryDeliveryVolumeRepository>();

            options.AddRepository<TbBreweryDeliveryVolumeTemp, TbBreweryDeliveryVolumeTemps.EfCoreTbBreweryDeliveryVolumeTempRepository>();

            options.AddRepository<TbBreweryImage, TbBreweryImages.EfCoreTbBreweryImageRepository>();

            options.AddRepository<TbBrewerySku, TbBrewerySkus.EfCoreTbBrewerySkuRepository>();

            options.AddRepository<TbBrewerySkuTemp, TbBrewerySkuTemps.EfCoreTbBrewerySkuTempRepository>();

            options.AddRepository<TbBreweryTemp, TbBreweryTemps.EfCoreTbBreweryTempRepository>();

            options.AddRepository<TbCompanyBoard, TbCompanyBoards.EfCoreTbCompanyBoardRepository>();

            options.AddRepository<TbCompanyBranch, TbCompanyBranchs.EfCoreTbCompanyBranchRepository>();

            options.AddRepository<TbCompanyBranchImage, TbCompanyBranchImages.EfCoreTbCompanyBranchImageRepository>();

            options.AddRepository<TbCompanyBusiness, TbCompanyBusinesses.EfCoreTbCompanyBusinessRepository>();

            options.AddRepository<TbCompanyBusinessDetail, TbCompanyBusinessDetails.EfCoreTbCompanyBusinessDetailRepository>();

            options.AddRepository<TbCompanyMapping, TbCompanyMappings.EfCoreTbCompanyMappingRepository>();

            options.AddRepository<TbCompanyPersonTemp, TbCompanyPersonTemps.EfCoreTbCompanyPersonTempRepository>();

            options.AddRepository<TbCompanyStock, TbCompanyStocks.EfCoreTbCompanyStockRepository>();

            options.AddRepository<TbCompanyTemp, TbCompanyTemps.EfCoreTbCompanyTempRepository>();

            options.AddRepository<TbConfigRetirementTime, TbConfigRetirementTimes.EfCoreTbConfigRetirementTimeRepository>();

            options.AddRepository<TbContact, TbContacts.EfCoreTbContactRepository>();

            options.AddRepository<TbHisBrewery, TbHisBreweries.EfCoreTbHisBreweryRepository>();

            options.AddRepository<TbHisBreweryDeliveryVolume, TbHisBreweryDeliveryVolumes.EfCoreTbHisBreweryDeliveryVolumeRepository>();

            options.AddRepository<TbHisBrewerySku, TbHisBrewerySkus.EfCoreTbHisBrewerySkuRepository>();

            options.AddRepository<TbHisCompany, TbHisCompanies.EfCoreTbHisCompanyRepository>();

            options.AddRepository<TbHisCompanyPerson, TbHisCompanyPersons.EfCoreTbHisCompanyPersonRepository>();

            options.AddRepository<TbHisLogPrinting, TbHisLogPrintings.EfCoreTbHisLogPrintingRepository>();

            options.AddRepository<TbHisPerson, TbHisPersons.EfCoreTbHisPersonRepository>();

            options.AddRepository<TbInvest, TbInvests.EfCoreTbInvestRepository>();

            options.AddRepository<TbInvestDetail, TbInvestDetails.EfCoreTbInvestDetailRepository>();

            options.AddRepository<TbInvestPerson, TbInvestPersons.EfCoreTbInvestPersonRepository>();

            options.AddRepository<TbLogError, TbLogErrors.EfCoreTbLogErrorRepository>();

            options.AddRepository<TbLogExportData, TbLogExportDatas.EfCoreTbLogExportDataRepository>();

            options.AddRepository<TbLogLogin, TbLogLogins.EfCoreTbLogLoginRepository>();

            options.AddRepository<TbLogPrinting, TbLogPrintings.EfCoreTbLogPrintingRepository>();

            options.AddRepository<TbLogRefeshAccount, TbLogRefeshAccounts.EfCoreTbLogRefeshAccountRepository>();

            options.AddRepository<TbLogSendEmail, TbLogSendEmails.EfCoreTbLogSendEmailRepository>();

            options.AddRepository<TbLogSendEmailRetirement, TbLogSendEmailRetirements.EfCoreTbLogSendEmailRetirementRepository>();

            options.AddRepository<TbLogSyncUat, TbLogSyncUats.EfCoreTbLogSyncUatRepository>();

            options.AddRepository<TbMenu, TbMenus.EfCoreTbMenuRepository>();

            options.AddRepository<TbPerson, TbPersons.EfCoreTbPersonRepository>();

            options.AddRepository<TbPersonTemp, TbPersonTemps.EfCoreTbPersonTempRepository>();

            options.AddRepository<TbPosition, TbPositions.EfCoreTbPositionRepository>();

            options.AddRepository<TbRole, TbRoles.EfCoreTbRoleRepository>();

            options.AddRepository<TbStockPrice, TbStockPrices.EfCoreTbStockPriceRepository>();

            options.AddRepository<TbUserInRole, TbUserInRoles.EfCoreTbUserInRoleRepository>();

            options.AddRepository<TbTimeScript, TbTimeScripts.EfCoreTbTimeScriptRepository>();

            options.AddRepository<TbNationality, TbNationalities.EfCoreTbNationalityRepository>();

            options.AddRepository<TbFileUploadTemp, TbFileUploadTemps.EfCoreTbFileUploadTempRepository>();

            options.AddRepository<TbCompanyMajorTemp, TbCompanyMajorTemps.EfCoreTbCompanyMajorTempRepository>();

            options.AddRepository<TbCompanyBranchTemp, TbCompanyBranchTemps.EfCoreTbCompanyBranchTempRepository>();

            options.AddRepository<TbCompanyBusinessTemp, TbCompanyBusinessTemps.EfCoreTbCompanyBusinessTempRepository>();

            options.AddRepository<TbCompanyBusinessDetailTemp, TbCompanyBusinessDetailTemps.EfCoreTbCompanyBusinessDetailTempRepository>();

            options.AddRepository<TbCompanyMappingTemp, TbCompanyMappingTemps.EfCoreTbCompanyMappingTempRepository>();

            options.AddRepository<TbCompanyStockTemp, TbCompanyStockTemps.EfCoreTbCompanyStockTempRepository>();

            options.AddRepository<TbContactTemp, TbContactTemps.EfCoreTbContactTempRepository>();

            options.AddRepository<TbLandInfoTemp, TbLandInfoTemps.EfCoreTbLandInfoTempRepository>();

            options.AddRepository<TbNationalityTemp, TbNationalityTemps.EfCoreTbNationalityTempRepository>();

            options.AddRepository<TbAdditionInfoTemp, TbAdditionInfoTemps.EfCoreTbAdditionInfoTempRepository>();

            options.AddRepository<TbCompanyInvestTemp, TbCompanyInvestTemps.EfCoreTbCompanyInvestTempRepository>();

            options.AddRepository<TbCompanyMemberCouncilTerm, TbCompanyMemberCouncilTerms.EfCoreTbCompanyMemberCouncilTermRepository>();
             
            options.AddRepository<TsClass, TsClasses.EfCoreTsClassRepository>();

            options.AddRepository<TsClassTemp, TsClassTemps.EfCoreTsClassTempRepository>();

            options.AddRepository<TbUserMappingBrewery, TbUserMappingBreweries.EfCoreTbUserMappingBreweryRepository>();

            options.AddRepository<TbUserMappingCompany, TbUserMappingCompanies.EfCoreTbUserMappingCompanyRepository>();

            options.AddRepository<TbUserMappingPerson, TbUserMappingPersons.EfCoreTbUserMappingPersonRepository>();

        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also Sabeco_FactsheetDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });

    }
}
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
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using Volo.Abp.Users;
using Sabeco_Factsheet.TbNationalities;
using Sabeco_Factsheet.TbCompanyBranchTemps;
using Sabeco_Factsheet.TbCompanyBusinessDetailTemps;
using Sabeco_Factsheet.TbCompanyBusinessTemps;
using Sabeco_Factsheet.TbCompanyMajorTemps;
using Sabeco_Factsheet.TbCompanyMappingTemps;
using Sabeco_Factsheet.TbCompanyStockTemps;
using Sabeco_Factsheet.TbContactTemps;
using Sabeco_Factsheet.TbFileUploadTemps;
using Sabeco_Factsheet.TbLandInfoTemps;
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

[ReplaceDbContext(typeof(IIdentityProDbContext))]
[ReplaceDbContext(typeof(ISaasDbContext))]
[ConnectionStringName("Default")]
public class Sabeco_FactsheetDbContext :
    AbpDbContext<Sabeco_FactsheetDbContext>,
    IIdentityProDbContext,
    ISaasDbContext
{
    public DbSet<TbUserMappingPerson> TbUserMappingPersons { get; set; } = null!;
    public DbSet<TbUserMappingCompany> TbUserMappingCompanies { get; set; } = null!;
    public DbSet<TbUserMappingBrewery> TbUserMappingBreweries { get; set; } = null!;
    public DbSet<TsClassTemp> TsClassTemps { get; set; } = null!;
    public DbSet<TsClass> TsClasses { get; set; } = null!;
    public DbSet<TbCompanyMemberCouncilTerm> TbCompanyMemberCouncilTerms { get; set; } = null!;
    public DbSet<TbCompanyInvestTemp> TbCompanyInvestTemps { get; set; } = null!;
    public DbSet<TbAdditionInfoTemp> TbAdditionInfoTemps { get; set; } = null!;
    public DbSet<TbNationalityTemp> TbNationalityTemps { get; set; } = null!;
    public DbSet<TbLandInfoTemp> TbLandInfoTemps { get; set; } = null!;
    public DbSet<TbContactTemp> TbContactTemps { get; set; } = null!;
    public DbSet<TbCompanyStockTemp> TbCompanyStockTemps { get; set; } = null!;
    public DbSet<TbCompanyMappingTemp> TbCompanyMappingTemps { get; set; } = null!;
    public DbSet<TbCompanyBusinessDetailTemp> TbCompanyBusinessDetailTemps { get; set; } = null!;
    public DbSet<TbCompanyBusinessTemp> TbCompanyBusinessTemps { get; set; } = null!;
    public DbSet<TbCompanyBranchTemp> TbCompanyBranchTemps { get; set; } = null!;
    public DbSet<TbCompanyMajorTemp> TbCompanyMajorTemps { get; set; } = null!;
    public DbSet<TbFileUploadTemp> TbFileUploadTemps { get; set; } = null!;
    public DbSet<TbNationality> TbNationalities { get; set; } = null!;
    public DbSet<TbTimeScript> TbTimeScripts { get; set; } = null!;
    public DbSet<TbUserInRole> TbUserInRoles { get; set; } = null!;
    public DbSet<TbStockPrice> TbStockPrices { get; set; } = null!;
    public DbSet<TbRole> TbRoles { get; set; } = null!;
    public DbSet<TbPosition> TbPositions { get; set; } = null!;
    public DbSet<TbPersonTemp> TbPersonTemps { get; set; } = null!;
    public DbSet<TbPerson> TbPersons { get; set; } = null!;
    public DbSet<TbMenu> TbMenus { get; set; } = null!;
    public DbSet<TbLogSyncUat> TbLogSyncUats { get; set; } = null!;
    public DbSet<TbLogSendEmailRetirement> TbLogSendEmailRetirements { get; set; } = null!;
    public DbSet<TbLogSendEmail> TbLogSendEmails { get; set; } = null!;
    public DbSet<TbLogRefeshAccount> TbLogRefeshAccounts { get; set; } = null!;
    public DbSet<TbLogPrinting> TbLogPrintings { get; set; } = null!;
    public DbSet<TbLogLogin> TbLogLogins { get; set; } = null!;
    public DbSet<TbLogExportData> TbLogExportDatas { get; set; } = null!;
    public DbSet<TbLogError> TbLogErrors { get; set; } = null!;
    public DbSet<TbInvestPerson> TbInvestPersons { get; set; } = null!;
    public DbSet<TbInvestDetail> TbInvestDetails { get; set; } = null!;
    public DbSet<TbInvest> TbInvests { get; set; } = null!;
    public DbSet<TbHisPerson> TbHisPersons { get; set; } = null!;
    public DbSet<TbHisLogPrinting> TbHisLogPrintings { get; set; } = null!;
    public DbSet<TbHisCompanyPerson> TbHisCompanyPersons { get; set; } = null!;
    public DbSet<TbHisCompany> TbHisCompanies { get; set; } = null!;
    public DbSet<TbHisBrewerySku> TbHisBrewerySkus { get; set; } = null!;
    public DbSet<TbHisBreweryDeliveryVolume> TbHisBreweryDeliveryVolumes { get; set; } = null!;
    public DbSet<TbHisBrewery> TbHisBreweries { get; set; } = null!;
    public DbSet<TbContact> TbContacts { get; set; } = null!;
    public DbSet<TbConfigRetirementTime> TbConfigRetirementTimes { get; set; } = null!;
    public DbSet<TbCompanyTemp> TbCompanyTemps { get; set; } = null!;
    public DbSet<TbCompanyStock> TbCompanyStocks { get; set; } = null!;
    public DbSet<TbCompanyPersonTemp> TbCompanyPersonTemps { get; set; } = null!;
    public DbSet<TbCompanyMapping> TbCompanyMappings { get; set; } = null!;
    public DbSet<TbCompanyBusinessDetail> TbCompanyBusinessDetails { get; set; } = null!;
    public DbSet<TbCompanyBusiness> TbCompanyBusinesses { get; set; } = null!;
    public DbSet<TbCompanyBranchImage> TbCompanyBranchImages { get; set; } = null!;
    public DbSet<TbCompanyBranch> TbCompanyBranchs { get; set; } = null!;
    public DbSet<TbCompanyBoard> TbCompanyBoards { get; set; } = null!;
    public DbSet<TbBreweryTemp> TbBreweryTemps { get; set; } = null!;
    public DbSet<TbBrewerySkuTemp> TbBrewerySkuTemps { get; set; } = null!;
    public DbSet<TbBrewerySku> TbBrewerySkus { get; set; } = null!;
    public DbSet<TbBreweryImage> TbBreweryImages { get; set; } = null!;
    public DbSet<TbBreweryDeliveryVolumeTemp> TbBreweryDeliveryVolumeTemps { get; set; } = null!;
    public DbSet<TbBreweryDeliveryVolume> TbBreweryDeliveryVolumes { get; set; } = null!;
    public DbSet<TbBrewery> TbBreweries { get; set; } = null!;
    public DbSet<TbBranch> TbBranchs { get; set; } = null!;
    public DbSet<TbAsset> TbAssets { get; set; } = null!;
    public DbSet<TbTerm> TbTerms { get; set; } = null!;
    public DbSet<TbSku> TbSkus { get; set; } = null!;
    public DbSet<FileDescriptors.FileDescriptor> FileDescriptors { get; set; } = null!;
    public DbSet<TbLandInfo> TbLandInfos { get; set; } = null!;
    public DbSet<TbFileUpload> TbFileUploads { get; set; } = null!;
    public DbSet<TbCompanyPerson> TbCompanyPersons { get; set; } = null!;
    public DbSet<TbCompanyMajor> TbCompanyMajors { get; set; } = null!;
    public DbSet<TbCompanyInvest> TbCompanyInvests { get; set; } = null!;
    public DbSet<TbCompany> TbCompanies { get; set; } = null!;
    public DbSet<TbAdditionInfo> TbAdditionInfos { get; set; } = null!;
    public DbSet<TbUser> TbUsers { get; set; } = null!;
    public DbSet<TbInfoUpdate> TbInfoUpdates { get; set; } = null!;


    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // SaaS
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public Sabeco_FactsheetDbContext(DbContextOptions<Sabeco_FactsheetDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentityPro();
        builder.ConfigureOpenIddictPro();
        builder.ConfigureFeatureManagement();
        builder.ConfigureLanguageManagement();
        builder.ConfigureSaas();
        builder.ConfigureTextTemplateManagement();
        builder.ConfigureBlobStoring();
        builder.ConfigureGdpr();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "YourEntities", Sabeco_FactsheetConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //}); 

        builder.Entity<FileDescriptors.FileDescriptor>(b =>
        {
            b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "FileDescriptor", Sabeco_FactsheetConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name);
            b.Property(x => x.MimeType);
        });
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbTerm>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbTerm", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.BranchId).HasColumnName(nameof(TbTerm.BranchId)).IsRequired();
                b.Property(x => x.TermCode).HasColumnName(nameof(TbTerm.TermCode)).IsRequired().HasMaxLength(TbTermConsts.TermCodeMaxLength);
                b.Property(x => x.FromYear).HasColumnName(nameof(TbTerm.FromYear));
                b.Property(x => x.ToYear).HasColumnName(nameof(TbTerm.ToYear));
                b.Property(x => x.Description).HasColumnName(nameof(TbTerm.Description)).HasMaxLength(TbTermConsts.DescriptionMaxLength);
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbAdditionInfo>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbAdditionInfo", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbAdditionInfo.CompanyId)).IsRequired();
                b.Property(x => x.DocDate).HasColumnName(nameof(TbAdditionInfo.DocDate));
                b.Property(x => x.TypeOfGroup).HasColumnName(nameof(TbAdditionInfo.TypeOfGroup)).HasMaxLength(TbAdditionInfoConsts.TypeOfGroupMaxLength);
                b.Property(x => x.TypeOfEvent).HasColumnName(nameof(TbAdditionInfo.TypeOfEvent));
                b.Property(x => x.Description).HasColumnName(nameof(TbAdditionInfo.Description));
                b.Property(x => x.NoOfDocument).HasColumnName(nameof(TbAdditionInfo.NoOfDocument));
                b.Property(x => x.Remark).HasColumnName(nameof(TbAdditionInfo.Remark));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbAdditionInfo.IsActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbAdditionInfo.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbAdditionInfo.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbAdditionInfo.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbAdditionInfo.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbBranch>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbBranch", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Code).HasColumnName(nameof(TbBranch.Code)).IsRequired().HasMaxLength(TbBranchConsts.CodeMaxLength);
                b.Property(x => x.BriefName).HasColumnName(nameof(TbBranch.BriefName)).HasMaxLength(TbBranchConsts.BriefNameMaxLength);
                b.Property(x => x.Name).HasColumnName(nameof(TbBranch.Name)).IsRequired().HasMaxLength(TbBranchConsts.NameMaxLength);
                b.Property(x => x.Name_EN).HasColumnName(nameof(TbBranch.Name_EN)).HasMaxLength(TbBranchConsts.Name_ENMaxLength);
                b.Property(x => x.CompanyCode).HasColumnName(nameof(TbBranch.CompanyCode)).HasMaxLength(TbBranchConsts.CompanyCodeMaxLength);
                b.Property(x => x.Description).HasColumnName(nameof(TbBranch.Description)).HasMaxLength(TbBranchConsts.DescriptionMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbBranch.IsActive)).IsRequired();
                b.Property(x => x.Crt_Date).HasColumnName(nameof(TbBranch.Crt_Date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbBrewery>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbBrewery", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.BreweryCode).HasColumnName(nameof(TbBrewery.BreweryCode)).IsRequired().HasMaxLength(TbBreweryConsts.BreweryCodeMaxLength);
                b.Property(x => x.BreweryName).HasColumnName(nameof(TbBrewery.BreweryName)).IsRequired().HasMaxLength(TbBreweryConsts.BreweryNameMaxLength);
                b.Property(x => x.BreweryName_EN).HasColumnName(nameof(TbBrewery.BreweryName_EN)).HasMaxLength(TbBreweryConsts.BreweryName_ENMaxLength);
                b.Property(x => x.BriefName).HasColumnName(nameof(TbBrewery.BriefName));
                b.Property(x => x.BreweryAdress).HasColumnName(nameof(TbBrewery.BreweryAdress));
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbBrewery.CompanyId)).IsRequired();
                b.Property(x => x.CapacityVolume).HasColumnName(nameof(TbBrewery.CapacityVolume));
                b.Property(x => x.DeliveryVolume).HasColumnName(nameof(TbBrewery.DeliveryVolume));
                b.Property(x => x.Note).HasColumnName(nameof(TbBrewery.Note));
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbBrewery.DocStatus));
                b.Property(x => x.isActive).HasColumnName(nameof(TbBrewery.isActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbBrewery.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbBrewery.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbBrewery.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbBrewery.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbAsset>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbAsset", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbAsset.CompanyId)).IsRequired();
                b.Property(x => x.AssetType).HasColumnName(nameof(TbAsset.AssetType)).HasMaxLength(TbAssetConsts.AssetTypeMaxLength);
                b.Property(x => x.AssetItem).HasColumnName(nameof(TbAsset.AssetItem)).HasMaxLength(TbAssetConsts.AssetItemMaxLength);
                b.Property(x => x.AssetAddress).HasColumnName(nameof(TbAsset.AssetAddress)).HasMaxLength(TbAssetConsts.AssetAddressMaxLength);
                b.Property(x => x.Quantity).HasColumnName(nameof(TbAsset.Quantity));
                b.Property(x => x.DocNo).HasColumnName(nameof(TbAsset.DocNo)).HasMaxLength(TbAssetConsts.DocNoMaxLength);
                b.Property(x => x.DocDate).HasColumnName(nameof(TbAsset.DocDate));
                b.Property(x => x.ExpireDate).HasColumnName(nameof(TbAsset.ExpireDate));
                b.Property(x => x.Description).HasColumnName(nameof(TbAsset.Description)).HasMaxLength(TbAssetConsts.DescriptionMaxLength);
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbAsset.DocStatus));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbAsset.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbAsset.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbAsset.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbAsset.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbAsset.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbBreweryDeliveryVolume>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbBreweryDeliveryVolume", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => new { x.BreweryId, x.Year }).IsUnique();
                b.Property(x => x.BreweryId).HasColumnName(nameof(TbBreweryDeliveryVolume.BreweryId));
                b.Property(x => x.BreweryCode).HasColumnName(nameof(TbBreweryDeliveryVolume.BreweryCode)).HasMaxLength(TbBreweryDeliveryVolumeConsts.BreweryCodeMaxLength);
                b.Property(x => x.Year).HasColumnName(nameof(TbBreweryDeliveryVolume.Year));
                b.Property(x => x.DeliveryVolume).HasColumnName(nameof(TbBreweryDeliveryVolume.DeliveryVolume));
                b.Property(x => x.isActive).HasColumnName(nameof(TbBreweryDeliveryVolume.isActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbBreweryDeliveryVolume.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbBreweryDeliveryVolume.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbBreweryDeliveryVolume.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbBreweryDeliveryVolume.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbBreweryDeliveryVolumeTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbBreweryDeliveryVolume_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention(); 
                b.Property(x => x.idBreweryDeliveryVolume).HasColumnName(nameof(TbBreweryDeliveryVolumeTemp.idBreweryDeliveryVolume));
                b.Property(x => x.BreweryId).HasColumnName(nameof(TbBreweryDeliveryVolumeTemp.BreweryId));
                b.Property(x => x.BreweryCode).HasColumnName(nameof(TbBreweryDeliveryVolumeTemp.BreweryCode)).HasMaxLength(TbBreweryDeliveryVolumeTempConsts.BreweryCodeMaxLength);
                b.Property(x => x.Year).HasColumnName(nameof(TbBreweryDeliveryVolumeTemp.Year));
                b.Property(x => x.DeliveryVolume).HasColumnName(nameof(TbBreweryDeliveryVolumeTemp.DeliveryVolume));
                b.Property(x => x.isActive).HasColumnName(nameof(TbBreweryDeliveryVolumeTemp.isActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbBreweryDeliveryVolumeTemp.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbBreweryDeliveryVolumeTemp.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbBreweryDeliveryVolumeTemp.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbBreweryDeliveryVolumeTemp.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbBreweryImage>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbBreweryImage", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbBreweryImage.CompanyId));
                b.Property(x => x.BreweryImage).HasColumnName(nameof(TbBreweryImage.BreweryImage));
                b.Property(x => x.ImageLink).HasColumnName(nameof(TbBreweryImage.ImageLink));
                b.Property(x => x.isActive).HasColumnName(nameof(TbBreweryImage.isActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbBreweryImage.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbBreweryImage.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbBreweryImage.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbBreweryImage.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbBrewerySku>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbBrewerySKU", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => new { x.BreweryId, x.SKUId, x.Year }).IsUnique();
                b.Property(x => x.Year).HasColumnName(nameof(TbBrewerySku.Year));
                b.Property(x => x.BreweryCode).HasColumnName(nameof(TbBrewerySku.BreweryCode)).HasMaxLength(TbBrewerySkuConsts.BreweryCodeMaxLength);
                b.Property(x => x.SKUCode).HasColumnName(nameof(TbBrewerySku.SKUCode)).HasMaxLength(TbBrewerySkuConsts.SKUCodeMaxLength);
                b.Property(x => x.ProductionVolume).HasColumnName(nameof(TbBrewerySku.ProductionVolume));
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbBrewerySku.DocStatus));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbBrewerySku.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbBrewerySku.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbBrewerySku.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbBrewerySku.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbBrewerySku.mod_user));
                b.Property(x => x.BreweryId).HasColumnName(nameof(TbBrewerySku.BreweryId));
                b.Property(x => x.SKUId).HasColumnName(nameof(TbBrewerySku.SKUId));
            });

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbBrewerySkuTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbBrewerySKU_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention(); 
                b.Property(x => x.idBrewerySKU).HasColumnName(nameof(TbBrewerySkuTemp.idBrewerySKU));
                b.Property(x => x.Year).HasColumnName(nameof(TbBrewerySkuTemp.Year));
                b.Property(x => x.BreweryCode).HasColumnName(nameof(TbBrewerySkuTemp.BreweryCode)).HasMaxLength(TbBrewerySkuTempConsts.BreweryCodeMaxLength);
                b.Property(x => x.SKUCode).HasColumnName(nameof(TbBrewerySkuTemp.SKUCode)).HasMaxLength(TbBrewerySkuTempConsts.SKUCodeMaxLength);
                b.Property(x => x.ProductionVolume).HasColumnName(nameof(TbBrewerySkuTemp.ProductionVolume));
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbBrewerySkuTemp.DocStatus));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbBrewerySkuTemp.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbBrewerySkuTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbBrewerySkuTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbBrewerySkuTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbBrewerySkuTemp.mod_user));
                b.Property(x => x.BreweryId).HasColumnName(nameof(TbBrewerySkuTemp.BreweryId));
                b.Property(x => x.SKUId).HasColumnName(nameof(TbBrewerySkuTemp.SKUId));
            });
        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbBreweryTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbBrewery_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.idBrewery).HasColumnName(nameof(TbBreweryTemp.idBrewery)).IsRequired();
                b.Property(x => x.BreweryCode).HasColumnName(nameof(TbBreweryTemp.BreweryCode)).IsRequired().HasMaxLength(TbBreweryTempConsts.BreweryCodeMaxLength);
                b.Property(x => x.BreweryName).HasColumnName(nameof(TbBreweryTemp.BreweryName)).IsRequired().HasMaxLength(TbBreweryTempConsts.BreweryNameMaxLength);
                b.Property(x => x.BreweryName_EN).HasColumnName(nameof(TbBreweryTemp.BreweryName_EN)).HasMaxLength(TbBreweryTempConsts.BreweryName_ENMaxLength);
                b.Property(x => x.BriefName).HasColumnName(nameof(TbBreweryTemp.BriefName));
                b.Property(x => x.BreweryAdress).HasColumnName(nameof(TbBreweryTemp.BreweryAdress));
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbBreweryTemp.CompanyId)).IsRequired();
                b.Property(x => x.CapacityVolume).HasColumnName(nameof(TbBreweryTemp.CapacityVolume));
                b.Property(x => x.DeliveryVolume).HasColumnName(nameof(TbBreweryTemp.DeliveryVolume));
                b.Property(x => x.Note).HasColumnName(nameof(TbBreweryTemp.Note));
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbBreweryTemp.DocStatus));
                b.Property(x => x.isActive).HasColumnName(nameof(TbBreweryTemp.isActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbBreweryTemp.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbBreweryTemp.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbBreweryTemp.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbBreweryTemp.mod_date));
            });

        } 
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyBranch>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyBranch", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyBranch.CompanyId));
                b.Property(x => x.BranchName).HasColumnName(nameof(TbCompanyBranch.BranchName));
                b.Property(x => x.BranchAddress).HasColumnName(nameof(TbCompanyBranch.BranchAddress));
                b.Property(x => x.BranchCode).HasColumnName(nameof(TbCompanyBranch.BranchCode));
                b.Property(x => x.ContactPerson).HasColumnName(nameof(TbCompanyBranch.ContactPerson));
                b.Property(x => x.ContactPhone).HasColumnName(nameof(TbCompanyBranch.ContactPhone));
                b.Property(x => x.Email).HasColumnName(nameof(TbCompanyBranch.Email));
                b.Property(x => x.isActive).HasColumnName(nameof(TbCompanyBranch.isActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbCompanyBranch.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbCompanyBranch.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyBranch.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyBranch.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyBranchImage>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyBranchImage", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyBranchImage.CompanyId));
                b.Property(x => x.BranchImage).HasColumnName(nameof(TbCompanyBranchImage.BranchImage));
                b.Property(x => x.ImageLink).HasColumnName(nameof(TbCompanyBranchImage.ImageLink));
                b.Property(x => x.isActive).HasColumnName(nameof(TbCompanyBranchImage.isActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbCompanyBranchImage.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbCompanyBranchImage.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyBranchImage.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyBranchImage.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyBusiness>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyBusiness", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyBusiness.CompanyId)).IsRequired();
                b.Property(x => x.License).HasColumnName(nameof(TbCompanyBusiness.License)).HasMaxLength(TbCompanyBusinessConsts.LicenseMaxLength);
                b.Property(x => x.RegistrationNo).HasColumnName(nameof(TbCompanyBusiness.RegistrationNo)).IsRequired();
                b.Property(x => x.RegistrationDate).HasColumnName(nameof(TbCompanyBusiness.RegistrationDate)).IsRequired();
                b.Property(x => x.CompanyName).HasColumnName(nameof(TbCompanyBusiness.CompanyName)).HasMaxLength(TbCompanyBusinessConsts.CompanyNameMaxLength);
                b.Property(x => x.CompanyAddress).HasColumnName(nameof(TbCompanyBusiness.CompanyAddress)).HasMaxLength(TbCompanyBusinessConsts.CompanyAddressMaxLength);
                b.Property(x => x.LegalRepresent).HasColumnName(nameof(TbCompanyBusiness.LegalRepresent)).HasMaxLength(TbCompanyBusinessConsts.LegalRepresentMaxLength);
                b.Property(x => x.CompanyType).HasColumnName(nameof(TbCompanyBusiness.CompanyType)).HasMaxLength(TbCompanyBusinessConsts.CompanyTypeMaxLength);
                b.Property(x => x.MajorBusiness).HasColumnName(nameof(TbCompanyBusiness.MajorBusiness)).HasMaxLength(TbCompanyBusinessConsts.MajorBusinessMaxLength);
                b.Property(x => x.OtherActivity).HasColumnName(nameof(TbCompanyBusiness.OtherActivity)).HasMaxLength(TbCompanyBusinessConsts.OtherActivityMaxLength);
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyBusiness.Note)).HasMaxLength(TbCompanyBusinessConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyBusiness.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyBusiness.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyBusiness.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyBusiness.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyBusiness.mod_user));
                b.Property(x => x.LatestAmendment).HasColumnName(nameof(TbCompanyBusiness.LatestAmendment));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyBusinessDetail>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyBusinessDetail", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ParentId).HasColumnName(nameof(TbCompanyBusinessDetail.ParentId)).IsRequired();
                b.Property(x => x.RegistrationCode).HasColumnName(nameof(TbCompanyBusinessDetail.RegistrationCode)).IsRequired().HasMaxLength(TbCompanyBusinessDetailConsts.RegistrationCodeMaxLength);
                b.Property(x => x.RegistrationName).HasColumnName(nameof(TbCompanyBusinessDetail.RegistrationName)).HasMaxLength(TbCompanyBusinessDetailConsts.RegistrationNameMaxLength);
                b.Property(x => x.RegistrationName_EN).HasColumnName(nameof(TbCompanyBusinessDetail.RegistrationName_EN)).HasMaxLength(TbCompanyBusinessDetailConsts.RegistrationName_ENMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyBusinessDetail.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyBusinessDetail.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyBusinessDetail.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyBusinessDetail.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyBusinessDetail.mod_user));
            });

        } 
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyMapping>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyMapping", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyMapping.CompanyId));
                b.Property(x => x.CompanyTypeShareholdingCode).HasColumnName(nameof(TbCompanyMapping.CompanyTypeShareholdingCode));
                b.Property(x => x.CompanyTypesCode).HasColumnName(nameof(TbCompanyMapping.CompanyTypesCode));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyMapping.Note));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyMapping.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyMapping.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyMapping.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyMapping.mod_user));
                b.Property(x => x.idCompanyTypeShareholdingCode).HasColumnName(nameof(TbCompanyMapping.idCompanyTypeShareholdingCode));
                b.Property(x => x.idCompanyTypesCode).HasColumnName(nameof(TbCompanyMapping.idCompanyTypesCode));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyStock>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyStock", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyStock.CompanyId)).IsRequired();
                b.Property(x => x.CompanyCode).HasColumnName(nameof(TbCompanyStock.CompanyCode)).IsRequired().HasMaxLength(TbCompanyStockConsts.CompanyCodeMaxLength);
                b.Property(x => x.IsPublicCompany).HasColumnName(nameof(TbCompanyStock.IsPublicCompany)).IsRequired();
                b.Property(x => x.StockExchange).HasColumnName(nameof(TbCompanyStock.StockExchange)).HasMaxLength(TbCompanyStockConsts.StockExchangeMaxLength);
                b.Property(x => x.RegistrationDate).HasColumnName(nameof(TbCompanyStock.RegistrationDate));
                b.Property(x => x.CharteredCapital).HasColumnName(nameof(TbCompanyStock.CharteredCapital));
                b.Property(x => x.ParValue).HasColumnName(nameof(TbCompanyStock.ParValue));
                b.Property(x => x.TotalShare).HasColumnName(nameof(TbCompanyStock.TotalShare));
                b.Property(x => x.ListedShare).HasColumnName(nameof(TbCompanyStock.ListedShare));
                b.Property(x => x.Description).HasColumnName(nameof(TbCompanyStock.Description)).HasMaxLength(TbCompanyStockConsts.DescriptionMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyStock.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyStock.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyStock.crt_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompany_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.idCompany).HasColumnName(nameof(TbCompanyTemp.idCompany)).IsRequired();
                b.Property(x => x.ParentId).HasColumnName(nameof(TbCompanyTemp.ParentId)).IsRequired();
                b.Property(x => x.IsGroup).HasColumnName(nameof(TbCompanyTemp.IsGroup)).IsRequired();
                b.Property(x => x.Code).HasColumnName(nameof(TbCompanyTemp.Code)).IsRequired().HasMaxLength(TbCompanyTempConsts.CodeMaxLength);
                b.Property(x => x.Name).HasColumnName(nameof(TbCompanyTemp.Name)).IsRequired().HasMaxLength(TbCompanyTempConsts.NameMaxLength);
                b.Property(x => x.Name_EN).HasColumnName(nameof(TbCompanyTemp.Name_EN)).HasMaxLength(TbCompanyTempConsts.Name_ENMaxLength);
                b.Property(x => x.BriefName).HasColumnName(nameof(TbCompanyTemp.BriefName)).HasMaxLength(TbCompanyTempConsts.BriefNameMaxLength);
                b.Property(x => x.ContactInfo_01).HasColumnName(nameof(TbCompanyTemp.ContactInfo_01)).HasMaxLength(TbCompanyTempConsts.ContactInfo_01MaxLength);
                b.Property(x => x.ContactInfo_02).HasColumnName(nameof(TbCompanyTemp.ContactInfo_02)).HasMaxLength(TbCompanyTempConsts.ContactInfo_02MaxLength);
                b.Property(x => x.ContactInfo_03).HasColumnName(nameof(TbCompanyTemp.ContactInfo_03)).HasMaxLength(TbCompanyTempConsts.ContactInfo_03MaxLength);
                b.Property(x => x.ContactInfo_04).HasColumnName(nameof(TbCompanyTemp.ContactInfo_04)).HasMaxLength(TbCompanyTempConsts.ContactInfo_04MaxLength);
                b.Property(x => x.ContactInfo_05).HasColumnName(nameof(TbCompanyTemp.ContactInfo_05)).HasMaxLength(TbCompanyTempConsts.ContactInfo_05MaxLength);
                b.Property(x => x.ContactInfo_06).HasColumnName(nameof(TbCompanyTemp.ContactInfo_06)).HasMaxLength(TbCompanyTempConsts.ContactInfo_06MaxLength);
                b.Property(x => x.StockCode).HasColumnName(nameof(TbCompanyTemp.StockCode)).HasMaxLength(TbCompanyTempConsts.StockCodeMaxLength);
                b.Property(x => x.StockExchange).HasColumnName(nameof(TbCompanyTemp.StockExchange)).HasMaxLength(TbCompanyTempConsts.StockExchangeMaxLength);
                b.Property(x => x.StockRegistrationDate).HasColumnName(nameof(TbCompanyTemp.StockRegistrationDate));
                b.Property(x => x.IsPublicCompany).HasColumnName(nameof(TbCompanyTemp.IsPublicCompany));
                b.Property(x => x.LicenseNo).HasColumnName(nameof(TbCompanyTemp.LicenseNo)).HasMaxLength(TbCompanyTempConsts.LicenseNoMaxLength);
                b.Property(x => x.License).HasColumnName(nameof(TbCompanyTemp.License)).HasMaxLength(TbCompanyTempConsts.LicenseMaxLength);
                b.Property(x => x.RegistrationOrder).HasColumnName(nameof(TbCompanyTemp.RegistrationOrder));
                b.Property(x => x.RegistrationDate0).HasColumnName(nameof(TbCompanyTemp.RegistrationDate0));
                b.Property(x => x.RegistrationDate).HasColumnName(nameof(TbCompanyTemp.RegistrationDate));
                b.Property(x => x.LatestAmendment).HasColumnName(nameof(TbCompanyTemp.LatestAmendment));
                b.Property(x => x.LegalRepresent).HasColumnName(nameof(TbCompanyTemp.LegalRepresent)).HasMaxLength(TbCompanyTempConsts.LegalRepresentMaxLength);
                b.Property(x => x.CompanyType).HasColumnName(nameof(TbCompanyTemp.CompanyType)).HasMaxLength(TbCompanyTempConsts.CompanyTypeMaxLength);
                b.Property(x => x.CharteredCapital).HasColumnName(nameof(TbCompanyTemp.CharteredCapital));
                b.Property(x => x.TotalShare).HasColumnName(nameof(TbCompanyTemp.TotalShare));
                b.Property(x => x.ListedShare).HasColumnName(nameof(TbCompanyTemp.ListedShare));
                b.Property(x => x.ParValue).HasColumnName(nameof(TbCompanyTemp.ParValue));
                b.Property(x => x.ContactName1).HasColumnName(nameof(TbCompanyTemp.ContactName1)).HasMaxLength(TbCompanyTempConsts.ContactName1MaxLength);
                b.Property(x => x.ContactDept1).HasColumnName(nameof(TbCompanyTemp.ContactDept1)).HasMaxLength(TbCompanyTempConsts.ContactDept1MaxLength);
                b.Property(x => x.ContactMail1).HasColumnName(nameof(TbCompanyTemp.ContactMail1)).HasMaxLength(TbCompanyTempConsts.ContactMail1MaxLength);
                b.Property(x => x.ContactPosition1).HasColumnName(nameof(TbCompanyTemp.ContactPosition1)).HasMaxLength(TbCompanyTempConsts.ContactPosition1MaxLength);
                b.Property(x => x.ContactPhone1).HasColumnName(nameof(TbCompanyTemp.ContactPhone1)).HasMaxLength(TbCompanyTempConsts.ContactPhone1MaxLength);
                b.Property(x => x.ContactName2).HasColumnName(nameof(TbCompanyTemp.ContactName2)).HasMaxLength(TbCompanyTempConsts.ContactName2MaxLength);
                b.Property(x => x.ContactDept2).HasColumnName(nameof(TbCompanyTemp.ContactDept2)).HasMaxLength(TbCompanyTempConsts.ContactDept2MaxLength);
                b.Property(x => x.ContactMail2).HasColumnName(nameof(TbCompanyTemp.ContactMail2)).HasMaxLength(TbCompanyTempConsts.ContactMail2MaxLength);
                b.Property(x => x.ContactPosition2).HasColumnName(nameof(TbCompanyTemp.ContactPosition2)).HasMaxLength(TbCompanyTempConsts.ContactPosition2MaxLength);
                b.Property(x => x.ContactPhone2).HasColumnName(nameof(TbCompanyTemp.ContactPhone2)).HasMaxLength(TbCompanyTempConsts.ContactPhone2MaxLength);
                b.Property(x => x.longtitude).HasColumnName(nameof(TbCompanyTemp.longtitude));
                b.Property(x => x.latitude).HasColumnName(nameof(TbCompanyTemp.latitude));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyTemp.Note)).HasMaxLength(TbCompanyTempConsts.NoteMaxLength);
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbCompanyTemp.DocStatus));
                b.Property(x => x.DirectShareholding).HasColumnName(nameof(TbCompanyTemp.DirectShareholding));
                b.Property(x => x.ConsolidatedShareholding).HasColumnName(nameof(TbCompanyTemp.ConsolidatedShareholding));
                b.Property(x => x.ConsolidateNoted).HasColumnName(nameof(TbCompanyTemp.ConsolidateNoted));
                b.Property(x => x.VotingRightDirect).HasColumnName(nameof(TbCompanyTemp.VotingRightDirect));
                b.Property(x => x.VotingRightTotal).HasColumnName(nameof(TbCompanyTemp.VotingRightTotal));
                b.Property(x => x.Image).HasColumnName(nameof(TbCompanyTemp.Image));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyTemp.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyTemp.mod_user));
                b.Property(x => x.BravoCode).HasColumnName(nameof(TbCompanyTemp.BravoCode)).HasMaxLength(TbCompanyTempConsts.BravoCodeMaxLength);
                b.Property(x => x.LegacyCode).HasColumnName(nameof(TbCompanyTemp.LegacyCode)).HasMaxLength(TbCompanyTempConsts.LegacyCodeMaxLength);
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbConfigRetirementTime>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbConfigRetirementTime", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Code).HasColumnName(nameof(TbConfigRetirementTime.Code));
                b.Property(x => x.YearNumb).HasColumnName(nameof(TbConfigRetirementTime.YearNumb));
                b.Property(x => x.MonthNumb).HasColumnName(nameof(TbConfigRetirementTime.MonthNumb));
                b.Property(x => x.DayNumb).HasColumnName(nameof(TbConfigRetirementTime.DayNumb));
                b.Property(x => x.Note).HasColumnName(nameof(TbConfigRetirementTime.Note));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbConfigRetirementTime.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbConfigRetirementTime.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbConfigRetirementTime.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbConfigRetirementTime.mod_user));
            });

        } 
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbHisBrewery>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbHisBrewery", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.IsSendMail).HasColumnName(nameof(TbHisBrewery.IsSendMail));
                b.Property(x => x.DateSendMail).HasColumnName(nameof(TbHisBrewery.DateSendMail));
                b.Property(x => x.InsertDate).HasColumnName(nameof(TbHisBrewery.InsertDate)).IsRequired();
                b.Property(x => x.Type).HasColumnName(nameof(TbHisBrewery.Type)).IsRequired();
                b.Property(x => x.IdBrewery).HasColumnName(nameof(TbHisBrewery.IdBrewery)).IsRequired();
                b.Property(x => x.BreweryName).HasColumnName(nameof(TbHisBrewery.BreweryName)).IsRequired().HasMaxLength(TbHisBreweryConsts.BreweryNameMaxLength);
                b.Property(x => x.BreweryName_EN).HasColumnName(nameof(TbHisBrewery.BreweryName_EN)).HasMaxLength(TbHisBreweryConsts.BreweryName_ENMaxLength);
                b.Property(x => x.BreweryAdress).HasColumnName(nameof(TbHisBrewery.BreweryAdress));
                b.Property(x => x.BriefName).HasColumnName(nameof(TbHisBrewery.BriefName));
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbHisBrewery.CompanyId)).IsRequired();
                b.Property(x => x.CapacityVolume).HasColumnName(nameof(TbHisBrewery.CapacityVolume));
                b.Property(x => x.DeliveryVolume).HasColumnName(nameof(TbHisBrewery.DeliveryVolume));
                b.Property(x => x.Note).HasColumnName(nameof(TbHisBrewery.Note));
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbHisBrewery.DocStatus));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbHisBrewery.IsActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbHisBrewery.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbHisBrewery.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbHisBrewery.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbHisBrewery.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbHisBreweryDeliveryVolume>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbHisBreweryDeliveryVolume", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.IsSendMail).HasColumnName(nameof(TbHisBreweryDeliveryVolume.IsSendMail));
                b.Property(x => x.DateSendMail).HasColumnName(nameof(TbHisBreweryDeliveryVolume.DateSendMail));
                b.Property(x => x.InsertDate).HasColumnName(nameof(TbHisBreweryDeliveryVolume.InsertDate));
                b.Property(x => x.Type).HasColumnName(nameof(TbHisBreweryDeliveryVolume.Type)).IsRequired();
                b.Property(x => x.IdBreweryDeliveryVolume).HasColumnName(nameof(TbHisBreweryDeliveryVolume.IdBreweryDeliveryVolume)).IsRequired();
                b.Property(x => x.BreweryId).HasColumnName(nameof(TbHisBreweryDeliveryVolume.BreweryId));
                b.Property(x => x.BreweryCode).HasColumnName(nameof(TbHisBreweryDeliveryVolume.BreweryCode)).HasMaxLength(TbHisBreweryDeliveryVolumeConsts.BreweryCodeMaxLength);
                b.Property(x => x.Year).HasColumnName(nameof(TbHisBreweryDeliveryVolume.Year));
                b.Property(x => x.DeliveryVolume).HasColumnName(nameof(TbHisBreweryDeliveryVolume.DeliveryVolume));
                b.Property(x => x.isActive).HasColumnName(nameof(TbHisBreweryDeliveryVolume.isActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbHisBreweryDeliveryVolume.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbHisBreweryDeliveryVolume.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbHisBreweryDeliveryVolume.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbHisBreweryDeliveryVolume.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbHisBrewerySku>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbHisBrewerySKU", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.IsSendMail).HasColumnName(nameof(TbHisBrewerySku.IsSendMail));
                b.Property(x => x.DateSendMail).HasColumnName(nameof(TbHisBrewerySku.DateSendMail));
                b.Property(x => x.InsertDate).HasColumnName(nameof(TbHisBrewerySku.InsertDate));
                b.Property(x => x.Type).HasColumnName(nameof(TbHisBrewerySku.Type)).IsRequired();
                b.Property(x => x.IdBrewerySKU).HasColumnName(nameof(TbHisBrewerySku.IdBrewerySKU)).IsRequired();
                b.Property(x => x.Year).HasColumnName(nameof(TbHisBrewerySku.Year));
                b.Property(x => x.BreweryCode).HasColumnName(nameof(TbHisBrewerySku.BreweryCode)).HasMaxLength(TbHisBrewerySkuConsts.BreweryCodeMaxLength);
                b.Property(x => x.SKUCode).HasColumnName(nameof(TbHisBrewerySku.SKUCode)).HasMaxLength(TbHisBrewerySkuConsts.SKUCodeMaxLength);
                b.Property(x => x.ProductionVolume).HasColumnName(nameof(TbHisBrewerySku.ProductionVolume));
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbHisBrewerySku.DocStatus));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbHisBrewerySku.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbHisBrewerySku.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbHisBrewerySku.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbHisBrewerySku.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbHisBrewerySku.mod_user));
                b.Property(x => x.BreweryId).HasColumnName(nameof(TbHisBrewerySku.BreweryId));
                b.Property(x => x.SKUId).HasColumnName(nameof(TbHisBrewerySku.SKUId));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbHisCompany>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbHisCompany", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.IsSendMail).HasColumnName(nameof(TbHisCompany.IsSendMail));
                b.Property(x => x.DateSendMail).HasColumnName(nameof(TbHisCompany.DateSendMail));
                b.Property(x => x.InsertDate).HasColumnName(nameof(TbHisCompany.InsertDate));
                b.Property(x => x.Type).HasColumnName(nameof(TbHisCompany.Type)).IsRequired();
                b.Property(x => x.IdCompany).HasColumnName(nameof(TbHisCompany.IdCompany)).IsRequired();
                b.Property(x => x.ParentId).HasColumnName(nameof(TbHisCompany.ParentId)).IsRequired();
                b.Property(x => x.IsGroup).HasColumnName(nameof(TbHisCompany.IsGroup)).IsRequired();
                b.Property(x => x.Code).HasColumnName(nameof(TbHisCompany.Code)).IsRequired().HasMaxLength(TbHisCompanyConsts.CodeMaxLength);
                b.Property(x => x.Name).HasColumnName(nameof(TbHisCompany.Name)).IsRequired().HasMaxLength(TbHisCompanyConsts.NameMaxLength);
                b.Property(x => x.Name_EN).HasColumnName(nameof(TbHisCompany.Name_EN)).HasMaxLength(TbHisCompanyConsts.Name_ENMaxLength);
                b.Property(x => x.BriefName).HasColumnName(nameof(TbHisCompany.BriefName)).HasMaxLength(TbHisCompanyConsts.BriefNameMaxLength);
                b.Property(x => x.ContactInfo_01).HasColumnName(nameof(TbHisCompany.ContactInfo_01)).HasMaxLength(TbHisCompanyConsts.ContactInfo_01MaxLength);
                b.Property(x => x.ContactInfo_02).HasColumnName(nameof(TbHisCompany.ContactInfo_02)).HasMaxLength(TbHisCompanyConsts.ContactInfo_02MaxLength);
                b.Property(x => x.ContactInfo_03).HasColumnName(nameof(TbHisCompany.ContactInfo_03)).HasMaxLength(TbHisCompanyConsts.ContactInfo_03MaxLength);
                b.Property(x => x.ContactInfo_04).HasColumnName(nameof(TbHisCompany.ContactInfo_04)).HasMaxLength(TbHisCompanyConsts.ContactInfo_04MaxLength);
                b.Property(x => x.ContactInfo_05).HasColumnName(nameof(TbHisCompany.ContactInfo_05)).HasMaxLength(TbHisCompanyConsts.ContactInfo_05MaxLength);
                b.Property(x => x.ContactInfo_06).HasColumnName(nameof(TbHisCompany.ContactInfo_06)).HasMaxLength(TbHisCompanyConsts.ContactInfo_06MaxLength);
                b.Property(x => x.StockCode).HasColumnName(nameof(TbHisCompany.StockCode)).HasMaxLength(TbHisCompanyConsts.StockCodeMaxLength);
                b.Property(x => x.StockExchange).HasColumnName(nameof(TbHisCompany.StockExchange)).HasMaxLength(TbHisCompanyConsts.StockExchangeMaxLength);
                b.Property(x => x.StockRegistrationDate).HasColumnName(nameof(TbHisCompany.StockRegistrationDate));
                b.Property(x => x.IsPublicCompany).HasColumnName(nameof(TbHisCompany.IsPublicCompany));
                b.Property(x => x.LicenseNo).HasColumnName(nameof(TbHisCompany.LicenseNo)).HasMaxLength(TbHisCompanyConsts.LicenseNoMaxLength);
                b.Property(x => x.License).HasColumnName(nameof(TbHisCompany.License)).HasMaxLength(TbHisCompanyConsts.LicenseMaxLength);
                b.Property(x => x.RegistrationOrder).HasColumnName(nameof(TbHisCompany.RegistrationOrder));
                b.Property(x => x.RegistrationDate0).HasColumnName(nameof(TbHisCompany.RegistrationDate0));
                b.Property(x => x.RegistrationDate).HasColumnName(nameof(TbHisCompany.RegistrationDate));
                b.Property(x => x.LatestAmendment).HasColumnName(nameof(TbHisCompany.LatestAmendment));
                b.Property(x => x.LegalRepresent).HasColumnName(nameof(TbHisCompany.LegalRepresent)).HasMaxLength(TbHisCompanyConsts.LegalRepresentMaxLength);
                b.Property(x => x.CompanyType).HasColumnName(nameof(TbHisCompany.CompanyType)).HasMaxLength(TbHisCompanyConsts.CompanyTypeMaxLength);
                b.Property(x => x.CharteredCapital).HasColumnName(nameof(TbHisCompany.CharteredCapital));
                b.Property(x => x.TotalShare).HasColumnName(nameof(TbHisCompany.TotalShare));
                b.Property(x => x.ListedShare).HasColumnName(nameof(TbHisCompany.ListedShare));
                b.Property(x => x.ParValue).HasColumnName(nameof(TbHisCompany.ParValue));
                b.Property(x => x.ContactName1).HasColumnName(nameof(TbHisCompany.ContactName1)).HasMaxLength(TbHisCompanyConsts.ContactName1MaxLength);
                b.Property(x => x.ContactDept1).HasColumnName(nameof(TbHisCompany.ContactDept1)).HasMaxLength(TbHisCompanyConsts.ContactDept1MaxLength);
                b.Property(x => x.ContactMail1).HasColumnName(nameof(TbHisCompany.ContactMail1)).HasMaxLength(TbHisCompanyConsts.ContactMail1MaxLength);
                b.Property(x => x.ContactPosition1).HasColumnName(nameof(TbHisCompany.ContactPosition1)).HasMaxLength(TbHisCompanyConsts.ContactPosition1MaxLength);
                b.Property(x => x.ContactPhone1).HasColumnName(nameof(TbHisCompany.ContactPhone1)).HasMaxLength(TbHisCompanyConsts.ContactPhone1MaxLength);
                b.Property(x => x.ContactName2).HasColumnName(nameof(TbHisCompany.ContactName2)).HasMaxLength(TbHisCompanyConsts.ContactName2MaxLength);
                b.Property(x => x.ContactDept2).HasColumnName(nameof(TbHisCompany.ContactDept2)).HasMaxLength(TbHisCompanyConsts.ContactDept2MaxLength);
                b.Property(x => x.ContactMail2).HasColumnName(nameof(TbHisCompany.ContactMail2)).HasMaxLength(TbHisCompanyConsts.ContactMail2MaxLength);
                b.Property(x => x.ContactPosition2).HasColumnName(nameof(TbHisCompany.ContactPosition2)).HasMaxLength(TbHisCompanyConsts.ContactPosition2MaxLength);
                b.Property(x => x.ContactPhone2).HasColumnName(nameof(TbHisCompany.ContactPhone2)).HasMaxLength(TbHisCompanyConsts.ContactPhone2MaxLength);
                b.Property(x => x.longtitude).HasColumnName(nameof(TbHisCompany.longtitude));
                b.Property(x => x.latitude).HasColumnName(nameof(TbHisCompany.latitude));
                b.Property(x => x.Note).HasColumnName(nameof(TbHisCompany.Note)).HasMaxLength(TbHisCompanyConsts.NoteMaxLength);
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbHisCompany.DocStatus));
                b.Property(x => x.DirectShareholding).HasColumnName(nameof(TbHisCompany.DirectShareholding));
                b.Property(x => x.ConsolidatedShareholding).HasColumnName(nameof(TbHisCompany.ConsolidatedShareholding));
                b.Property(x => x.ConsolidateNoted).HasColumnName(nameof(TbHisCompany.ConsolidateNoted));
                b.Property(x => x.VotingRightDirect).HasColumnName(nameof(TbHisCompany.VotingRightDirect));
                b.Property(x => x.VotingRightTotal).HasColumnName(nameof(TbHisCompany.VotingRightTotal));
                b.Property(x => x.Image).HasColumnName(nameof(TbHisCompany.Image));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbHisCompany.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbHisCompany.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbHisCompany.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbHisCompany.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbHisCompany.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbHisLogPrinting>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbHisLogPrinting", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.IsSendMail).HasColumnName(nameof(TbHisLogPrinting.IsSendMail));
                b.Property(x => x.DateSendMail).HasColumnName(nameof(TbHisLogPrinting.DateSendMail));
                b.Property(x => x.Type).HasColumnName(nameof(TbHisLogPrinting.Type));
                b.Property(x => x.InsertDate).HasColumnName(nameof(TbHisLogPrinting.InsertDate)).IsRequired();
                b.Property(x => x.UserName).HasColumnName(nameof(TbHisLogPrinting.UserName)).HasMaxLength(TbHisLogPrintingConsts.UserNameMaxLength);
                b.Property(x => x.CompanyCode).HasColumnName(nameof(TbHisLogPrinting.CompanyCode)).HasMaxLength(TbHisLogPrintingConsts.CompanyCodeMaxLength);
                b.Property(x => x.FileLanguage).HasColumnName(nameof(TbHisLogPrinting.FileLanguage)).HasMaxLength(TbHisLogPrintingConsts.FileLanguageMaxLength);
                b.Property(x => x.IsPrinting).HasColumnName(nameof(TbHisLogPrinting.IsPrinting));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbHisPerson>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbHisPerson", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.IsSendMail).HasColumnName(nameof(TbHisPerson.IsSendMail));
                b.Property(x => x.DateSendMail).HasColumnName(nameof(TbHisPerson.DateSendMail));
                b.Property(x => x.InsertDate).HasColumnName(nameof(TbHisPerson.InsertDate));
                b.Property(x => x.Type).HasColumnName(nameof(TbHisPerson.Type)).IsRequired();
                b.Property(x => x.IdPerson).HasColumnName(nameof(TbHisPerson.IdPerson)).IsRequired();
                b.Property(x => x.Code).HasColumnName(nameof(TbHisPerson.Code)).IsRequired().HasMaxLength(TbHisPersonConsts.CodeMaxLength);
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbHisPerson.CompanyId));
                b.Property(x => x.FullName).HasColumnName(nameof(TbHisPerson.FullName)).IsRequired().HasMaxLength(TbHisPersonConsts.FullNameMaxLength);
                b.Property(x => x.BirthDate).HasColumnName(nameof(TbHisPerson.BirthDate)).IsRequired();
                b.Property(x => x.BirthPlace).HasColumnName(nameof(TbHisPerson.BirthPlace)).HasMaxLength(TbHisPersonConsts.BirthPlaceMaxLength);
                b.Property(x => x.Address).HasColumnName(nameof(TbHisPerson.Address)).HasMaxLength(TbHisPersonConsts.AddressMaxLength);
                b.Property(x => x.IDCardNo).HasColumnName(nameof(TbHisPerson.IDCardNo)).HasMaxLength(TbHisPersonConsts.IDCardNoMaxLength);
                b.Property(x => x.IDCardDate).HasColumnName(nameof(TbHisPerson.IDCardDate));
                b.Property(x => x.IdCardIssuePlace).HasColumnName(nameof(TbHisPerson.IdCardIssuePlace)).HasMaxLength(TbHisPersonConsts.IdCardIssuePlaceMaxLength);
                b.Property(x => x.Ethnicity).HasColumnName(nameof(TbHisPerson.Ethnicity)).HasMaxLength(TbHisPersonConsts.EthnicityMaxLength);
                b.Property(x => x.Religion).HasColumnName(nameof(TbHisPerson.Religion)).HasMaxLength(TbHisPersonConsts.ReligionMaxLength);
                b.Property(x => x.NationalityCode).HasColumnName(nameof(TbHisPerson.NationalityCode)).HasMaxLength(TbHisPersonConsts.NationalityCodeMaxLength);
                b.Property(x => x.Gender).HasColumnName(nameof(TbHisPerson.Gender)).HasMaxLength(TbHisPersonConsts.GenderMaxLength);
                b.Property(x => x.Phone).HasColumnName(nameof(TbHisPerson.Phone)).HasMaxLength(TbHisPersonConsts.PhoneMaxLength);
                b.Property(x => x.Email).HasColumnName(nameof(TbHisPerson.Email)).HasMaxLength(TbHisPersonConsts.EmailMaxLength);
                b.Property(x => x.Note).HasColumnName(nameof(TbHisPerson.Note)).HasMaxLength(TbHisPersonConsts.NoteMaxLength);
                b.Property(x => x.Image).HasColumnName(nameof(TbHisPerson.Image));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbHisPerson.IsActive));
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbHisPerson.DocStatus));
                b.Property(x => x.IsCheckRetirement).HasColumnName(nameof(TbHisPerson.IsCheckRetirement));
                b.Property(x => x.IsCheckTermEnd).HasColumnName(nameof(TbHisPerson.IsCheckTermEnd));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbHisPerson.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbHisPerson.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbHisPerson.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbHisPerson.mod_user));
                b.Property(x => x.OldCode).HasColumnName(nameof(TbHisPerson.OldCode)).HasMaxLength(TbHisPersonConsts.OldCodeMaxLength);
            });

        } 
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbHisCompanyPerson>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbHisCompanyPerson", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.IsSendMail).HasColumnName(nameof(TbHisCompanyPerson.IsSendMail));
                b.Property(x => x.DateSendMail).HasColumnName(nameof(TbHisCompanyPerson.DateSendMail));
                b.Property(x => x.InsertDate).HasColumnName(nameof(TbHisCompanyPerson.InsertDate));
                b.Property(x => x.Type).HasColumnName(nameof(TbHisCompanyPerson.Type)).IsRequired();
                b.Property(x => x.BranchCode).HasColumnName(nameof(TbHisCompanyPerson.BranchCode)).HasMaxLength(TbHisCompanyPersonConsts.BranchCodeMaxLength);
                b.Property(x => x.IdCompanyPerson).HasColumnName(nameof(TbHisCompanyPerson.IdCompanyPerson)).IsRequired();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbHisCompanyPerson.CompanyId)).IsRequired();
                b.Property(x => x.PersonId).HasColumnName(nameof(TbHisCompanyPerson.PersonId)).IsRequired();
                b.Property(x => x.FromDate).HasColumnName(nameof(TbHisCompanyPerson.FromDate));
                b.Property(x => x.ToDate).HasColumnName(nameof(TbHisCompanyPerson.ToDate));
                b.Property(x => x.PositionId).HasColumnName(nameof(TbHisCompanyPerson.PositionId));
                b.Property(x => x.PositionCode).HasColumnName(nameof(TbHisCompanyPerson.PositionCode)).HasMaxLength(TbHisCompanyPersonConsts.PositionCodeMaxLength);
                b.Property(x => x.PersonalValue).HasColumnName(nameof(TbHisCompanyPerson.PersonalValue));
                b.Property(x => x.PersonalSharePercentage).HasColumnName(nameof(TbHisCompanyPerson.PersonalSharePercentage));
                b.Property(x => x.OwnerValue).HasColumnName(nameof(TbHisCompanyPerson.OwnerValue));
                b.Property(x => x.RepresentativePercentage).HasColumnName(nameof(TbHisCompanyPerson.RepresentativePercentage));
                b.Property(x => x.Note).HasColumnName(nameof(TbHisCompanyPerson.Note)).HasMaxLength(TbHisCompanyPersonConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbHisCompanyPerson.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbHisCompanyPerson.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbHisCompanyPerson.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbHisCompanyPerson.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbHisCompanyPerson.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbLandInfo>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbLandInfo", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbLandInfo.CompanyId)).IsRequired();
                b.Property(x => x.Description).HasColumnName(nameof(TbLandInfo.Description));
                b.Property(x => x.Address).HasColumnName(nameof(TbLandInfo.Address));
                b.Property(x => x.TypeOfLand).HasColumnName(nameof(TbLandInfo.TypeOfLand)).IsRequired();
                b.Property(x => x.Area).HasColumnName(nameof(TbLandInfo.Area));
                b.Property(x => x.SupportingDocument).HasColumnName(nameof(TbLandInfo.SupportingDocument));
                b.Property(x => x.IssueDate).HasColumnName(nameof(TbLandInfo.IssueDate));
                b.Property(x => x.ExpiryDate).HasColumnName(nameof(TbLandInfo.ExpiryDate));
                b.Property(x => x.Payment).HasColumnName(nameof(TbLandInfo.Payment));
                b.Property(x => x.Remark).HasColumnName(nameof(TbLandInfo.Remark));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbLandInfo.IsActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbLandInfo.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbLandInfo.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbLandInfo.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbLandInfo.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbLogError>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbLogError", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.TimeLog).HasColumnName(nameof(TbLogError.TimeLog)).IsRequired();
                b.Property(x => x.UserLog).HasColumnName(nameof(TbLogError.UserLog)).IsRequired();
                b.Property(x => x.IPAddress).HasColumnName(nameof(TbLogError.IPAddress));
                b.Property(x => x.ClassLog).HasColumnName(nameof(TbLogError.ClassLog));
                b.Property(x => x.FunctionLog).HasColumnName(nameof(TbLogError.FunctionLog)).IsRequired();
                b.Property(x => x.ReasonFailed).HasColumnName(nameof(TbLogError.ReasonFailed)).IsRequired();
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbLogExportData>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbLogExportData", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.TimeExport).HasColumnName(nameof(TbLogExportData.TimeExport)).IsRequired();
                b.Property(x => x.IsSuccess).HasColumnName(nameof(TbLogExportData.IsSuccess)).IsRequired();
                b.Property(x => x.UserExport).HasColumnName(nameof(TbLogExportData.UserExport)).IsRequired();
                b.Property(x => x.TableName).HasColumnName(nameof(TbLogExportData.TableName));
                b.Property(x => x.ReasonExportFailed).HasColumnName(nameof(TbLogExportData.ReasonExportFailed));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbLogLogin>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbLogLogin", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.UserName).HasColumnName(nameof(TbLogLogin.UserName));
                b.Property(x => x.LoginDate).HasColumnName(nameof(TbLogLogin.LoginDate));
                b.Property(x => x.IPTracking).HasColumnName(nameof(TbLogLogin.IPTracking)).IsRequired();
                b.Property(x => x.StatusLogin).HasColumnName(nameof(TbLogLogin.StatusLogin));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbLogPrinting>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbLogPrinting", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.userName).HasColumnName(nameof(TbLogPrinting.userName)).HasMaxLength(TbLogPrintingConsts.userNameMaxLength);
                b.Property(x => x.companyCode).HasColumnName(nameof(TbLogPrinting.companyCode)).HasMaxLength(TbLogPrintingConsts.companyCodeMaxLength);
                b.Property(x => x.fileLanguage).HasColumnName(nameof(TbLogPrinting.fileLanguage)).HasMaxLength(TbLogPrintingConsts.fileLanguageMaxLength);
                b.Property(x => x.isPrinting).HasColumnName(nameof(TbLogPrinting.isPrinting));
                b.Property(x => x.printTime).HasColumnName(nameof(TbLogPrinting.printTime));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbLogRefeshAccount>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbLogRefeshAccount", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.AccessToken).HasColumnName(nameof(TbLogRefeshAccount.AccessToken)).IsRequired();
                b.Property(x => x.TimeRefesh).HasColumnName(nameof(TbLogRefeshAccount.TimeRefesh)).IsRequired();
                b.Property(x => x.IsSuccess).HasColumnName(nameof(TbLogRefeshAccount.IsSuccess)).IsRequired();
                b.Property(x => x.UseRefesh).HasColumnName(nameof(TbLogRefeshAccount.UseRefesh));
                b.Property(x => x.FailedReason).HasColumnName(nameof(TbLogRefeshAccount.FailedReason));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbLogSendEmail>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbLogSendEmail", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.TimeSend).HasColumnName(nameof(TbLogSendEmail.TimeSend)).IsRequired();
                b.Property(x => x.IsSuccess).HasColumnName(nameof(TbLogSendEmail.IsSuccess)).IsRequired();
                b.Property(x => x.UserSend).HasColumnName(nameof(TbLogSendEmail.UserSend));
                b.Property(x => x.TypeEmail).HasColumnName(nameof(TbLogSendEmail.TypeEmail));
                b.Property(x => x.FailedReason).HasColumnName(nameof(TbLogSendEmail.FailedReason));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbLogSendEmailRetirement>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbLogSendEmailRetirement", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.idCompany).HasColumnName(nameof(TbLogSendEmailRetirement.idCompany));
                b.Property(x => x.idPerson).HasColumnName(nameof(TbLogSendEmailRetirement.idPerson));
                b.Property(x => x.IsSendEmail).HasColumnName(nameof(TbLogSendEmailRetirement.IsSendEmail));
                b.Property(x => x.DateSendEmail).HasColumnName(nameof(TbLogSendEmailRetirement.DateSendEmail));
                b.Property(x => x.Type).HasColumnName(nameof(TbLogSendEmailRetirement.Type));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbLogSyncUat>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbLogSyncUAT", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.TimeExport).HasColumnName(nameof(TbLogSyncUat.TimeExport)).IsRequired();
                b.Property(x => x.IsSuccess).HasColumnName(nameof(TbLogSyncUat.IsSuccess)).IsRequired();
                b.Property(x => x.UserExport).HasColumnName(nameof(TbLogSyncUat.UserExport)).IsRequired();
                b.Property(x => x.ReasonExportFailed).HasColumnName(nameof(TbLogSyncUat.ReasonExportFailed));
            });

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbMenu>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbMenu", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ControlName).HasColumnName(nameof(TbMenu.ControlName)).IsRequired().HasMaxLength(TbMenuConsts.ControlNameMaxLength);
                b.Property(x => x.Description).HasColumnName(nameof(TbMenu.Description)).IsRequired().HasMaxLength(TbMenuConsts.DescriptionMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbMenu.IsActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbMenu.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbMenu.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbMenu.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbMenu.mod_date));
            });

        }  
        if (builder.IsHostDatabase())
        {

        } 
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbRole>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbRole", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Code).HasColumnName(nameof(TbRole.Code)).IsRequired().HasMaxLength(TbRoleConsts.CodeMaxLength);
                b.Property(x => x.Name).HasColumnName(nameof(TbRole.Name)).IsRequired().HasMaxLength(TbRoleConsts.NameMaxLength);
                b.Property(x => x.Description).HasColumnName(nameof(TbRole.Description)).HasMaxLength(TbRoleConsts.DescriptionMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbRole.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbRole.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbRole.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbRole.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbRole.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbStockPrice>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbStockPrice", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.StockCode).HasColumnName(nameof(TbStockPrice.StockCode)).IsRequired().HasMaxLength(TbStockPriceConsts.StockCodeMaxLength);
                b.Property(x => x.StockDate).HasColumnName(nameof(TbStockPrice.StockDate));
                b.Property(x => x.LimitUpPrice).HasColumnName(nameof(TbStockPrice.LimitUpPrice));
                b.Property(x => x.LimitDownPrice).HasColumnName(nameof(TbStockPrice.LimitDownPrice));
                b.Property(x => x.ReferencePrice).HasColumnName(nameof(TbStockPrice.ReferencePrice));
                b.Property(x => x.SaleQty1).HasColumnName(nameof(TbStockPrice.SaleQty1));
                b.Property(x => x.SalePrice1).HasColumnName(nameof(TbStockPrice.SalePrice1));
                b.Property(x => x.SaleQty2).HasColumnName(nameof(TbStockPrice.SaleQty2));
                b.Property(x => x.SalePrice2).HasColumnName(nameof(TbStockPrice.SalePrice2));
                b.Property(x => x.SaleQty3).HasColumnName(nameof(TbStockPrice.SaleQty3));
                b.Property(x => x.SalePrice3).HasColumnName(nameof(TbStockPrice.SalePrice3));
                b.Property(x => x.BuyQty1).HasColumnName(nameof(TbStockPrice.BuyQty1));
                b.Property(x => x.BuyPrice1).HasColumnName(nameof(TbStockPrice.BuyPrice1));
                b.Property(x => x.BuyQty2).HasColumnName(nameof(TbStockPrice.BuyQty2));
                b.Property(x => x.BuyPrice2).HasColumnName(nameof(TbStockPrice.BuyPrice2));
                b.Property(x => x.BuyQty3).HasColumnName(nameof(TbStockPrice.BuyQty3));
                b.Property(x => x.BuyPrice3).HasColumnName(nameof(TbStockPrice.BuyPrice3));
                b.Property(x => x.TransactionPrice).HasColumnName(nameof(TbStockPrice.TransactionPrice));
                b.Property(x => x.TransactionQty).HasColumnName(nameof(TbStockPrice.TransactionQty));
                b.Property(x => x.TotalQty).HasColumnName(nameof(TbStockPrice.TotalQty));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbStockPrice.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbStockPrice.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbStockPrice.crt_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbSku>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbSKU", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Code).HasColumnName(nameof(TbSku.Code)).HasMaxLength(TbSkuConsts.CodeMaxLength);
                b.Property(x => x.Name).HasColumnName(nameof(TbSku.Name)).HasMaxLength(TbSkuConsts.NameMaxLength);
                b.Property(x => x.Name_EN).HasColumnName(nameof(TbSku.Name_EN)).HasMaxLength(TbSkuConsts.Name_ENMaxLength);
                b.Property(x => x.BrandCode).HasColumnName(nameof(TbSku.BrandCode)).HasMaxLength(TbSkuConsts.BrandCodeMaxLength);
                b.Property(x => x.Unit).HasColumnName(nameof(TbSku.Unit)).HasMaxLength(TbSkuConsts.UnitMaxLength);
                b.Property(x => x.ItemBaseType).HasColumnName(nameof(TbSku.ItemBaseType)).HasMaxLength(TbSkuConsts.ItemBaseTypeMaxLength);
                b.Property(x => x.PackSize).HasColumnName(nameof(TbSku.PackSize));
                b.Property(x => x.PackQuantity).HasColumnName(nameof(TbSku.PackQuantity));
                b.Property(x => x.Weight).HasColumnName(nameof(TbSku.Weight));
                b.Property(x => x.ExpiryDate).HasColumnName(nameof(TbSku.ExpiryDate));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbSku.IsActive));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbSku.crt_user));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbSku.crt_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbSku.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbSku.mod_date));
            });

        } 
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbUserInRole>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbUserInRole", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.RoleId).HasColumnName(nameof(TbUserInRole.RoleId)).IsRequired();
                b.Property(x => x.UserId).HasColumnName(nameof(TbUserInRole.UserId)).IsRequired();
                b.Property(x => x.IsActive).HasColumnName(nameof(TbUserInRole.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbUserInRole.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbUserInRole.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbUserInRole.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbUserInRole.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbTimeScript>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbTimeScript", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Code).HasColumnName(nameof(TbTimeScript.Code)).HasMaxLength(TbTimeScriptConsts.CodeMaxLength);
                b.Property(x => x.Year).HasColumnName(nameof(TbTimeScript.Year));
                b.Property(x => x.Month).HasColumnName(nameof(TbTimeScript.Month));
                b.Property(x => x.Day).HasColumnName(nameof(TbTimeScript.Day));
                b.Property(x => x.Hour).HasColumnName(nameof(TbTimeScript.Hour));
                b.Property(x => x.Minute).HasColumnName(nameof(TbTimeScript.Minute));
                b.Property(x => x.Second).HasColumnName(nameof(TbTimeScript.Second));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbNationality>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbNationality", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Code).HasColumnName(nameof(TbNationality.Code)).HasMaxLength(TbNationalityConsts.CodeMaxLength);
                b.Property(x => x.Code2).HasColumnName(nameof(TbNationality.Code2)).HasMaxLength(TbNationalityConsts.Code2MaxLength);
                b.Property(x => x.Name_en).HasColumnName(nameof(TbNationality.Name_en)).HasMaxLength(TbNationalityConsts.Name_enMaxLength);
                b.Property(x => x.Name_vn).HasColumnName(nameof(TbNationality.Name_vn)).HasMaxLength(TbNationalityConsts.Name_vnMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbNationality.IsActive));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyMajorTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyMajor_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyMajorTemp.CompanyId)).IsRequired();
                b.Property(x => x.ShareHolderMajor).HasColumnName(nameof(TbCompanyMajorTemp.ShareHolderMajor)).IsRequired();
                b.Property(x => x.ShareHolderType).HasColumnName(nameof(TbCompanyMajorTemp.ShareHolderType)).IsRequired().HasMaxLength(TbCompanyMajorTempConsts.ShareHolderTypeMaxLength);
                b.Property(x => x.FromDate).HasColumnName(nameof(TbCompanyMajorTemp.FromDate));
                b.Property(x => x.ToDate).HasColumnName(nameof(TbCompanyMajorTemp.ToDate));
                b.Property(x => x.ShareHolderValue).HasColumnName(nameof(TbCompanyMajorTemp.ShareHolderValue));
                b.Property(x => x.ShareHolderRate).HasColumnName(nameof(TbCompanyMajorTemp.ShareHolderRate));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyMajorTemp.Note)).HasMaxLength(TbCompanyMajorTempConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyMajorTemp.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyMajorTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyMajorTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyMajorTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyMajorTemp.mod_user));
                b.Property(x => x.ClassId).HasColumnName(nameof(TbCompanyMajorTemp.ClassId));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyBranchTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyBranch_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyBranchTemp.CompanyId));
                b.Property(x => x.BranchName).HasColumnName(nameof(TbCompanyBranchTemp.BranchName));
                b.Property(x => x.BranchAddress).HasColumnName(nameof(TbCompanyBranchTemp.BranchAddress));
                b.Property(x => x.BranchCode).HasColumnName(nameof(TbCompanyBranchTemp.BranchCode));
                b.Property(x => x.ContactPerson).HasColumnName(nameof(TbCompanyBranchTemp.ContactPerson));
                b.Property(x => x.ContactPhone).HasColumnName(nameof(TbCompanyBranchTemp.ContactPhone));
                b.Property(x => x.Email).HasColumnName(nameof(TbCompanyBranchTemp.Email));
                b.Property(x => x.isActive).HasColumnName(nameof(TbCompanyBranchTemp.isActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbCompanyBranchTemp.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbCompanyBranchTemp.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyBranchTemp.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyBranchTemp.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyBusinessTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyBusiness_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyBusinessTemp.CompanyId)).IsRequired();
                b.Property(x => x.License).HasColumnName(nameof(TbCompanyBusinessTemp.License)).HasMaxLength(TbCompanyBusinessTempConsts.LicenseMaxLength);
                b.Property(x => x.RegistrationNo).HasColumnName(nameof(TbCompanyBusinessTemp.RegistrationNo)).IsRequired();
                b.Property(x => x.RegistrationDate).HasColumnName(nameof(TbCompanyBusinessTemp.RegistrationDate)).IsRequired();
                b.Property(x => x.CompanyName).HasColumnName(nameof(TbCompanyBusinessTemp.CompanyName)).HasMaxLength(TbCompanyBusinessTempConsts.CompanyNameMaxLength);
                b.Property(x => x.CompanyAddress).HasColumnName(nameof(TbCompanyBusinessTemp.CompanyAddress)).HasMaxLength(TbCompanyBusinessTempConsts.CompanyAddressMaxLength);
                b.Property(x => x.LegalRepresent).HasColumnName(nameof(TbCompanyBusinessTemp.LegalRepresent)).HasMaxLength(TbCompanyBusinessTempConsts.LegalRepresentMaxLength);
                b.Property(x => x.CompanyType).HasColumnName(nameof(TbCompanyBusinessTemp.CompanyType)).HasMaxLength(TbCompanyBusinessTempConsts.CompanyTypeMaxLength);
                b.Property(x => x.MajorBusiness).HasColumnName(nameof(TbCompanyBusinessTemp.MajorBusiness)).HasMaxLength(TbCompanyBusinessTempConsts.MajorBusinessMaxLength);
                b.Property(x => x.OtherActivity).HasColumnName(nameof(TbCompanyBusinessTemp.OtherActivity)).HasMaxLength(TbCompanyBusinessTempConsts.OtherActivityMaxLength);
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyBusinessTemp.Note)).HasMaxLength(TbCompanyBusinessTempConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyBusinessTemp.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyBusinessTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyBusinessTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyBusinessTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyBusinessTemp.mod_user));
                b.Property(x => x.LatestAmendment).HasColumnName(nameof(TbCompanyBusinessTemp.LatestAmendment));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyBusinessDetailTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyBusinessDetail_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ParentId).HasColumnName(nameof(TbCompanyBusinessDetailTemp.ParentId)).IsRequired();
                b.Property(x => x.RegistrationCode).HasColumnName(nameof(TbCompanyBusinessDetailTemp.RegistrationCode)).IsRequired().HasMaxLength(TbCompanyBusinessDetailTempConsts.RegistrationCodeMaxLength);
                b.Property(x => x.RegistrationName).HasColumnName(nameof(TbCompanyBusinessDetailTemp.RegistrationName)).HasMaxLength(TbCompanyBusinessDetailTempConsts.RegistrationNameMaxLength);
                b.Property(x => x.RegistrationName_EN).HasColumnName(nameof(TbCompanyBusinessDetailTemp.RegistrationName_EN)).HasMaxLength(TbCompanyBusinessDetailTempConsts.RegistrationName_ENMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyBusinessDetailTemp.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyBusinessDetailTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyBusinessDetailTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyBusinessDetailTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyBusinessDetailTemp.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyMappingTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyMapping_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyMappingTemp.CompanyId));
                b.Property(x => x.CompanyTypeShareholdingCode).HasColumnName(nameof(TbCompanyMappingTemp.CompanyTypeShareholdingCode));
                b.Property(x => x.CompanyTypesCode).HasColumnName(nameof(TbCompanyMappingTemp.CompanyTypesCode));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyMappingTemp.Note));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyMappingTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyMappingTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyMappingTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyMappingTemp.mod_user));
                b.Property(x => x.idCompanyTypeShareholdingCode).HasColumnName(nameof(TbCompanyMappingTemp.idCompanyTypeShareholdingCode));
                b.Property(x => x.idCompanyTypesCode).HasColumnName(nameof(TbCompanyMappingTemp.idCompanyTypesCode));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyStockTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyStock_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyStockTemp.CompanyId)).IsRequired();
                b.Property(x => x.CompanyCode).HasColumnName(nameof(TbCompanyStockTemp.CompanyCode)).IsRequired().HasMaxLength(TbCompanyStockTempConsts.CompanyCodeMaxLength);
                b.Property(x => x.IsPublicCompany).HasColumnName(nameof(TbCompanyStockTemp.IsPublicCompany)).IsRequired();
                b.Property(x => x.StockExchange).HasColumnName(nameof(TbCompanyStockTemp.StockExchange)).HasMaxLength(TbCompanyStockTempConsts.StockExchangeMaxLength);
                b.Property(x => x.RegistrationDate).HasColumnName(nameof(TbCompanyStockTemp.RegistrationDate));
                b.Property(x => x.CharteredCapital).HasColumnName(nameof(TbCompanyStockTemp.CharteredCapital));
                b.Property(x => x.ParValue).HasColumnName(nameof(TbCompanyStockTemp.ParValue));
                b.Property(x => x.TotalShare).HasColumnName(nameof(TbCompanyStockTemp.TotalShare));
                b.Property(x => x.ListedShare).HasColumnName(nameof(TbCompanyStockTemp.ListedShare));
                b.Property(x => x.Description).HasColumnName(nameof(TbCompanyStockTemp.Description)).HasMaxLength(TbCompanyStockTempConsts.DescriptionMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyStockTemp.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyStockTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyStockTemp.crt_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbContactTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbContact_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.companyid).HasColumnName(nameof(TbContactTemp.companyid)).IsRequired();
                b.Property(x => x.ContactName).HasColumnName(nameof(TbContactTemp.ContactName)).IsRequired().HasMaxLength(TbContactTempConsts.ContactNameMaxLength);
                b.Property(x => x.ContactDept).HasColumnName(nameof(TbContactTemp.ContactDept)).HasMaxLength(TbContactTempConsts.ContactDeptMaxLength);
                b.Property(x => x.ContactPosition).HasColumnName(nameof(TbContactTemp.ContactPosition)).HasMaxLength(TbContactTempConsts.ContactPositionMaxLength);
                b.Property(x => x.ContactEmail).HasColumnName(nameof(TbContactTemp.ContactEmail)).HasMaxLength(TbContactTempConsts.ContactEmailMaxLength);
                b.Property(x => x.ContactPhone).HasColumnName(nameof(TbContactTemp.ContactPhone)).HasMaxLength(TbContactTempConsts.ContactPhoneMaxLength);
                b.Property(x => x.Note).HasColumnName(nameof(TbContactTemp.Note)).HasMaxLength(TbContactTempConsts.NoteMaxLength);
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbContactTemp.DocStatus));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbContactTemp.IsActive)).IsRequired();
                b.Property(x => x.crt_user).HasColumnName(nameof(TbContactTemp.crt_user));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbContactTemp.crt_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbContactTemp.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbContactTemp.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbLandInfoTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbLandInfo_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbLandInfoTemp.CompanyId)).IsRequired();
                b.Property(x => x.Description).HasColumnName(nameof(TbLandInfoTemp.Description));
                b.Property(x => x.Address).HasColumnName(nameof(TbLandInfoTemp.Address));
                b.Property(x => x.TypeOfLand).HasColumnName(nameof(TbLandInfoTemp.TypeOfLand)).IsRequired();
                b.Property(x => x.Area).HasColumnName(nameof(TbLandInfoTemp.Area));
                b.Property(x => x.SupportingDocument).HasColumnName(nameof(TbLandInfoTemp.SupportingDocument));
                b.Property(x => x.IssueDate).HasColumnName(nameof(TbLandInfoTemp.IssueDate));
                b.Property(x => x.ExpiryDate).HasColumnName(nameof(TbLandInfoTemp.ExpiryDate));
                b.Property(x => x.Payment).HasColumnName(nameof(TbLandInfoTemp.Payment));
                b.Property(x => x.Remark).HasColumnName(nameof(TbLandInfoTemp.Remark));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbLandInfoTemp.IsActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbLandInfoTemp.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbLandInfoTemp.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbLandInfoTemp.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbLandInfoTemp.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbNationalityTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbNationality_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Code).HasColumnName(nameof(TbNationalityTemp.Code)).HasMaxLength(TbNationalityTempConsts.CodeMaxLength);
                b.Property(x => x.Code2).HasColumnName(nameof(TbNationalityTemp.Code2)).HasMaxLength(TbNationalityTempConsts.Code2MaxLength);
                b.Property(x => x.Name_en).HasColumnName(nameof(TbNationalityTemp.Name_en)).HasMaxLength(TbNationalityTempConsts.Name_enMaxLength);
                b.Property(x => x.Name_vn).HasColumnName(nameof(TbNationalityTemp.Name_vn)).HasMaxLength(TbNationalityTempConsts.Name_vnMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbNationalityTemp.IsActive));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbAdditionInfoTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbAdditionInfo_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbAdditionInfoTemp.CompanyId)).IsRequired();
                b.Property(x => x.DocDate).HasColumnName(nameof(TbAdditionInfoTemp.DocDate));
                b.Property(x => x.TypeOfGroup).HasColumnName(nameof(TbAdditionInfoTemp.TypeOfGroup)).HasMaxLength(TbAdditionInfoTempConsts.TypeOfGroupMaxLength);
                b.Property(x => x.TypeOfEvent).HasColumnName(nameof(TbAdditionInfoTemp.TypeOfEvent));
                b.Property(x => x.Description).HasColumnName(nameof(TbAdditionInfoTemp.Description));
                b.Property(x => x.NoOfDocument).HasColumnName(nameof(TbAdditionInfoTemp.NoOfDocument));
                b.Property(x => x.Remark).HasColumnName(nameof(TbAdditionInfoTemp.Remark));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbAdditionInfoTemp.IsActive));
                b.Property(x => x.create_user).HasColumnName(nameof(TbAdditionInfoTemp.create_user));
                b.Property(x => x.create_date).HasColumnName(nameof(TbAdditionInfoTemp.create_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbAdditionInfoTemp.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbAdditionInfoTemp.mod_date));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyInvestTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyInvest_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyInvestTemp.CompanyId)).IsRequired();
                b.Property(x => x.CompanyName).HasColumnName(nameof(TbCompanyInvestTemp.CompanyName));
                b.Property(x => x.Shares).HasColumnName(nameof(TbCompanyInvestTemp.Shares));
                b.Property(x => x.Holding).HasColumnName(nameof(TbCompanyInvestTemp.Holding));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyInvestTemp.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyInvestTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyInvestTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyInvestTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyInvestTemp.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyMemberCouncilTerm>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyMemberCouncilTerm", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyMemberCouncilTerm.CompanyId));
                b.Property(x => x.TermFrom).HasColumnName(nameof(TbCompanyMemberCouncilTerm.TermFrom));
                b.Property(x => x.TermEnd).HasColumnName(nameof(TbCompanyMemberCouncilTerm.TermEnd));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TsClassTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tsClass_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ParentCode).HasColumnName(nameof(TsClassTemp.ParentCode)).IsRequired().HasMaxLength(TsClassTempConsts.ParentCodeMaxLength);
                b.Property(x => x.Code).HasColumnName(nameof(TsClassTemp.Code)).IsRequired().HasMaxLength(TsClassTempConsts.CodeMaxLength);
                b.Property(x => x.Name).HasColumnName(nameof(TsClassTemp.Name)).HasMaxLength(TsClassTempConsts.NameMaxLength);
                b.Property(x => x.Name_EN).HasColumnName(nameof(TsClassTemp.Name_EN)).HasMaxLength(TsClassTempConsts.Name_ENMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TsClassTemp.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TsClassTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TsClassTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TsClassTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TsClassTemp.mod_user));
                b.Property(x => x.Code_Type).HasColumnName(nameof(TsClassTemp.Code_Type)).HasMaxLength(TsClassTempConsts.Code_TypeMaxLength);
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TsClass>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tsClass", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ParentCode).HasColumnName(nameof(TsClass.ParentCode)).IsRequired().HasMaxLength(TsClassConsts.ParentCodeMaxLength);
                b.Property(x => x.Code).HasColumnName(nameof(TsClass.Code)).IsRequired().HasMaxLength(TsClassConsts.CodeMaxLength);
                b.Property(x => x.Name).HasColumnName(nameof(TsClass.Name)).HasMaxLength(TsClassConsts.NameMaxLength);
                b.Property(x => x.Name_EN).HasColumnName(nameof(TsClass.Name_EN)).HasMaxLength(TsClassConsts.Name_ENMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TsClass.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TsClass.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TsClass.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TsClass.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TsClass.mod_user));
                b.Property(x => x.Code_Type).HasColumnName(nameof(TsClass.Code_Type)).HasMaxLength(TsClassConsts.Code_TypeMaxLength);
            });
        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbUserMappingBrewery>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbUserMappingBrewery", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.userid).HasColumnName(nameof(TbUserMappingBrewery.userid));
                b.Property(x => x.breweryid).HasColumnName(nameof(TbUserMappingBrewery.breweryid));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbUserMappingBrewery.IsActive));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbUserMappingCompany>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbUserMappingCompany", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.userid).HasColumnName(nameof(TbUserMappingCompany.userid));
                b.Property(x => x.companyid).HasColumnName(nameof(TbUserMappingCompany.companyid));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbUserMappingCompany.IsActive));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbUserMappingPerson>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbUserMappingPerson", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.userid).HasColumnName(nameof(TbUserMappingPerson.userid));
                b.Property(x => x.personid).HasColumnName(nameof(TbUserMappingPerson.personid));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbUserMappingPerson.IsActive));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbInfoUpdate>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbInfoUpdate", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.TableName).HasColumnName(nameof(TbInfoUpdate.TableName)).IsRequired().HasMaxLength(TbInfoUpdateConsts.TableNameMaxLength);
                b.Property(x => x.ColumnName).HasColumnName(nameof(TbInfoUpdate.ColumnName)).IsRequired().HasMaxLength(TbInfoUpdateConsts.ColumnNameMaxLength);
                b.Property(x => x.ScreenName).HasColumnName(nameof(TbInfoUpdate.ScreenName));
                b.Property(x => x.ScreenId).HasColumnName(nameof(TbInfoUpdate.ScreenId));
                b.Property(x => x.RowId).HasColumnName(nameof(TbInfoUpdate.RowId)).IsRequired();
                b.Property(x => x.Command).HasColumnName(nameof(TbInfoUpdate.Command)).IsRequired().HasMaxLength(TbInfoUpdateConsts.CommandMaxLength);
                b.Property(x => x.GroupName).HasColumnName(nameof(TbInfoUpdate.GroupName));
                b.Property(x => x.LastValue).HasColumnName(nameof(TbInfoUpdate.LastValue)).HasMaxLength(TbInfoUpdateConsts.LastValueMaxLength);
                b.Property(x => x.NewValue).HasColumnName(nameof(TbInfoUpdate.NewValue)).HasMaxLength(TbInfoUpdateConsts.NewValueMaxLength);
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbInfoUpdate.DocStatus));
                b.Property(x => x.Comment).HasColumnName(nameof(TbInfoUpdate.Comment)).HasMaxLength(TbInfoUpdateConsts.CommentMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbInfoUpdate.IsActive)).IsRequired();
                b.Property(x => x.crt_user).HasColumnName(nameof(TbInfoUpdate.crt_user));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbInfoUpdate.crt_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbInfoUpdate.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbInfoUpdate.mod_date));
                b.Property(x => x.ChangeSetId).HasColumnName(nameof(TbInfoUpdate.ChangeSetId));
                b.Property(x => x.TimeAssessment).HasColumnName(nameof(TbInfoUpdate.TimeAssessment));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyPerson>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyPerson", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.BranchCode).HasColumnName(nameof(TbCompanyPerson.BranchCode)).HasMaxLength(TbCompanyPersonConsts.BranchCodeMaxLength);
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyPerson.CompanyId)).IsRequired();
                b.Property(x => x.PersonId).HasColumnName(nameof(TbCompanyPerson.PersonId)).IsRequired();
                b.Property(x => x.PositionId).HasColumnName(nameof(TbCompanyPerson.PositionId));
                b.Property(x => x.FromDate).HasColumnName(nameof(TbCompanyPerson.FromDate));
                b.Property(x => x.ToDate).HasColumnName(nameof(TbCompanyPerson.ToDate));
                b.Property(x => x.PositionCode).HasColumnName(nameof(TbCompanyPerson.PositionCode)).HasMaxLength(TbCompanyPersonConsts.PositionCodeMaxLength);
                b.Property(x => x.PostionType).HasColumnName(nameof(TbCompanyPerson.PostionType));
                b.Property(x => x.PersonalValue).HasColumnName(nameof(TbCompanyPerson.PersonalValue));
                b.Property(x => x.PersonalSharePercentage).HasColumnName(nameof(TbCompanyPerson.PersonalSharePercentage));
                b.Property(x => x.OwnerValue).HasColumnName(nameof(TbCompanyPerson.OwnerValue));
                b.Property(x => x.RepresentativePercentage).HasColumnName(nameof(TbCompanyPerson.RepresentativePercentage));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyPerson.Note)).HasMaxLength(TbCompanyPersonConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyPerson.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyPerson.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyPerson.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyPerson.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyPerson.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyPersonTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyPerson_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.idCompanyPerson).HasColumnName(nameof(TbCompanyPersonTemp.idCompanyPerson));
                b.Property(x => x.BranchCode).HasColumnName(nameof(TbCompanyPersonTemp.BranchCode)).HasMaxLength(TbCompanyPersonTempConsts.BranchCodeMaxLength);
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyPersonTemp.CompanyId)).IsRequired();
                b.Property(x => x.PersonId).HasColumnName(nameof(TbCompanyPersonTemp.PersonId)).IsRequired();
                b.Property(x => x.PositionId).HasColumnName(nameof(TbCompanyPersonTemp.PositionId));
                b.Property(x => x.FromDate).HasColumnName(nameof(TbCompanyPersonTemp.FromDate));
                b.Property(x => x.ToDate).HasColumnName(nameof(TbCompanyPersonTemp.ToDate));
                b.Property(x => x.PositionType).HasColumnName(nameof(TbCompanyPersonTemp.PositionType));
                b.Property(x => x.PositionCode).HasColumnName(nameof(TbCompanyPersonTemp.PositionCode)).HasMaxLength(TbCompanyPersonTempConsts.PositionCodeMaxLength);
                b.Property(x => x.PersonalValue).HasColumnName(nameof(TbCompanyPersonTemp.PersonalValue));
                b.Property(x => x.PersonalSharePercentage).HasColumnName(nameof(TbCompanyPersonTemp.PersonalSharePercentage));
                b.Property(x => x.OwnerValue).HasColumnName(nameof(TbCompanyPersonTemp.OwnerValue));
                b.Property(x => x.RepresentativePercentage).HasColumnName(nameof(TbCompanyPersonTemp.RepresentativePercentage));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyPersonTemp.Note)).HasMaxLength(TbCompanyPersonTempConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyPersonTemp.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyPersonTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyPersonTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyPersonTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyPersonTemp.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbFileUpload>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbFileUpload", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.companyId).HasColumnName(nameof(TbFileUpload.companyId));
                b.Property(x => x.personId).HasColumnName(nameof(TbFileUpload.personId));
                b.Property(x => x.fileName).HasColumnName(nameof(TbFileUpload.fileName));
                b.Property(x => x.fullFileName).HasColumnName(nameof(TbFileUpload.fullFileName));
                b.Property(x => x.fileLink).HasColumnName(nameof(TbFileUpload.fileLink));
                b.Property(x => x.uploadDate).HasColumnName(nameof(TbFileUpload.uploadDate));
                b.Property(x => x.UserUpload).HasColumnName(nameof(TbFileUpload.UserUpload));
                b.Property(x => x.note).HasColumnName(nameof(TbFileUpload.note));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbFileUpload.IsActive));
                b.Property(x => x.DownloadCount).HasColumnName(nameof(TbFileUpload.DownloadCount));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbFileUpload.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbFileUpload.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbFileUpload.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbFileUpload.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbFileUploadTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbFileUpload_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.companyId).HasColumnName(nameof(TbFileUploadTemp.companyId));
                b.Property(x => x.personId).HasColumnName(nameof(TbFileUploadTemp.personId));
                b.Property(x => x.fileName).HasColumnName(nameof(TbFileUploadTemp.fileName));
                b.Property(x => x.fullFileName).HasColumnName(nameof(TbFileUploadTemp.fullFileName));
                b.Property(x => x.fileLink).HasColumnName(nameof(TbFileUploadTemp.fileLink));
                b.Property(x => x.uploadDate).HasColumnName(nameof(TbFileUploadTemp.uploadDate));
                b.Property(x => x.UserUpload).HasColumnName(nameof(TbFileUploadTemp.UserUpload));
                b.Property(x => x.note).HasColumnName(nameof(TbFileUploadTemp.note));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbFileUploadTemp.IsActive));
                b.Property(x => x.DownloadCount).HasColumnName(nameof(TbFileUploadTemp.DownloadCount));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbFileUploadTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbFileUploadTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbFileUploadTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbFileUploadTemp.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompany>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompany", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ParentId).HasColumnName(nameof(TbCompany.ParentId)).IsRequired();
                b.Property(x => x.IsGroup).HasColumnName(nameof(TbCompany.IsGroup)).IsRequired();
                b.Property(x => x.Code).HasColumnName(nameof(TbCompany.Code)).IsRequired().HasMaxLength(TbCompanyConsts.CodeMaxLength);
                b.Property(x => x.Name).HasColumnName(nameof(TbCompany.Name)).IsRequired().HasMaxLength(TbCompanyConsts.NameMaxLength);
                b.Property(x => x.Name_EN).HasColumnName(nameof(TbCompany.Name_EN)).HasMaxLength(TbCompanyConsts.Name_ENMaxLength);
                b.Property(x => x.BriefName).HasColumnName(nameof(TbCompany.BriefName)).HasMaxLength(TbCompanyConsts.BriefNameMaxLength);
                b.Property(x => x.ContactInfo_01).HasColumnName(nameof(TbCompany.ContactInfo_01)).HasMaxLength(TbCompanyConsts.ContactInfo_01MaxLength);
                b.Property(x => x.ContactInfo_02).HasColumnName(nameof(TbCompany.ContactInfo_02)).HasMaxLength(TbCompanyConsts.ContactInfo_02MaxLength);
                b.Property(x => x.ContactInfo_03).HasColumnName(nameof(TbCompany.ContactInfo_03)).HasMaxLength(TbCompanyConsts.ContactInfo_03MaxLength);
                b.Property(x => x.ContactInfo_04).HasColumnName(nameof(TbCompany.ContactInfo_04)).HasMaxLength(TbCompanyConsts.ContactInfo_04MaxLength);
                b.Property(x => x.ContactInfo_05).HasColumnName(nameof(TbCompany.ContactInfo_05)).HasMaxLength(TbCompanyConsts.ContactInfo_05MaxLength);
                b.Property(x => x.ContactInfo_06).HasColumnName(nameof(TbCompany.ContactInfo_06)).HasMaxLength(TbCompanyConsts.ContactInfo_06MaxLength);
                b.Property(x => x.StockCode).HasColumnName(nameof(TbCompany.StockCode)).HasMaxLength(TbCompanyConsts.StockCodeMaxLength);
                b.Property(x => x.StockExchange).HasColumnName(nameof(TbCompany.StockExchange)).HasMaxLength(TbCompanyConsts.StockExchangeMaxLength);
                b.Property(x => x.StockRegistrationDate).HasColumnName(nameof(TbCompany.StockRegistrationDate));
                b.Property(x => x.IsPublicCompany).HasColumnName(nameof(TbCompany.IsPublicCompany));
                b.Property(x => x.LicenseNo).HasColumnName(nameof(TbCompany.LicenseNo)).HasMaxLength(TbCompanyConsts.LicenseNoMaxLength);
                b.Property(x => x.License).HasColumnName(nameof(TbCompany.License)).HasMaxLength(TbCompanyConsts.LicenseMaxLength);
                b.Property(x => x.RegistrationOrder).HasColumnName(nameof(TbCompany.RegistrationOrder));
                b.Property(x => x.RegistrationDate0).HasColumnName(nameof(TbCompany.RegistrationDate0));
                b.Property(x => x.RegistrationDate).HasColumnName(nameof(TbCompany.RegistrationDate));
                b.Property(x => x.LatestAmendment).HasColumnName(nameof(TbCompany.LatestAmendment));
                b.Property(x => x.LegalRepresent).HasColumnName(nameof(TbCompany.LegalRepresent)).HasMaxLength(TbCompanyConsts.LegalRepresentMaxLength);
                b.Property(x => x.CompanyType).HasColumnName(nameof(TbCompany.CompanyType)).HasMaxLength(TbCompanyConsts.CompanyTypeMaxLength);
                b.Property(x => x.CharteredCapital).HasColumnName(nameof(TbCompany.CharteredCapital));
                b.Property(x => x.TotalShare).HasColumnName(nameof(TbCompany.TotalShare));
                b.Property(x => x.ListedShare).HasColumnName(nameof(TbCompany.ListedShare));
                b.Property(x => x.ParValue).HasColumnName(nameof(TbCompany.ParValue));
                b.Property(x => x.ContactName1).HasColumnName(nameof(TbCompany.ContactName1)).HasMaxLength(TbCompanyConsts.ContactName1MaxLength);
                b.Property(x => x.ContactDept1).HasColumnName(nameof(TbCompany.ContactDept1)).HasMaxLength(TbCompanyConsts.ContactDept1MaxLength);
                b.Property(x => x.ContactMail1).HasColumnName(nameof(TbCompany.ContactMail1)).HasMaxLength(TbCompanyConsts.ContactMail1MaxLength);
                b.Property(x => x.ContactPosition1).HasColumnName(nameof(TbCompany.ContactPosition1)).HasMaxLength(TbCompanyConsts.ContactPosition1MaxLength);
                b.Property(x => x.ContactPhone1).HasColumnName(nameof(TbCompany.ContactPhone1)).HasMaxLength(TbCompanyConsts.ContactPhone1MaxLength);
                b.Property(x => x.ContactName2).HasColumnName(nameof(TbCompany.ContactName2)).HasMaxLength(TbCompanyConsts.ContactName2MaxLength);
                b.Property(x => x.ContactDept2).HasColumnName(nameof(TbCompany.ContactDept2)).HasMaxLength(TbCompanyConsts.ContactDept2MaxLength);
                b.Property(x => x.ContactMail2).HasColumnName(nameof(TbCompany.ContactMail2)).HasMaxLength(TbCompanyConsts.ContactMail2MaxLength);
                b.Property(x => x.ContactPosition2).HasColumnName(nameof(TbCompany.ContactPosition2)).HasMaxLength(TbCompanyConsts.ContactPosition2MaxLength);
                b.Property(x => x.ContactPhone2).HasColumnName(nameof(TbCompany.ContactPhone2)).HasMaxLength(TbCompanyConsts.ContactPhone2MaxLength);
                b.Property(x => x.longtitude).HasColumnName(nameof(TbCompany.longtitude));
                b.Property(x => x.latitude).HasColumnName(nameof(TbCompany.latitude));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompany.Note)).HasMaxLength(TbCompanyConsts.NoteMaxLength);
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbCompany.DocStatus));
                b.Property(x => x.DirectShareholding).HasColumnName(nameof(TbCompany.DirectShareholding));
                b.Property(x => x.ConsolidatedShareholding).HasColumnName(nameof(TbCompany.ConsolidatedShareholding));
                b.Property(x => x.ConsolidateNoted).HasColumnName(nameof(TbCompany.ConsolidateNoted));
                b.Property(x => x.VotingRightDirect).HasColumnName(nameof(TbCompany.VotingRightDirect));
                b.Property(x => x.VotingRightTotal).HasColumnName(nameof(TbCompany.VotingRightTotal));
                b.Property(x => x.Image).HasColumnName(nameof(TbCompany.Image));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompany.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompany.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompany.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompany.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompany.mod_user));
                b.Property(x => x.BravoCode).HasColumnName(nameof(TbCompany.BravoCode)).HasMaxLength(TbCompanyConsts.BravoCodeMaxLength);
                b.Property(x => x.LegacyCode).HasColumnName(nameof(TbCompany.LegacyCode)).HasMaxLength(TbCompanyConsts.LegacyCodeMaxLength);
                b.Property(x => x.idCompanyType).HasColumnName(nameof(TbCompany.idCompanyType));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbCompany.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbPerson>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbPerson", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Code).HasColumnName(nameof(TbPerson.Code)).IsRequired().HasMaxLength(TbPersonConsts.CodeMaxLength);
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbPerson.CompanyId));
                b.Property(x => x.FullName).HasColumnName(nameof(TbPerson.FullName)).IsRequired().HasMaxLength(TbPersonConsts.FullNameMaxLength);
                b.Property(x => x.BirthDate).HasColumnName(nameof(TbPerson.BirthDate)).IsRequired();
                b.Property(x => x.BirthPlace).HasColumnName(nameof(TbPerson.BirthPlace)).HasMaxLength(TbPersonConsts.BirthPlaceMaxLength);
                b.Property(x => x.Address).HasColumnName(nameof(TbPerson.Address)).HasMaxLength(TbPersonConsts.AddressMaxLength);
                b.Property(x => x.IDCardNo).HasColumnName(nameof(TbPerson.IDCardNo)).HasMaxLength(TbPersonConsts.IDCardNoMaxLength);
                b.Property(x => x.IDCardDate).HasColumnName(nameof(TbPerson.IDCardDate));
                b.Property(x => x.IdCardIssuePlace).HasColumnName(nameof(TbPerson.IdCardIssuePlace)).HasMaxLength(TbPersonConsts.IdCardIssuePlaceMaxLength);
                b.Property(x => x.Ethnicity).HasColumnName(nameof(TbPerson.Ethnicity)).HasMaxLength(TbPersonConsts.EthnicityMaxLength);
                b.Property(x => x.Religion).HasColumnName(nameof(TbPerson.Religion)).HasMaxLength(TbPersonConsts.ReligionMaxLength);
                b.Property(x => x.NationalityCode).HasColumnName(nameof(TbPerson.NationalityCode)).HasMaxLength(TbPersonConsts.NationalityCodeMaxLength);
                b.Property(x => x.Gender).HasColumnName(nameof(TbPerson.Gender)).HasMaxLength(TbPersonConsts.GenderMaxLength);
                b.Property(x => x.Phone).HasColumnName(nameof(TbPerson.Phone)).HasMaxLength(TbPersonConsts.PhoneMaxLength);
                b.Property(x => x.Email).HasColumnName(nameof(TbPerson.Email)).HasMaxLength(TbPersonConsts.EmailMaxLength);
                b.Property(x => x.Note).HasColumnName(nameof(TbPerson.Note)).HasMaxLength(TbPersonConsts.NoteMaxLength);
                b.Property(x => x.Image).HasColumnName(nameof(TbPerson.Image));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbPerson.IsActive));
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbPerson.DocStatus));
                b.Property(x => x.IsCheckRetirement).HasColumnName(nameof(TbPerson.IsCheckRetirement));
                b.Property(x => x.IsCheckTermEnd).HasColumnName(nameof(TbPerson.IsCheckTermEnd));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbPerson.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbPerson.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbPerson.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbPerson.mod_user));
                b.Property(x => x.OldCode).HasColumnName(nameof(TbPerson.OldCode)).HasMaxLength(TbPersonConsts.OldCodeMaxLength);
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbPerson.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbPersonTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbPerson_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.idPerson).HasColumnName(nameof(TbPersonTemp.idPerson));
                b.Property(x => x.Code).HasColumnName(nameof(TbPersonTemp.Code)).IsRequired().HasMaxLength(TbPersonTempConsts.CodeMaxLength);
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbPersonTemp.CompanyId));
                b.Property(x => x.FullName).HasColumnName(nameof(TbPersonTemp.FullName)).IsRequired().HasMaxLength(TbPersonTempConsts.FullNameMaxLength);
                b.Property(x => x.BirthDate).HasColumnName(nameof(TbPersonTemp.BirthDate)).IsRequired();
                b.Property(x => x.BirthPlace).HasColumnName(nameof(TbPersonTemp.BirthPlace)).HasMaxLength(TbPersonTempConsts.BirthPlaceMaxLength);
                b.Property(x => x.Address).HasColumnName(nameof(TbPersonTemp.Address)).HasMaxLength(TbPersonTempConsts.AddressMaxLength);
                b.Property(x => x.IDCardNo).HasColumnName(nameof(TbPersonTemp.IDCardNo)).HasMaxLength(TbPersonTempConsts.IDCardNoMaxLength);
                b.Property(x => x.IDCardDate).HasColumnName(nameof(TbPersonTemp.IDCardDate));
                b.Property(x => x.IdCardIssuePlace).HasColumnName(nameof(TbPersonTemp.IdCardIssuePlace)).HasMaxLength(TbPersonTempConsts.IdCardIssuePlaceMaxLength);
                b.Property(x => x.Ethnicity).HasColumnName(nameof(TbPersonTemp.Ethnicity)).HasMaxLength(TbPersonTempConsts.EthnicityMaxLength);
                b.Property(x => x.Religion).HasColumnName(nameof(TbPersonTemp.Religion)).HasMaxLength(TbPersonTempConsts.ReligionMaxLength);
                b.Property(x => x.NationalityCode).HasColumnName(nameof(TbPersonTemp.NationalityCode)).HasMaxLength(TbPersonTempConsts.NationalityCodeMaxLength);
                b.Property(x => x.Gender).HasColumnName(nameof(TbPersonTemp.Gender)).HasMaxLength(TbPersonTempConsts.GenderMaxLength);
                b.Property(x => x.Phone).HasColumnName(nameof(TbPersonTemp.Phone)).HasMaxLength(TbPersonTempConsts.PhoneMaxLength);
                b.Property(x => x.Email).HasColumnName(nameof(TbPersonTemp.Email)).HasMaxLength(TbPersonTempConsts.EmailMaxLength);
                b.Property(x => x.Note).HasColumnName(nameof(TbPersonTemp.Note)).HasMaxLength(TbPersonTempConsts.NoteMaxLength);
                b.Property(x => x.Image).HasColumnName(nameof(TbPersonTemp.Image));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbPersonTemp.IsActive));
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbPersonTemp.DocStatus));
                b.Property(x => x.IsCheckRetirement).HasColumnName(nameof(TbPersonTemp.IsCheckRetirement));
                b.Property(x => x.IsCheckTermEnd).HasColumnName(nameof(TbPersonTemp.IsCheckTermEnd));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbPersonTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbPersonTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbPersonTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbPersonTemp.mod_user));
                b.Property(x => x.OldCode).HasColumnName(nameof(TbPersonTemp.OldCode)).HasMaxLength(TbPersonTempConsts.OldCodeMaxLength);
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbPosition>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbPosition", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Code).HasColumnName(nameof(TbPosition.Code)).IsRequired().HasMaxLength(TbPositionConsts.CodeMaxLength);
                b.Property(x => x.Name).HasColumnName(nameof(TbPosition.Name)).IsRequired().HasMaxLength(TbPositionConsts.NameMaxLength);
                b.Property(x => x.Name_EN).HasColumnName(nameof(TbPosition.Name_EN)).IsRequired().HasMaxLength(TbPositionConsts.Name_ENMaxLength);
                b.Property(x => x.PositionType).HasColumnName(nameof(TbPosition.PositionType));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbPosition.IsActive)).IsRequired();
                b.Property(x => x.crt_user).HasColumnName(nameof(TbPosition.crt_user));
                b.Property(x => x.ctr_date).HasColumnName(nameof(TbPosition.ctr_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbPosition.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbPosition.mod_date));
                b.Property(x => x.OrderNumb).HasColumnName(nameof(TbPosition.OrderNumb));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbPosition.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbInvest>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbInvest", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.BranchCode).HasColumnName(nameof(TbInvest.BranchCode)).IsRequired().HasMaxLength(TbInvestConsts.BranchCodeMaxLength);
                b.Property(x => x.BranchId).HasColumnName(nameof(TbInvest.BranchId));
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbInvest.CompanyId));
                b.Property(x => x.CompanyCode).HasColumnName(nameof(TbInvest.CompanyCode)).IsRequired().HasMaxLength(TbInvestConsts.CompanyCodeMaxLength);
                b.Property(x => x.ShareNumTotal).HasColumnName(nameof(TbInvest.ShareNumTotal));
                b.Property(x => x.ShareValueTotal).HasColumnName(nameof(TbInvest.ShareValueTotal));
                b.Property(x => x.Note).HasColumnName(nameof(TbInvest.Note)).HasMaxLength(TbInvestConsts.NoteMaxLength);
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbInvest.DocStatus));
                b.Property(x => x.InvestGroup).HasColumnName(nameof(TbInvest.InvestGroup));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbInvest.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbInvest.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbInvest.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbInvest.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbInvest.mod_user));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbInvest.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbInvestDetail>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbInvestDetail", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ParentId).HasColumnName(nameof(TbInvestDetail.ParentId)).IsRequired();
                b.Property(x => x.DocDate).HasColumnName(nameof(TbInvestDetail.DocDate));
                b.Property(x => x.DocNo).HasColumnName(nameof(TbInvestDetail.DocNo)).HasMaxLength(TbInvestDetailConsts.DocNoMaxLength);
                b.Property(x => x.InvestType).HasColumnName(nameof(TbInvestDetail.InvestType)).IsRequired();
                b.Property(x => x.ShareNum).HasColumnName(nameof(TbInvestDetail.ShareNum));
                b.Property(x => x.ShareValue).HasColumnName(nameof(TbInvestDetail.ShareValue));
                b.Property(x => x.Note).HasColumnName(nameof(TbInvestDetail.Note)).HasMaxLength(TbInvestDetailConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbInvestDetail.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbInvestDetail.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbInvestDetail.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbInvestDetail.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbInvestDetail.mod_user));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbInvestDetail.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbInvestPerson>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbInvestPerson", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ParentId).HasColumnName(nameof(TbInvestPerson.ParentId)).IsRequired();
                b.Property(x => x.PersonId).HasColumnName(nameof(TbInvestPerson.PersonId)).IsRequired();
                b.Property(x => x.FromDate).HasColumnName(nameof(TbInvestPerson.FromDate)).IsRequired();
                b.Property(x => x.PersonalValue).HasColumnName(nameof(TbInvestPerson.PersonalValue));
                b.Property(x => x.OwnerValue).HasColumnName(nameof(TbInvestPerson.OwnerValue));
                b.Property(x => x.Note).HasColumnName(nameof(TbInvestPerson.Note)).HasMaxLength(TbInvestPersonConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbInvestPerson.IsActive));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbInvestPerson.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbInvestPerson.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbInvestPerson.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbInvestPerson.mod_user));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbInvestPerson.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbContact>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbContact", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.companyid).HasColumnName(nameof(TbContact.companyid)).IsRequired();
                b.Property(x => x.ContactName).HasColumnName(nameof(TbContact.ContactName)).IsRequired().HasMaxLength(TbContactConsts.ContactNameMaxLength);
                b.Property(x => x.ContactDept).HasColumnName(nameof(TbContact.ContactDept)).HasMaxLength(TbContactConsts.ContactDeptMaxLength);
                b.Property(x => x.ContactPosition).HasColumnName(nameof(TbContact.ContactPosition)).HasMaxLength(TbContactConsts.ContactPositionMaxLength);
                b.Property(x => x.ContactEmail).HasColumnName(nameof(TbContact.ContactEmail)).HasMaxLength(TbContactConsts.ContactEmailMaxLength);
                b.Property(x => x.ContactPhone).HasColumnName(nameof(TbContact.ContactPhone)).HasMaxLength(TbContactConsts.ContactPhoneMaxLength);
                b.Property(x => x.Note).HasColumnName(nameof(TbContact.Note)).HasMaxLength(TbContactConsts.NoteMaxLength);
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbContact.DocStatus));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbContact.IsActive)).IsRequired();
                b.Property(x => x.crt_user).HasColumnName(nameof(TbContact.crt_user));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbContact.crt_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbContact.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbContact.mod_date));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbContact.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbContactTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbContact_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.companyid).HasColumnName(nameof(TbContactTemp.companyid)).IsRequired();
                b.Property(x => x.ContactName).HasColumnName(nameof(TbContactTemp.ContactName)).IsRequired().HasMaxLength(TbContactTempConsts.ContactNameMaxLength);
                b.Property(x => x.ContactDept).HasColumnName(nameof(TbContactTemp.ContactDept)).HasMaxLength(TbContactTempConsts.ContactDeptMaxLength);
                b.Property(x => x.ContactPosition).HasColumnName(nameof(TbContactTemp.ContactPosition)).HasMaxLength(TbContactTempConsts.ContactPositionMaxLength);
                b.Property(x => x.ContactEmail).HasColumnName(nameof(TbContactTemp.ContactEmail)).HasMaxLength(TbContactTempConsts.ContactEmailMaxLength);
                b.Property(x => x.ContactPhone).HasColumnName(nameof(TbContactTemp.ContactPhone)).HasMaxLength(TbContactTempConsts.ContactPhoneMaxLength);
                b.Property(x => x.Note).HasColumnName(nameof(TbContactTemp.Note)).HasMaxLength(TbContactTempConsts.NoteMaxLength);
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbContactTemp.DocStatus));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbContactTemp.IsActive)).IsRequired();
                b.Property(x => x.crt_user).HasColumnName(nameof(TbContactTemp.crt_user));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbContactTemp.crt_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbContactTemp.mod_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbContactTemp.mod_date));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbContactTemp.IsDeleted));
            });

        } 
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyBoard>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyBoard", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.BranchCode).HasColumnName(nameof(TbCompanyBoard.BranchCode)).HasMaxLength(TbCompanyBoardConsts.BranchCodeMaxLength);
                b.Property(x => x.CompanyCode).HasColumnName(nameof(TbCompanyBoard.CompanyCode)).IsRequired().HasMaxLength(TbCompanyBoardConsts.CompanyCodeMaxLength);
                b.Property(x => x.PersonCode).HasColumnName(nameof(TbCompanyBoard.PersonCode)).IsRequired().HasMaxLength(TbCompanyBoardConsts.PersonCodeMaxLength);
                b.Property(x => x.FromDate).HasColumnName(nameof(TbCompanyBoard.FromDate));
                b.Property(x => x.ToDate).HasColumnName(nameof(TbCompanyBoard.ToDate));
                b.Property(x => x.PositionCode).HasColumnName(nameof(TbCompanyBoard.PositionCode)).HasMaxLength(TbCompanyBoardConsts.PositionCodeMaxLength);
                b.Property(x => x.PersonalValue).HasColumnName(nameof(TbCompanyBoard.PersonalValue));
                b.Property(x => x.OwnerValue).HasColumnName(nameof(TbCompanyBoard.OwnerValue));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyBoard.Note)).HasMaxLength(TbCompanyBoardConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyBoard.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyBoard.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyBoard.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyBoard.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyBoard.mod_user));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbCompanyBoard.IsDeleted));
            });

        } 
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbAsset>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbAsset", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbAsset.CompanyId)).IsRequired();
                b.Property(x => x.AssetType).HasColumnName(nameof(TbAsset.AssetType)).HasMaxLength(TbAssetConsts.AssetTypeMaxLength);
                b.Property(x => x.AssetItem).HasColumnName(nameof(TbAsset.AssetItem)).HasMaxLength(TbAssetConsts.AssetItemMaxLength);
                b.Property(x => x.AssetAddress).HasColumnName(nameof(TbAsset.AssetAddress)).HasMaxLength(TbAssetConsts.AssetAddressMaxLength);
                b.Property(x => x.Quantity).HasColumnName(nameof(TbAsset.Quantity));
                b.Property(x => x.DocNo).HasColumnName(nameof(TbAsset.DocNo)).HasMaxLength(TbAssetConsts.DocNoMaxLength);
                b.Property(x => x.DocDate).HasColumnName(nameof(TbAsset.DocDate));
                b.Property(x => x.ExpireDate).HasColumnName(nameof(TbAsset.ExpireDate));
                b.Property(x => x.Description).HasColumnName(nameof(TbAsset.Description)).HasMaxLength(TbAssetConsts.DescriptionMaxLength);
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbAsset.DocStatus));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbAsset.IsActive));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbAsset.IsDeleted));
                b.Property(x => x.crt_date).HasColumnName(nameof(TbAsset.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbAsset.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbAsset.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbAsset.mod_user));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyInvest>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyInvest", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyInvest.CompanyId)).IsRequired();
                b.Property(x => x.CompanyName).HasColumnName(nameof(TbCompanyInvest.CompanyName));
                b.Property(x => x.Shares).HasColumnName(nameof(TbCompanyInvest.Shares));
                b.Property(x => x.Holding).HasColumnName(nameof(TbCompanyInvest.Holding));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyInvest.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyInvest.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyInvest.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyInvest.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyInvest.mod_user));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbCompanyInvest.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyPerson>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyPerson", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.BranchCode).HasColumnName(nameof(TbCompanyPerson.BranchCode)).HasMaxLength(TbCompanyPersonConsts.BranchCodeMaxLength);
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyPerson.CompanyId)).IsRequired();
                b.Property(x => x.PersonId).HasColumnName(nameof(TbCompanyPerson.PersonId)).IsRequired();
                b.Property(x => x.PositionId).HasColumnName(nameof(TbCompanyPerson.PositionId));
                b.Property(x => x.FromDate).HasColumnName(nameof(TbCompanyPerson.FromDate));
                b.Property(x => x.ToDate).HasColumnName(nameof(TbCompanyPerson.ToDate));
                b.Property(x => x.PositionCode).HasColumnName(nameof(TbCompanyPerson.PositionCode)).HasMaxLength(TbCompanyPersonConsts.PositionCodeMaxLength);
                b.Property(x => x.PostionType).HasColumnName(nameof(TbCompanyPerson.PostionType));
                b.Property(x => x.PersonalValue).HasColumnName(nameof(TbCompanyPerson.PersonalValue));
                b.Property(x => x.PersonalSharePercentage).HasColumnName(nameof(TbCompanyPerson.PersonalSharePercentage));
                b.Property(x => x.OwnerValue).HasColumnName(nameof(TbCompanyPerson.OwnerValue));
                b.Property(x => x.RepresentativePercentage).HasColumnName(nameof(TbCompanyPerson.RepresentativePercentage));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyPerson.Note)).HasMaxLength(TbCompanyPersonConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyPerson.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyPerson.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyPerson.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyPerson.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyPerson.mod_user));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbCompanyPerson.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyPersonTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyPerson_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.idCompanyPerson).HasColumnName(nameof(TbCompanyPersonTemp.idCompanyPerson));
                b.Property(x => x.BranchCode).HasColumnName(nameof(TbCompanyPersonTemp.BranchCode)).HasMaxLength(TbCompanyPersonTempConsts.BranchCodeMaxLength);
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyPersonTemp.CompanyId)).IsRequired();
                b.Property(x => x.PersonId).HasColumnName(nameof(TbCompanyPersonTemp.PersonId)).IsRequired();
                b.Property(x => x.PositionId).HasColumnName(nameof(TbCompanyPersonTemp.PositionId));
                b.Property(x => x.FromDate).HasColumnName(nameof(TbCompanyPersonTemp.FromDate));
                b.Property(x => x.ToDate).HasColumnName(nameof(TbCompanyPersonTemp.ToDate));
                b.Property(x => x.PositionType).HasColumnName(nameof(TbCompanyPersonTemp.PositionType));
                b.Property(x => x.PositionCode).HasColumnName(nameof(TbCompanyPersonTemp.PositionCode)).HasMaxLength(TbCompanyPersonTempConsts.PositionCodeMaxLength);
                b.Property(x => x.PersonalValue).HasColumnName(nameof(TbCompanyPersonTemp.PersonalValue));
                b.Property(x => x.PersonalSharePercentage).HasColumnName(nameof(TbCompanyPersonTemp.PersonalSharePercentage));
                b.Property(x => x.OwnerValue).HasColumnName(nameof(TbCompanyPersonTemp.OwnerValue));
                b.Property(x => x.RepresentativePercentage).HasColumnName(nameof(TbCompanyPersonTemp.RepresentativePercentage));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyPersonTemp.Note)).HasMaxLength(TbCompanyPersonTempConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyPersonTemp.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyPersonTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyPersonTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyPersonTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyPersonTemp.mod_user));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbCompanyPersonTemp.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyMajor>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyMajor", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyMajor.CompanyId)).IsRequired();
                b.Property(x => x.ShareHolderMajor).HasColumnName(nameof(TbCompanyMajor.ShareHolderMajor)).IsRequired();
                b.Property(x => x.ShareHolderType).HasColumnName(nameof(TbCompanyMajor.ShareHolderType)).IsRequired().HasMaxLength(TbCompanyMajorConsts.ShareHolderTypeMaxLength);
                b.Property(x => x.FromDate).HasColumnName(nameof(TbCompanyMajor.FromDate));
                b.Property(x => x.ToDate).HasColumnName(nameof(TbCompanyMajor.ToDate));
                b.Property(x => x.ShareHolderValue).HasColumnName(nameof(TbCompanyMajor.ShareHolderValue));
                b.Property(x => x.ShareHolderRate).HasColumnName(nameof(TbCompanyMajor.ShareHolderRate));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyMajor.Note)).HasMaxLength(TbCompanyMajorConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyMajor.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyMajor.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyMajor.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyMajor.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyMajor.mod_user));
                b.Property(x => x.ClassId).HasColumnName(nameof(TbCompanyMajor.ClassId));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbCompanyMajor.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbCompanyMajorTemp>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbCompanyMajor_Temp", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbCompanyMajorTemp.CompanyId)).IsRequired();
                b.Property(x => x.ShareHolderMajor).HasColumnName(nameof(TbCompanyMajorTemp.ShareHolderMajor)).IsRequired();
                b.Property(x => x.ShareHolderType).HasColumnName(nameof(TbCompanyMajorTemp.ShareHolderType)).IsRequired().HasMaxLength(TbCompanyMajorTempConsts.ShareHolderTypeMaxLength);
                b.Property(x => x.FromDate).HasColumnName(nameof(TbCompanyMajorTemp.FromDate));
                b.Property(x => x.ToDate).HasColumnName(nameof(TbCompanyMajorTemp.ToDate));
                b.Property(x => x.ShareHolderValue).HasColumnName(nameof(TbCompanyMajorTemp.ShareHolderValue));
                b.Property(x => x.ShareHolderRate).HasColumnName(nameof(TbCompanyMajorTemp.ShareHolderRate));
                b.Property(x => x.Note).HasColumnName(nameof(TbCompanyMajorTemp.Note)).HasMaxLength(TbCompanyMajorTempConsts.NoteMaxLength);
                b.Property(x => x.IsActive).HasColumnName(nameof(TbCompanyMajorTemp.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbCompanyMajorTemp.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbCompanyMajorTemp.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbCompanyMajorTemp.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbCompanyMajorTemp.mod_user));
                b.Property(x => x.ClassId).HasColumnName(nameof(TbCompanyMajorTemp.ClassId));
                b.Property(x => x.IsDeleted).HasColumnName(nameof(TbCompanyMajorTemp.IsDeleted));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<TbUser>(b =>
            {
                b.ToTable(Sabeco_FactsheetConsts.DbTablePrefix + "tbUsers", Sabeco_FactsheetConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.UserPrincipalName).HasColumnName(nameof(TbUser.UserPrincipalName)).IsRequired().HasMaxLength(TbUserConsts.UserPrincipalNameMaxLength);
                b.Property(x => x.UserName).HasColumnName(nameof(TbUser.UserName)).IsRequired().HasMaxLength(TbUserConsts.UserNameMaxLength);
                b.Property(x => x.FullName).HasColumnName(nameof(TbUser.FullName)).IsRequired().HasMaxLength(TbUserConsts.FullNameMaxLength);
                b.Property(x => x.Email).HasColumnName(nameof(TbUser.Email)).HasMaxLength(TbUserConsts.EmailMaxLength);
                b.Property(x => x.CompanyId).HasColumnName(nameof(TbUser.CompanyId));
                b.Property(x => x.DocStatus).HasColumnName(nameof(TbUser.DocStatus));
                b.Property(x => x.IsActive).HasColumnName(nameof(TbUser.IsActive)).IsRequired();
                b.Property(x => x.crt_date).HasColumnName(nameof(TbUser.crt_date));
                b.Property(x => x.crt_user).HasColumnName(nameof(TbUser.crt_user));
                b.Property(x => x.mod_date).HasColumnName(nameof(TbUser.mod_date));
                b.Property(x => x.mod_user).HasColumnName(nameof(TbUser.mod_user));
                b.Property(x => x.AbpUserId).HasColumnName(nameof(TbUser.AbpUserId));
            });

        }
    }
}
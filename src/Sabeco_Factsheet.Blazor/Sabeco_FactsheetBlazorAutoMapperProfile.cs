using AutoMapper;
using Sabeco_Factsheet.TbAdditionInfos;
using Sabeco_Factsheet.TbAssets;
using Sabeco_Factsheet.TbBranchs;
using Sabeco_Factsheet.TbBreweries;
using Sabeco_Factsheet.TbBreweryDeliveryVolumes;
using Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps;
using Sabeco_Factsheet.TbBreweryImages;
using Sabeco_Factsheet.TbBrewerySkus;
using Sabeco_Factsheet.TbBrewerySkuTemps;
using Sabeco_Factsheet.TbBreweryTemps;
using Sabeco_Factsheet.TbCompanies;
using Sabeco_Factsheet.TbCompanyBoards;
using Sabeco_Factsheet.TbCompanyBranchImages;
using Sabeco_Factsheet.TbCompanyBranchs;
using Sabeco_Factsheet.TbCompanyBusinessDetails;
using Sabeco_Factsheet.TbCompanyBusinesses;
using Sabeco_Factsheet.TbCompanyInvests;
using Sabeco_Factsheet.TbCompanyMajors;
using Sabeco_Factsheet.TbCompanyMappings;
using Sabeco_Factsheet.TbCompanyMemberCouncilTerms;
using Sabeco_Factsheet.TbCompanyPersons;
using Sabeco_Factsheet.TbCompanyPersonTemps;
using Sabeco_Factsheet.TbCompanyStocks;
using Sabeco_Factsheet.TbCompanyTemps;
using Sabeco_Factsheet.TbConfigRetirementTimes;
using Sabeco_Factsheet.TbContacts;
using Sabeco_Factsheet.TbFileUploads;
using Sabeco_Factsheet.TbHisBreweries;
using Sabeco_Factsheet.TbInfoUpdates;
using Sabeco_Factsheet.TbInvestDetails;
using Sabeco_Factsheet.TbInvestPersons;
using Sabeco_Factsheet.TbInvests;
using Sabeco_Factsheet.TbLandInfos;
using Sabeco_Factsheet.TbMenus;
using Sabeco_Factsheet.TbNationalities;
using Sabeco_Factsheet.TbPersons;
using Sabeco_Factsheet.TbPersonTemps;
using Sabeco_Factsheet.TbPositions;
using Sabeco_Factsheet.TbRoles;
using Sabeco_Factsheet.TbUsers;
using Sabeco_Factsheet.TbSkus;
using Sabeco_Factsheet.TbTerms;
using Sabeco_Factsheet.TbUserMappingBreweries;
using Sabeco_Factsheet.TbUserMappingCompanies;
using Sabeco_Factsheet.TbUserMappingPersons;
using Sabeco_Factsheet.TbHisBreweryDeliveryVolumes;
using Sabeco_Factsheet.TbHisBrewerySkus;
using Sabeco_Factsheet.TbHisCompanies;
using Sabeco_Factsheet.TbHisCompanyPersons;
using Sabeco_Factsheet.TbHisLogPrintings;
using Sabeco_Factsheet.TbHisPersons;
using Sabeco_Factsheet.TbLogErrors;
using Sabeco_Factsheet.TbLogExportDatas;
using Sabeco_Factsheet.TbLogLogins;
using Sabeco_Factsheet.TbLogPrintings;
using Sabeco_Factsheet.TbLogRefeshAccounts;
using Sabeco_Factsheet.TbLogSendEmailRetirements;
using Sabeco_Factsheet.TbLogSendEmails;
using Sabeco_Factsheet.TbLogSyncUats;
using Sabeco_Factsheet.TbStockPrices;
using Sabeco_Factsheet.TbTimeScripts;
using Sabeco_Factsheet.TbUserInRoles;
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
using Sabeco_Factsheet.TsClasses;
using Sabeco_Factsheet.TsClassTemps;

namespace Sabeco_Factsheet.Blazor;

public class Sabeco_FactsheetBlazorAutoMapperProfile : Profile
{
    public Sabeco_FactsheetBlazorAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Blazor project.

        CreateMap<TbInfoUpdateDto, TbInfoUpdateUpdateDto>();
        CreateMap<TbInfoUpdateDto, TbInfoUpdateCreateDto>();
        CreateMap<TbInfoUpdateUpdateDto, TbInfoUpdateCreateDto>();

        CreateMap<TbUserDto, TbUserUpdateDto>();
        CreateMap<TbUserDto, TbUserCreateDto>();
        CreateMap<TbUserUpdateDto, TbUserCreateDto>();

        CreateMap<TbAdditionInfoDto, TbAdditionInfoUpdateDto>();
        CreateMap<TbAdditionInfoDto, TbAdditionInfoCreateDto>();
        CreateMap<TbAdditionInfoUpdateDto, TbAdditionInfoCreateDto>();

        CreateMap<TbCompanyDto, TbCompanyUpdateDto>();
        CreateMap<TbCompanyDto, TbCompanyCreateDto>();
        CreateMap<TbCompanyUpdateDto, TbCompanyCreateDto>();

        CreateMap<TbCompanyInvestDto, TbCompanyInvestUpdateDto>();
        CreateMap<TbCompanyInvestDto, TbCompanyInvestCreateDto>();
        CreateMap<TbCompanyInvestUpdateDto, TbCompanyInvestCreateDto>();

        CreateMap<TbCompanyMajorDto, TbCompanyMajorUpdateDto>();
        CreateMap<TbCompanyMajorDto, TbCompanyMajorCreateDto>();
        CreateMap<TbCompanyMajorUpdateDto, TbCompanyMajorCreateDto>();

        CreateMap<TbCompanyPersonDto, TbCompanyPersonUpdateDto>();
        CreateMap<TbCompanyPersonDto, TbCompanyPersonCreateDto>();
        CreateMap<TbCompanyPersonUpdateDto, TbCompanyPersonCreateDto>();

        CreateMap<TbFileUploadDto, TbFileUploadUpdateDto>();
        CreateMap<TbFileUploadDto, TbFileUploadCreateDto>();
        CreateMap<TbFileUploadUpdateDto, TbFileUploadCreateDto>();

        CreateMap<TbLandInfoDto, TbLandInfoUpdateDto>();
        CreateMap<TbLandInfoDto, TbLandInfoCreateDto>();
        CreateMap<TbLandInfoUpdateDto, TbLandInfoCreateDto>();

        CreateMap<TbPositionDto, TbPositionUpdateDto>();
        CreateMap<TbPositionDto, TbPositionCreateDto>();
        CreateMap<TbPositionUpdateDto, TbPositionCreateDto>();

        CreateMap<TbRoleDto, TbRoleUpdateDto>();
        CreateMap<TbRoleDto, TbRoleCreateDto>();
        CreateMap<TbRoleUpdateDto, TbRoleCreateDto>();

        CreateMap<TbContactDto, TbContactUpdateDto>();
        CreateMap<TbContactDto, TbContactCreateDto>();
        CreateMap<TbContactUpdateDto, TbContactCreateDto>();

        CreateMap<TbAssetDto, TbAssetUpdateDto>();
        CreateMap<TbAssetDto, TbAssetCreateDto>();
        CreateMap<TbAssetUpdateDto, TbAssetCreateDto>();

        CreateMap<TbBreweryDto, TbBreweryUpdateDto>();
        CreateMap<TbBreweryDto, TbBreweryCreateDto>();
        CreateMap<TbBreweryUpdateDto, TbBreweryCreateDto>();

        CreateMap<TbBreweryDeliveryVolumeDto, TbBreweryDeliveryVolumeUpdateDto>();
        CreateMap<TbBreweryDeliveryVolumeDto, TbBreweryDeliveryVolumeCreateDto>();
        CreateMap<TbBreweryDeliveryVolumeUpdateDto, TbBreweryDeliveryVolumeCreateDto>();

        CreateMap<TbBreweryDeliveryVolumeTempDto, TbBreweryDeliveryVolumeTempUpdateDto>();
        CreateMap<TbBreweryDeliveryVolumeTempDto, TbBreweryDeliveryVolumeTempCreateDto>();
        CreateMap<TbBreweryDeliveryVolumeTempUpdateDto, TbBreweryDeliveryVolumeTempCreateDto>();

        CreateMap<TbBreweryImageDto, TbBreweryImageUpdateDto>();
        CreateMap<TbBreweryImageDto, TbBreweryImageCreateDto>();
        CreateMap<TbBreweryImageUpdateDto, TbBreweryImageCreateDto>();

        CreateMap<TbBrewerySkuDto, TbBrewerySkuUpdateDto>();
        CreateMap<TbBrewerySkuDto, TbBrewerySkuCreateDto>();
        CreateMap<TbBrewerySkuUpdateDto, TbBrewerySkuCreateDto>();

        CreateMap<TbBrewerySkuTempDto, TbBrewerySkuTempUpdateDto>();
        CreateMap<TbBrewerySkuTempDto, TbBrewerySkuTempCreateDto>();
        CreateMap<TbBrewerySkuTempUpdateDto, TbBrewerySkuTempCreateDto>();

        CreateMap<TbBreweryTempDto, TbBreweryTempUpdateDto>();
        CreateMap<TbBreweryTempDto, TbBreweryTempCreateDto>();
        CreateMap<TbBreweryTempUpdateDto, TbBreweryTempCreateDto>();

        CreateMap<TbCompanyBoardDto, TbCompanyBoardUpdateDto>();
        CreateMap<TbCompanyBoardDto, TbCompanyBoardCreateDto>();
        CreateMap<TbCompanyBoardUpdateDto, TbCompanyBoardCreateDto>();

        CreateMap<TbCompanyBranchDto, TbCompanyBranchUpdateDto>();
        CreateMap<TbCompanyBranchDto, TbCompanyBranchCreateDto>();
        CreateMap<TbCompanyBranchUpdateDto, TbCompanyBranchCreateDto>();

        CreateMap<TbCompanyBranchImageDto, TbCompanyBranchImageUpdateDto>();
        CreateMap<TbCompanyBranchImageDto, TbCompanyBranchImageCreateDto>();
        CreateMap<TbCompanyBranchImageUpdateDto, TbCompanyBranchImageCreateDto>();

        CreateMap<TbCompanyBusinessDto, TbCompanyBusinessUpdateDto>();
        CreateMap<TbCompanyBusinessDto, TbCompanyBusinessCreateDto>();
        CreateMap<TbCompanyBusinessUpdateDto, TbCompanyBusinessCreateDto>();

        CreateMap<TbCompanyBusinessDetailDto, TbCompanyBusinessDetailUpdateDto>();
        CreateMap<TbCompanyBusinessDetailDto, TbCompanyBusinessDetailCreateDto>();
        CreateMap<TbCompanyBusinessDetailUpdateDto, TbCompanyBusinessDetailCreateDto>();

        CreateMap<TbCompanyMemberCouncilTermDto, TbCompanyMemberCouncilTermUpdateDto>();
        CreateMap<TbCompanyMemberCouncilTermDto, TbCompanyMemberCouncilTermCreateDto>();
        CreateMap<TbCompanyMemberCouncilTermUpdateDto, TbCompanyMemberCouncilTermCreateDto>();

        CreateMap<TbCompanyMappingDto, TbCompanyMappingUpdateDto>();
        CreateMap<TbCompanyMappingDto, TbCompanyMappingCreateDto>();
        CreateMap<TbCompanyMappingUpdateDto, TbCompanyMappingCreateDto>();

        CreateMap<TbCompanyPersonTempDto, TbCompanyPersonTempUpdateDto>();
        CreateMap<TbCompanyPersonTempDto, TbCompanyPersonTempCreateDto>();
        CreateMap<TbCompanyPersonTempUpdateDto, TbCompanyPersonTempCreateDto>();

        CreateMap<TbCompanyStockDto, TbCompanyStockUpdateDto>();
        CreateMap<TbCompanyStockDto, TbCompanyStockCreateDto>();
        CreateMap<TbCompanyStockUpdateDto, TbCompanyStockCreateDto>();

        CreateMap<TbCompanyTempDto, TbCompanyTempUpdateDto>();
        CreateMap<TbCompanyTempDto, TbCompanyTempCreateDto>();
        CreateMap<TbCompanyTempUpdateDto, TbCompanyTempCreateDto>();

        CreateMap<TbConfigRetirementTimeDto, TbConfigRetirementTimeUpdateDto>();
        CreateMap<TbConfigRetirementTimeDto, TbConfigRetirementTimeCreateDto>();
        CreateMap<TbConfigRetirementTimeUpdateDto, TbConfigRetirementTimeCreateDto>();

        CreateMap<TbHisBreweryDto, TbHisBreweryUpdateDto>();
        CreateMap<TbHisBreweryDto, TbHisBreweryCreateDto>();
        CreateMap<TbHisBreweryUpdateDto, TbHisBreweryCreateDto>();

        CreateMap<TbPersonDto, TbPersonUpdateDto>();
        CreateMap<TbPersonDto, TbPersonCreateDto>();
        CreateMap<TbPersonUpdateDto, TbPersonCreateDto>();

        CreateMap<TbPersonTempDto, TbPersonTempUpdateDto>();
        CreateMap<TbPersonTempDto, TbPersonTempCreateDto>();
        CreateMap<TbPersonTempUpdateDto, TbPersonTempCreateDto>();

        CreateMap<TbNationalityDto, TbNationalityUpdateDto>();
        CreateMap<TbNationalityDto, TbNationalityCreateDto>();
        CreateMap<TbNationalityUpdateDto, TbNationalityCreateDto>();

        CreateMap<TbMenuDto, TbMenuUpdateDto>();
        CreateMap<TbMenuDto, TbMenuCreateDto>();
        CreateMap<TbMenuUpdateDto, TbMenuCreateDto>();

        CreateMap<TbInvestPersonDto, TbInvestPersonUpdateDto>();
        CreateMap<TbInvestPersonDto, TbInvestPersonCreateDto>();
        CreateMap<TbInvestPersonUpdateDto, TbInvestPersonCreateDto>();

        CreateMap<TbInvestDto, TbInvestUpdateDto>();
        CreateMap<TbInvestDto, TbInvestCreateDto>();
        CreateMap<TbInvestUpdateDto, TbInvestCreateDto>();

        CreateMap<TbInvestDetailDto, TbInvestDetailUpdateDto>();
        CreateMap<TbInvestDetailDto, TbInvestDetailCreateDto>();
        CreateMap<TbInvestDetailUpdateDto, TbInvestDetailCreateDto>();

        CreateMap<TbBranchDto, TbBranchUpdateDto>();
        CreateMap<TbBranchDto, TbBranchCreateDto>();
        CreateMap<TbBranchUpdateDto, TbBranchCreateDto>();

        CreateMap<TbSkuDto, TbSkuUpdateDto>();
        CreateMap<TbSkuDto, TbSkuCreateDto>();
        CreateMap<TbSkuUpdateDto, TbSkuCreateDto>();

        CreateMap<TbTermDto, TbTermUpdateDto>();
        CreateMap<TbTermDto, TbTermCreateDto>();
        CreateMap<TbTermUpdateDto, TbTermCreateDto>();

        CreateMap<TbUserMappingPersonDto, TbUserMappingPersonUpdateDto>();
        CreateMap<TbUserMappingPersonDto, TbUserMappingPersonCreateDto>();
        CreateMap<TbUserMappingPersonUpdateDto, TbUserMappingPersonCreateDto>();

        CreateMap<TbUserMappingCompanyDto, TbUserMappingCompanyUpdateDto>();
        CreateMap<TbUserMappingCompanyDto, TbUserMappingCompanyCreateDto>();
        CreateMap<TbUserMappingCompanyUpdateDto, TbUserMappingCompanyCreateDto>();

        CreateMap<TbUserMappingBreweryDto, TbUserMappingBreweryUpdateDto>();
        CreateMap<TbUserMappingBreweryDto, TbUserMappingBreweryCreateDto>();
        CreateMap<TbUserMappingBreweryUpdateDto, TbUserMappingBreweryCreateDto>();

        CreateMap<TbCompanyStockDto, TbCompanyStockUpdateDto>();
        CreateMap<TbCompanyStockDto, TbCompanyStockCreateDto>();
        CreateMap<TbCompanyStockUpdateDto, TbCompanyStockCreateDto>();

        CreateMap<TbHisBreweryDeliveryVolumeDto, TbHisBreweryDeliveryVolumeUpdateDto>();
        CreateMap<TbHisBreweryDeliveryVolumeDto, TbHisBreweryDeliveryVolumeCreateDto>();
        CreateMap<TbHisBreweryDeliveryVolumeUpdateDto, TbHisBreweryDeliveryVolumeCreateDto>();

        CreateMap<TbHisBrewerySkuDto, TbHisBrewerySkuUpdateDto>();
        CreateMap<TbHisBrewerySkuDto, TbHisBrewerySkuCreateDto>();
        CreateMap<TbHisBrewerySkuUpdateDto, TbHisBrewerySkuCreateDto>();

        CreateMap<TbHisCompanyDto, TbHisCompanyUpdateDto>();
        CreateMap<TbHisCompanyDto, TbHisCompanyCreateDto>();
        CreateMap<TbHisCompanyUpdateDto, TbHisCompanyCreateDto>();

        CreateMap<TbHisCompanyPersonDto, TbHisCompanyPersonUpdateDto>();
        CreateMap<TbHisCompanyPersonDto, TbHisCompanyPersonCreateDto>();
        CreateMap<TbHisCompanyPersonUpdateDto, TbHisCompanyPersonCreateDto>();

        CreateMap<TbHisLogPrintingDto, TbHisLogPrintingUpdateDto>();
        CreateMap<TbHisLogPrintingDto, TbHisLogPrintingCreateDto>();
        CreateMap<TbHisLogPrintingUpdateDto, TbHisLogPrintingCreateDto>();

        CreateMap<TbHisPersonDto, TbHisPersonUpdateDto>();
        CreateMap<TbHisPersonDto, TbHisPersonCreateDto>();
        CreateMap<TbHisPersonUpdateDto, TbHisPersonCreateDto>();

        CreateMap<TbTimeScriptDto, TbTimeScriptUpdateDto>();
        CreateMap<TbTimeScriptDto, TbTimeScriptCreateDto>();
        CreateMap<TbTimeScriptUpdateDto, TbTimeScriptCreateDto>();

        CreateMap<TbStockPriceDto, TbStockPriceUpdateDto>();
        CreateMap<TbStockPriceDto, TbStockPriceCreateDto>();
        CreateMap<TbStockPriceUpdateDto, TbStockPriceCreateDto>();

        CreateMap<TbLogErrorDto, TbLogErrorUpdateDto>();
        CreateMap<TbLogErrorDto, TbLogErrorCreateDto>();
        CreateMap<TbLogErrorUpdateDto, TbLogErrorCreateDto>();

        CreateMap<TbLogExportDataDto, TbLogExportDataUpdateDto>();
        CreateMap<TbLogExportDataDto, TbLogExportDataCreateDto>();
        CreateMap<TbLogExportDataUpdateDto, TbLogExportDataCreateDto>();

        CreateMap<TbLogLoginDto, TbLogLoginUpdateDto>();
        CreateMap<TbLogLoginDto, TbLogLoginCreateDto>();
        CreateMap<TbLogLoginUpdateDto, TbLogLoginCreateDto>();

        CreateMap<TbLogPrintingDto, TbLogPrintingUpdateDto>();
        CreateMap<TbLogPrintingDto, TbLogPrintingCreateDto>();
        CreateMap<TbLogPrintingUpdateDto, TbLogPrintingCreateDto>();

        CreateMap<TbLogRefeshAccountDto, TbLogRefeshAccountUpdateDto>();
        CreateMap<TbLogRefeshAccountDto, TbLogRefeshAccountCreateDto>();
        CreateMap<TbLogRefeshAccountUpdateDto, TbLogRefeshAccountCreateDto>();

        CreateMap<TbLogSendEmailDto, TbLogSendEmailUpdateDto>();
        CreateMap<TbLogSendEmailDto, TbLogSendEmailCreateDto>();
        CreateMap<TbLogSendEmailUpdateDto, TbLogSendEmailCreateDto>();

        CreateMap<TbLogSendEmailRetirementDto, TbLogSendEmailRetirementUpdateDto>();
        CreateMap<TbLogSendEmailRetirementDto, TbLogSendEmailRetirementCreateDto>();
        CreateMap<TbLogSendEmailRetirementUpdateDto, TbLogSendEmailRetirementCreateDto>();

        CreateMap<TbLogSyncUatDto, TbLogSyncUatUpdateDto>();
        CreateMap<TbLogSyncUatDto, TbLogSyncUatCreateDto>();
        CreateMap<TbLogSyncUatUpdateDto, TbLogSyncUatCreateDto>();

        CreateMap<TbUserInRoleDto, TbUserInRoleUpdateDto>();
        CreateMap<TbUserInRoleDto, TbUserInRoleCreateDto>();
        CreateMap<TbUserInRoleUpdateDto, TbUserInRoleCreateDto>();

        CreateMap<TbFileUploadTempDto, TbFileUploadTempUpdateDto>();
        CreateMap<TbFileUploadTempDto, TbFileUploadTempCreateDto>();
        CreateMap<TbFileUploadTempUpdateDto, TbFileUploadTempCreateDto>();

        CreateMap<TbCompanyMajorTempDto, TbCompanyMajorTempUpdateDto>();
        CreateMap<TbCompanyMajorTempDto, TbCompanyMajorTempCreateDto>();
        CreateMap<TbCompanyMajorTempUpdateDto, TbCompanyMajorTempCreateDto>();

        CreateMap<TbCompanyBranchTempDto, TbCompanyBranchTempUpdateDto>();
        CreateMap<TbCompanyBranchTempDto, TbCompanyBranchTempCreateDto>();
        CreateMap<TbCompanyBranchTempUpdateDto, TbCompanyBranchTempCreateDto>();

        CreateMap<TbCompanyBusinessTempDto, TbCompanyBusinessTempUpdateDto>();
        CreateMap<TbCompanyBusinessTempDto, TbCompanyBusinessTempCreateDto>();
        CreateMap<TbCompanyBusinessTempUpdateDto, TbCompanyBusinessTempCreateDto>();

        CreateMap<TbCompanyBusinessDetailTempDto, TbCompanyBusinessDetailTempUpdateDto>();
        CreateMap<TbCompanyBusinessDetailTempDto, TbCompanyBusinessDetailTempCreateDto>();
        CreateMap<TbCompanyBusinessDetailTempUpdateDto, TbCompanyBusinessDetailTempCreateDto>();

        CreateMap<TbCompanyMappingTempDto, TbCompanyMappingTempUpdateDto>();
        CreateMap<TbCompanyMappingTempDto, TbCompanyMappingTempCreateDto>();
        CreateMap<TbCompanyMappingTempUpdateDto, TbCompanyMappingTempCreateDto>();

        CreateMap<TbCompanyStockTempDto, TbCompanyStockTempUpdateDto>();
        CreateMap<TbCompanyStockTempDto, TbCompanyStockTempCreateDto>();
        CreateMap<TbCompanyStockTempUpdateDto, TbCompanyStockTempCreateDto>();

        CreateMap<TbContactTempDto, TbContactTempUpdateDto>();
        CreateMap<TbContactTempDto, TbContactTempCreateDto>();
        CreateMap<TbContactTempUpdateDto, TbContactTempCreateDto>();

        CreateMap<TbLandInfoTempDto, TbLandInfoTempUpdateDto>();
        CreateMap<TbLandInfoTempDto, TbLandInfoTempCreateDto>();
        CreateMap<TbLandInfoTempUpdateDto, TbLandInfoTempCreateDto>();

        CreateMap<TbNationalityTempDto, TbNationalityTempUpdateDto>();
        CreateMap<TbNationalityTempDto, TbNationalityTempCreateDto>();
        CreateMap<TbNationalityTempUpdateDto, TbNationalityTempCreateDto>();

        CreateMap<TbAdditionInfoTempDto, TbAdditionInfoTempUpdateDto>();
        CreateMap<TbAdditionInfoTempDto, TbAdditionInfoTempCreateDto>();
        CreateMap<TbAdditionInfoTempUpdateDto, TbAdditionInfoTempCreateDto>();

        CreateMap<TbCompanyInvestTempDto, TbCompanyInvestTempUpdateDto>();
        CreateMap<TbCompanyInvestTempDto, TbCompanyInvestTempCreateDto>();
        CreateMap<TbCompanyInvestTempUpdateDto, TbCompanyInvestTempCreateDto>();

        CreateMap<TsClassDto, TsClassUpdateDto>();
        CreateMap<TsClassDto, TsClassCreateDto>();
        CreateMap<TsClassUpdateDto, TsClassCreateDto>();

        CreateMap<TsClassTempDto, TsClassTempUpdateDto>();
        CreateMap<TsClassTempDto, TsClassTempCreateDto>();
        CreateMap<TsClassTempUpdateDto, TsClassTempCreateDto>();

    }
}

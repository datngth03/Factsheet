using Sabeco_Factsheet.TbFileUploads;
using Sabeco_Factsheet.TbUserMappingBreweries;
using Sabeco_Factsheet.TbUserMappingCompanies;
using Sabeco_Factsheet.TbUserMappingPersons;
using Sabeco_Factsheet.TbBranchs;
using Sabeco_Factsheet.TbInvestDetails;
using Sabeco_Factsheet.TbInvests;
using Sabeco_Factsheet.TbInvestPersons;
using Sabeco_Factsheet.TbMenus;
using Sabeco_Factsheet.TbNationalities;
using Sabeco_Factsheet.TbPersonTemps;
using Sabeco_Factsheet.TbPersons;
using Sabeco_Factsheet.TbHisBreweries;
using Sabeco_Factsheet.TbConfigRetirementTimes;
using Sabeco_Factsheet.TbCompanyTemps;
using Sabeco_Factsheet.TbCompanyStocks;
using Sabeco_Factsheet.TbCompanyPersonTemps;
using Sabeco_Factsheet.TbCompanyMappings;
using Sabeco_Factsheet.TbCompanyMemberCouncilTerms;
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
using Sabeco_Factsheet.TbAssets;
using Sabeco_Factsheet.TbContacts;
using Sabeco_Factsheet.TbRoles;
using Sabeco_Factsheet.TbPositions;
using Sabeco_Factsheet.TbLandInfos;
using Sabeco_Factsheet.TbCompanyPersons;
using Sabeco_Factsheet.TbCompanyMajors;
using Sabeco_Factsheet.TbCompanyInvests;
using Sabeco_Factsheet.TbCompanies;
using Sabeco_Factsheet.TbAdditionInfos;

using System;
using Sabeco_Factsheet.Shared;
using Volo.Abp.AutoMapper;
using AutoMapper;
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
using Sabeco_Factsheet.TbUsers;
using Sabeco_Factsheet.TbInfoUpdates;
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
using Sabeco_Factsheet.TbSkus;
using Sabeco_Factsheet.TbTerms;

namespace Sabeco_Factsheet;

public class Sabeco_FactsheetApplicationAutoMapperProfile : Profile
{
    public Sabeco_FactsheetApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
         
        CreateMap<TbAdditionInfo, TbAdditionInfoDto>().Ignore(x => x.IsChanged);
        CreateMap<TbAdditionInfo, TbAdditionInfoExcelDto>();

        CreateMap<TbCompany, TbCompanyDto>();
        CreateMap<TbCompany, TbCompanyExcelDto>();

        CreateMap<TbCompanyInvest, TbCompanyInvestDto>();
        CreateMap<TbCompanyInvest, TbCompanyInvestExcelDto>();

        CreateMap<TbCompanyMajor, TbCompanyMajorDto>();
        CreateMap<TbCompanyMajor, TbCompanyMajorExcelDto>();

        CreateMap<TbCompanyPerson, TbCompanyPersonDto>();
        CreateMap<TbCompanyPerson, TbCompanyPersonExcelDto>();

        CreateMap<TbLandInfo, TbLandInfoDto>().Ignore(x => x.IsChanged);
        CreateMap<TbLandInfo, TbLandInfoExcelDto>();

        CreateMap<TbCompany, TbCompanyDto>().Ignore(x => x.IsChanged);

        CreateMap<TbCompanyInvest, TbCompanyInvestDto>().Ignore(x => x.IsChanged);

        CreateMap<TbCompanyMajor, TbCompanyMajorDto>().Ignore(x => x.IsChanged);

        CreateMap<TbPosition, TbPositionDto>();

        CreateMap<TbRole, TbRoleDto>().Ignore(x => x.IsChanged);
        CreateMap<TbRole, TbRoleExcelDto>();

        CreateMap<TbPosition, TbPositionExcelDto>();

        CreateMap<TbContact, TbContactDto>();
        CreateMap<TbContact, TbContactExcelDto>();

        CreateMap<TbAsset, TbAssetDto>();
        CreateMap<TbAsset, TbAssetExcelDto>();

        CreateMap<TbBrewery, TbBreweryDto>().Ignore(x => x.IsChanged);
        CreateMap<TbBrewery, TbBreweryExcelDto>();

        CreateMap<TbBreweryDeliveryVolume, TbBreweryDeliveryVolumeDto>().Ignore(x => x.IsChanged);
        CreateMap<TbBreweryDeliveryVolume, TbBreweryDeliveryVolumeExcelDto>();

        CreateMap<TbBreweryDeliveryVolumeTemp, TbBreweryDeliveryVolumeTempDto>().Ignore(x => x.IsChanged);
        CreateMap<TbBreweryDeliveryVolumeTemp, TbBreweryDeliveryVolumeTempExcelDto>();

        CreateMap<TbBreweryImage, TbBreweryImageDto>().Ignore(x => x.IsChanged);
        CreateMap<TbBreweryImage, TbBreweryImageExcelDto>();

        CreateMap<TbBrewerySku, TbBrewerySkuDto>().Ignore(x => x.IsChanged);
        CreateMap<TbBrewerySku, TbBrewerySkuExcelDto>();

        CreateMap<TbBrewerySkuTemp, TbBrewerySkuTempDto>().Ignore(x => x.IsChanged);
        CreateMap<TbBrewerySkuTemp, TbBrewerySkuTempExcelDto>();

        CreateMap<TbBreweryTemp, TbBreweryTempDto>().Ignore(x => x.IsChanged);
        CreateMap<TbBreweryTemp, TbBreweryTempExcelDto>();

        CreateMap<TbCompanyBoard, TbCompanyBoardDto>();
        CreateMap<TbCompanyBoard, TbCompanyBoardExcelDto>();

        CreateMap<TbCompanyBranch, TbCompanyBranchDto>().Ignore(x => x.IsChanged);
        CreateMap<TbCompanyBranch, TbCompanyBranchExcelDto>();

        CreateMap<TbCompanyBranchImage, TbCompanyBranchImageDto>().Ignore(x => x.IsChanged);
        CreateMap<TbCompanyBranchImage, TbCompanyBranchImageExcelDto>();

        CreateMap<TbCompanyBusiness, TbCompanyBusinessDto>().Ignore(x => x.IsChanged);
        CreateMap<TbCompanyBusiness, TbCompanyBusinessExcelDto>();

        CreateMap<TbCompanyBusinessDetail, TbCompanyBusinessDetailDto>().Ignore(x => x.IsChanged);
        CreateMap<TbCompanyBusinessDetail, TbCompanyBusinessDetailExcelDto>();

        CreateMap<TbCompanyMemberCouncilTerm, TbCompanyMemberCouncilTermDto>();
        CreateMap<TbCompanyMemberCouncilTerm, TbCompanyMemberCouncilTermExcelDto>();

        CreateMap<TbCompanyMapping, TbCompanyMappingDto>().Ignore(x => x.IsChanged);
        CreateMap<TbCompanyMapping, TbCompanyMappingExcelDto>();

        CreateMap<TbCompanyPersonTemp, TbCompanyPersonTempDto>();
        CreateMap<TbCompanyPersonTemp, TbCompanyPersonTempExcelDto>();

        CreateMap<TbCompanyStock, TbCompanyStockDto>();
        CreateMap<TbCompanyStock, TbCompanyStockExcelDto>();

        CreateMap<TbCompanyTemp, TbCompanyTempDto>();
        CreateMap<TbCompanyTemp, TbCompanyTempExcelDto>();

        CreateMap<TbConfigRetirementTime, TbConfigRetirementTimeDto>().Ignore(x => x.IsChanged);
        CreateMap<TbConfigRetirementTime, TbConfigRetirementTimeExcelDto>();

        CreateMap<TbHisBrewery, TbHisBreweryDto>().Ignore(x => x.IsChanged);
        CreateMap<TbHisBrewery, TbHisBreweryExcelDto>();

        CreateMap<TbPerson, TbPersonDto>();
        CreateMap<TbPerson, TbPersonExcelDto>();

        CreateMap<TbPersonTemp, TbPersonTempDto>();
        CreateMap<TbPersonTemp, TbPersonTempExcelDto>();

        CreateMap<TbNationality, TbNationalityDto>();
        CreateMap<TbNationality, TbNationalityExcelDto>();

        CreateMap<TbMenu, TbMenuDto>().Ignore(x => x.IsChanged);
        CreateMap<TbMenu, TbMenuExcelDto>();

        CreateMap<TbInvestPerson, TbInvestPersonDto>();
        CreateMap<TbInvestPerson, TbInvestPersonExcelDto>();

        CreateMap<TbInvest, TbInvestDto>();
        CreateMap<TbInvest, TbInvestExcelDto>();

        CreateMap<TbInvestDetail, TbInvestDetailDto>();
        CreateMap<TbInvestDetail, TbInvestDetailExcelDto>();

        CreateMap<TbBranch, TbBranchDto>();
        CreateMap<TbBranch, TbBranchExcelDto>();

        CreateMap<TbUserMappingPerson, TbUserMappingPersonDto>();
        CreateMap<TbUserMappingPerson, TbUserMappingPersonExcelDto>();

        CreateMap<TbUserMappingCompany, TbUserMappingCompanyDto>();
        CreateMap<TbUserMappingCompany, TbUserMappingCompanyExcelDto>();

        CreateMap<TbUserMappingBrewery, TbUserMappingBreweryDto>();
        CreateMap<TbUserMappingBrewery, TbUserMappingBreweryExcelDto>();
        
        CreateMap<TbUser, TbUserDto>();
        CreateMap<TbUser, TbUserExcelDto>();
        CreateMap<TbUser, TbUserDto>().Ignore(x => x.IsChanged);
         
        CreateMap<TbCompanyStock, TbCompanyStockDto>();
        CreateMap<TbCompanyStock, TbCompanyStockExcelDto>();

        CreateMap<TbHisBrewery, TbHisBreweryDto>();

        CreateMap<TbHisBreweryDeliveryVolume, TbHisBreweryDeliveryVolumeDto>();
        CreateMap<TbHisBreweryDeliveryVolume, TbHisBreweryDeliveryVolumeExcelDto>();

        CreateMap<TbHisBrewerySku, TbHisBrewerySkuDto>();
        CreateMap<TbHisBrewerySku, TbHisBrewerySkuExcelDto>();

        CreateMap<TbHisCompany, TbHisCompanyDto>();
        CreateMap<TbHisCompany, TbHisCompanyExcelDto>();

        CreateMap<TbHisCompanyPerson, TbHisCompanyPersonDto>();
        CreateMap<TbHisCompanyPerson, TbHisCompanyPersonExcelDto>();

        CreateMap<TbHisLogPrinting, TbHisLogPrintingDto>();
        CreateMap<TbHisLogPrinting, TbHisLogPrintingExcelDto>();

        CreateMap<TbHisPerson, TbHisPersonDto>();
        CreateMap<TbHisPerson, TbHisPersonExcelDto>();

        CreateMap<TbTimeScript, TbTimeScriptDto>();
        CreateMap<TbTimeScript, TbTimeScriptExcelDto>();

        CreateMap<TbStockPrice, TbStockPriceDto>();
        CreateMap<TbStockPrice, TbStockPriceExcelDto>();

        CreateMap<TbLogError, TbLogErrorDto>();
        CreateMap<TbLogError, TbLogErrorExcelDto>();

        CreateMap<TbLogExportData, TbLogExportDataDto>();
        CreateMap<TbLogExportData, TbLogExportDataExcelDto>();

        CreateMap<TbLogLogin, TbLogLoginDto>();
        CreateMap<TbLogLogin, TbLogLoginExcelDto>();

        CreateMap<TbLogPrinting, TbLogPrintingDto>();
        CreateMap<TbLogPrinting, TbLogPrintingExcelDto>();

        CreateMap<TbLogRefeshAccount, TbLogRefeshAccountDto>();
        CreateMap<TbLogRefeshAccount, TbLogRefeshAccountExcelDto>();

        CreateMap<TbLogSendEmail, TbLogSendEmailDto>();
        CreateMap<TbLogSendEmail, TbLogSendEmailExcelDto>();

        CreateMap<TbLogSendEmailRetirement, TbLogSendEmailRetirementDto>();
        CreateMap<TbLogSendEmailRetirement, TbLogSendEmailRetirementExcelDto>();

        CreateMap<TbLogSyncUat, TbLogSyncUatDto>();
        CreateMap<TbLogSyncUat, TbLogSyncUatExcelDto>();

        CreateMap<TbMenu, TbMenuDto>();

        CreateMap<TbConfigRetirementTime, TbConfigRetirementTimeDto>();

        CreateMap<TbBrewerySkuTemp, TbBrewerySkuTempDto>();

        CreateMap<TbFileUpload, TbFileUploadDto>();
        CreateMap<TbFileUpload, TbFileUploadDto>().Ignore(x => x.IsChanged);
        CreateMap<TbFileUpload, TbFileUploadExcelDto>();
 
        CreateMap<TbFileUploadTemp, TbFileUploadTempDto>();
        CreateMap<TbFileUploadTemp, TbFileUploadTempDto>().Ignore(x => x.IsChanged);
        CreateMap<TbFileUploadTemp, TbFileUploadTempExcelDto>();
         
        CreateMap<TbUserInRole, TbUserInRoleDto>();
        CreateMap<TbUserInRole, TbUserInRoleExcelDto>(); 

        CreateMap<TbCompanyMajorTemp, TbCompanyMajorTempDto>();
        CreateMap<TbCompanyMajorTemp, TbCompanyMajorTempExcelDto>();

        CreateMap<TbCompanyBranchTemp, TbCompanyBranchTempDto>();
        CreateMap<TbCompanyBranchTemp, TbCompanyBranchTempExcelDto>();

        CreateMap<TbCompanyBusinessTemp, TbCompanyBusinessTempDto>();
        CreateMap<TbCompanyBusinessTemp, TbCompanyBusinessTempExcelDto>();

        CreateMap<TbCompanyBusinessDetailTemp, TbCompanyBusinessDetailTempDto>();
        CreateMap<TbCompanyBusinessDetailTemp, TbCompanyBusinessDetailTempExcelDto>();

        CreateMap<TbCompanyMappingTemp, TbCompanyMappingTempDto>();
        CreateMap<TbCompanyMappingTemp, TbCompanyMappingTempExcelDto>();

        CreateMap<TbCompanyStockTemp, TbCompanyStockTempDto>();
        CreateMap<TbCompanyStockTemp, TbCompanyStockTempExcelDto>();

        CreateMap<TbContactTemp, TbContactTempDto>();
        CreateMap<TbContactTemp, TbContactTempExcelDto>();

        CreateMap<TbLandInfoTemp, TbLandInfoTempDto>();
        CreateMap<TbLandInfoTemp, TbLandInfoTempExcelDto>();

        CreateMap<TbNationalityTemp, TbNationalityTempDto>();
        CreateMap<TbNationalityTemp, TbNationalityTempExcelDto>();
        
        CreateMap<TbAdditionInfoTemp, TbAdditionInfoTempDto>();
        CreateMap<TbAdditionInfoTemp, TbAdditionInfoTempExcelDto>();

        CreateMap<TbCompanyInvestTemp, TbCompanyInvestTempDto>();
        CreateMap<TbCompanyInvestTemp, TbCompanyInvestTempExcelDto>();
          
        CreateMap<TsClass, TsClassDto>();
        CreateMap<TsClass, TsClassExcelDto>();

        CreateMap<TsClassTemp, TsClassTempDto>();
        CreateMap<TsClassTemp, TsClassTempExcelDto>();

        CreateMap<TbInfoUpdate, TbInfoUpdateDto>().Ignore(x => x.IsChanged);
        CreateMap<TbInfoUpdate, TbInfoUpdateExcelDto>();
         
        CreateMap<TbSku, TbSkuDto>(); 
        CreateMap<TbSku, TbSkuDto>().Ignore(x => x.IsChanged);
        CreateMap<TbSku, TbSkuExcelDto>();

        CreateMap<TbTerm, TbTermDto>();
        CreateMap<TbTerm, TbTermExcelDto>();

        CreateMap<TbAdditionInfo, TbAdditionInfoDto>();

        CreateMap<TbAsset, TbAssetDto>();
        CreateMap<TbAsset, TbAssetExcelDto>();

        CreateMap<TbBranch, TbBranchDto>();
        CreateMap<TbBranch, TbBranchExcelDto>();

        CreateMap<TbBrewery, TbBreweryDto>();
        CreateMap<TbBrewery, TbBreweryExcelDto>();

        CreateMap<TbBreweryDeliveryVolume, TbBreweryDeliveryVolumeDto>();
        CreateMap<TbBreweryDeliveryVolume, TbBreweryDeliveryVolumeExcelDto>();

        CreateMap<TbBreweryDeliveryVolumeTemp, TbBreweryDeliveryVolumeTempDto>();
        CreateMap<TbBreweryDeliveryVolumeTemp, TbBreweryDeliveryVolumeTempExcelDto>();

        CreateMap<TbBreweryImage, TbBreweryImageDto>();
        CreateMap<TbBreweryImage, TbBreweryImageExcelDto>();

        CreateMap<TbBrewerySku, TbBrewerySkuDto>();
        CreateMap<TbBrewerySku, TbBrewerySkuExcelDto>();

        CreateMap<TbBrewerySkuTemp, TbBrewerySkuTempDto>();
        CreateMap<TbBrewerySkuTemp, TbBrewerySkuTempExcelDto>();

        CreateMap<TbBreweryTemp, TbBreweryTempDto>();
        CreateMap<TbBreweryTemp, TbBreweryTempExcelDto>();

        CreateMap<TbCompanyBoard, TbCompanyBoardDto>();
        CreateMap<TbCompanyBoard, TbCompanyBoardExcelDto>();

        CreateMap<TbCompanyBranch, TbCompanyBranchDto>();
        CreateMap<TbCompanyBranch, TbCompanyBranchExcelDto>();

        CreateMap<TbCompanyBranchImage, TbCompanyBranchImageDto>();
        CreateMap<TbCompanyBranchImage, TbCompanyBranchImageExcelDto>();

        CreateMap<TbCompanyBusiness, TbCompanyBusinessDto>();
        CreateMap<TbCompanyBusiness, TbCompanyBusinessExcelDto>();

        CreateMap<TbCompanyBusinessDetail, TbCompanyBusinessDetailDto>();
        CreateMap<TbCompanyBusinessDetail, TbCompanyBusinessDetailExcelDto>();

        CreateMap<TbCompanyMapping, TbCompanyMappingDto>();
        CreateMap<TbCompanyMapping, TbCompanyMappingExcelDto>();

        CreateMap<TbCompanyPersonTemp, TbCompanyPersonTempDto>();
        CreateMap<TbCompanyPersonTemp, TbCompanyPersonTempExcelDto>();

        CreateMap<TbCompanyStock, TbCompanyStockDto>();
        CreateMap<TbCompanyStock, TbCompanyStockExcelDto>();

        CreateMap<TbCompanyTemp, TbCompanyTempDto>();
        CreateMap<TbCompanyTemp, TbCompanyTempExcelDto>();

        CreateMap<TbConfigRetirementTime, TbConfigRetirementTimeDto>();
        CreateMap<TbConfigRetirementTime, TbConfigRetirementTimeExcelDto>();

        CreateMap<TbLandInfo, TbLandInfoDto>(); 
         
    }
}
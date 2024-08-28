using Sabeco_Factsheet.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Sabeco_Factsheet.Permissions;

public class Sabeco_FactsheetPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(Sabeco_FactsheetPermissions.GroupName);

        myGroup.AddPermission(Sabeco_FactsheetPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(Sabeco_FactsheetPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(Sabeco_FactsheetPermissions.MyPermission1, L("Permission:MyPermission1"));
        var tbInfoUpdatePermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbInfoUpdates.Default, L("Permission:TbInfoUpdates"));
        tbInfoUpdatePermission.AddChild(Sabeco_FactsheetPermissions.TbInfoUpdates.Create, L("Permission:Create"));
        tbInfoUpdatePermission.AddChild(Sabeco_FactsheetPermissions.TbInfoUpdates.Edit, L("Permission:Edit"));
        tbInfoUpdatePermission.AddChild(Sabeco_FactsheetPermissions.TbInfoUpdates.Delete, L("Permission:Delete"));

        var tbUserPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbUsers.Default, L("Permission:TbUsers"));
        tbUserPermission.AddChild(Sabeco_FactsheetPermissions.TbUsers.Create, L("Permission:Create"));
        tbUserPermission.AddChild(Sabeco_FactsheetPermissions.TbUsers.Edit, L("Permission:Edit"));
        tbUserPermission.AddChild(Sabeco_FactsheetPermissions.TbUsers.Delete, L("Permission:Delete"));

        var tbAdditionInfoPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbAdditionInfos.Default, L("Permission:TbAdditionInfos"));
        tbAdditionInfoPermission.AddChild(Sabeco_FactsheetPermissions.TbAdditionInfos.Create, L("Permission:Create"));
        tbAdditionInfoPermission.AddChild(Sabeco_FactsheetPermissions.TbAdditionInfos.Edit, L("Permission:Edit"));
        tbAdditionInfoPermission.AddChild(Sabeco_FactsheetPermissions.TbAdditionInfos.Delete, L("Permission:Delete"));

        var tbCompanyPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanies.Default, L("Permission:TbCompanies"));
        tbCompanyPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanies.Create, L("Permission:Create"));
        tbCompanyPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanies.Edit, L("Permission:Edit"));
        tbCompanyPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanies.Delete, L("Permission:Delete"));

        var tbCompanyInvestPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyInvests.Default, L("Permission:TbCompanyInvests"));
        tbCompanyInvestPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyInvests.Create, L("Permission:Create"));
        tbCompanyInvestPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyInvests.Edit, L("Permission:Edit"));
        tbCompanyInvestPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyInvests.Delete, L("Permission:Delete"));

        var tbCompanyMajorPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyMajors.Default, L("Permission:TbCompanyMajors"));
        tbCompanyMajorPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMajors.Create, L("Permission:Create"));
        tbCompanyMajorPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMajors.Edit, L("Permission:Edit"));
        tbCompanyMajorPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMajors.Delete, L("Permission:Delete"));

        var tbCompanyPersonPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyPersons.Default, L("Permission:TbCompanyPersons"));
        tbCompanyPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyPersons.Create, L("Permission:Create"));
        tbCompanyPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyPersons.Edit, L("Permission:Edit"));
        tbCompanyPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyPersons.Delete, L("Permission:Delete"));

        var tbFileUploadPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbFileUploads.Default, L("Permission:TbFileUploads"));
        tbFileUploadPermission.AddChild(Sabeco_FactsheetPermissions.TbFileUploads.Create, L("Permission:Create"));
        tbFileUploadPermission.AddChild(Sabeco_FactsheetPermissions.TbFileUploads.Edit, L("Permission:Edit"));
        tbFileUploadPermission.AddChild(Sabeco_FactsheetPermissions.TbFileUploads.Delete, L("Permission:Delete"));

        var tbLandInfoPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbLandInfos.Default, L("Permission:TbLandInfos"));
        tbLandInfoPermission.AddChild(Sabeco_FactsheetPermissions.TbLandInfos.Create, L("Permission:Create"));
        tbLandInfoPermission.AddChild(Sabeco_FactsheetPermissions.TbLandInfos.Edit, L("Permission:Edit"));
        tbLandInfoPermission.AddChild(Sabeco_FactsheetPermissions.TbLandInfos.Delete, L("Permission:Delete"));

        var tbPositionPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbPositions.Default, L("Permission:TbPositions"));
        tbPositionPermission.AddChild(Sabeco_FactsheetPermissions.TbPositions.Create, L("Permission:Create"));
        tbPositionPermission.AddChild(Sabeco_FactsheetPermissions.TbPositions.Edit, L("Permission:Edit"));
        tbPositionPermission.AddChild(Sabeco_FactsheetPermissions.TbPositions.Delete, L("Permission:Delete"));

        var tbRolePermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbRoles.Default, L("Permission:TbRoles"));
        tbRolePermission.AddChild(Sabeco_FactsheetPermissions.TbRoles.Create, L("Permission:Create"));
        tbRolePermission.AddChild(Sabeco_FactsheetPermissions.TbRoles.Edit, L("Permission:Edit"));
        tbRolePermission.AddChild(Sabeco_FactsheetPermissions.TbRoles.Delete, L("Permission:Delete"));

        var tbContactPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbContacts.Default, L("Permission:TbContacts"));
        tbContactPermission.AddChild(Sabeco_FactsheetPermissions.TbContacts.Create, L("Permission:Create"));
        tbContactPermission.AddChild(Sabeco_FactsheetPermissions.TbContacts.Edit, L("Permission:Edit"));
        tbContactPermission.AddChild(Sabeco_FactsheetPermissions.TbContacts.Delete, L("Permission:Delete"));

        var tbAssetPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbAssets.Default, L("Permission:TbAssets"));
        tbAssetPermission.AddChild(Sabeco_FactsheetPermissions.TbAssets.Create, L("Permission:Create"));
        tbAssetPermission.AddChild(Sabeco_FactsheetPermissions.TbAssets.Edit, L("Permission:Edit"));
        tbAssetPermission.AddChild(Sabeco_FactsheetPermissions.TbAssets.Delete, L("Permission:Delete"));

        var tbBreweryPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbBreweries.Default, L("Permission:TbBreweries"));
        tbBreweryPermission.AddChild(Sabeco_FactsheetPermissions.TbBreweries.Create, L("Permission:Create"));
        tbBreweryPermission.AddChild(Sabeco_FactsheetPermissions.TbBreweries.Edit, L("Permission:Edit"));
        tbBreweryPermission.AddChild(Sabeco_FactsheetPermissions.TbBreweries.Delete, L("Permission:Delete"));

        var tbBreweryDeliveryVolumePermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumes.Default, L("Permission:TbBreweryDeliveryVolumes"));
        tbBreweryDeliveryVolumePermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumes.Create, L("Permission:Create"));
        tbBreweryDeliveryVolumePermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumes.Edit, L("Permission:Edit"));
        tbBreweryDeliveryVolumePermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumes.Delete, L("Permission:Delete"));

        var tbBreweryDeliveryVolumeTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumeTemps.Default, L("Permission:TbBreweryDeliveryVolumeTemps"));
        tbBreweryDeliveryVolumeTempPermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumeTemps.Create, L("Permission:Create"));
        tbBreweryDeliveryVolumeTempPermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumeTemps.Edit, L("Permission:Edit"));
        tbBreweryDeliveryVolumeTempPermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumeTemps.Delete, L("Permission:Delete"));

        var tbBreweryImagePermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbBreweryImages.Default, L("Permission:TbBreweryImages"));
        tbBreweryImagePermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryImages.Create, L("Permission:Create"));
        tbBreweryImagePermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryImages.Edit, L("Permission:Edit"));
        tbBreweryImagePermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryImages.Delete, L("Permission:Delete"));

        var tbBrewerySkuPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbBrewerySkus.Default, L("Permission:TbBrewerySkus"));
        tbBrewerySkuPermission.AddChild(Sabeco_FactsheetPermissions.TbBrewerySkus.Create, L("Permission:Create"));
        tbBrewerySkuPermission.AddChild(Sabeco_FactsheetPermissions.TbBrewerySkus.Edit, L("Permission:Edit"));
        tbBrewerySkuPermission.AddChild(Sabeco_FactsheetPermissions.TbBrewerySkus.Delete, L("Permission:Delete"));

        var tbBrewerySkuTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbBrewerySkuTemps.Default, L("Permission:TbBrewerySkuTemps"));
        tbBrewerySkuTempPermission.AddChild(Sabeco_FactsheetPermissions.TbBrewerySkuTemps.Create, L("Permission:Create"));
        tbBrewerySkuTempPermission.AddChild(Sabeco_FactsheetPermissions.TbBrewerySkuTemps.Edit, L("Permission:Edit"));
        tbBrewerySkuTempPermission.AddChild(Sabeco_FactsheetPermissions.TbBrewerySkuTemps.Delete, L("Permission:Delete"));

        var tbBreweryTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbBreweryTemps.Default, L("Permission:TbBreweryTemps"));
        tbBreweryTempPermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryTemps.Create, L("Permission:Create"));
        tbBreweryTempPermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryTemps.Edit, L("Permission:Edit"));
        tbBreweryTempPermission.AddChild(Sabeco_FactsheetPermissions.TbBreweryTemps.Delete, L("Permission:Delete"));

        var tbCompanyBoardPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyBoards.Default, L("Permission:TbCompanyBoards"));
        tbCompanyBoardPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBoards.Create, L("Permission:Create"));
        tbCompanyBoardPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBoards.Edit, L("Permission:Edit"));
        tbCompanyBoardPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBoards.Delete, L("Permission:Delete"));

        var tbCompanyBranchPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyBranchs.Default, L("Permission:TbCompanyBranchs"));
        tbCompanyBranchPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBranchs.Create, L("Permission:Create"));
        tbCompanyBranchPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBranchs.Edit, L("Permission:Edit"));
        tbCompanyBranchPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBranchs.Delete, L("Permission:Delete"));

        var tbCompanyBranchImagePermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyBranchImages.Default, L("Permission:TbCompanyBranchImages"));
        tbCompanyBranchImagePermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBranchImages.Create, L("Permission:Create"));
        tbCompanyBranchImagePermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBranchImages.Edit, L("Permission:Edit"));
        tbCompanyBranchImagePermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBranchImages.Delete, L("Permission:Delete"));

        var tbCompanyBusinessPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyBusinesses.Default, L("Permission:TbCompanyBusinesses"));
        tbCompanyBusinessPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinesses.Create, L("Permission:Create"));
        tbCompanyBusinessPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinesses.Edit, L("Permission:Edit"));
        tbCompanyBusinessPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinesses.Delete, L("Permission:Delete"));

        var tbCompanyBusinessDetailPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyBusinessDetails.Default, L("Permission:TbCompanyBusinessDetails"));
        tbCompanyBusinessDetailPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinessDetails.Create, L("Permission:Create"));
        tbCompanyBusinessDetailPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinessDetails.Edit, L("Permission:Edit"));
        tbCompanyBusinessDetailPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinessDetails.Delete, L("Permission:Delete"));

        var tbCompanyMemberCouncilTermPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyMemberCouncilTerms.Default, L("Permission:TbCompanyMemberCouncilTerms"));
        tbCompanyMemberCouncilTermPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMemberCouncilTerms.Create, L("Permission:Create"));
        tbCompanyMemberCouncilTermPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMemberCouncilTerms.Edit, L("Permission:Edit"));
        tbCompanyMemberCouncilTermPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMemberCouncilTerms.Delete, L("Permission:Delete"));

        var tbCompanyMappingPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyMappings.Default, L("Permission:TbCompanyMappings"));
        tbCompanyMappingPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMappings.Create, L("Permission:Create"));
        tbCompanyMappingPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMappings.Edit, L("Permission:Edit"));
        tbCompanyMappingPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMappings.Delete, L("Permission:Delete"));

        var tbCompanyPersonTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyPersonTemps.Default, L("Permission:TbCompanyPersonTemps"));
        tbCompanyPersonTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyPersonTemps.Create, L("Permission:Create"));
        tbCompanyPersonTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyPersonTemps.Edit, L("Permission:Edit"));
        tbCompanyPersonTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyPersonTemps.Delete, L("Permission:Delete"));

        var TbCompanyStockPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyStocks.Default, L("Permission:TbCompanyStocks"));
        TbCompanyStockPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyStocks.Create, L("Permission:Create"));
        TbCompanyStockPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyStocks.Edit, L("Permission:Edit"));
        TbCompanyStockPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyStocks.Delete, L("Permission:Delete"));

        var tbCompanyTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyTemps.Default, L("Permission:TbCompanyTemps"));
        tbCompanyTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyTemps.Create, L("Permission:Create"));
        tbCompanyTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyTemps.Edit, L("Permission:Edit"));
        tbCompanyTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyTemps.Delete, L("Permission:Delete"));

        var tbConfigRetirementTimePermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbConfigRetirementTimes.Default, L("Permission:TbConfigRetirementTimes"));
        tbConfigRetirementTimePermission.AddChild(Sabeco_FactsheetPermissions.TbConfigRetirementTimes.Create, L("Permission:Create"));
        tbConfigRetirementTimePermission.AddChild(Sabeco_FactsheetPermissions.TbConfigRetirementTimes.Edit, L("Permission:Edit"));
        tbConfigRetirementTimePermission.AddChild(Sabeco_FactsheetPermissions.TbConfigRetirementTimes.Delete, L("Permission:Delete"));

        var tbHisBreweryPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbHisBreweries.Default, L("Permission:TbHisBreweries"));
        tbHisBreweryPermission.AddChild(Sabeco_FactsheetPermissions.TbHisBreweries.Create, L("Permission:Create"));
        tbHisBreweryPermission.AddChild(Sabeco_FactsheetPermissions.TbHisBreweries.Edit, L("Permission:Edit"));
        tbHisBreweryPermission.AddChild(Sabeco_FactsheetPermissions.TbHisBreweries.Delete, L("Permission:Delete"));

        var tbPersonPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbPersons.Default, L("Permission:TbPersons"));
        tbPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbPersons.Create, L("Permission:Create"));
        tbPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbPersons.Edit, L("Permission:Edit"));
        tbPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbPersons.Delete, L("Permission:Delete"));

        var tbPersonTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbPersonTemps.Default, L("Permission:TbPersonTemps"));
        tbPersonTempPermission.AddChild(Sabeco_FactsheetPermissions.TbPersonTemps.Create, L("Permission:Create"));
        tbPersonTempPermission.AddChild(Sabeco_FactsheetPermissions.TbPersonTemps.Edit, L("Permission:Edit"));
        tbPersonTempPermission.AddChild(Sabeco_FactsheetPermissions.TbPersonTemps.Delete, L("Permission:Delete"));

        var tbNationalityPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbNationalities.Default, L("Permission:TbNationalities"));
        tbNationalityPermission.AddChild(Sabeco_FactsheetPermissions.TbNationalities.Create, L("Permission:Create"));
        tbNationalityPermission.AddChild(Sabeco_FactsheetPermissions.TbNationalities.Edit, L("Permission:Edit"));
        tbNationalityPermission.AddChild(Sabeco_FactsheetPermissions.TbNationalities.Delete, L("Permission:Delete"));

        var tbMenuPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbMenus.Default, L("Permission:TbMenus"));
        tbMenuPermission.AddChild(Sabeco_FactsheetPermissions.TbMenus.Create, L("Permission:Create"));
        tbMenuPermission.AddChild(Sabeco_FactsheetPermissions.TbMenus.Edit, L("Permission:Edit"));
        tbMenuPermission.AddChild(Sabeco_FactsheetPermissions.TbMenus.Delete, L("Permission:Delete"));

        var tbInvestPersonPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbInvestPersons.Default, L("Permission:TbInvestPersons"));
        tbInvestPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbInvestPersons.Create, L("Permission:Create"));
        tbInvestPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbInvestPersons.Edit, L("Permission:Edit"));
        tbInvestPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbInvestPersons.Delete, L("Permission:Delete"));

        var tbInvestPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbInvests.Default, L("Permission:TbInvests"));
        tbInvestPermission.AddChild(Sabeco_FactsheetPermissions.TbInvests.Create, L("Permission:Create"));
        tbInvestPermission.AddChild(Sabeco_FactsheetPermissions.TbInvests.Edit, L("Permission:Edit"));
        tbInvestPermission.AddChild(Sabeco_FactsheetPermissions.TbInvests.Delete, L("Permission:Delete"));

        var tbInvestDetailPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbInvestDetails.Default, L("Permission:TbInvestDetails"));
        tbInvestDetailPermission.AddChild(Sabeco_FactsheetPermissions.TbInvestDetails.Create, L("Permission:Create"));
        tbInvestDetailPermission.AddChild(Sabeco_FactsheetPermissions.TbInvestDetails.Edit, L("Permission:Edit"));
        tbInvestDetailPermission.AddChild(Sabeco_FactsheetPermissions.TbInvestDetails.Delete, L("Permission:Delete"));

        var tbBranchPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbBranchs.Default, L("Permission:TbBranchs"));
        tbBranchPermission.AddChild(Sabeco_FactsheetPermissions.TbBranchs.Create, L("Permission:Create"));
        tbBranchPermission.AddChild(Sabeco_FactsheetPermissions.TbBranchs.Edit, L("Permission:Edit"));
        tbBranchPermission.AddChild(Sabeco_FactsheetPermissions.TbBranchs.Delete, L("Permission:Delete"));

        var tbSkuPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbSkus.Default, L("Permission:TbSkus"));
        tbSkuPermission.AddChild(Sabeco_FactsheetPermissions.TbSkus.Create, L("Permission:Create"));
        tbSkuPermission.AddChild(Sabeco_FactsheetPermissions.TbSkus.Edit, L("Permission:Edit"));
        tbSkuPermission.AddChild(Sabeco_FactsheetPermissions.TbSkus.Delete, L("Permission:Delete"));

        var tbTermPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbTerms.Default, L("Permission:TbTerms"));
        tbTermPermission.AddChild(Sabeco_FactsheetPermissions.TbTerms.Create, L("Permission:Create"));
        tbTermPermission.AddChild(Sabeco_FactsheetPermissions.TbTerms.Edit, L("Permission:Edit"));
        tbTermPermission.AddChild(Sabeco_FactsheetPermissions.TbTerms.Delete, L("Permission:Delete"));

        var tbUserMappingPersonPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbUserMappingPersons.Default, L("Permission:TbUserMappingPersons"));
        tbUserMappingPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbUserMappingPersons.Create, L("Permission:Create"));
        tbUserMappingPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbUserMappingPersons.Edit, L("Permission:Edit"));
        tbUserMappingPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbUserMappingPersons.Delete, L("Permission:Delete"));

        var tbUserMappingCompanyPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbUserMappingCompanies.Default, L("Permission:TbUserMappingCompanies"));
        tbUserMappingCompanyPermission.AddChild(Sabeco_FactsheetPermissions.TbUserMappingCompanies.Create, L("Permission:Create"));
        tbUserMappingCompanyPermission.AddChild(Sabeco_FactsheetPermissions.TbUserMappingCompanies.Edit, L("Permission:Edit"));
        tbUserMappingCompanyPermission.AddChild(Sabeco_FactsheetPermissions.TbUserMappingCompanies.Delete, L("Permission:Delete"));

        var tbUserMappingBreweryPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbUserMappingBreweries.Default, L("Permission:TbUserMappingBreweries"));
        tbUserMappingBreweryPermission.AddChild(Sabeco_FactsheetPermissions.TbUserMappingBreweries.Create, L("Permission:Create"));
        tbUserMappingBreweryPermission.AddChild(Sabeco_FactsheetPermissions.TbUserMappingBreweries.Edit, L("Permission:Edit"));
        tbUserMappingBreweryPermission.AddChild(Sabeco_FactsheetPermissions.TbUserMappingBreweries.Delete, L("Permission:Delete"));
         
        var tbHisBreweryDeliveryVolumePermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbHisBreweryDeliveryVolumes.Default, L("Permission:TbHisBreweryDeliveryVolumes"));
        tbHisBreweryDeliveryVolumePermission.AddChild(Sabeco_FactsheetPermissions.TbHisBreweryDeliveryVolumes.Create, L("Permission:Create"));
        tbHisBreweryDeliveryVolumePermission.AddChild(Sabeco_FactsheetPermissions.TbHisBreweryDeliveryVolumes.Edit, L("Permission:Edit"));
        tbHisBreweryDeliveryVolumePermission.AddChild(Sabeco_FactsheetPermissions.TbHisBreweryDeliveryVolumes.Delete, L("Permission:Delete"));

        var tbHisBrewerySkuPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbHisBrewerySkus.Default, L("Permission:TbHisBrewerySkus"));
        tbHisBrewerySkuPermission.AddChild(Sabeco_FactsheetPermissions.TbHisBrewerySkus.Create, L("Permission:Create"));
        tbHisBrewerySkuPermission.AddChild(Sabeco_FactsheetPermissions.TbHisBrewerySkus.Edit, L("Permission:Edit"));
        tbHisBrewerySkuPermission.AddChild(Sabeco_FactsheetPermissions.TbHisBrewerySkus.Delete, L("Permission:Delete"));

        var tbHisCompanyPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbHisCompanies.Default, L("Permission:TbHisCompanies"));
        tbHisCompanyPermission.AddChild(Sabeco_FactsheetPermissions.TbHisCompanies.Create, L("Permission:Create"));
        tbHisCompanyPermission.AddChild(Sabeco_FactsheetPermissions.TbHisCompanies.Edit, L("Permission:Edit"));
        tbHisCompanyPermission.AddChild(Sabeco_FactsheetPermissions.TbHisCompanies.Delete, L("Permission:Delete"));

        var tbHisCompanyPersonPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbHisCompanyPersons.Default, L("Permission:TbHisCompanyPersons"));
        tbHisCompanyPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbHisCompanyPersons.Create, L("Permission:Create"));
        tbHisCompanyPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbHisCompanyPersons.Edit, L("Permission:Edit"));
        tbHisCompanyPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbHisCompanyPersons.Delete, L("Permission:Delete"));

        var tbHisLogPrintingPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbHisLogPrintings.Default, L("Permission:TbHisLogPrintings"));
        tbHisLogPrintingPermission.AddChild(Sabeco_FactsheetPermissions.TbHisLogPrintings.Create, L("Permission:Create"));
        tbHisLogPrintingPermission.AddChild(Sabeco_FactsheetPermissions.TbHisLogPrintings.Edit, L("Permission:Edit"));
        tbHisLogPrintingPermission.AddChild(Sabeco_FactsheetPermissions.TbHisLogPrintings.Delete, L("Permission:Delete"));

        var tbHisPersonPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbHisPersons.Default, L("Permission:TbHisPersons"));
        tbHisPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbHisPersons.Create, L("Permission:Create"));
        tbHisPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbHisPersons.Edit, L("Permission:Edit"));
        tbHisPersonPermission.AddChild(Sabeco_FactsheetPermissions.TbHisPersons.Delete, L("Permission:Delete"));

        var tbTimeScriptPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbTimeScripts.Default, L("Permission:TbTimeScripts"));
        tbTimeScriptPermission.AddChild(Sabeco_FactsheetPermissions.TbTimeScripts.Create, L("Permission:Create"));
        tbTimeScriptPermission.AddChild(Sabeco_FactsheetPermissions.TbTimeScripts.Edit, L("Permission:Edit"));
        tbTimeScriptPermission.AddChild(Sabeco_FactsheetPermissions.TbTimeScripts.Delete, L("Permission:Delete"));

        var tbStockPricePermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbStockPrices.Default, L("Permission:TbStockPrices"));
        tbStockPricePermission.AddChild(Sabeco_FactsheetPermissions.TbStockPrices.Create, L("Permission:Create"));
        tbStockPricePermission.AddChild(Sabeco_FactsheetPermissions.TbStockPrices.Edit, L("Permission:Edit"));
        tbStockPricePermission.AddChild(Sabeco_FactsheetPermissions.TbStockPrices.Delete, L("Permission:Delete"));

        var tbLogErrorPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbLogErrors.Default, L("Permission:TbLogErrors"));
        tbLogErrorPermission.AddChild(Sabeco_FactsheetPermissions.TbLogErrors.Create, L("Permission:Create"));
        tbLogErrorPermission.AddChild(Sabeco_FactsheetPermissions.TbLogErrors.Edit, L("Permission:Edit"));
        tbLogErrorPermission.AddChild(Sabeco_FactsheetPermissions.TbLogErrors.Delete, L("Permission:Delete"));

        var tbLogExportDataPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbLogExportDatas.Default, L("Permission:TbLogExportDatas"));
        tbLogExportDataPermission.AddChild(Sabeco_FactsheetPermissions.TbLogExportDatas.Create, L("Permission:Create"));
        tbLogExportDataPermission.AddChild(Sabeco_FactsheetPermissions.TbLogExportDatas.Edit, L("Permission:Edit"));
        tbLogExportDataPermission.AddChild(Sabeco_FactsheetPermissions.TbLogExportDatas.Delete, L("Permission:Delete"));

        var tbLogLoginPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbLogLogins.Default, L("Permission:TbLogLogins"));
        tbLogLoginPermission.AddChild(Sabeco_FactsheetPermissions.TbLogLogins.Create, L("Permission:Create"));
        tbLogLoginPermission.AddChild(Sabeco_FactsheetPermissions.TbLogLogins.Edit, L("Permission:Edit"));
        tbLogLoginPermission.AddChild(Sabeco_FactsheetPermissions.TbLogLogins.Delete, L("Permission:Delete"));

        var tbLogPrintingPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbLogPrintings.Default, L("Permission:TbLogPrintings"));
        tbLogPrintingPermission.AddChild(Sabeco_FactsheetPermissions.TbLogPrintings.Create, L("Permission:Create"));
        tbLogPrintingPermission.AddChild(Sabeco_FactsheetPermissions.TbLogPrintings.Edit, L("Permission:Edit"));
        tbLogPrintingPermission.AddChild(Sabeco_FactsheetPermissions.TbLogPrintings.Delete, L("Permission:Delete"));

        var tbLogRefeshAccountPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbLogRefeshAccounts.Default, L("Permission:TbLogRefeshAccounts"));
        tbLogRefeshAccountPermission.AddChild(Sabeco_FactsheetPermissions.TbLogRefeshAccounts.Create, L("Permission:Create"));
        tbLogRefeshAccountPermission.AddChild(Sabeco_FactsheetPermissions.TbLogRefeshAccounts.Edit, L("Permission:Edit"));
        tbLogRefeshAccountPermission.AddChild(Sabeco_FactsheetPermissions.TbLogRefeshAccounts.Delete, L("Permission:Delete"));

        var tbLogSendEmailPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbLogSendEmails.Default, L("Permission:TbLogSendEmails"));
        tbLogSendEmailPermission.AddChild(Sabeco_FactsheetPermissions.TbLogSendEmails.Create, L("Permission:Create"));
        tbLogSendEmailPermission.AddChild(Sabeco_FactsheetPermissions.TbLogSendEmails.Edit, L("Permission:Edit"));
        tbLogSendEmailPermission.AddChild(Sabeco_FactsheetPermissions.TbLogSendEmails.Delete, L("Permission:Delete"));

        var tbLogSendEmailRetirementPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbLogSendEmailRetirements.Default, L("Permission:TbLogSendEmailRetirements"));
        tbLogSendEmailRetirementPermission.AddChild(Sabeco_FactsheetPermissions.TbLogSendEmailRetirements.Create, L("Permission:Create"));
        tbLogSendEmailRetirementPermission.AddChild(Sabeco_FactsheetPermissions.TbLogSendEmailRetirements.Edit, L("Permission:Edit"));
        tbLogSendEmailRetirementPermission.AddChild(Sabeco_FactsheetPermissions.TbLogSendEmailRetirements.Delete, L("Permission:Delete"));

        var tbLogSyncUatPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbLogSyncUats.Default, L("Permission:TbLogSyncUats"));
        tbLogSyncUatPermission.AddChild(Sabeco_FactsheetPermissions.TbLogSyncUats.Create, L("Permission:Create"));
        tbLogSyncUatPermission.AddChild(Sabeco_FactsheetPermissions.TbLogSyncUats.Edit, L("Permission:Edit"));
        tbLogSyncUatPermission.AddChild(Sabeco_FactsheetPermissions.TbLogSyncUats.Delete, L("Permission:Delete"));

        var tbUserInRolePermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbUserInRoles.Default, L("Permission:TbUserInRoles"));
        tbUserInRolePermission.AddChild(Sabeco_FactsheetPermissions.TbUserInRoles.Create, L("Permission:Create"));
        tbUserInRolePermission.AddChild(Sabeco_FactsheetPermissions.TbUserInRoles.Edit, L("Permission:Edit"));
        tbUserInRolePermission.AddChild(Sabeco_FactsheetPermissions.TbUserInRoles.Delete, L("Permission:Delete"));

        var tbFileUploadTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbFileUploadTemps.Default, L("Permission:TbFileUploadTemps"));
        tbFileUploadTempPermission.AddChild(Sabeco_FactsheetPermissions.TbFileUploadTemps.Create, L("Permission:Create"));
        tbFileUploadTempPermission.AddChild(Sabeco_FactsheetPermissions.TbFileUploadTemps.Edit, L("Permission:Edit"));
        tbFileUploadTempPermission.AddChild(Sabeco_FactsheetPermissions.TbFileUploadTemps.Delete, L("Permission:Delete"));

        var tbCompanyMajorTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyMajorTemps.Default, L("Permission:TbCompanyMajorTemps"));
        tbCompanyMajorTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMajorTemps.Create, L("Permission:Create"));
        tbCompanyMajorTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMajorTemps.Edit, L("Permission:Edit"));
        tbCompanyMajorTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMajorTemps.Delete, L("Permission:Delete"));

        var tbCompanyBranchTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyBranchTemps.Default, L("Permission:TbCompanyBranchTemps"));
        tbCompanyBranchTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBranchTemps.Create, L("Permission:Create"));
        tbCompanyBranchTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBranchTemps.Edit, L("Permission:Edit"));
        tbCompanyBranchTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBranchTemps.Delete, L("Permission:Delete"));

        var tbCompanyBusinessTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyBusinessTemps.Default, L("Permission:TbCompanyBusinessTemps"));
        tbCompanyBusinessTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinessTemps.Create, L("Permission:Create"));
        tbCompanyBusinessTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinessTemps.Edit, L("Permission:Edit"));
        tbCompanyBusinessTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinessTemps.Delete, L("Permission:Delete"));

        var tbCompanyBusinessDetailTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyBusinessDetailTemps.Default, L("Permission:TbCompanyBusinessDetailTemps"));
        tbCompanyBusinessDetailTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinessDetailTemps.Create, L("Permission:Create"));
        tbCompanyBusinessDetailTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinessDetailTemps.Edit, L("Permission:Edit"));
        tbCompanyBusinessDetailTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyBusinessDetailTemps.Delete, L("Permission:Delete"));

        var tbCompanyMappingTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyMappingTemps.Default, L("Permission:TbCompanyMappingTemps"));
        tbCompanyMappingTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMappingTemps.Create, L("Permission:Create"));
        tbCompanyMappingTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMappingTemps.Edit, L("Permission:Edit"));
        tbCompanyMappingTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyMappingTemps.Delete, L("Permission:Delete"));

        var tbCompanyStockTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyStockTemps.Default, L("Permission:TbCompanyStockTemps"));
        tbCompanyStockTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyStockTemps.Create, L("Permission:Create"));
        tbCompanyStockTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyStockTemps.Edit, L("Permission:Edit"));
        tbCompanyStockTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyStockTemps.Delete, L("Permission:Delete"));

        var tbContactTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbContactTemps.Default, L("Permission:TbContactTemps"));
        tbContactTempPermission.AddChild(Sabeco_FactsheetPermissions.TbContactTemps.Create, L("Permission:Create"));
        tbContactTempPermission.AddChild(Sabeco_FactsheetPermissions.TbContactTemps.Edit, L("Permission:Edit"));
        tbContactTempPermission.AddChild(Sabeco_FactsheetPermissions.TbContactTemps.Delete, L("Permission:Delete"));

        var tbLandInfoTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbLandInfoTemps.Default, L("Permission:TbLandInfoTemps"));
        tbLandInfoTempPermission.AddChild(Sabeco_FactsheetPermissions.TbLandInfoTemps.Create, L("Permission:Create"));
        tbLandInfoTempPermission.AddChild(Sabeco_FactsheetPermissions.TbLandInfoTemps.Edit, L("Permission:Edit"));
        tbLandInfoTempPermission.AddChild(Sabeco_FactsheetPermissions.TbLandInfoTemps.Delete, L("Permission:Delete"));

        var tbNationalityTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbNationalityTemps.Default, L("Permission:TbNationalityTemps"));
        tbNationalityTempPermission.AddChild(Sabeco_FactsheetPermissions.TbNationalityTemps.Create, L("Permission:Create"));
        tbNationalityTempPermission.AddChild(Sabeco_FactsheetPermissions.TbNationalityTemps.Edit, L("Permission:Edit"));
        tbNationalityTempPermission.AddChild(Sabeco_FactsheetPermissions.TbNationalityTemps.Delete, L("Permission:Delete"));

        var tbAdditionInfoTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbAdditionInfoTemps.Default, L("Permission:TbAdditionInfoTemps"));
        tbAdditionInfoTempPermission.AddChild(Sabeco_FactsheetPermissions.TbAdditionInfoTemps.Create, L("Permission:Create"));
        tbAdditionInfoTempPermission.AddChild(Sabeco_FactsheetPermissions.TbAdditionInfoTemps.Edit, L("Permission:Edit"));
        tbAdditionInfoTempPermission.AddChild(Sabeco_FactsheetPermissions.TbAdditionInfoTemps.Delete, L("Permission:Delete"));

        var tbCompanyInvestTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TbCompanyInvestTemps.Default, L("Permission:TbCompanyInvestTemps"));
        tbCompanyInvestTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyInvestTemps.Create, L("Permission:Create"));
        tbCompanyInvestTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyInvestTemps.Edit, L("Permission:Edit"));
        tbCompanyInvestTempPermission.AddChild(Sabeco_FactsheetPermissions.TbCompanyInvestTemps.Delete, L("Permission:Delete"));

        var tsClassPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TsClasses.Default, L("Permission:TsClasses"));
        tsClassPermission.AddChild(Sabeco_FactsheetPermissions.TsClasses.Create, L("Permission:Create"));
        tsClassPermission.AddChild(Sabeco_FactsheetPermissions.TsClasses.Edit, L("Permission:Edit"));
        tsClassPermission.AddChild(Sabeco_FactsheetPermissions.TsClasses.Delete, L("Permission:Delete"));

        var tsClassTempPermission = myGroup.AddPermission(Sabeco_FactsheetPermissions.TsClassTemps.Default, L("Permission:TsClassTemps"));
        tsClassTempPermission.AddChild(Sabeco_FactsheetPermissions.TsClassTemps.Create, L("Permission:Create"));
        tsClassTempPermission.AddChild(Sabeco_FactsheetPermissions.TsClassTemps.Edit, L("Permission:Edit"));
        tsClassTempPermission.AddChild(Sabeco_FactsheetPermissions.TsClassTemps.Delete, L("Permission:Delete"));
    }


    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<Sabeco_FactsheetResource>(name);
    }
}
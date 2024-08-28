using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbAssets
{
    public abstract class TbAssetManagerBase : DomainService
    {
        public ITbAssetRepository _tbAssetRepository;

        public TbAssetManagerBase(ITbAssetRepository tbAssetRepository)
        {
            _tbAssetRepository = tbAssetRepository;
        }

        public virtual async Task<TbAsset> CreateAsync(
        int companyId, bool isDeleted, string? assetType = null, string? assetItem = null, string? assetAddress = null, decimal? quantity = null, string? docNo = null, DateTime? docDate = null, DateTime? expireDate = null, string? description = null, byte? docStatus = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.Length(assetType, nameof(assetType), TbAssetConsts.AssetTypeMaxLength);
            Check.Length(assetItem, nameof(assetItem), TbAssetConsts.AssetItemMaxLength);
            Check.Length(assetAddress, nameof(assetAddress), TbAssetConsts.AssetAddressMaxLength);
            Check.Length(docNo, nameof(docNo), TbAssetConsts.DocNoMaxLength);
            Check.Length(description, nameof(description), TbAssetConsts.DescriptionMaxLength);

            var tbAsset = new TbAsset(

             companyId, isDeleted, assetType, assetItem, assetAddress, quantity, docNo, docDate, expireDate, description, docStatus, isActive, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbAssetRepository.InsertAsync(tbAsset);
        }

        public virtual async Task<TbAsset> UpdateAsync(
            int id,
            int companyId, bool isDeleted, string? assetType = null, string? assetItem = null, string? assetAddress = null, decimal? quantity = null, string? docNo = null, DateTime? docDate = null, DateTime? expireDate = null, string? description = null, byte? docStatus = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.Length(assetType, nameof(assetType), TbAssetConsts.AssetTypeMaxLength);
            Check.Length(assetItem, nameof(assetItem), TbAssetConsts.AssetItemMaxLength);
            Check.Length(assetAddress, nameof(assetAddress), TbAssetConsts.AssetAddressMaxLength);
            Check.Length(docNo, nameof(docNo), TbAssetConsts.DocNoMaxLength);
            Check.Length(description, nameof(description), TbAssetConsts.DescriptionMaxLength);

            var tbAsset = await _tbAssetRepository.GetAsync(id);

            tbAsset.CompanyId = companyId;
            tbAsset.IsDeleted = isDeleted;
            tbAsset.AssetType = assetType;
            tbAsset.AssetItem = assetItem;
            tbAsset.AssetAddress = assetAddress;
            tbAsset.Quantity = quantity;
            tbAsset.DocNo = docNo;
            tbAsset.DocDate = docDate;
            tbAsset.ExpireDate = expireDate;
            tbAsset.Description = description;
            tbAsset.DocStatus = docStatus;
            tbAsset.IsActive = isActive;
            tbAsset.crt_date = crt_date;
            tbAsset.crt_user = crt_user;
            tbAsset.mod_date = mod_date;
            tbAsset.mod_user = mod_user;

            return await _tbAssetRepository.UpdateAsync(tbAsset);
        }

    }
}
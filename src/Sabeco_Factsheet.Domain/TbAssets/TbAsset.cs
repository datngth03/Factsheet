using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbAssets
{
    public abstract class TbAssetBase : Entity<int>
    {
        public virtual int CompanyId { get; set; }

        [CanBeNull]
        public virtual string? AssetType { get; set; }

        [CanBeNull]
        public virtual string? AssetItem { get; set; }

        [CanBeNull]
        public virtual string? AssetAddress { get; set; }

        public virtual decimal? Quantity { get; set; }

        [CanBeNull]
        public virtual string? DocNo { get; set; }

        public virtual DateTime? DocDate { get; set; }

        public virtual DateTime? ExpireDate { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        public virtual byte? DocStatus { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        protected TbAssetBase()
        {

        }

        public TbAssetBase(int companyId, bool isDeleted, string? assetType = null, string? assetItem = null, string? assetAddress = null, decimal? quantity = null, string? docNo = null, DateTime? docDate = null, DateTime? expireDate = null, string? description = null, byte? docStatus = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            Check.Length(assetType, nameof(assetType), TbAssetConsts.AssetTypeMaxLength, 0);
            Check.Length(assetItem, nameof(assetItem), TbAssetConsts.AssetItemMaxLength, 0);
            Check.Length(assetAddress, nameof(assetAddress), TbAssetConsts.AssetAddressMaxLength, 0);
            Check.Length(docNo, nameof(docNo), TbAssetConsts.DocNoMaxLength, 0);
            Check.Length(description, nameof(description), TbAssetConsts.DescriptionMaxLength, 0);
            CompanyId = companyId;
            IsDeleted = isDeleted;
            AssetType = assetType;
            AssetItem = assetItem;
            AssetAddress = assetAddress;
            Quantity = quantity;
            DocNo = docNo;
            DocDate = docDate;
            ExpireDate = expireDate;
            Description = description;
            DocStatus = docStatus;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
        }

    }
}
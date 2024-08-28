using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbAssets
{
    public abstract class TbAssetDtoBase : AuditedEntityDto<int>
    {
        public int CompanyId { get; set; }
        public string? AssetType { get; set; }
        public string? AssetItem { get; set; }
        public string? AssetAddress { get; set; }
        public decimal? Quantity { get; set; }
        public string? DocNo { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string? Description { get; set; }
        public byte? DocStatus { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }

    }
}
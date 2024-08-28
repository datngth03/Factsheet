using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbAssets
{
    public abstract class TbAssetUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }
        [StringLength(TbAssetConsts.AssetTypeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? AssetType { get; set; }
        [StringLength(TbAssetConsts.AssetItemMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? AssetItem { get; set; }
        [StringLength(TbAssetConsts.AssetAddressMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? AssetAddress { get; set; }
        public decimal? Quantity { get; set; }
        [StringLength(TbAssetConsts.DocNoMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? DocNo { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        [StringLength(TbAssetConsts.DescriptionMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Description { get; set; }
        public byte? DocStatus { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public bool IsDeleted { get; set; }

    }
}
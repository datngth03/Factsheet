using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbAssets
{
    public abstract class TbAssetExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public string? AssetType { get; set; }
        public string? AssetItem { get; set; }
        public string? AssetAddress { get; set; }
        public decimal? QuantityMin { get; set; }
        public decimal? QuantityMax { get; set; }
        public string? DocNo { get; set; }
        public DateTime? DocDateMin { get; set; }
        public DateTime? DocDateMax { get; set; }
        public DateTime? ExpireDateMin { get; set; }
        public DateTime? ExpireDateMax { get; set; }
        public string? Description { get; set; }
        public byte? DocStatusMin { get; set; }
        public byte? DocStatusMax { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }

        public TbAssetExcelDownloadDtoBase()
        {

        }
    }
}
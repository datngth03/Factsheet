using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbLandInfos
{
    public abstract class TbLandInfoExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? TypeOfLand { get; set; }
        public decimal? AreaMin { get; set; }
        public decimal? AreaMax { get; set; }
        public string? SupportingDocument { get; set; }
        public DateTime? IssueDateMin { get; set; }
        public DateTime? IssueDateMax { get; set; }
        public DateTime? ExpiryDateMin { get; set; }
        public DateTime? ExpiryDateMax { get; set; }
        public string? Payment { get; set; }
        public string? Remark { get; set; }
        public bool? IsActive { get; set; }
        public int? create_userMin { get; set; }
        public int? create_userMax { get; set; }
        public DateTime? create_dateMin { get; set; }
        public DateTime? create_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }

        public TbLandInfoExcelDownloadDtoBase()
        {

        }
    }
}
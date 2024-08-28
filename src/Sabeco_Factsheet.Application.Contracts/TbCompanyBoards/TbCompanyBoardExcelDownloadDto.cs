using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbCompanyBoards
{
    public abstract class TbCompanyBoardExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? BranchCode { get; set; }
        public string? CompanyCode { get; set; }
        public string? PersonCode { get; set; }
        public DateTime? FromDateMin { get; set; }
        public DateTime? FromDateMax { get; set; }
        public DateTime? ToDateMin { get; set; }
        public DateTime? ToDateMax { get; set; }
        public string? PositionCode { get; set; }
        public int? PersonalValueMin { get; set; }
        public int? PersonalValueMax { get; set; }
        public int? OwnerValueMin { get; set; }
        public int? OwnerValueMax { get; set; }
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public bool? IsDeleted { get; set; }

        public TbCompanyBoardExcelDownloadDtoBase()
        {

        }
    }
}
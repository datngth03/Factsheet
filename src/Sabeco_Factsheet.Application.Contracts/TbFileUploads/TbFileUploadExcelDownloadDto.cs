using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbFileUploads
{
    public abstract class TbFileUploadExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? companyIdMin { get; set; }
        public int? companyIdMax { get; set; }
        public int? personIdMin { get; set; }
        public int? personIdMax { get; set; }
        public string? fileName { get; set; }
        public string? fullFileName { get; set; }
        public string? fileLink { get; set; }
        public DateTime? uploadDateMin { get; set; }
        public DateTime? uploadDateMax { get; set; }
        public int? UserUploadMin { get; set; }
        public int? UserUploadMax { get; set; }
        public string? note { get; set; }
        public bool? IsActive { get; set; }
        public int? DownloadCountMin { get; set; }
        public int? DownloadCountMax { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }

        public TbFileUploadExcelDownloadDtoBase()
        {

        }
    }
}
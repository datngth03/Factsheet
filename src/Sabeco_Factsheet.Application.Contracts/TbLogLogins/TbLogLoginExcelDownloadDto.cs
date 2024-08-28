using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbLogLogins
{
    public abstract class TbLogLoginExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? UserName { get; set; }
        public DateTime? LoginDateMin { get; set; }
        public DateTime? LoginDateMax { get; set; }
        public string? IPTracking { get; set; }
        public bool? StatusLogin { get; set; }

        public TbLogLoginExcelDownloadDtoBase()
        {

        }
    }
}
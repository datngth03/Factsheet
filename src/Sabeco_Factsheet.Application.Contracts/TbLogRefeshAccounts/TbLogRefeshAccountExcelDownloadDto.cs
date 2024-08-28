using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public abstract class TbLogRefeshAccountExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? AccessToken { get; set; }
        public DateTime? TimeRefeshMin { get; set; }
        public DateTime? TimeRefeshMax { get; set; }
        public bool? IsSuccess { get; set; }
        public string? UseRefesh { get; set; }
        public string? FailedReason { get; set; }

        public TbLogRefeshAccountExcelDownloadDtoBase()
        {

        }
    }
}
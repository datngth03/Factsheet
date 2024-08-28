using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbLogErrors
{
    public abstract class TbLogErrorExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public DateTime? TimeLogMin { get; set; }
        public DateTime? TimeLogMax { get; set; }
        public int? UserLogMin { get; set; }
        public int? UserLogMax { get; set; }
        public string? IPAddress { get; set; }
        public string? ClassLog { get; set; }
        public string? FunctionLog { get; set; }
        public string? ReasonFailed { get; set; }

        public TbLogErrorExcelDownloadDtoBase()
        {

        }
    }
}
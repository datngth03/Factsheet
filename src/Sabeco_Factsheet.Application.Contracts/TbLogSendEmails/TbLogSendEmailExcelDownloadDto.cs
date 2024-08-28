using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbLogSendEmails
{
    public abstract class TbLogSendEmailExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public DateTime? TimeSendMin { get; set; }
        public DateTime? TimeSendMax { get; set; }
        public bool? IsSuccess { get; set; }
        public string? UserSend { get; set; }
        public string? TypeEmail { get; set; }
        public string? FailedReason { get; set; }

        public TbLogSendEmailExcelDownloadDtoBase()
        {

        }
    }
}
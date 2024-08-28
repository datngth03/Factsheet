using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbHisLogPrintings
{
    public abstract class TbHisLogPrintingExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMailMin { get; set; }
        public DateTime? DateSendMailMax { get; set; }
        public int? TypeMin { get; set; }
        public int? TypeMax { get; set; }
        public DateTime? InsertDateMin { get; set; }
        public DateTime? InsertDateMax { get; set; }
        public string? UserName { get; set; }
        public string? CompanyCode { get; set; }
        public string? FileLanguage { get; set; }
        public bool? IsPrinting { get; set; }

        public TbHisLogPrintingExcelDownloadDtoBase()
        {

        }
    }
}
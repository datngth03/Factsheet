using System;

namespace Sabeco_Factsheet.TbLogPrintings
{
    public abstract class TbLogPrintingExcelDtoBase
    {
        public string? userName { get; set; }
        public string? companyCode { get; set; }
        public string? fileLanguage { get; set; }
        public bool? isPrinting { get; set; }
        public DateTime? printTime { get; set; }
    }
}
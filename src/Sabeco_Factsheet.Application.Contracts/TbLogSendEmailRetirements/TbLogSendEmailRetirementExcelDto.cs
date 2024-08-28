using System;

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public abstract class TbLogSendEmailRetirementExcelDtoBase
    {
        public int? idCompany { get; set; }
        public int? idPerson { get; set; }
        public bool? IsSendEmail { get; set; }
        public DateTime? DateSendEmail { get; set; }
        public int? Type { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public abstract class TbLogSendEmailRetirementCreateDtoBase
    {
        public int? idCompany { get; set; }
        public int? idPerson { get; set; }
        public bool? IsSendEmail { get; set; }
        public DateTime? DateSendEmail { get; set; }
        public int? Type { get; set; }
    }
}
using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogPrintings
{
    public abstract class TbLogPrintingDtoBase : AuditedEntityDto<int>
    {
        public string? userName { get; set; }
        public string? companyCode { get; set; }
        public string? fileLanguage { get; set; }
        public bool? isPrinting { get; set; }
        public DateTime? printTime { get; set; }

    }
}
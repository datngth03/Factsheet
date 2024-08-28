using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public abstract class TbLogSendEmailRetirementUpdateDtoBase : AuditedEntityDto<int>
    {
        public int? idCompany { get; set; }
        public int? idPerson { get; set; }
        public bool? IsSendEmail { get; set; }
        public DateTime? DateSendEmail { get; set; }
        public int? Type { get; set; }

    }
}
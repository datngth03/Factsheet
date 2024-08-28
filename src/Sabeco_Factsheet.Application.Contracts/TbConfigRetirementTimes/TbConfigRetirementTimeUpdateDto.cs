using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbConfigRetirementTimes
{
    public abstract class TbConfigRetirementTimeUpdateDtoBase : AuditedEntityDto<int>
    {
        public string? Code { get; set; }
        public int? YearNumb { get; set; }
        public int? MonthNumb { get; set; }
        public int? DayNumb { get; set; }
        public string? Note { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }

    }
}
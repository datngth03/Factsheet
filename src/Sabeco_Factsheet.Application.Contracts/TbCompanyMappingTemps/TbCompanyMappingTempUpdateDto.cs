using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbCompanyMappingTemps
{
    public abstract class TbCompanyMappingTempUpdateDtoBase : AuditedEntityDto<int>
    {
        public int? CompanyId { get; set; }
        public string? CompanyTypeShareholdingCode { get; set; }
        public string? CompanyTypesCode { get; set; }
        public string? Note { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public int? idCompanyTypeShareholdingCode { get; set; }
        public int? idCompanyTypesCode { get; set; }

    }
}
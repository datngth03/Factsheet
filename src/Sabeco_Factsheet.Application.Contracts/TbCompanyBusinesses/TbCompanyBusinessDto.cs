using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbCompanyBusinesses
{
    public abstract class TbCompanyBusinessDtoBase : AuditedEntityDto<int>
    {
        public int CompanyId { get; set; }
        public string? License { get; set; }
        public byte RegistrationNo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? LegalRepresent { get; set; }
        public string? CompanyType { get; set; }
        public string? MajorBusiness { get; set; }
        public string? OtherActivity { get; set; }
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? LatestAmendment { get; set; }

    }
}
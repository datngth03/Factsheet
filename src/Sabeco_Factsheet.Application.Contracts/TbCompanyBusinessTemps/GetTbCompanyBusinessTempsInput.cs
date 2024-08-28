using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbCompanyBusinessTemps
{
    public abstract class GetTbCompanyBusinessTempsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public string? License { get; set; }
        public byte? RegistrationNoMin { get; set; }
        public byte? RegistrationNoMax { get; set; }
        public DateTime? RegistrationDateMin { get; set; }
        public DateTime? RegistrationDateMax { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? LegalRepresent { get; set; }
        public string? CompanyType { get; set; }
        public string? MajorBusiness { get; set; }
        public string? OtherActivity { get; set; }
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public DateTime? LatestAmendmentMin { get; set; }
        public DateTime? LatestAmendmentMax { get; set; }

        public GetTbCompanyBusinessTempsInputBase()
        {

        }
    }
}
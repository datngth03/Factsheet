using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbCompanyMappings
{
    public abstract class GetTbCompanyMappingsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public string? CompanyTypeShareholdingCode { get; set; }
        public string? CompanyTypesCode { get; set; }
        public string? Note { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public int? idCompanyTypeShareholdingCodeMin { get; set; }
        public int? idCompanyTypeShareholdingCodeMax { get; set; }
        public int? idCompanyTypesCodeMin { get; set; }
        public int? idCompanyTypesCodeMax { get; set; }

        public GetTbCompanyMappingsInputBase()
        {

        }
    }
}
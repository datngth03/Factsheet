using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbCompanyBusinessDetails
{
    public abstract class GetTbCompanyBusinessDetailsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? ParentIdMin { get; set; }
        public int? ParentIdMax { get; set; }
        public string? RegistrationCode { get; set; }
        public string? RegistrationName { get; set; }
        public string? RegistrationName_EN { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }

        public GetTbCompanyBusinessDetailsInputBase()
        {

        }
    }
}
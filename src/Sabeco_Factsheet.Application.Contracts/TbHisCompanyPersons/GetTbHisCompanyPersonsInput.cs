using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbHisCompanyPersons
{
    public abstract class GetTbHisCompanyPersonsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMailMin { get; set; }
        public DateTime? DateSendMailMax { get; set; }
        public DateTime? InsertDateMin { get; set; }
        public DateTime? InsertDateMax { get; set; }
        public int? TypeMin { get; set; }
        public int? TypeMax { get; set; }
        public string? BranchCode { get; set; }
        public int? IdCompanyPersonMin { get; set; }
        public int? IdCompanyPersonMax { get; set; }
        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public int? PersonIdMin { get; set; }
        public int? PersonIdMax { get; set; }
        public DateTime? FromDateMin { get; set; }
        public DateTime? FromDateMax { get; set; }
        public DateTime? ToDateMin { get; set; }
        public DateTime? ToDateMax { get; set; }
        public int? PositionIdMin { get; set; }
        public int? PositionIdMax { get; set; }
        public string? PositionCode { get; set; }
        public decimal? PersonalValueMin { get; set; }
        public decimal? PersonalValueMax { get; set; }
        public decimal? PersonalSharePercentageMin { get; set; }
        public decimal? PersonalSharePercentageMax { get; set; }
        public decimal? OwnerValueMin { get; set; }
        public decimal? OwnerValueMax { get; set; }
        public decimal? RepresentativePercentageMin { get; set; }
        public decimal? RepresentativePercentageMax { get; set; }
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

        public GetTbHisCompanyPersonsInputBase()
        {

        }
    }
}
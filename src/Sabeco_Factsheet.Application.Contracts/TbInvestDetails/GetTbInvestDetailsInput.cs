using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbInvestDetails
{
    public abstract class GetTbInvestDetailsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? ParentIdMin { get; set; }
        public int? ParentIdMax { get; set; }
        public DateTime? DocDateMin { get; set; }
        public DateTime? DocDateMax { get; set; }
        public string? DocNo { get; set; }
        public int? InvestTypeMin { get; set; }
        public int? InvestTypeMax { get; set; }
        public int? ShareNumMin { get; set; }
        public int? ShareNumMax { get; set; }
        public decimal? ShareValueMin { get; set; }
        public decimal? ShareValueMax { get; set; }
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
        public bool? IsDeleted { get; set; }

        public GetTbInvestDetailsInputBase()
        {

        }
    }
}
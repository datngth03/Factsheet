using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbConfigRetirementTimes
{
    public abstract class GetTbConfigRetirementTimesInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public int? YearNumbMin { get; set; }
        public int? YearNumbMax { get; set; }
        public int? MonthNumbMin { get; set; }
        public int? MonthNumbMax { get; set; }
        public int? DayNumbMin { get; set; }
        public int? DayNumbMax { get; set; }
        public string? Note { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }

        public GetTbConfigRetirementTimesInputBase()
        {

        }
    }
}
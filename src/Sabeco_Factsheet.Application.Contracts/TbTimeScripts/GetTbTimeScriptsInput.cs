using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbTimeScripts
{
    public abstract class GetTbTimeScriptsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public int? YearMin { get; set; }
        public int? YearMax { get; set; }
        public int? MonthMin { get; set; }
        public int? MonthMax { get; set; }
        public int? DayMin { get; set; }
        public int? DayMax { get; set; }
        public int? HourMin { get; set; }
        public int? HourMax { get; set; }
        public int? MinuteMin { get; set; }
        public int? MinuteMax { get; set; }
        public int? SecondMin { get; set; }
        public int? SecondMax { get; set; }

        public GetTbTimeScriptsInputBase()
        {

        }
    }
}
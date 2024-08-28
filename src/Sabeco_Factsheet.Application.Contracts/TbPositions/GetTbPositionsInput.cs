using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbPositions
{
    public abstract class GetTbPositionsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Name_EN { get; set; }
        public byte? PositionTypeMin { get; set; }
        public byte? PositionTypeMax { get; set; }
        public bool? IsActive { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? ctr_dateMin { get; set; }
        public DateTime? ctr_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? OrderNumbMin { get; set; }
        public int? OrderNumbMax { get; set; }
        public bool? IsDeleted { get; set; }

        public GetTbPositionsInputBase()
        {

        }
    }
}
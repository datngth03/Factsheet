using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbAdditionInfoTemps
{
    public abstract class GetTbAdditionInfoTempsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public DateTime? DocDateMin { get; set; }
        public DateTime? DocDateMax { get; set; }
        public string? TypeOfGroup { get; set; }
        public string? TypeOfEvent { get; set; }
        public string? Description { get; set; }
        public string? NoOfDocument { get; set; }
        public string? Remark { get; set; }
        public bool? IsActive { get; set; }
        public int? create_userMin { get; set; }
        public int? create_userMax { get; set; }
        public DateTime? create_dateMin { get; set; }
        public DateTime? create_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }

        public GetTbAdditionInfoTempsInputBase()
        {

        }
    }
}
using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbMenus
{
    public abstract class GetTbMenusInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? ControlName { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public int? create_userMin { get; set; }
        public int? create_userMax { get; set; }
        public DateTime? create_dateMin { get; set; }
        public DateTime? create_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }

        public GetTbMenusInputBase()
        {

        }
    }
}
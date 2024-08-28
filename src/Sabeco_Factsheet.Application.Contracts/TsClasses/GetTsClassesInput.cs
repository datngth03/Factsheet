using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TsClasses
{
    public abstract class GetTsClassesInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? ParentCode { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Name_EN { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public string? Code_Type { get; set; }

        public GetTsClassesInputBase()
        {

        }
    }
}
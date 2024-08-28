using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbLogLogins
{
    public abstract class GetTbLogLoginsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? UserName { get; set; }
        public DateTime? LoginDateMin { get; set; }
        public DateTime? LoginDateMax { get; set; }
        public string? IPTracking { get; set; }
        public bool? StatusLogin { get; set; }

        public GetTbLogLoginsInputBase()
        {

        }
    }
}
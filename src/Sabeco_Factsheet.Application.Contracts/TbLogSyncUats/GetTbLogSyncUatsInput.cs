using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbLogSyncUats
{
    public abstract class GetTbLogSyncUatsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public DateTime? TimeExportMin { get; set; }
        public DateTime? TimeExportMax { get; set; }
        public bool? IsSuccess { get; set; }
        public int? UserExportMin { get; set; }
        public int? UserExportMax { get; set; }
        public string? ReasonExportFailed { get; set; }

        public GetTbLogSyncUatsInputBase()
        {

        }
    }
}
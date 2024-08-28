using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbInfoUpdates
{
    public abstract class GetTbInfoUpdatesInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? TableName { get; set; }
        public string? ColumnName { get; set; }
        public string? ScreenName { get; set; }
        public int? ScreenIdMin { get; set; }
        public int? ScreenIdMax { get; set; }
        public int? RowIdMin { get; set; }
        public int? RowIdMax { get; set; }
        public string? Command { get; set; }
        public string? GroupName { get; set; }
        public string? LastValue { get; set; }
        public string? NewValue { get; set; }
        public byte? DocStatusMin { get; set; }
        public byte? DocStatusMax { get; set; }
        public string? Comment { get; set; }
        public int? IsActiveMin { get; set; }
        public int? IsActiveMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public Guid? ChangeSetId { get; set; }
        public DateTime? TimeAssessmentMin { get; set; }
        public DateTime? TimeAssessmentMax { get; set; }
        public bool? IsVisible { get; set; }

        public GetTbInfoUpdatesInputBase()
        {

        }
    }
}
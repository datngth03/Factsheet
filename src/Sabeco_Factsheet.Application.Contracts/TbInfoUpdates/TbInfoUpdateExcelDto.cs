using System;

namespace Sabeco_Factsheet.TbInfoUpdates
{
    public abstract class TbInfoUpdateExcelDtoBase
    {
        public string TableName { get; set; } = null!;
        public string ColumnName { get; set; } = null!;
        public string? ScreenName { get; set; }
        public int ScreenId { get; set; }
        public int RowId { get; set; }
        public string Command { get; set; } = null!;
        public string? GroupName { get; set; }
        public string? LastValue { get; set; }
        public string? NewValue { get; set; }
        public byte? DocStatus { get; set; }
        public string? Comment { get; set; }
        public int IsActive { get; set; }
        public int? crt_user { get; set; }
        public DateTime? crt_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
        public Guid? ChangeSetId { get; set; }
        public DateTime? TimeAssessment { get; set; }
        public bool IsVisible { get; set; }
    }
}
using System;

namespace Sabeco_Factsheet.TbLogLogins
{
    public abstract class TbLogLoginExcelDtoBase
    {
        public string? UserName { get; set; }
        public DateTime? LoginDate { get; set; }
        public string IPTracking { get; set; } = null!;
        public bool? StatusLogin { get; set; }
    }
}
using System;

namespace Sabeco_Factsheet.TbLogSyncUats
{
    public abstract class TbLogSyncUatExcelDtoBase
    {
        public DateTime TimeExport { get; set; }
        public bool IsSuccess { get; set; }
        public int UserExport { get; set; }
        public string? ReasonExportFailed { get; set; }
    }
}
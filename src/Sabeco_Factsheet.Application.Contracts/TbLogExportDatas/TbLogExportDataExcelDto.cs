using System;

namespace Sabeco_Factsheet.TbLogExportDatas
{
    public abstract class TbLogExportDataExcelDtoBase
    {
        public DateTime TimeExport { get; set; }
        public bool IsSuccess { get; set; }
        public int UserExport { get; set; }
        public string? TableName { get; set; }
        public string? ReasonExportFailed { get; set; }
    }
}
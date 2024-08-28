using System;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public abstract class TbLogRefeshAccountExcelDtoBase
    {
        public string AccessToken { get; set; } = null!;
        public DateTime TimeRefesh { get; set; }
        public bool IsSuccess { get; set; }
        public string? UseRefesh { get; set; }
        public string? FailedReason { get; set; }
    }
}
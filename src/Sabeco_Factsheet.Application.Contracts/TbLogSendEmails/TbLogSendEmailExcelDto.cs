using System;

namespace Sabeco_Factsheet.TbLogSendEmails
{
    public abstract class TbLogSendEmailExcelDtoBase
    {
        public DateTime TimeSend { get; set; }
        public bool IsSuccess { get; set; }
        public string? UserSend { get; set; }
        public string? TypeEmail { get; set; }
        public string? FailedReason { get; set; }
    }
}
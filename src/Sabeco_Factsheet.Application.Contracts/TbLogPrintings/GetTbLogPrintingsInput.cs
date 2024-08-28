using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbLogPrintings
{
    public abstract class GetTbLogPrintingsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? userName { get; set; }
        public string? companyCode { get; set; }
        public string? fileLanguage { get; set; }
        public bool? isPrinting { get; set; }
        public DateTime? printTimeMin { get; set; }
        public DateTime? printTimeMax { get; set; }

        public GetTbLogPrintingsInputBase()
        {

        }
    }
}
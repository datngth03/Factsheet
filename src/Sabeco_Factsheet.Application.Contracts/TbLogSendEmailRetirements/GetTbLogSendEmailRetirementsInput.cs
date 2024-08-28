using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public abstract class GetTbLogSendEmailRetirementsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? idCompanyMin { get; set; }
        public int? idCompanyMax { get; set; }
        public int? idPersonMin { get; set; }
        public int? idPersonMax { get; set; }
        public bool? IsSendEmail { get; set; }
        public DateTime? DateSendEmailMin { get; set; }
        public DateTime? DateSendEmailMax { get; set; }
        public int? TypeMin { get; set; }
        public int? TypeMax { get; set; }

        public GetTbLogSendEmailRetirementsInputBase()
        {

        }
    }
}
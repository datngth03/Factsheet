using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbContacts
{
    public abstract class GetTbContactsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? companyidMin { get; set; }
        public int? companyidMax { get; set; }
        public string? ContactName { get; set; }
        public string? ContactDept { get; set; }
        public string? ContactPosition { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? Note { get; set; }
        public byte? DocStatusMin { get; set; }
        public byte? DocStatusMax { get; set; }
        public bool? IsActive { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public bool? IsDeleted { get; set; }

        public GetTbContactsInputBase()
        {

        }
    }
}
using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbUsers
{
    public abstract class GetTbUsersInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? UserPrincipalName { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public byte? DocStatusMin { get; set; }
        public byte? DocStatusMax { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public Guid? AbpUserId { get; set; }

        public GetTbUsersInputBase()
        {

        }
    }
}
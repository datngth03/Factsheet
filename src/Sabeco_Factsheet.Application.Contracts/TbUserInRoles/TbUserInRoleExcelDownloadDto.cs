using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbUserInRoles
{
    public abstract class TbUserInRoleExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? RoleIdMin { get; set; }
        public int? RoleIdMax { get; set; }
        public int? UserIdMin { get; set; }
        public int? UserIdMax { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }

        public TbUserInRoleExcelDownloadDtoBase()
        {

        }
    }
}
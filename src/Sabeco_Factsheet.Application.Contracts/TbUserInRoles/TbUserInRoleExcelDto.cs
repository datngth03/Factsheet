using System;

namespace Sabeco_Factsheet.TbUserInRoles
{
    public abstract class TbUserInRoleExcelDtoBase
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
    }
}
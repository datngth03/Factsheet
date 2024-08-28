using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbUserInRoles
{
    public abstract class TbUserInRoleCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int UserId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
    }
}
using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbMenus
{
    public abstract class TbMenuDtoBase : AuditedEntityDto<int>
    {
        public string ControlName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? IsActive { get; set; }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }

    }
}
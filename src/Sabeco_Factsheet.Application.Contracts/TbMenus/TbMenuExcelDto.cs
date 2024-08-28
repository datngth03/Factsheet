using System;

namespace Sabeco_Factsheet.TbMenus
{
    public abstract class TbMenuExcelDtoBase
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
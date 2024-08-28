using System;

namespace Sabeco_Factsheet.TsClasses
{
    public abstract class TsClassExcelDtoBase
    {
        public string ParentCode { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public string? Name_EN { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public string? Code_Type { get; set; }
    }
}
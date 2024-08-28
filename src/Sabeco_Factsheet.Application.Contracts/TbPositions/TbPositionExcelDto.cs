using System;

namespace Sabeco_Factsheet.TbPositions
{
    public abstract class TbPositionExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Name_EN { get; set; } = null!;
        public byte? PositionType { get; set; }
        public bool IsActive { get; set; }
        public int? crt_user { get; set; }
        public DateTime? ctr_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? OrderNumb { get; set; }
        public bool IsDeleted { get; set; }
    }
}
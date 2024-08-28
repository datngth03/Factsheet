using System;

namespace Sabeco_Factsheet.TbInvestPersons
{
    public abstract class TbInvestPersonExcelDtoBase
    {
        public int ParentId { get; set; }
        public int PersonId { get; set; }
        public DateTime FromDate { get; set; }
        public int? PersonalValue { get; set; }
        public int? OwnerValue { get; set; }
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public bool IsDeleted { get; set; }
    }
}
using System;

namespace Sabeco_Factsheet.TbCompanyBranchImages
{
    public abstract class TbCompanyBranchImageExcelDtoBase
    {
        public int? CompanyId { get; set; }
        public string? BranchImage { get; set; }
        public string? ImageLink { get; set; }
        public bool? isActive { get; set; }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
    }
}
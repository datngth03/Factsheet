using System;

namespace Sabeco_Factsheet.TbBreweryImages
{
    public abstract class TbBreweryImageExcelDtoBase
    {
        public int? CompanyId { get; set; }
        public string? BreweryImage { get; set; }
        public string? ImageLink { get; set; }
        public bool? isActive { get; set; }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
    }
}
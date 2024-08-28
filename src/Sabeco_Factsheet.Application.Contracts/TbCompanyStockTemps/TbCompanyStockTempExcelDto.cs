using System;

namespace Sabeco_Factsheet.TbCompanyStockTemps
{
    public abstract class TbCompanyStockTempExcelDtoBase
    {
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; } = null!;
        public bool IsPublicCompany { get; set; }
        public string? StockExchange { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public decimal? CharteredCapital { get; set; }
        public decimal? ParValue { get; set; }
        public int? TotalShare { get; set; }
        public int? ListedShare { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
    }
}
using System;

namespace Sabeco_Factsheet.TbStockPrices
{
    public abstract class TbStockPriceExcelDtoBase
    {
        public string StockCode { get; set; } = null!;
        public DateTime? StockDate { get; set; }
        public decimal? LimitUpPrice { get; set; }
        public decimal? LimitDownPrice { get; set; }
        public decimal? ReferencePrice { get; set; }
        public decimal? SaleQty1 { get; set; }
        public decimal? SalePrice1 { get; set; }
        public decimal? SaleQty2 { get; set; }
        public decimal? SalePrice2 { get; set; }
        public decimal? SaleQty3 { get; set; }
        public decimal? SalePrice3 { get; set; }
        public decimal? BuyQty1 { get; set; }
        public decimal? BuyPrice1 { get; set; }
        public decimal? BuyQty2 { get; set; }
        public decimal? BuyPrice2 { get; set; }
        public decimal? BuyQty3 { get; set; }
        public decimal? BuyPrice3 { get; set; }
        public decimal? TransactionPrice { get; set; }
        public decimal? TransactionQty { get; set; }
        public decimal? TotalQty { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
    }
}
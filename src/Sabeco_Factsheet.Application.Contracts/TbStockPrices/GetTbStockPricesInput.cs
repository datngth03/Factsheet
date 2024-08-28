using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbStockPrices
{
    public abstract class GetTbStockPricesInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? StockCode { get; set; }
        public DateTime? StockDateMin { get; set; }
        public DateTime? StockDateMax { get; set; }
        public decimal? LimitUpPriceMin { get; set; }
        public decimal? LimitUpPriceMax { get; set; }
        public decimal? LimitDownPriceMin { get; set; }
        public decimal? LimitDownPriceMax { get; set; }
        public decimal? ReferencePriceMin { get; set; }
        public decimal? ReferencePriceMax { get; set; }
        public decimal? SaleQty1Min { get; set; }
        public decimal? SaleQty1Max { get; set; }
        public decimal? SalePrice1Min { get; set; }
        public decimal? SalePrice1Max { get; set; }
        public decimal? SaleQty2Min { get; set; }
        public decimal? SaleQty2Max { get; set; }
        public decimal? SalePrice2Min { get; set; }
        public decimal? SalePrice2Max { get; set; }
        public decimal? SaleQty3Min { get; set; }
        public decimal? SaleQty3Max { get; set; }
        public decimal? SalePrice3Min { get; set; }
        public decimal? SalePrice3Max { get; set; }
        public decimal? BuyQty1Min { get; set; }
        public decimal? BuyQty1Max { get; set; }
        public decimal? BuyPrice1Min { get; set; }
        public decimal? BuyPrice1Max { get; set; }
        public decimal? BuyQty2Min { get; set; }
        public decimal? BuyQty2Max { get; set; }
        public decimal? BuyPrice2Min { get; set; }
        public decimal? BuyPrice2Max { get; set; }
        public decimal? BuyQty3Min { get; set; }
        public decimal? BuyQty3Max { get; set; }
        public decimal? BuyPrice3Min { get; set; }
        public decimal? BuyPrice3Max { get; set; }
        public decimal? TransactionPriceMin { get; set; }
        public decimal? TransactionPriceMax { get; set; }
        public decimal? TransactionQtyMin { get; set; }
        public decimal? TransactionQtyMax { get; set; }
        public decimal? TotalQtyMin { get; set; }
        public decimal? TotalQtyMax { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }

        public GetTbStockPricesInputBase()
        {

        }
    }
}
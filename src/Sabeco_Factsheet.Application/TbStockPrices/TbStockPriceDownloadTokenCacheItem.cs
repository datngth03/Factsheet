using System;

namespace Sabeco_Factsheet.TbStockPrices;

public abstract class TbStockPriceDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}
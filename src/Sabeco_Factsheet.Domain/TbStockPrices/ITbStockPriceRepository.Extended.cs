using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbStockPrices
{
    public partial interface ITbStockPriceRepository
    {
        //HQSOFT's generated code:
        Task<List<TbStockPrice>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? stockCode = null,
                    DateTime? stockDateMin = null,
                    DateTime? stockDateMax = null,
                    decimal? limitUpPriceMin = null,
                    decimal? limitUpPriceMax = null,
                    decimal? limitDownPriceMin = null,
                    decimal? limitDownPriceMax = null,
                    decimal? referencePriceMin = null,
                    decimal? referencePriceMax = null,
                    decimal? saleQty1Min = null,
                    decimal? saleQty1Max = null,
                    decimal? salePrice1Min = null,
                    decimal? salePrice1Max = null,
                    decimal? saleQty2Min = null,
                    decimal? saleQty2Max = null,
                    decimal? salePrice2Min = null,
                    decimal? salePrice2Max = null,
                    decimal? saleQty3Min = null,
                    decimal? saleQty3Max = null,
                    decimal? salePrice3Min = null,
                    decimal? salePrice3Max = null,
                    decimal? buyQty1Min = null,
                    decimal? buyQty1Max = null,
                    decimal? buyPrice1Min = null,
                    decimal? buyPrice1Max = null,
                    decimal? buyQty2Min = null,
                    decimal? buyQty2Max = null,
                    decimal? buyPrice2Min = null,
                    decimal? buyPrice2Max = null,
                    decimal? buyQty3Min = null,
                    decimal? buyQty3Max = null,
                    decimal? buyPrice3Min = null,
                    decimal? buyPrice3Max = null,
                    decimal? transactionPriceMin = null,
                    decimal? transactionPriceMax = null,
                    decimal? transactionQtyMin = null,
                    decimal? transactionQtyMax = null,
                    decimal? totalQtyMin = null,
                    decimal? totalQtyMax = null,
                    bool? isActive = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
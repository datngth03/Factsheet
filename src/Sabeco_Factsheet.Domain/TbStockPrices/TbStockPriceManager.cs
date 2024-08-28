using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbStockPrices
{
    public abstract class TbStockPriceManagerBase : DomainService
    {
        public ITbStockPriceRepository _tbStockPriceRepository;

        public TbStockPriceManagerBase(ITbStockPriceRepository tbStockPriceRepository)
        {
            _tbStockPriceRepository = tbStockPriceRepository;
        }

        public virtual async Task<TbStockPrice> CreateAsync(
        string stockCode, DateTime? stockDate = null, decimal? limitUpPrice = null, decimal? limitDownPrice = null, decimal? referencePrice = null, decimal? saleQty1 = null, decimal? salePrice1 = null, decimal? saleQty2 = null, decimal? salePrice2 = null, decimal? saleQty3 = null, decimal? salePrice3 = null, decimal? buyQty1 = null, decimal? buyPrice1 = null, decimal? buyQty2 = null, decimal? buyPrice2 = null, decimal? buyQty3 = null, decimal? buyPrice3 = null, decimal? transactionPrice = null, decimal? transactionQty = null, decimal? totalQty = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null)
        {
            Check.NotNullOrWhiteSpace(stockCode, nameof(stockCode));
            Check.Length(stockCode, nameof(stockCode), TbStockPriceConsts.StockCodeMaxLength);

            var tbStockPrice = new TbStockPrice(

             stockCode, stockDate, limitUpPrice, limitDownPrice, referencePrice, saleQty1, salePrice1, saleQty2, salePrice2, saleQty3, salePrice3, buyQty1, buyPrice1, buyQty2, buyPrice2, buyQty3, buyPrice3, transactionPrice, transactionQty, totalQty, isActive, crt_date, crt_user
             );

            return await _tbStockPriceRepository.InsertAsync(tbStockPrice);
        }

        public virtual async Task<TbStockPrice> UpdateAsync(
            int id,
            string stockCode, DateTime? stockDate = null, decimal? limitUpPrice = null, decimal? limitDownPrice = null, decimal? referencePrice = null, decimal? saleQty1 = null, decimal? salePrice1 = null, decimal? saleQty2 = null, decimal? salePrice2 = null, decimal? saleQty3 = null, decimal? salePrice3 = null, decimal? buyQty1 = null, decimal? buyPrice1 = null, decimal? buyQty2 = null, decimal? buyPrice2 = null, decimal? buyQty3 = null, decimal? buyPrice3 = null, decimal? transactionPrice = null, decimal? transactionQty = null, decimal? totalQty = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null
        )
        {
            Check.NotNullOrWhiteSpace(stockCode, nameof(stockCode));
            Check.Length(stockCode, nameof(stockCode), TbStockPriceConsts.StockCodeMaxLength);

            var tbStockPrice = await _tbStockPriceRepository.GetAsync(id);

            tbStockPrice.StockCode = stockCode;
            tbStockPrice.StockDate = stockDate;
            tbStockPrice.LimitUpPrice = limitUpPrice;
            tbStockPrice.LimitDownPrice = limitDownPrice;
            tbStockPrice.ReferencePrice = referencePrice;
            tbStockPrice.SaleQty1 = saleQty1;
            tbStockPrice.SalePrice1 = salePrice1;
            tbStockPrice.SaleQty2 = saleQty2;
            tbStockPrice.SalePrice2 = salePrice2;
            tbStockPrice.SaleQty3 = saleQty3;
            tbStockPrice.SalePrice3 = salePrice3;
            tbStockPrice.BuyQty1 = buyQty1;
            tbStockPrice.BuyPrice1 = buyPrice1;
            tbStockPrice.BuyQty2 = buyQty2;
            tbStockPrice.BuyPrice2 = buyPrice2;
            tbStockPrice.BuyQty3 = buyQty3;
            tbStockPrice.BuyPrice3 = buyPrice3;
            tbStockPrice.TransactionPrice = transactionPrice;
            tbStockPrice.TransactionQty = transactionQty;
            tbStockPrice.TotalQty = totalQty;
            tbStockPrice.IsActive = isActive;
            tbStockPrice.crt_date = crt_date;
            tbStockPrice.crt_user = crt_user;

            return await _tbStockPriceRepository.UpdateAsync(tbStockPrice);
        }

    }
}
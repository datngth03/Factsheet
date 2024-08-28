using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Sabeco_Factsheet.EntityFrameworkCore;

namespace Sabeco_Factsheet.TbStockPrices
{
    public abstract class EfCoreTbStockPriceRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbStockPrice, int>
    {
        public EfCoreTbStockPriceRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
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
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, stockCode, stockDateMin, stockDateMax, limitUpPriceMin, limitUpPriceMax, limitDownPriceMin, limitDownPriceMax, referencePriceMin, referencePriceMax, saleQty1Min, saleQty1Max, salePrice1Min, salePrice1Max, saleQty2Min, saleQty2Max, salePrice2Min, salePrice2Max, saleQty3Min, saleQty3Max, salePrice3Min, salePrice3Max, buyQty1Min, buyQty1Max, buyPrice1Min, buyPrice1Max, buyQty2Min, buyQty2Max, buyPrice2Min, buyPrice2Max, buyQty3Min, buyQty3Max, buyPrice3Min, buyPrice3Max, transactionPriceMin, transactionPriceMax, transactionQtyMin, transactionQtyMax, totalQtyMin, totalQtyMax, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbStockPrice>> GetListAsync(
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
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, stockCode, stockDateMin, stockDateMax, limitUpPriceMin, limitUpPriceMax, limitDownPriceMin, limitDownPriceMax, referencePriceMin, referencePriceMax, saleQty1Min, saleQty1Max, salePrice1Min, salePrice1Max, saleQty2Min, saleQty2Max, salePrice2Min, salePrice2Max, saleQty3Min, saleQty3Max, salePrice3Min, salePrice3Max, buyQty1Min, buyQty1Max, buyPrice1Min, buyPrice1Max, buyQty2Min, buyQty2Max, buyPrice2Min, buyPrice2Max, buyQty3Min, buyQty3Max, buyPrice3Min, buyPrice3Max, transactionPriceMin, transactionPriceMax, transactionQtyMin, transactionQtyMax, totalQtyMin, totalQtyMax, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbStockPriceConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, stockCode, stockDateMin, stockDateMax, limitUpPriceMin, limitUpPriceMax, limitDownPriceMin, limitDownPriceMax, referencePriceMin, referencePriceMax, saleQty1Min, saleQty1Max, salePrice1Min, salePrice1Max, saleQty2Min, saleQty2Max, salePrice2Min, salePrice2Max, saleQty3Min, saleQty3Max, salePrice3Min, salePrice3Max, buyQty1Min, buyQty1Max, buyPrice1Min, buyPrice1Max, buyQty2Min, buyQty2Max, buyPrice2Min, buyPrice2Max, buyQty3Min, buyQty3Max, buyPrice3Min, buyPrice3Max, transactionPriceMin, transactionPriceMax, transactionQtyMin, transactionQtyMax, totalQtyMin, totalQtyMax, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbStockPrice> ApplyFilter(
            IQueryable<TbStockPrice> query,
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
            int? crt_userMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.StockCode.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(stockCode), e => e.StockCode.ToLower().Contains(stockCode.ToLower()))
                    .WhereIf(stockDateMin.HasValue, e => e.StockDate >= stockDateMin!.Value)
                    .WhereIf(stockDateMax.HasValue, e => e.StockDate <= stockDateMax!.Value)
                    .WhereIf(limitUpPriceMin.HasValue, e => e.LimitUpPrice >= limitUpPriceMin!.Value)
                    .WhereIf(limitUpPriceMax.HasValue, e => e.LimitUpPrice <= limitUpPriceMax!.Value)
                    .WhereIf(limitDownPriceMin.HasValue, e => e.LimitDownPrice >= limitDownPriceMin!.Value)
                    .WhereIf(limitDownPriceMax.HasValue, e => e.LimitDownPrice <= limitDownPriceMax!.Value)
                    .WhereIf(referencePriceMin.HasValue, e => e.ReferencePrice >= referencePriceMin!.Value)
                    .WhereIf(referencePriceMax.HasValue, e => e.ReferencePrice <= referencePriceMax!.Value)
                    .WhereIf(saleQty1Min.HasValue, e => e.SaleQty1 >= saleQty1Min!.Value)
                    .WhereIf(saleQty1Max.HasValue, e => e.SaleQty1 <= saleQty1Max!.Value)
                    .WhereIf(salePrice1Min.HasValue, e => e.SalePrice1 >= salePrice1Min!.Value)
                    .WhereIf(salePrice1Max.HasValue, e => e.SalePrice1 <= salePrice1Max!.Value)
                    .WhereIf(saleQty2Min.HasValue, e => e.SaleQty2 >= saleQty2Min!.Value)
                    .WhereIf(saleQty2Max.HasValue, e => e.SaleQty2 <= saleQty2Max!.Value)
                    .WhereIf(salePrice2Min.HasValue, e => e.SalePrice2 >= salePrice2Min!.Value)
                    .WhereIf(salePrice2Max.HasValue, e => e.SalePrice2 <= salePrice2Max!.Value)
                    .WhereIf(saleQty3Min.HasValue, e => e.SaleQty3 >= saleQty3Min!.Value)
                    .WhereIf(saleQty3Max.HasValue, e => e.SaleQty3 <= saleQty3Max!.Value)
                    .WhereIf(salePrice3Min.HasValue, e => e.SalePrice3 >= salePrice3Min!.Value)
                    .WhereIf(salePrice3Max.HasValue, e => e.SalePrice3 <= salePrice3Max!.Value)
                    .WhereIf(buyQty1Min.HasValue, e => e.BuyQty1 >= buyQty1Min!.Value)
                    .WhereIf(buyQty1Max.HasValue, e => e.BuyQty1 <= buyQty1Max!.Value)
                    .WhereIf(buyPrice1Min.HasValue, e => e.BuyPrice1 >= buyPrice1Min!.Value)
                    .WhereIf(buyPrice1Max.HasValue, e => e.BuyPrice1 <= buyPrice1Max!.Value)
                    .WhereIf(buyQty2Min.HasValue, e => e.BuyQty2 >= buyQty2Min!.Value)
                    .WhereIf(buyQty2Max.HasValue, e => e.BuyQty2 <= buyQty2Max!.Value)
                    .WhereIf(buyPrice2Min.HasValue, e => e.BuyPrice2 >= buyPrice2Min!.Value)
                    .WhereIf(buyPrice2Max.HasValue, e => e.BuyPrice2 <= buyPrice2Max!.Value)
                    .WhereIf(buyQty3Min.HasValue, e => e.BuyQty3 >= buyQty3Min!.Value)
                    .WhereIf(buyQty3Max.HasValue, e => e.BuyQty3 <= buyQty3Max!.Value)
                    .WhereIf(buyPrice3Min.HasValue, e => e.BuyPrice3 >= buyPrice3Min!.Value)
                    .WhereIf(buyPrice3Max.HasValue, e => e.BuyPrice3 <= buyPrice3Max!.Value)
                    .WhereIf(transactionPriceMin.HasValue, e => e.TransactionPrice >= transactionPriceMin!.Value)
                    .WhereIf(transactionPriceMax.HasValue, e => e.TransactionPrice <= transactionPriceMax!.Value)
                    .WhereIf(transactionQtyMin.HasValue, e => e.TransactionQty >= transactionQtyMin!.Value)
                    .WhereIf(transactionQtyMax.HasValue, e => e.TransactionQty <= transactionQtyMax!.Value)
                    .WhereIf(totalQtyMin.HasValue, e => e.TotalQty >= totalQtyMin!.Value)
                    .WhereIf(totalQtyMax.HasValue, e => e.TotalQty <= totalQtyMax!.Value)
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value);
        }
    }
}
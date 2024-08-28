using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Sabeco_Factsheet.Permissions;
using Sabeco_Factsheet.TbStockPrices;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbStockPrices
{

    [Authorize(Sabeco_FactsheetPermissions.TbStockPrices.Default)]
    public abstract class TbStockPricesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbStockPriceDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbStockPriceRepository _tbStockPriceRepository;
        protected TbStockPriceManager _tbStockPriceManager;

        public TbStockPricesAppServiceBase(ITbStockPriceRepository tbStockPriceRepository, TbStockPriceManager tbStockPriceManager, IDistributedCache<TbStockPriceDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbStockPriceRepository = tbStockPriceRepository;
            _tbStockPriceManager = tbStockPriceManager;

        }

        public virtual async Task<PagedResultDto<TbStockPriceDto>> GetListAsync(GetTbStockPricesInput input)
        {
            var totalCount = await _tbStockPriceRepository.GetCountAsync(input.FilterText, input.StockCode, input.StockDateMin, input.StockDateMax, input.LimitUpPriceMin, input.LimitUpPriceMax, input.LimitDownPriceMin, input.LimitDownPriceMax, input.ReferencePriceMin, input.ReferencePriceMax, input.SaleQty1Min, input.SaleQty1Max, input.SalePrice1Min, input.SalePrice1Max, input.SaleQty2Min, input.SaleQty2Max, input.SalePrice2Min, input.SalePrice2Max, input.SaleQty3Min, input.SaleQty3Max, input.SalePrice3Min, input.SalePrice3Max, input.BuyQty1Min, input.BuyQty1Max, input.BuyPrice1Min, input.BuyPrice1Max, input.BuyQty2Min, input.BuyQty2Max, input.BuyPrice2Min, input.BuyPrice2Max, input.BuyQty3Min, input.BuyQty3Max, input.BuyPrice3Min, input.BuyPrice3Max, input.TransactionPriceMin, input.TransactionPriceMax, input.TransactionQtyMin, input.TransactionQtyMax, input.TotalQtyMin, input.TotalQtyMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax);
            var items = await _tbStockPriceRepository.GetListAsync(input.FilterText, input.StockCode, input.StockDateMin, input.StockDateMax, input.LimitUpPriceMin, input.LimitUpPriceMax, input.LimitDownPriceMin, input.LimitDownPriceMax, input.ReferencePriceMin, input.ReferencePriceMax, input.SaleQty1Min, input.SaleQty1Max, input.SalePrice1Min, input.SalePrice1Max, input.SaleQty2Min, input.SaleQty2Max, input.SalePrice2Min, input.SalePrice2Max, input.SaleQty3Min, input.SaleQty3Max, input.SalePrice3Min, input.SalePrice3Max, input.BuyQty1Min, input.BuyQty1Max, input.BuyPrice1Min, input.BuyPrice1Max, input.BuyQty2Min, input.BuyQty2Max, input.BuyPrice2Min, input.BuyPrice2Max, input.BuyQty3Min, input.BuyQty3Max, input.BuyPrice3Min, input.BuyPrice3Max, input.TransactionPriceMin, input.TransactionPriceMax, input.TransactionQtyMin, input.TransactionQtyMax, input.TotalQtyMin, input.TotalQtyMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbStockPriceDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbStockPrice>, List<TbStockPriceDto>>(items)
            };
        }

        public virtual async Task<TbStockPriceDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbStockPrice, TbStockPriceDto>(await _tbStockPriceRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbStockPrices.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbStockPriceRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbStockPrices.Create)]
        public virtual async Task<TbStockPriceDto> CreateAsync(TbStockPriceCreateDto input)
        {

            var tbStockPrice = await _tbStockPriceManager.CreateAsync(
            input.StockCode, input.StockDate, input.LimitUpPrice, input.LimitDownPrice, input.ReferencePrice, input.SaleQty1, input.SalePrice1, input.SaleQty2, input.SalePrice2, input.SaleQty3, input.SalePrice3, input.BuyQty1, input.BuyPrice1, input.BuyQty2, input.BuyPrice2, input.BuyQty3, input.BuyPrice3, input.TransactionPrice, input.TransactionQty, input.TotalQty, input.IsActive, input.crt_date, input.crt_user
            );

            return ObjectMapper.Map<TbStockPrice, TbStockPriceDto>(tbStockPrice);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbStockPrices.Edit)]
        public virtual async Task<TbStockPriceDto> UpdateAsync(int id, TbStockPriceUpdateDto input)
        {

            var tbStockPrice = await _tbStockPriceManager.UpdateAsync(
            id,
            input.StockCode, input.StockDate, input.LimitUpPrice, input.LimitDownPrice, input.ReferencePrice, input.SaleQty1, input.SalePrice1, input.SaleQty2, input.SalePrice2, input.SaleQty3, input.SalePrice3, input.BuyQty1, input.BuyPrice1, input.BuyQty2, input.BuyPrice2, input.BuyQty3, input.BuyPrice3, input.TransactionPrice, input.TransactionQty, input.TotalQty, input.IsActive, input.crt_date, input.crt_user
            );

            return ObjectMapper.Map<TbStockPrice, TbStockPriceDto>(tbStockPrice);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbStockPriceExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbStockPriceRepository.GetListAsync(input.FilterText, input.StockCode, input.StockDateMin, input.StockDateMax, input.LimitUpPriceMin, input.LimitUpPriceMax, input.LimitDownPriceMin, input.LimitDownPriceMax, input.ReferencePriceMin, input.ReferencePriceMax, input.SaleQty1Min, input.SaleQty1Max, input.SalePrice1Min, input.SalePrice1Max, input.SaleQty2Min, input.SaleQty2Max, input.SalePrice2Min, input.SalePrice2Max, input.SaleQty3Min, input.SaleQty3Max, input.SalePrice3Min, input.SalePrice3Max, input.BuyQty1Min, input.BuyQty1Max, input.BuyPrice1Min, input.BuyPrice1Max, input.BuyQty2Min, input.BuyQty2Max, input.BuyPrice2Min, input.BuyPrice2Max, input.BuyQty3Min, input.BuyQty3Max, input.BuyPrice3Min, input.BuyPrice3Max, input.TransactionPriceMin, input.TransactionPriceMax, input.TransactionQtyMin, input.TransactionQtyMax, input.TotalQtyMin, input.TotalQtyMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbStockPrice>, List<TbStockPriceExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbStockPrices.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbstockpriceIds)
        {
            await _tbStockPriceRepository.DeleteManyAsync(tbstockpriceIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbStockPrices.Delete)]
        public virtual async Task DeleteAllAsync(GetTbStockPricesInput input)
        {
            await _tbStockPriceRepository.DeleteAllAsync(input.FilterText, input.StockCode, input.StockDateMin, input.StockDateMax, input.LimitUpPriceMin, input.LimitUpPriceMax, input.LimitDownPriceMin, input.LimitDownPriceMax, input.ReferencePriceMin, input.ReferencePriceMax, input.SaleQty1Min, input.SaleQty1Max, input.SalePrice1Min, input.SalePrice1Max, input.SaleQty2Min, input.SaleQty2Max, input.SalePrice2Min, input.SalePrice2Max, input.SaleQty3Min, input.SaleQty3Max, input.SalePrice3Min, input.SalePrice3Max, input.BuyQty1Min, input.BuyQty1Max, input.BuyPrice1Min, input.BuyPrice1Max, input.BuyQty2Min, input.BuyQty2Max, input.BuyPrice2Min, input.BuyPrice2Max, input.BuyQty3Min, input.BuyQty3Max, input.BuyPrice3Min, input.BuyPrice3Max, input.TransactionPriceMin, input.TransactionPriceMax, input.TransactionQtyMin, input.TransactionQtyMax, input.TotalQtyMin, input.TotalQtyMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbStockPriceDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new Sabeco_Factsheet.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}
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
using Sabeco_Factsheet.TbCompanyStocks;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyStocks
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyStocks.Default)]
    public abstract class TbCompanyStocksAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyStockDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyStockRepository _tbCompanyStockRepository;
        protected TbCompanyStockManager _tbCompanyStockManager;

        public TbCompanyStocksAppServiceBase(ITbCompanyStockRepository tbCompanyStockRepository, TbCompanyStockManager tbCompanyStockManager, IDistributedCache<TbCompanyStockDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyStockRepository = tbCompanyStockRepository;
            _tbCompanyStockManager = tbCompanyStockManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyStockDto>> GetListAsync(GetTbCompanyStocksInput input)
        {
            var totalCount = await _tbCompanyStockRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.IsPublicCompany, input.StockExchange, input.RegistrationDateMin, input.RegistrationDateMax, input.CharteredCapitalMin, input.CharteredCapitalMax, input.ParValueMin, input.ParValueMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax);
            var items = await _tbCompanyStockRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.IsPublicCompany, input.StockExchange, input.RegistrationDateMin, input.RegistrationDateMax, input.CharteredCapitalMin, input.CharteredCapitalMax, input.ParValueMin, input.ParValueMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyStockDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyStock>, List<TbCompanyStockDto>>(items)
            };
        }

        public virtual async Task<TbCompanyStockDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyStock, TbCompanyStockDto>(await _tbCompanyStockRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyStocks.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyStockRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyStocks.Create)]
        public virtual async Task<TbCompanyStockDto> CreateAsync(TbCompanyStockCreateDto input)
        {

            var tbCompanyStock = await _tbCompanyStockManager.CreateAsync(
            input.CompanyId, input.CompanyCode, input.IsPublicCompany, input.IsActive, input.StockExchange, input.RegistrationDate, input.CharteredCapital, input.ParValue, input.TotalShare, input.ListedShare, input.Description, input.crt_date, input.crt_user
            );

            return ObjectMapper.Map<TbCompanyStock, TbCompanyStockDto>(tbCompanyStock);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyStocks.Edit)]
        public virtual async Task<TbCompanyStockDto> UpdateAsync(int id, TbCompanyStockUpdateDto input)
        {

            var tbCompanyStock = await _tbCompanyStockManager.UpdateAsync(
            id,
            input.CompanyId, input.CompanyCode, input.IsPublicCompany, input.IsActive, input.StockExchange, input.RegistrationDate, input.CharteredCapital, input.ParValue, input.TotalShare, input.ListedShare, input.Description, input.crt_date, input.crt_user
            );

            return ObjectMapper.Map<TbCompanyStock, TbCompanyStockDto>(tbCompanyStock);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyStockExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyStockRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.IsPublicCompany, input.StockExchange, input.RegistrationDateMin, input.RegistrationDateMax, input.CharteredCapitalMin, input.CharteredCapitalMax, input.ParValueMin, input.ParValueMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyStock>, List<TbCompanyStockExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyStocks.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanystockIds)
        {
            await _tbCompanyStockRepository.DeleteManyAsync(tbcompanystockIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyStocks.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyStocksInput input)
        {
            await _tbCompanyStockRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.IsPublicCompany, input.StockExchange, input.RegistrationDateMin, input.RegistrationDateMax, input.CharteredCapitalMin, input.CharteredCapitalMax, input.ParValueMin, input.ParValueMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyStockDownloadTokenCacheItem { Token = token },
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
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
using Sabeco_Factsheet.TbCompanyStockTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyStockTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyStockTemps.Default)]
    public abstract class TbCompanyStockTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyStockTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyStockTempRepository _tbCompanyStockTempRepository;
        protected TbCompanyStockTempManager _tbCompanyStockTempManager;

        public TbCompanyStockTempsAppServiceBase(ITbCompanyStockTempRepository tbCompanyStockTempRepository, TbCompanyStockTempManager tbCompanyStockTempManager, IDistributedCache<TbCompanyStockTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyStockTempRepository = tbCompanyStockTempRepository;
            _tbCompanyStockTempManager = tbCompanyStockTempManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyStockTempDto>> GetListAsync(GetTbCompanyStockTempsInput input)
        {
            var totalCount = await _tbCompanyStockTempRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.IsPublicCompany, input.StockExchange, input.RegistrationDateMin, input.RegistrationDateMax, input.CharteredCapitalMin, input.CharteredCapitalMax, input.ParValueMin, input.ParValueMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax);
            var items = await _tbCompanyStockTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.IsPublicCompany, input.StockExchange, input.RegistrationDateMin, input.RegistrationDateMax, input.CharteredCapitalMin, input.CharteredCapitalMax, input.ParValueMin, input.ParValueMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyStockTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyStockTemp>, List<TbCompanyStockTempDto>>(items)
            };
        }

        public virtual async Task<TbCompanyStockTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyStockTemp, TbCompanyStockTempDto>(await _tbCompanyStockTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyStockTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyStockTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyStockTemps.Create)]
        public virtual async Task<TbCompanyStockTempDto> CreateAsync(TbCompanyStockTempCreateDto input)
        {

            var tbCompanyStockTemp = await _tbCompanyStockTempManager.CreateAsync(
            input.CompanyId, input.CompanyCode, input.IsPublicCompany, input.IsActive, input.StockExchange, input.RegistrationDate, input.CharteredCapital, input.ParValue, input.TotalShare, input.ListedShare, input.Description, input.crt_date, input.crt_user
            );

            return ObjectMapper.Map<TbCompanyStockTemp, TbCompanyStockTempDto>(tbCompanyStockTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyStockTemps.Edit)]
        public virtual async Task<TbCompanyStockTempDto> UpdateAsync(int id, TbCompanyStockTempUpdateDto input)
        {

            var tbCompanyStockTemp = await _tbCompanyStockTempManager.UpdateAsync(
            id,
            input.CompanyId, input.CompanyCode, input.IsPublicCompany, input.IsActive, input.StockExchange, input.RegistrationDate, input.CharteredCapital, input.ParValue, input.TotalShare, input.ListedShare, input.Description, input.crt_date, input.crt_user
            );

            return ObjectMapper.Map<TbCompanyStockTemp, TbCompanyStockTempDto>(tbCompanyStockTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyStockTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyStockTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.IsPublicCompany, input.StockExchange, input.RegistrationDateMin, input.RegistrationDateMax, input.CharteredCapitalMin, input.CharteredCapitalMax, input.ParValueMin, input.ParValueMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyStockTemp>, List<TbCompanyStockTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyStockTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanystocktempIds)
        {
            await _tbCompanyStockTempRepository.DeleteManyAsync(tbcompanystocktempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyStockTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyStockTempsInput input)
        {
            await _tbCompanyStockTempRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.IsPublicCompany, input.StockExchange, input.RegistrationDateMin, input.RegistrationDateMax, input.CharteredCapitalMin, input.CharteredCapitalMax, input.ParValueMin, input.ParValueMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyStockTempDownloadTokenCacheItem { Token = token },
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
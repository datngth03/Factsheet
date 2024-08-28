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
using Sabeco_Factsheet.TbBrewerySkuTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBrewerySkuTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkuTemps.Default)]
    public abstract class TbBrewerySkuTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbBrewerySkuTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbBrewerySkuTempRepository _tbBrewerySkuTempRepository;
        protected TbBrewerySkuTempManager _tbBrewerySkuTempManager;

        public TbBrewerySkuTempsAppServiceBase(ITbBrewerySkuTempRepository tbBrewerySkuTempRepository, TbBrewerySkuTempManager tbBrewerySkuTempManager, IDistributedCache<TbBrewerySkuTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbBrewerySkuTempRepository = tbBrewerySkuTempRepository;
            _tbBrewerySkuTempManager = tbBrewerySkuTempManager;

        }

        public virtual async Task<PagedResultDto<TbBrewerySkuTempDto>> GetListAsync(GetTbBrewerySkuTempsInput input)
        {
            var totalCount = await _tbBrewerySkuTempRepository.GetCountAsync(input.FilterText, input.idBrewerySKUMin, input.idBrewerySKUMax, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax);
            var items = await _tbBrewerySkuTempRepository.GetListAsync(input.FilterText, input.idBrewerySKUMin, input.idBrewerySKUMax, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbBrewerySkuTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbBrewerySkuTemp>, List<TbBrewerySkuTempDto>>(items)
            };
        }

        public virtual async Task<TbBrewerySkuTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbBrewerySkuTemp, TbBrewerySkuTempDto>(await _tbBrewerySkuTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkuTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbBrewerySkuTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkuTemps.Create)]
        public virtual async Task<TbBrewerySkuTempDto> CreateAsync(TbBrewerySkuTempCreateDto input)
        {

            var tbBrewerySkuTemp = await _tbBrewerySkuTempManager.CreateAsync(
            input.idBrewerySKU, input.Year, input.BreweryCode, input.SKUCode, input.ProductionVolume, input.DocStatus, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.BreweryId, input.SKUId
            );

            return ObjectMapper.Map<TbBrewerySkuTemp, TbBrewerySkuTempDto>(tbBrewerySkuTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkuTemps.Edit)]
        public virtual async Task<TbBrewerySkuTempDto> UpdateAsync(int id, TbBrewerySkuTempUpdateDto input)
        {

            var tbBrewerySkuTemp = await _tbBrewerySkuTempManager.UpdateAsync(
            id,
            input.idBrewerySKU, input.Year, input.BreweryCode, input.SKUCode, input.ProductionVolume, input.DocStatus, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.BreweryId, input.SKUId
            );

            return ObjectMapper.Map<TbBrewerySkuTemp, TbBrewerySkuTempDto>(tbBrewerySkuTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBrewerySkuTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbBrewerySkuTempRepository.GetListAsync(input.FilterText, input.idBrewerySKUMin, input.idBrewerySKUMax, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbBrewerySkuTemp>, List<TbBrewerySkuTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkuTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbbreweryskutempIds)
        {
            await _tbBrewerySkuTempRepository.DeleteManyAsync(tbbreweryskutempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkuTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbBrewerySkuTempsInput input)
        {
            await _tbBrewerySkuTempRepository.DeleteAllAsync(input.FilterText, input.idBrewerySKUMin, input.idBrewerySKUMax, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbBrewerySkuTempDownloadTokenCacheItem { Token = token },
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
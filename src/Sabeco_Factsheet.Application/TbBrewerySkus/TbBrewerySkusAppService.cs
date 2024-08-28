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
using Sabeco_Factsheet.TbBrewerySkus;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBrewerySkus
{

    [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkus.Default)]
    public abstract class TbBrewerySkusAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbBrewerySkuDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbBrewerySkuRepository _tbBrewerySkuRepository;
        protected TbBrewerySkuManager _tbBrewerySkuManager;

        public TbBrewerySkusAppServiceBase(ITbBrewerySkuRepository tbBrewerySkuRepository, TbBrewerySkuManager tbBrewerySkuManager, IDistributedCache<TbBrewerySkuDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbBrewerySkuRepository = tbBrewerySkuRepository;
            _tbBrewerySkuManager = tbBrewerySkuManager;

        }

        public virtual async Task<PagedResultDto<TbBrewerySkuDto>> GetListAsync(GetTbBrewerySkusInput input)
        {
            var totalCount = await _tbBrewerySkuRepository.GetCountAsync(input.FilterText, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax);
            var items = await _tbBrewerySkuRepository.GetListAsync(input.FilterText, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbBrewerySkuDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbBrewerySku>, List<TbBrewerySkuDto>>(items)
            };
        }

        public virtual async Task<TbBrewerySkuDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbBrewerySku, TbBrewerySkuDto>(await _tbBrewerySkuRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkus.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbBrewerySkuRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkus.Create)]
        public virtual async Task<TbBrewerySkuDto> CreateAsync(TbBrewerySkuCreateDto input)
        {

            var tbBrewerySku = await _tbBrewerySkuManager.CreateAsync(
            input.Year, input.BreweryCode, input.SKUCode, input.ProductionVolume, input.DocStatus, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.BreweryId, input.SKUId
            );

            return ObjectMapper.Map<TbBrewerySku, TbBrewerySkuDto>(tbBrewerySku);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkus.Edit)]
        public virtual async Task<TbBrewerySkuDto> UpdateAsync(int id, TbBrewerySkuUpdateDto input)
        {

            var tbBrewerySku = await _tbBrewerySkuManager.UpdateAsync(
            id,
            input.Year, input.BreweryCode, input.SKUCode, input.ProductionVolume, input.DocStatus, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.BreweryId, input.SKUId
            );

            return ObjectMapper.Map<TbBrewerySku, TbBrewerySkuDto>(tbBrewerySku);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBrewerySkuExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbBrewerySkuRepository.GetListAsync(input.FilterText, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbBrewerySku>, List<TbBrewerySkuExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkus.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbbreweryskuIds)
        {
            await _tbBrewerySkuRepository.DeleteManyAsync(tbbreweryskuIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBrewerySkus.Delete)]
        public virtual async Task DeleteAllAsync(GetTbBrewerySkusInput input)
        {
            await _tbBrewerySkuRepository.DeleteAllAsync(input.FilterText, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbBrewerySkuDownloadTokenCacheItem { Token = token },
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
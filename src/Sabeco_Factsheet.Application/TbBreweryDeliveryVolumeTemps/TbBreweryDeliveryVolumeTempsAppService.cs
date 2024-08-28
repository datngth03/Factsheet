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
using Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumeTemps.Default)]
    public abstract class TbBreweryDeliveryVolumeTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbBreweryDeliveryVolumeTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbBreweryDeliveryVolumeTempRepository _tbBreweryDeliveryVolumeTempRepository;
        protected TbBreweryDeliveryVolumeTempManager _tbBreweryDeliveryVolumeTempManager;

        public TbBreweryDeliveryVolumeTempsAppServiceBase(ITbBreweryDeliveryVolumeTempRepository tbBreweryDeliveryVolumeTempRepository, TbBreweryDeliveryVolumeTempManager tbBreweryDeliveryVolumeTempManager, IDistributedCache<TbBreweryDeliveryVolumeTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbBreweryDeliveryVolumeTempRepository = tbBreweryDeliveryVolumeTempRepository;
            _tbBreweryDeliveryVolumeTempManager = tbBreweryDeliveryVolumeTempManager;

        }

        public virtual async Task<PagedResultDto<TbBreweryDeliveryVolumeTempDto>> GetListAsync(GetTbBreweryDeliveryVolumeTempsInput input)
        {
            var totalCount = await _tbBreweryDeliveryVolumeTempRepository.GetCountAsync(input.FilterText, input.idBreweryDeliveryVolumeMin, input.idBreweryDeliveryVolumeMax, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbBreweryDeliveryVolumeTempRepository.GetListAsync(input.FilterText, input.idBreweryDeliveryVolumeMin, input.idBreweryDeliveryVolumeMax, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbBreweryDeliveryVolumeTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbBreweryDeliveryVolumeTemp>, List<TbBreweryDeliveryVolumeTempDto>>(items)
            };
        }

        public virtual async Task<TbBreweryDeliveryVolumeTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbBreweryDeliveryVolumeTemp, TbBreweryDeliveryVolumeTempDto>(await _tbBreweryDeliveryVolumeTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumeTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbBreweryDeliveryVolumeTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumeTemps.Create)]
        public virtual async Task<TbBreweryDeliveryVolumeTempDto> CreateAsync(TbBreweryDeliveryVolumeTempCreateDto input)
        {

            var tbBreweryDeliveryVolumeTemp = await _tbBreweryDeliveryVolumeTempManager.CreateAsync(
            input.idBreweryDeliveryVolume, input.BreweryId, input.BreweryCode, input.Year, input.DeliveryVolume, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbBreweryDeliveryVolumeTemp, TbBreweryDeliveryVolumeTempDto>(tbBreweryDeliveryVolumeTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumeTemps.Edit)]
        public virtual async Task<TbBreweryDeliveryVolumeTempDto> UpdateAsync(int id, TbBreweryDeliveryVolumeTempUpdateDto input)
        {

            var tbBreweryDeliveryVolumeTemp = await _tbBreweryDeliveryVolumeTempManager.UpdateAsync(
            id,
            input.idBreweryDeliveryVolume, input.BreweryId, input.BreweryCode, input.Year, input.DeliveryVolume, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbBreweryDeliveryVolumeTemp, TbBreweryDeliveryVolumeTempDto>(tbBreweryDeliveryVolumeTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBreweryDeliveryVolumeTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbBreweryDeliveryVolumeTempRepository.GetListAsync(input.FilterText, input.idBreweryDeliveryVolumeMin, input.idBreweryDeliveryVolumeMax, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbBreweryDeliveryVolumeTemp>, List<TbBreweryDeliveryVolumeTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumeTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbbrewerydeliveryvolumetempIds)
        {
            await _tbBreweryDeliveryVolumeTempRepository.DeleteManyAsync(tbbrewerydeliveryvolumetempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumeTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbBreweryDeliveryVolumeTempsInput input)
        {
            await _tbBreweryDeliveryVolumeTempRepository.DeleteAllAsync(input.FilterText, input.idBreweryDeliveryVolumeMin, input.idBreweryDeliveryVolumeMax, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbBreweryDeliveryVolumeTempDownloadTokenCacheItem { Token = token },
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
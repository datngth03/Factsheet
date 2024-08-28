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
using Sabeco_Factsheet.TbBreweryDeliveryVolumes;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumes
{

    [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumes.Default)]
    public abstract class TbBreweryDeliveryVolumesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbBreweryDeliveryVolumeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbBreweryDeliveryVolumeRepository _tbBreweryDeliveryVolumeRepository;
        protected TbBreweryDeliveryVolumeManager _tbBreweryDeliveryVolumeManager;

        public TbBreweryDeliveryVolumesAppServiceBase(ITbBreweryDeliveryVolumeRepository tbBreweryDeliveryVolumeRepository, TbBreweryDeliveryVolumeManager tbBreweryDeliveryVolumeManager, IDistributedCache<TbBreweryDeliveryVolumeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbBreweryDeliveryVolumeRepository = tbBreweryDeliveryVolumeRepository;
            _tbBreweryDeliveryVolumeManager = tbBreweryDeliveryVolumeManager;

        }

        public virtual async Task<PagedResultDto<TbBreweryDeliveryVolumeDto>> GetListAsync(GetTbBreweryDeliveryVolumesInput input)
        {
            var totalCount = await _tbBreweryDeliveryVolumeRepository.GetCountAsync(input.FilterText, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbBreweryDeliveryVolumeRepository.GetListAsync(input.FilterText, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbBreweryDeliveryVolumeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbBreweryDeliveryVolume>, List<TbBreweryDeliveryVolumeDto>>(items)
            };
        }

        public virtual async Task<TbBreweryDeliveryVolumeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbBreweryDeliveryVolume, TbBreweryDeliveryVolumeDto>(await _tbBreweryDeliveryVolumeRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbBreweryDeliveryVolumeRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumes.Create)]
        public virtual async Task<TbBreweryDeliveryVolumeDto> CreateAsync(TbBreweryDeliveryVolumeCreateDto input)
        {

            var tbBreweryDeliveryVolume = await _tbBreweryDeliveryVolumeManager.CreateAsync(
            input.BreweryId, input.BreweryCode, input.Year, input.DeliveryVolume, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbBreweryDeliveryVolume, TbBreweryDeliveryVolumeDto>(tbBreweryDeliveryVolume);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumes.Edit)]
        public virtual async Task<TbBreweryDeliveryVolumeDto> UpdateAsync(int id, TbBreweryDeliveryVolumeUpdateDto input)
        {

            var tbBreweryDeliveryVolume = await _tbBreweryDeliveryVolumeManager.UpdateAsync(
            id,
            input.BreweryId, input.BreweryCode, input.Year, input.DeliveryVolume, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbBreweryDeliveryVolume, TbBreweryDeliveryVolumeDto>(tbBreweryDeliveryVolume);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBreweryDeliveryVolumeExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbBreweryDeliveryVolumeRepository.GetListAsync(input.FilterText, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbBreweryDeliveryVolume>, List<TbBreweryDeliveryVolumeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbbrewerydeliveryvolumeIds)
        {
            await _tbBreweryDeliveryVolumeRepository.DeleteManyAsync(tbbrewerydeliveryvolumeIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryDeliveryVolumes.Delete)]
        public virtual async Task DeleteAllAsync(GetTbBreweryDeliveryVolumesInput input)
        {
            await _tbBreweryDeliveryVolumeRepository.DeleteAllAsync(input.FilterText, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbBreweryDeliveryVolumeDownloadTokenCacheItem { Token = token },
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
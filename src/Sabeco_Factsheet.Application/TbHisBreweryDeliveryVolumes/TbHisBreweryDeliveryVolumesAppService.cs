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
using Sabeco_Factsheet.TbHisBreweryDeliveryVolumes;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisBreweryDeliveryVolumes
{

    [Authorize(Sabeco_FactsheetPermissions.TbHisBreweryDeliveryVolumes.Default)]
    public abstract class TbHisBreweryDeliveryVolumesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbHisBreweryDeliveryVolumeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbHisBreweryDeliveryVolumeRepository _tbHisBreweryDeliveryVolumeRepository;
        protected TbHisBreweryDeliveryVolumeManager _tbHisBreweryDeliveryVolumeManager;

        public TbHisBreweryDeliveryVolumesAppServiceBase(ITbHisBreweryDeliveryVolumeRepository tbHisBreweryDeliveryVolumeRepository, TbHisBreweryDeliveryVolumeManager tbHisBreweryDeliveryVolumeManager, IDistributedCache<TbHisBreweryDeliveryVolumeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbHisBreweryDeliveryVolumeRepository = tbHisBreweryDeliveryVolumeRepository;
            _tbHisBreweryDeliveryVolumeManager = tbHisBreweryDeliveryVolumeManager;

        }

        public virtual async Task<PagedResultDto<TbHisBreweryDeliveryVolumeDto>> GetListAsync(GetTbHisBreweryDeliveryVolumesInput input)
        {
            var totalCount = await _tbHisBreweryDeliveryVolumeRepository.GetCountAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBreweryDeliveryVolumeMin, input.IdBreweryDeliveryVolumeMax, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbHisBreweryDeliveryVolumeRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBreweryDeliveryVolumeMin, input.IdBreweryDeliveryVolumeMax, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbHisBreweryDeliveryVolumeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbHisBreweryDeliveryVolume>, List<TbHisBreweryDeliveryVolumeDto>>(items)
            };
        }

        public virtual async Task<TbHisBreweryDeliveryVolumeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbHisBreweryDeliveryVolume, TbHisBreweryDeliveryVolumeDto>(await _tbHisBreweryDeliveryVolumeRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBreweryDeliveryVolumes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbHisBreweryDeliveryVolumeRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBreweryDeliveryVolumes.Create)]
        public virtual async Task<TbHisBreweryDeliveryVolumeDto> CreateAsync(TbHisBreweryDeliveryVolumeCreateDto input)
        {

            var tbHisBreweryDeliveryVolume = await _tbHisBreweryDeliveryVolumeManager.CreateAsync(
            input.Type, input.IdBreweryDeliveryVolume, input.IsSendMail, input.DateSendMail, input.InsertDate, input.BreweryId, input.BreweryCode, input.Year, input.DeliveryVolume, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbHisBreweryDeliveryVolume, TbHisBreweryDeliveryVolumeDto>(tbHisBreweryDeliveryVolume);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBreweryDeliveryVolumes.Edit)]
        public virtual async Task<TbHisBreweryDeliveryVolumeDto> UpdateAsync(int id, TbHisBreweryDeliveryVolumeUpdateDto input)
        {

            var tbHisBreweryDeliveryVolume = await _tbHisBreweryDeliveryVolumeManager.UpdateAsync(
            id,
            input.Type, input.IdBreweryDeliveryVolume, input.IsSendMail, input.DateSendMail, input.InsertDate, input.BreweryId, input.BreweryCode, input.Year, input.DeliveryVolume, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbHisBreweryDeliveryVolume, TbHisBreweryDeliveryVolumeDto>(tbHisBreweryDeliveryVolume);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisBreweryDeliveryVolumeExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbHisBreweryDeliveryVolumeRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBreweryDeliveryVolumeMin, input.IdBreweryDeliveryVolumeMax, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbHisBreweryDeliveryVolume>, List<TbHisBreweryDeliveryVolumeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBreweryDeliveryVolumes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbhisbrewerydeliveryvolumeIds)
        {
            await _tbHisBreweryDeliveryVolumeRepository.DeleteManyAsync(tbhisbrewerydeliveryvolumeIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBreweryDeliveryVolumes.Delete)]
        public virtual async Task DeleteAllAsync(GetTbHisBreweryDeliveryVolumesInput input)
        {
            await _tbHisBreweryDeliveryVolumeRepository.DeleteAllAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBreweryDeliveryVolumeMin, input.IdBreweryDeliveryVolumeMax, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbHisBreweryDeliveryVolumeDownloadTokenCacheItem { Token = token },
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
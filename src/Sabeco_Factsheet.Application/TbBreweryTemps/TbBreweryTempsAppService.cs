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
using Sabeco_Factsheet.TbBreweryTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweryTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbBreweryTemps.Default)]
    public abstract class TbBreweryTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbBreweryTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbBreweryTempRepository _tbBreweryTempRepository;
        protected TbBreweryTempManager _tbBreweryTempManager;

        public TbBreweryTempsAppServiceBase(ITbBreweryTempRepository tbBreweryTempRepository, TbBreweryTempManager tbBreweryTempManager, IDistributedCache<TbBreweryTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbBreweryTempRepository = tbBreweryTempRepository;
            _tbBreweryTempManager = tbBreweryTempManager;

        }

        public virtual async Task<PagedResultDto<TbBreweryTempDto>> GetListAsync(GetTbBreweryTempsInput input)
        {
            var totalCount = await _tbBreweryTempRepository.GetCountAsync(input.FilterText, input.idBreweryMin, input.idBreweryMax, input.BreweryCode, input.BreweryName, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbBreweryTempRepository.GetListAsync(input.FilterText, input.idBreweryMin, input.idBreweryMax, input.BreweryCode, input.BreweryName, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbBreweryTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbBreweryTemp>, List<TbBreweryTempDto>>(items)
            };
        }

        public virtual async Task<TbBreweryTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbBreweryTemp, TbBreweryTempDto>(await _tbBreweryTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbBreweryTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryTemps.Create)]
        public virtual async Task<TbBreweryTempDto> CreateAsync(TbBreweryTempCreateDto input)
        {

            var tbBreweryTemp = await _tbBreweryTempManager.CreateAsync(
            input.idBrewery, input.BreweryCode, input.BreweryName, input.CompanyId, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CapacityVolume, input.DeliveryVolume, input.Note, input.DocStatus, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbBreweryTemp, TbBreweryTempDto>(tbBreweryTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryTemps.Edit)]
        public virtual async Task<TbBreweryTempDto> UpdateAsync(int id, TbBreweryTempUpdateDto input)
        {

            var tbBreweryTemp = await _tbBreweryTempManager.UpdateAsync(
            id,
            input.idBrewery, input.BreweryCode, input.BreweryName, input.CompanyId, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CapacityVolume, input.DeliveryVolume, input.Note, input.DocStatus, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbBreweryTemp, TbBreweryTempDto>(tbBreweryTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBreweryTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbBreweryTempRepository.GetListAsync(input.FilterText, input.idBreweryMin, input.idBreweryMax, input.BreweryCode, input.BreweryName, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbBreweryTemp>, List<TbBreweryTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbbrewerytempIds)
        {
            await _tbBreweryTempRepository.DeleteManyAsync(tbbrewerytempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbBreweryTempsInput input)
        {
            await _tbBreweryTempRepository.DeleteAllAsync(input.FilterText, input.idBreweryMin, input.idBreweryMax, input.BreweryCode, input.BreweryName, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbBreweryTempDownloadTokenCacheItem { Token = token },
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
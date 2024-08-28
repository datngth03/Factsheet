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
using Sabeco_Factsheet.TbBreweries;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweries
{

    [Authorize(Sabeco_FactsheetPermissions.TbBreweries.Default)]
    public abstract class TbBreweriesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbBreweryDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbBreweryRepository _tbBreweryRepository;
        protected TbBreweryManager _tbBreweryManager;

        public TbBreweriesAppServiceBase(ITbBreweryRepository tbBreweryRepository, TbBreweryManager tbBreweryManager, IDistributedCache<TbBreweryDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbBreweryRepository = tbBreweryRepository;
            _tbBreweryManager = tbBreweryManager;

        }

        public virtual async Task<PagedResultDto<TbBreweryDto>> GetListAsync(GetTbBreweriesInput input)
        {
            var totalCount = await _tbBreweryRepository.GetCountAsync(input.FilterText, input.BreweryCode, input.BreweryName, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbBreweryRepository.GetListAsync(input.FilterText, input.BreweryCode, input.BreweryName, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbBreweryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbBrewery>, List<TbBreweryDto>>(items)
            };
        }

        public virtual async Task<TbBreweryDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbBrewery, TbBreweryDto>(await _tbBreweryRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweries.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbBreweryRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweries.Create)]
        public virtual async Task<TbBreweryDto> CreateAsync(TbBreweryCreateDto input)
        {

            var tbBrewery = await _tbBreweryManager.CreateAsync(
            input.BreweryCode, input.BreweryName, input.CompanyId, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CapacityVolume, input.DeliveryVolume, input.Note, input.DocStatus, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbBrewery, TbBreweryDto>(tbBrewery);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweries.Edit)]
        public virtual async Task<TbBreweryDto> UpdateAsync(int id, TbBreweryUpdateDto input)
        {

            var tbBrewery = await _tbBreweryManager.UpdateAsync(
            id,
            input.BreweryCode, input.BreweryName, input.CompanyId, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CapacityVolume, input.DeliveryVolume, input.Note, input.DocStatus, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbBrewery, TbBreweryDto>(tbBrewery);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBreweryExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbBreweryRepository.GetListAsync(input.FilterText, input.BreweryCode, input.BreweryName, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbBrewery>, List<TbBreweryExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweries.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbbreweryIds)
        {
            await _tbBreweryRepository.DeleteManyAsync(tbbreweryIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweries.Delete)]
        public virtual async Task DeleteAllAsync(GetTbBreweriesInput input)
        {
            await _tbBreweryRepository.DeleteAllAsync(input.FilterText, input.BreweryCode, input.BreweryName, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbBreweryDownloadTokenCacheItem { Token = token },
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
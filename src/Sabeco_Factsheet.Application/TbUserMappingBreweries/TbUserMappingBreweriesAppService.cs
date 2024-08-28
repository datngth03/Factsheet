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
using Sabeco_Factsheet.TbUserMappingBreweries;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{

    [Authorize(Sabeco_FactsheetPermissions.TbUserMappingBreweries.Default)]
    public abstract class TbUserMappingBreweriesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbUserMappingBreweryDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbUserMappingBreweryRepository _tbUserMappingBreweryRepository;
        protected TbUserMappingBreweryManager _tbUserMappingBreweryManager;

        public TbUserMappingBreweriesAppServiceBase(ITbUserMappingBreweryRepository tbUserMappingBreweryRepository, TbUserMappingBreweryManager tbUserMappingBreweryManager, IDistributedCache<TbUserMappingBreweryDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbUserMappingBreweryRepository = tbUserMappingBreweryRepository;
            _tbUserMappingBreweryManager = tbUserMappingBreweryManager;

        }

        public virtual async Task<PagedResultDto<TbUserMappingBreweryDto>> GetListAsync(GetTbUserMappingBreweriesInput input)
        {
            var totalCount = await _tbUserMappingBreweryRepository.GetCountAsync(input.FilterText, input.useridMin, input.useridMax, input.breweryidMin, input.breweryidMax, input.IsActive);
            var items = await _tbUserMappingBreweryRepository.GetListAsync(input.FilterText, input.useridMin, input.useridMax, input.breweryidMin, input.breweryidMax, input.IsActive, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbUserMappingBreweryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbUserMappingBrewery>, List<TbUserMappingBreweryDto>>(items)
            };
        }

        public virtual async Task<TbUserMappingBreweryDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbUserMappingBrewery, TbUserMappingBreweryDto>(await _tbUserMappingBreweryRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingBreweries.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbUserMappingBreweryRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingBreweries.Create)]
        public virtual async Task<TbUserMappingBreweryDto> CreateAsync(TbUserMappingBreweryCreateDto input)
        {

            var tbUserMappingBrewery = await _tbUserMappingBreweryManager.CreateAsync(
            input.userid, input.breweryid, input.IsActive
            );

            return ObjectMapper.Map<TbUserMappingBrewery, TbUserMappingBreweryDto>(tbUserMappingBrewery);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingBreweries.Edit)]
        public virtual async Task<TbUserMappingBreweryDto> UpdateAsync(int id, TbUserMappingBreweryUpdateDto input)
        {

            var tbUserMappingBrewery = await _tbUserMappingBreweryManager.UpdateAsync(
            id,
            input.userid, input.breweryid, input.IsActive
            );

            return ObjectMapper.Map<TbUserMappingBrewery, TbUserMappingBreweryDto>(tbUserMappingBrewery);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbUserMappingBreweryExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbUserMappingBreweryRepository.GetListAsync(input.FilterText, input.useridMin, input.useridMax, input.breweryidMin, input.breweryidMax, input.IsActive);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbUserMappingBrewery>, List<TbUserMappingBreweryExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingBreweries.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbusermappingbreweryIds)
        {
            await _tbUserMappingBreweryRepository.DeleteManyAsync(tbusermappingbreweryIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingBreweries.Delete)]
        public virtual async Task DeleteAllAsync(GetTbUserMappingBreweriesInput input)
        {
            await _tbUserMappingBreweryRepository.DeleteAllAsync(input.FilterText, input.useridMin, input.useridMax, input.breweryidMin, input.breweryidMax, input.IsActive);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbUserMappingBreweryDownloadTokenCacheItem { Token = token },
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
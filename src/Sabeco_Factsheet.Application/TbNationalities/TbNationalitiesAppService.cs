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
using Sabeco_Factsheet.TbNationalities;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbNationalities
{

    [Authorize(Sabeco_FactsheetPermissions.TbNationalities.Default)]
    public abstract class TbNationalitiesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbNationalityDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbNationalityRepository _tbNationalityRepository;
        protected TbNationalityManager _tbNationalityManager;

        public TbNationalitiesAppServiceBase(ITbNationalityRepository tbNationalityRepository, TbNationalityManager tbNationalityManager, IDistributedCache<TbNationalityDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbNationalityRepository = tbNationalityRepository;
            _tbNationalityManager = tbNationalityManager;

        }

        public virtual async Task<PagedResultDto<TbNationalityDto>> GetListAsync(GetTbNationalitiesInput input)
        {
            var totalCount = await _tbNationalityRepository.GetCountAsync(input.FilterText, input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive);
            var items = await _tbNationalityRepository.GetListAsync(input.FilterText, input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbNationalityDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbNationality>, List<TbNationalityDto>>(items)
            };
        }

        public virtual async Task<TbNationalityDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbNationality, TbNationalityDto>(await _tbNationalityRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbNationalities.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbNationalityRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbNationalities.Create)]
        public virtual async Task<TbNationalityDto> CreateAsync(TbNationalityCreateDto input)
        {

            var tbNationality = await _tbNationalityManager.CreateAsync(
            input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive
            );

            return ObjectMapper.Map<TbNationality, TbNationalityDto>(tbNationality);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbNationalities.Edit)]
        public virtual async Task<TbNationalityDto> UpdateAsync(int id, TbNationalityUpdateDto input)
        {

            var tbNationality = await _tbNationalityManager.UpdateAsync(
            id,
            input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive
            );

            return ObjectMapper.Map<TbNationality, TbNationalityDto>(tbNationality);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbNationalityExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbNationalityRepository.GetListAsync(input.FilterText, input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbNationality>, List<TbNationalityExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbNationalities.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbnationalityIds)
        {
            await _tbNationalityRepository.DeleteManyAsync(tbnationalityIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbNationalities.Delete)]
        public virtual async Task DeleteAllAsync(GetTbNationalitiesInput input)
        {
            await _tbNationalityRepository.DeleteAllAsync(input.FilterText, input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbNationalityDownloadTokenCacheItem { Token = token },
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
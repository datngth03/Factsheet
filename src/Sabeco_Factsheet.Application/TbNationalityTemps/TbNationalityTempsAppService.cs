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
using Sabeco_Factsheet.TbNationalityTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbNationalityTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbNationalityTemps.Default)]
    public abstract class TbNationalityTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbNationalityTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbNationalityTempRepository _tbNationalityTempRepository;
        protected TbNationalityTempManager _tbNationalityTempManager;

        public TbNationalityTempsAppServiceBase(ITbNationalityTempRepository tbNationalityTempRepository, TbNationalityTempManager tbNationalityTempManager, IDistributedCache<TbNationalityTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbNationalityTempRepository = tbNationalityTempRepository;
            _tbNationalityTempManager = tbNationalityTempManager;

        }

        public virtual async Task<PagedResultDto<TbNationalityTempDto>> GetListAsync(GetTbNationalityTempsInput input)
        {
            var totalCount = await _tbNationalityTempRepository.GetCountAsync(input.FilterText, input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive);
            var items = await _tbNationalityTempRepository.GetListAsync(input.FilterText, input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbNationalityTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbNationalityTemp>, List<TbNationalityTempDto>>(items)
            };
        }

        public virtual async Task<TbNationalityTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbNationalityTemp, TbNationalityTempDto>(await _tbNationalityTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbNationalityTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbNationalityTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbNationalityTemps.Create)]
        public virtual async Task<TbNationalityTempDto> CreateAsync(TbNationalityTempCreateDto input)
        {

            var tbNationalityTemp = await _tbNationalityTempManager.CreateAsync(
            input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive
            );

            return ObjectMapper.Map<TbNationalityTemp, TbNationalityTempDto>(tbNationalityTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbNationalityTemps.Edit)]
        public virtual async Task<TbNationalityTempDto> UpdateAsync(int id, TbNationalityTempUpdateDto input)
        {

            var tbNationalityTemp = await _tbNationalityTempManager.UpdateAsync(
            id,
            input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive
            );

            return ObjectMapper.Map<TbNationalityTemp, TbNationalityTempDto>(tbNationalityTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbNationalityTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbNationalityTempRepository.GetListAsync(input.FilterText, input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbNationalityTemp>, List<TbNationalityTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbNationalityTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbnationalitytempIds)
        {
            await _tbNationalityTempRepository.DeleteManyAsync(tbnationalitytempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbNationalityTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbNationalityTempsInput input)
        {
            await _tbNationalityTempRepository.DeleteAllAsync(input.FilterText, input.Code, input.Code2, input.Name_en, input.Name_vn, input.IsActive);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbNationalityTempDownloadTokenCacheItem { Token = token },
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
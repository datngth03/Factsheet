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
using Sabeco_Factsheet.TsClassTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TsClassTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TsClassTemps.Default)]
    public abstract class TsClassTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TsClassTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITsClassTempRepository _tsClassTempRepository;
        protected TsClassTempManager _tsClassTempManager;

        public TsClassTempsAppServiceBase(ITsClassTempRepository tsClassTempRepository, TsClassTempManager tsClassTempManager, IDistributedCache<TsClassTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tsClassTempRepository = tsClassTempRepository;
            _tsClassTempManager = tsClassTempManager;

        }

        public virtual async Task<PagedResultDto<TsClassTempDto>> GetListAsync(GetTsClassTempsInput input)
        {
            var totalCount = await _tsClassTempRepository.GetCountAsync(input.FilterText, input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Code_Type);
            var items = await _tsClassTempRepository.GetListAsync(input.FilterText, input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Code_Type, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TsClassTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TsClassTemp>, List<TsClassTempDto>>(items)
            };
        }

        public virtual async Task<TsClassTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TsClassTemp, TsClassTempDto>(await _tsClassTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TsClassTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tsClassTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TsClassTemps.Create)]
        public virtual async Task<TsClassTempDto> CreateAsync(TsClassTempCreateDto input)
        {

            var tsClassTemp = await _tsClassTempManager.CreateAsync(
            input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.Code_Type
            );

            return ObjectMapper.Map<TsClassTemp, TsClassTempDto>(tsClassTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TsClassTemps.Edit)]
        public virtual async Task<TsClassTempDto> UpdateAsync(int id, TsClassTempUpdateDto input)
        {

            var tsClassTemp = await _tsClassTempManager.UpdateAsync(
            id,
            input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.Code_Type
            );

            return ObjectMapper.Map<TsClassTemp, TsClassTempDto>(tsClassTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TsClassTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tsClassTempRepository.GetListAsync(input.FilterText, input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Code_Type);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TsClassTemp>, List<TsClassTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TsClassTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tsclasstempIds)
        {
            await _tsClassTempRepository.DeleteManyAsync(tsclasstempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TsClassTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTsClassTempsInput input)
        {
            await _tsClassTempRepository.DeleteAllAsync(input.FilterText, input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Code_Type);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TsClassTempDownloadTokenCacheItem { Token = token },
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
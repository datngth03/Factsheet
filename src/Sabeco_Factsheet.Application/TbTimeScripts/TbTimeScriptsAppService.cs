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
using Sabeco_Factsheet.TbTimeScripts;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbTimeScripts
{

    [Authorize(Sabeco_FactsheetPermissions.TbTimeScripts.Default)]
    public abstract class TbTimeScriptsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbTimeScriptDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbTimeScriptRepository _tbTimeScriptRepository;
        protected TbTimeScriptManager _tbTimeScriptManager;

        public TbTimeScriptsAppServiceBase(ITbTimeScriptRepository tbTimeScriptRepository, TbTimeScriptManager tbTimeScriptManager, IDistributedCache<TbTimeScriptDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbTimeScriptRepository = tbTimeScriptRepository;
            _tbTimeScriptManager = tbTimeScriptManager;

        }

        public virtual async Task<PagedResultDto<TbTimeScriptDto>> GetListAsync(GetTbTimeScriptsInput input)
        {
            var totalCount = await _tbTimeScriptRepository.GetCountAsync(input.FilterText, input.Code, input.YearMin, input.YearMax, input.MonthMin, input.MonthMax, input.DayMin, input.DayMax, input.HourMin, input.HourMax, input.MinuteMin, input.MinuteMax, input.SecondMin, input.SecondMax);
            var items = await _tbTimeScriptRepository.GetListAsync(input.FilterText, input.Code, input.YearMin, input.YearMax, input.MonthMin, input.MonthMax, input.DayMin, input.DayMax, input.HourMin, input.HourMax, input.MinuteMin, input.MinuteMax, input.SecondMin, input.SecondMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbTimeScriptDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbTimeScript>, List<TbTimeScriptDto>>(items)
            };
        }

        public virtual async Task<TbTimeScriptDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbTimeScript, TbTimeScriptDto>(await _tbTimeScriptRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbTimeScripts.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbTimeScriptRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbTimeScripts.Create)]
        public virtual async Task<TbTimeScriptDto> CreateAsync(TbTimeScriptCreateDto input)
        {

            var tbTimeScript = await _tbTimeScriptManager.CreateAsync(
            input.Code, input.Year, input.Month, input.Day, input.Hour, input.Minute, input.Second
            );

            return ObjectMapper.Map<TbTimeScript, TbTimeScriptDto>(tbTimeScript);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbTimeScripts.Edit)]
        public virtual async Task<TbTimeScriptDto> UpdateAsync(int id, TbTimeScriptUpdateDto input)
        {

            var tbTimeScript = await _tbTimeScriptManager.UpdateAsync(
            id,
            input.Code, input.Year, input.Month, input.Day, input.Hour, input.Minute, input.Second
            );

            return ObjectMapper.Map<TbTimeScript, TbTimeScriptDto>(tbTimeScript);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbTimeScriptExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbTimeScriptRepository.GetListAsync(input.FilterText, input.Code, input.YearMin, input.YearMax, input.MonthMin, input.MonthMax, input.DayMin, input.DayMax, input.HourMin, input.HourMax, input.MinuteMin, input.MinuteMax, input.SecondMin, input.SecondMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbTimeScript>, List<TbTimeScriptExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbTimeScripts.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbtimescriptIds)
        {
            await _tbTimeScriptRepository.DeleteManyAsync(tbtimescriptIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbTimeScripts.Delete)]
        public virtual async Task DeleteAllAsync(GetTbTimeScriptsInput input)
        {
            await _tbTimeScriptRepository.DeleteAllAsync(input.FilterText, input.Code, input.YearMin, input.YearMax, input.MonthMin, input.MonthMax, input.DayMin, input.DayMax, input.HourMin, input.HourMax, input.MinuteMin, input.MinuteMax, input.SecondMin, input.SecondMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbTimeScriptDownloadTokenCacheItem { Token = token },
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
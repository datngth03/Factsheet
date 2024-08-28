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
using Sabeco_Factsheet.TbConfigRetirementTimes;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbConfigRetirementTimes
{

    [Authorize(Sabeco_FactsheetPermissions.TbConfigRetirementTimes.Default)]
    public abstract class TbConfigRetirementTimesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbConfigRetirementTimeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbConfigRetirementTimeRepository _tbConfigRetirementTimeRepository;
        protected TbConfigRetirementTimeManager _tbConfigRetirementTimeManager;

        public TbConfigRetirementTimesAppServiceBase(ITbConfigRetirementTimeRepository tbConfigRetirementTimeRepository, TbConfigRetirementTimeManager tbConfigRetirementTimeManager, IDistributedCache<TbConfigRetirementTimeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbConfigRetirementTimeRepository = tbConfigRetirementTimeRepository;
            _tbConfigRetirementTimeManager = tbConfigRetirementTimeManager;

        }

        public virtual async Task<PagedResultDto<TbConfigRetirementTimeDto>> GetListAsync(GetTbConfigRetirementTimesInput input)
        {
            var totalCount = await _tbConfigRetirementTimeRepository.GetCountAsync(input.FilterText, input.Code, input.YearNumbMin, input.YearNumbMax, input.MonthNumbMin, input.MonthNumbMax, input.DayNumbMin, input.DayNumbMax, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
            var items = await _tbConfigRetirementTimeRepository.GetListAsync(input.FilterText, input.Code, input.YearNumbMin, input.YearNumbMax, input.MonthNumbMin, input.MonthNumbMax, input.DayNumbMin, input.DayNumbMax, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbConfigRetirementTimeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbConfigRetirementTime>, List<TbConfigRetirementTimeDto>>(items)
            };
        }

        public virtual async Task<TbConfigRetirementTimeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbConfigRetirementTime, TbConfigRetirementTimeDto>(await _tbConfigRetirementTimeRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbConfigRetirementTimes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbConfigRetirementTimeRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbConfigRetirementTimes.Create)]
        public virtual async Task<TbConfigRetirementTimeDto> CreateAsync(TbConfigRetirementTimeCreateDto input)
        {

            var tbConfigRetirementTime = await _tbConfigRetirementTimeManager.CreateAsync(
            input.Code, input.YearNumb, input.MonthNumb, input.DayNumb, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbConfigRetirementTime, TbConfigRetirementTimeDto>(tbConfigRetirementTime);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbConfigRetirementTimes.Edit)]
        public virtual async Task<TbConfigRetirementTimeDto> UpdateAsync(int id, TbConfigRetirementTimeUpdateDto input)
        {

            var tbConfigRetirementTime = await _tbConfigRetirementTimeManager.UpdateAsync(
            id,
            input.Code, input.YearNumb, input.MonthNumb, input.DayNumb, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbConfigRetirementTime, TbConfigRetirementTimeDto>(tbConfigRetirementTime);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbConfigRetirementTimeExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbConfigRetirementTimeRepository.GetListAsync(input.FilterText, input.Code, input.YearNumbMin, input.YearNumbMax, input.MonthNumbMin, input.MonthNumbMax, input.DayNumbMin, input.DayNumbMax, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbConfigRetirementTime>, List<TbConfigRetirementTimeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbConfigRetirementTimes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbconfigretirementtimeIds)
        {
            await _tbConfigRetirementTimeRepository.DeleteManyAsync(tbconfigretirementtimeIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbConfigRetirementTimes.Delete)]
        public virtual async Task DeleteAllAsync(GetTbConfigRetirementTimesInput input)
        {
            await _tbConfigRetirementTimeRepository.DeleteAllAsync(input.FilterText, input.Code, input.YearNumbMin, input.YearNumbMax, input.MonthNumbMin, input.MonthNumbMax, input.DayNumbMin, input.DayNumbMax, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbConfigRetirementTimeDownloadTokenCacheItem { Token = token },
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
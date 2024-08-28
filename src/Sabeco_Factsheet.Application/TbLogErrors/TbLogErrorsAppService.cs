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
using Sabeco_Factsheet.TbLogErrors;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogErrors
{

    [Authorize(Sabeco_FactsheetPermissions.TbLogErrors.Default)]
    public abstract class TbLogErrorsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbLogErrorDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbLogErrorRepository _tbLogErrorRepository;
        protected TbLogErrorManager _tbLogErrorManager;

        public TbLogErrorsAppServiceBase(ITbLogErrorRepository tbLogErrorRepository, TbLogErrorManager tbLogErrorManager, IDistributedCache<TbLogErrorDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbLogErrorRepository = tbLogErrorRepository;
            _tbLogErrorManager = tbLogErrorManager;

        }

        public virtual async Task<PagedResultDto<TbLogErrorDto>> GetListAsync(GetTbLogErrorsInput input)
        {
            var totalCount = await _tbLogErrorRepository.GetCountAsync(input.FilterText, input.TimeLogMin, input.TimeLogMax, input.UserLogMin, input.UserLogMax, input.IPAddress, input.ClassLog, input.FunctionLog, input.ReasonFailed);
            var items = await _tbLogErrorRepository.GetListAsync(input.FilterText, input.TimeLogMin, input.TimeLogMax, input.UserLogMin, input.UserLogMax, input.IPAddress, input.ClassLog, input.FunctionLog, input.ReasonFailed, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbLogErrorDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbLogError>, List<TbLogErrorDto>>(items)
            };
        }

        public virtual async Task<TbLogErrorDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbLogError, TbLogErrorDto>(await _tbLogErrorRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogErrors.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbLogErrorRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogErrors.Create)]
        public virtual async Task<TbLogErrorDto> CreateAsync(TbLogErrorCreateDto input)
        {

            var tbLogError = await _tbLogErrorManager.CreateAsync(
            input.TimeLog, input.UserLog, input.FunctionLog, input.ReasonFailed, input.IPAddress, input.ClassLog
            );

            return ObjectMapper.Map<TbLogError, TbLogErrorDto>(tbLogError);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogErrors.Edit)]
        public virtual async Task<TbLogErrorDto> UpdateAsync(int id, TbLogErrorUpdateDto input)
        {

            var tbLogError = await _tbLogErrorManager.UpdateAsync(
            id,
            input.TimeLog, input.UserLog, input.FunctionLog, input.ReasonFailed, input.IPAddress, input.ClassLog
            );

            return ObjectMapper.Map<TbLogError, TbLogErrorDto>(tbLogError);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogErrorExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbLogErrorRepository.GetListAsync(input.FilterText, input.TimeLogMin, input.TimeLogMax, input.UserLogMin, input.UserLogMax, input.IPAddress, input.ClassLog, input.FunctionLog, input.ReasonFailed);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbLogError>, List<TbLogErrorExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogErrors.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tblogerrorIds)
        {
            await _tbLogErrorRepository.DeleteManyAsync(tblogerrorIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogErrors.Delete)]
        public virtual async Task DeleteAllAsync(GetTbLogErrorsInput input)
        {
            await _tbLogErrorRepository.DeleteAllAsync(input.FilterText, input.TimeLogMin, input.TimeLogMax, input.UserLogMin, input.UserLogMax, input.IPAddress, input.ClassLog, input.FunctionLog, input.ReasonFailed);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbLogErrorDownloadTokenCacheItem { Token = token },
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
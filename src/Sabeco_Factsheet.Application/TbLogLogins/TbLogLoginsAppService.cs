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
using Sabeco_Factsheet.TbLogLogins;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogLogins
{

    [Authorize(Sabeco_FactsheetPermissions.TbLogLogins.Default)]
    public abstract class TbLogLoginsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbLogLoginDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbLogLoginRepository _tbLogLoginRepository;
        protected TbLogLoginManager _tbLogLoginManager;

        public TbLogLoginsAppServiceBase(ITbLogLoginRepository tbLogLoginRepository, TbLogLoginManager tbLogLoginManager, IDistributedCache<TbLogLoginDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbLogLoginRepository = tbLogLoginRepository;
            _tbLogLoginManager = tbLogLoginManager;

        }

        public virtual async Task<PagedResultDto<TbLogLoginDto>> GetListAsync(GetTbLogLoginsInput input)
        {
            var totalCount = await _tbLogLoginRepository.GetCountAsync(input.FilterText, input.UserName, input.LoginDateMin, input.LoginDateMax, input.IPTracking, input.StatusLogin);
            var items = await _tbLogLoginRepository.GetListAsync(input.FilterText, input.UserName, input.LoginDateMin, input.LoginDateMax, input.IPTracking, input.StatusLogin, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbLogLoginDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbLogLogin>, List<TbLogLoginDto>>(items)
            };
        }

        public virtual async Task<TbLogLoginDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbLogLogin, TbLogLoginDto>(await _tbLogLoginRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogLogins.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbLogLoginRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogLogins.Create)]
        public virtual async Task<TbLogLoginDto> CreateAsync(TbLogLoginCreateDto input)
        {

            var tbLogLogin = await _tbLogLoginManager.CreateAsync(
            input.IPTracking, input.UserName, input.LoginDate, input.StatusLogin
            );

            return ObjectMapper.Map<TbLogLogin, TbLogLoginDto>(tbLogLogin);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogLogins.Edit)]
        public virtual async Task<TbLogLoginDto> UpdateAsync(int id, TbLogLoginUpdateDto input)
        {

            var tbLogLogin = await _tbLogLoginManager.UpdateAsync(
            id,
            input.IPTracking, input.UserName, input.LoginDate, input.StatusLogin
            );

            return ObjectMapper.Map<TbLogLogin, TbLogLoginDto>(tbLogLogin);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogLoginExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbLogLoginRepository.GetListAsync(input.FilterText, input.UserName, input.LoginDateMin, input.LoginDateMax, input.IPTracking, input.StatusLogin);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbLogLogin>, List<TbLogLoginExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogLogins.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tblogloginIds)
        {
            await _tbLogLoginRepository.DeleteManyAsync(tblogloginIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogLogins.Delete)]
        public virtual async Task DeleteAllAsync(GetTbLogLoginsInput input)
        {
            await _tbLogLoginRepository.DeleteAllAsync(input.FilterText, input.UserName, input.LoginDateMin, input.LoginDateMax, input.IPTracking, input.StatusLogin);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbLogLoginDownloadTokenCacheItem { Token = token },
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
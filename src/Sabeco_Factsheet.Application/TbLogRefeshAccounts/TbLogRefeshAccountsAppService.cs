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
using Sabeco_Factsheet.TbLogRefeshAccounts;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{

    [Authorize(Sabeco_FactsheetPermissions.TbLogRefeshAccounts.Default)]
    public abstract class TbLogRefeshAccountsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbLogRefeshAccountDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbLogRefeshAccountRepository _tbLogRefeshAccountRepository;
        protected TbLogRefeshAccountManager _tbLogRefeshAccountManager;

        public TbLogRefeshAccountsAppServiceBase(ITbLogRefeshAccountRepository tbLogRefeshAccountRepository, TbLogRefeshAccountManager tbLogRefeshAccountManager, IDistributedCache<TbLogRefeshAccountDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbLogRefeshAccountRepository = tbLogRefeshAccountRepository;
            _tbLogRefeshAccountManager = tbLogRefeshAccountManager;

        }

        public virtual async Task<PagedResultDto<TbLogRefeshAccountDto>> GetListAsync(GetTbLogRefeshAccountsInput input)
        {
            var totalCount = await _tbLogRefeshAccountRepository.GetCountAsync(input.FilterText, input.AccessToken, input.TimeRefeshMin, input.TimeRefeshMax, input.IsSuccess, input.UseRefesh, input.FailedReason);
            var items = await _tbLogRefeshAccountRepository.GetListAsync(input.FilterText, input.AccessToken, input.TimeRefeshMin, input.TimeRefeshMax, input.IsSuccess, input.UseRefesh, input.FailedReason, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbLogRefeshAccountDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbLogRefeshAccount>, List<TbLogRefeshAccountDto>>(items)
            };
        }

        public virtual async Task<TbLogRefeshAccountDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbLogRefeshAccount, TbLogRefeshAccountDto>(await _tbLogRefeshAccountRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogRefeshAccounts.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbLogRefeshAccountRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogRefeshAccounts.Create)]
        public virtual async Task<TbLogRefeshAccountDto> CreateAsync(TbLogRefeshAccountCreateDto input)
        {

            var tbLogRefeshAccount = await _tbLogRefeshAccountManager.CreateAsync(
            input.AccessToken, input.TimeRefesh, input.IsSuccess, input.UseRefesh, input.FailedReason
            );

            return ObjectMapper.Map<TbLogRefeshAccount, TbLogRefeshAccountDto>(tbLogRefeshAccount);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogRefeshAccounts.Edit)]
        public virtual async Task<TbLogRefeshAccountDto> UpdateAsync(int id, TbLogRefeshAccountUpdateDto input)
        {

            var tbLogRefeshAccount = await _tbLogRefeshAccountManager.UpdateAsync(
            id,
            input.AccessToken, input.TimeRefesh, input.IsSuccess, input.UseRefesh, input.FailedReason
            );

            return ObjectMapper.Map<TbLogRefeshAccount, TbLogRefeshAccountDto>(tbLogRefeshAccount);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogRefeshAccountExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbLogRefeshAccountRepository.GetListAsync(input.FilterText, input.AccessToken, input.TimeRefeshMin, input.TimeRefeshMax, input.IsSuccess, input.UseRefesh, input.FailedReason);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbLogRefeshAccount>, List<TbLogRefeshAccountExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogRefeshAccounts.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tblogrefeshaccountIds)
        {
            await _tbLogRefeshAccountRepository.DeleteManyAsync(tblogrefeshaccountIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogRefeshAccounts.Delete)]
        public virtual async Task DeleteAllAsync(GetTbLogRefeshAccountsInput input)
        {
            await _tbLogRefeshAccountRepository.DeleteAllAsync(input.FilterText, input.AccessToken, input.TimeRefeshMin, input.TimeRefeshMax, input.IsSuccess, input.UseRefesh, input.FailedReason);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbLogRefeshAccountDownloadTokenCacheItem { Token = token },
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
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
using Sabeco_Factsheet.TbLogSendEmails;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogSendEmails
{

    [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmails.Default)]
    public abstract class TbLogSendEmailsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbLogSendEmailDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbLogSendEmailRepository _tbLogSendEmailRepository;
        protected TbLogSendEmailManager _tbLogSendEmailManager;

        public TbLogSendEmailsAppServiceBase(ITbLogSendEmailRepository tbLogSendEmailRepository, TbLogSendEmailManager tbLogSendEmailManager, IDistributedCache<TbLogSendEmailDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbLogSendEmailRepository = tbLogSendEmailRepository;
            _tbLogSendEmailManager = tbLogSendEmailManager;

        }

        public virtual async Task<PagedResultDto<TbLogSendEmailDto>> GetListAsync(GetTbLogSendEmailsInput input)
        {
            var totalCount = await _tbLogSendEmailRepository.GetCountAsync(input.FilterText, input.TimeSendMin, input.TimeSendMax, input.IsSuccess, input.UserSend, input.TypeEmail, input.FailedReason);
            var items = await _tbLogSendEmailRepository.GetListAsync(input.FilterText, input.TimeSendMin, input.TimeSendMax, input.IsSuccess, input.UserSend, input.TypeEmail, input.FailedReason, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbLogSendEmailDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbLogSendEmail>, List<TbLogSendEmailDto>>(items)
            };
        }

        public virtual async Task<TbLogSendEmailDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbLogSendEmail, TbLogSendEmailDto>(await _tbLogSendEmailRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmails.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbLogSendEmailRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmails.Create)]
        public virtual async Task<TbLogSendEmailDto> CreateAsync(TbLogSendEmailCreateDto input)
        {

            var tbLogSendEmail = await _tbLogSendEmailManager.CreateAsync(
            input.TimeSend, input.IsSuccess, input.UserSend, input.TypeEmail, input.FailedReason
            );

            return ObjectMapper.Map<TbLogSendEmail, TbLogSendEmailDto>(tbLogSendEmail);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmails.Edit)]
        public virtual async Task<TbLogSendEmailDto> UpdateAsync(int id, TbLogSendEmailUpdateDto input)
        {

            var tbLogSendEmail = await _tbLogSendEmailManager.UpdateAsync(
            id,
            input.TimeSend, input.IsSuccess, input.UserSend, input.TypeEmail, input.FailedReason
            );

            return ObjectMapper.Map<TbLogSendEmail, TbLogSendEmailDto>(tbLogSendEmail);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogSendEmailExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbLogSendEmailRepository.GetListAsync(input.FilterText, input.TimeSendMin, input.TimeSendMax, input.IsSuccess, input.UserSend, input.TypeEmail, input.FailedReason);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbLogSendEmail>, List<TbLogSendEmailExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmails.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tblogsendemailIds)
        {
            await _tbLogSendEmailRepository.DeleteManyAsync(tblogsendemailIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmails.Delete)]
        public virtual async Task DeleteAllAsync(GetTbLogSendEmailsInput input)
        {
            await _tbLogSendEmailRepository.DeleteAllAsync(input.FilterText, input.TimeSendMin, input.TimeSendMax, input.IsSuccess, input.UserSend, input.TypeEmail, input.FailedReason);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbLogSendEmailDownloadTokenCacheItem { Token = token },
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
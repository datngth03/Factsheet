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
using Sabeco_Factsheet.TbHisLogPrintings;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisLogPrintings
{

    [Authorize(Sabeco_FactsheetPermissions.TbHisLogPrintings.Default)]
    public abstract class TbHisLogPrintingsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbHisLogPrintingDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbHisLogPrintingRepository _tbHisLogPrintingRepository;
        protected TbHisLogPrintingManager _tbHisLogPrintingManager;

        public TbHisLogPrintingsAppServiceBase(ITbHisLogPrintingRepository tbHisLogPrintingRepository, TbHisLogPrintingManager tbHisLogPrintingManager, IDistributedCache<TbHisLogPrintingDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbHisLogPrintingRepository = tbHisLogPrintingRepository;
            _tbHisLogPrintingManager = tbHisLogPrintingManager;

        }

        public virtual async Task<PagedResultDto<TbHisLogPrintingDto>> GetListAsync(GetTbHisLogPrintingsInput input)
        {
            var totalCount = await _tbHisLogPrintingRepository.GetCountAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.TypeMin, input.TypeMax, input.InsertDateMin, input.InsertDateMax, input.UserName, input.CompanyCode, input.FileLanguage, input.IsPrinting);
            var items = await _tbHisLogPrintingRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.TypeMin, input.TypeMax, input.InsertDateMin, input.InsertDateMax, input.UserName, input.CompanyCode, input.FileLanguage, input.IsPrinting, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbHisLogPrintingDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbHisLogPrinting>, List<TbHisLogPrintingDto>>(items)
            };
        }

        public virtual async Task<TbHisLogPrintingDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbHisLogPrinting, TbHisLogPrintingDto>(await _tbHisLogPrintingRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisLogPrintings.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbHisLogPrintingRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisLogPrintings.Create)]
        public virtual async Task<TbHisLogPrintingDto> CreateAsync(TbHisLogPrintingCreateDto input)
        {

            var tbHisLogPrinting = await _tbHisLogPrintingManager.CreateAsync(
            input.InsertDate, input.IsSendMail, input.DateSendMail, input.Type, input.UserName, input.CompanyCode, input.FileLanguage, input.IsPrinting
            );

            return ObjectMapper.Map<TbHisLogPrinting, TbHisLogPrintingDto>(tbHisLogPrinting);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisLogPrintings.Edit)]
        public virtual async Task<TbHisLogPrintingDto> UpdateAsync(int id, TbHisLogPrintingUpdateDto input)
        {

            var tbHisLogPrinting = await _tbHisLogPrintingManager.UpdateAsync(
            id,
            input.InsertDate, input.IsSendMail, input.DateSendMail, input.Type, input.UserName, input.CompanyCode, input.FileLanguage, input.IsPrinting
            );

            return ObjectMapper.Map<TbHisLogPrinting, TbHisLogPrintingDto>(tbHisLogPrinting);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisLogPrintingExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbHisLogPrintingRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.TypeMin, input.TypeMax, input.InsertDateMin, input.InsertDateMax, input.UserName, input.CompanyCode, input.FileLanguage, input.IsPrinting);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbHisLogPrinting>, List<TbHisLogPrintingExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisLogPrintings.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbhislogprintingIds)
        {
            await _tbHisLogPrintingRepository.DeleteManyAsync(tbhislogprintingIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisLogPrintings.Delete)]
        public virtual async Task DeleteAllAsync(GetTbHisLogPrintingsInput input)
        {
            await _tbHisLogPrintingRepository.DeleteAllAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.TypeMin, input.TypeMax, input.InsertDateMin, input.InsertDateMax, input.UserName, input.CompanyCode, input.FileLanguage, input.IsPrinting);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbHisLogPrintingDownloadTokenCacheItem { Token = token },
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
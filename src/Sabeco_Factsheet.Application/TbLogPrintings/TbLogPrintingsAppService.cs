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
using Sabeco_Factsheet.TbLogPrintings;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogPrintings
{

    [Authorize(Sabeco_FactsheetPermissions.TbLogPrintings.Default)]
    public abstract class TbLogPrintingsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbLogPrintingDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbLogPrintingRepository _tbLogPrintingRepository;
        protected TbLogPrintingManager _tbLogPrintingManager;

        public TbLogPrintingsAppServiceBase(ITbLogPrintingRepository tbLogPrintingRepository, TbLogPrintingManager tbLogPrintingManager, IDistributedCache<TbLogPrintingDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbLogPrintingRepository = tbLogPrintingRepository;
            _tbLogPrintingManager = tbLogPrintingManager;

        }

        public virtual async Task<PagedResultDto<TbLogPrintingDto>> GetListAsync(GetTbLogPrintingsInput input)
        {
            var totalCount = await _tbLogPrintingRepository.GetCountAsync(input.FilterText, input.userName, input.companyCode, input.fileLanguage, input.isPrinting, input.printTimeMin, input.printTimeMax);
            var items = await _tbLogPrintingRepository.GetListAsync(input.FilterText, input.userName, input.companyCode, input.fileLanguage, input.isPrinting, input.printTimeMin, input.printTimeMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbLogPrintingDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbLogPrinting>, List<TbLogPrintingDto>>(items)
            };
        }

        public virtual async Task<TbLogPrintingDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbLogPrinting, TbLogPrintingDto>(await _tbLogPrintingRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogPrintings.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbLogPrintingRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogPrintings.Create)]
        public virtual async Task<TbLogPrintingDto> CreateAsync(TbLogPrintingCreateDto input)
        {

            var tbLogPrinting = await _tbLogPrintingManager.CreateAsync(
            input.userName, input.companyCode, input.fileLanguage, input.isPrinting, input.printTime
            );

            return ObjectMapper.Map<TbLogPrinting, TbLogPrintingDto>(tbLogPrinting);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogPrintings.Edit)]
        public virtual async Task<TbLogPrintingDto> UpdateAsync(int id, TbLogPrintingUpdateDto input)
        {

            var tbLogPrinting = await _tbLogPrintingManager.UpdateAsync(
            id,
            input.userName, input.companyCode, input.fileLanguage, input.isPrinting, input.printTime
            );

            return ObjectMapper.Map<TbLogPrinting, TbLogPrintingDto>(tbLogPrinting);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogPrintingExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbLogPrintingRepository.GetListAsync(input.FilterText, input.userName, input.companyCode, input.fileLanguage, input.isPrinting, input.printTimeMin, input.printTimeMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbLogPrinting>, List<TbLogPrintingExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogPrintings.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tblogprintingIds)
        {
            await _tbLogPrintingRepository.DeleteManyAsync(tblogprintingIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogPrintings.Delete)]
        public virtual async Task DeleteAllAsync(GetTbLogPrintingsInput input)
        {
            await _tbLogPrintingRepository.DeleteAllAsync(input.FilterText, input.userName, input.companyCode, input.fileLanguage, input.isPrinting, input.printTimeMin, input.printTimeMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbLogPrintingDownloadTokenCacheItem { Token = token },
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
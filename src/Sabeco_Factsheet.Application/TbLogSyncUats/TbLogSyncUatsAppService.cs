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
using Sabeco_Factsheet.TbLogSyncUats;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogSyncUats
{

    [Authorize(Sabeco_FactsheetPermissions.TbLogSyncUats.Default)]
    public abstract class TbLogSyncUatsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbLogSyncUatDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbLogSyncUatRepository _tbLogSyncUatRepository;
        protected TbLogSyncUatManager _tbLogSyncUatManager;

        public TbLogSyncUatsAppServiceBase(ITbLogSyncUatRepository tbLogSyncUatRepository, TbLogSyncUatManager tbLogSyncUatManager, IDistributedCache<TbLogSyncUatDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbLogSyncUatRepository = tbLogSyncUatRepository;
            _tbLogSyncUatManager = tbLogSyncUatManager;

        }

        public virtual async Task<PagedResultDto<TbLogSyncUatDto>> GetListAsync(GetTbLogSyncUatsInput input)
        {
            var totalCount = await _tbLogSyncUatRepository.GetCountAsync(input.FilterText, input.TimeExportMin, input.TimeExportMax, input.IsSuccess, input.UserExportMin, input.UserExportMax, input.ReasonExportFailed);
            var items = await _tbLogSyncUatRepository.GetListAsync(input.FilterText, input.TimeExportMin, input.TimeExportMax, input.IsSuccess, input.UserExportMin, input.UserExportMax, input.ReasonExportFailed, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbLogSyncUatDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbLogSyncUat>, List<TbLogSyncUatDto>>(items)
            };
        }

        public virtual async Task<TbLogSyncUatDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbLogSyncUat, TbLogSyncUatDto>(await _tbLogSyncUatRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSyncUats.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbLogSyncUatRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSyncUats.Create)]
        public virtual async Task<TbLogSyncUatDto> CreateAsync(TbLogSyncUatCreateDto input)
        {

            var tbLogSyncUat = await _tbLogSyncUatManager.CreateAsync(
            input.TimeExport, input.IsSuccess, input.UserExport, input.ReasonExportFailed
            );

            return ObjectMapper.Map<TbLogSyncUat, TbLogSyncUatDto>(tbLogSyncUat);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSyncUats.Edit)]
        public virtual async Task<TbLogSyncUatDto> UpdateAsync(int id, TbLogSyncUatUpdateDto input)
        {

            var tbLogSyncUat = await _tbLogSyncUatManager.UpdateAsync(
            id,
            input.TimeExport, input.IsSuccess, input.UserExport, input.ReasonExportFailed
            );

            return ObjectMapper.Map<TbLogSyncUat, TbLogSyncUatDto>(tbLogSyncUat);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogSyncUatExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbLogSyncUatRepository.GetListAsync(input.FilterText, input.TimeExportMin, input.TimeExportMax, input.IsSuccess, input.UserExportMin, input.UserExportMax, input.ReasonExportFailed);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbLogSyncUat>, List<TbLogSyncUatExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSyncUats.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tblogsyncuatIds)
        {
            await _tbLogSyncUatRepository.DeleteManyAsync(tblogsyncuatIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSyncUats.Delete)]
        public virtual async Task DeleteAllAsync(GetTbLogSyncUatsInput input)
        {
            await _tbLogSyncUatRepository.DeleteAllAsync(input.FilterText, input.TimeExportMin, input.TimeExportMax, input.IsSuccess, input.UserExportMin, input.UserExportMax, input.ReasonExportFailed);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbLogSyncUatDownloadTokenCacheItem { Token = token },
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
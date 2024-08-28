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
using Sabeco_Factsheet.TbLogExportDatas;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogExportDatas
{

    [Authorize(Sabeco_FactsheetPermissions.TbLogExportDatas.Default)]
    public abstract class TbLogExportDatasAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbLogExportDataDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbLogExportDataRepository _tbLogExportDataRepository;
        protected TbLogExportDataManager _tbLogExportDataManager;

        public TbLogExportDatasAppServiceBase(ITbLogExportDataRepository tbLogExportDataRepository, TbLogExportDataManager tbLogExportDataManager, IDistributedCache<TbLogExportDataDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbLogExportDataRepository = tbLogExportDataRepository;
            _tbLogExportDataManager = tbLogExportDataManager;

        }

        public virtual async Task<PagedResultDto<TbLogExportDataDto>> GetListAsync(GetTbLogExportDatasInput input)
        {
            var totalCount = await _tbLogExportDataRepository.GetCountAsync(input.FilterText, input.TimeExportMin, input.TimeExportMax, input.IsSuccess, input.UserExportMin, input.UserExportMax, input.TableName, input.ReasonExportFailed);
            var items = await _tbLogExportDataRepository.GetListAsync(input.FilterText, input.TimeExportMin, input.TimeExportMax, input.IsSuccess, input.UserExportMin, input.UserExportMax, input.TableName, input.ReasonExportFailed, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbLogExportDataDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbLogExportData>, List<TbLogExportDataDto>>(items)
            };
        }

        public virtual async Task<TbLogExportDataDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbLogExportData, TbLogExportDataDto>(await _tbLogExportDataRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogExportDatas.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbLogExportDataRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogExportDatas.Create)]
        public virtual async Task<TbLogExportDataDto> CreateAsync(TbLogExportDataCreateDto input)
        {

            var tbLogExportData = await _tbLogExportDataManager.CreateAsync(
            input.TimeExport, input.IsSuccess, input.UserExport, input.TableName, input.ReasonExportFailed
            );

            return ObjectMapper.Map<TbLogExportData, TbLogExportDataDto>(tbLogExportData);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogExportDatas.Edit)]
        public virtual async Task<TbLogExportDataDto> UpdateAsync(int id, TbLogExportDataUpdateDto input)
        {

            var tbLogExportData = await _tbLogExportDataManager.UpdateAsync(
            id,
            input.TimeExport, input.IsSuccess, input.UserExport, input.TableName, input.ReasonExportFailed
            );

            return ObjectMapper.Map<TbLogExportData, TbLogExportDataDto>(tbLogExportData);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogExportDataExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbLogExportDataRepository.GetListAsync(input.FilterText, input.TimeExportMin, input.TimeExportMax, input.IsSuccess, input.UserExportMin, input.UserExportMax, input.TableName, input.ReasonExportFailed);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbLogExportData>, List<TbLogExportDataExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogExportDatas.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tblogexportdataIds)
        {
            await _tbLogExportDataRepository.DeleteManyAsync(tblogexportdataIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogExportDatas.Delete)]
        public virtual async Task DeleteAllAsync(GetTbLogExportDatasInput input)
        {
            await _tbLogExportDataRepository.DeleteAllAsync(input.FilterText, input.TimeExportMin, input.TimeExportMax, input.IsSuccess, input.UserExportMin, input.UserExportMax, input.TableName, input.ReasonExportFailed);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbLogExportDataDownloadTokenCacheItem { Token = token },
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
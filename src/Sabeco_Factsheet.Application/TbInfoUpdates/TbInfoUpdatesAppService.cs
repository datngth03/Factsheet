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
using Sabeco_Factsheet.TbInfoUpdates;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbInfoUpdates
{

    [Authorize(Sabeco_FactsheetPermissions.TbInfoUpdates.Default)]
    public abstract class TbInfoUpdatesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbInfoUpdateDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbInfoUpdateRepository _tbInfoUpdateRepository;
        protected TbInfoUpdateManager _tbInfoUpdateManager;

        public TbInfoUpdatesAppServiceBase(ITbInfoUpdateRepository tbInfoUpdateRepository, TbInfoUpdateManager tbInfoUpdateManager, IDistributedCache<TbInfoUpdateDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbInfoUpdateRepository = tbInfoUpdateRepository;
            _tbInfoUpdateManager = tbInfoUpdateManager;

        }

        public virtual async Task<PagedResultDto<TbInfoUpdateDto>> GetListAsync(GetTbInfoUpdatesInput input)
        {
            var totalCount = await _tbInfoUpdateRepository.GetCountAsync(input.FilterText, input.TableName, input.ColumnName, input.ScreenName, input.ScreenIdMin, input.ScreenIdMax, input.RowIdMin, input.RowIdMax, input.Command, input.GroupName, input.LastValue, input.NewValue, input.DocStatusMin, input.DocStatusMax, input.Comment, input.IsActiveMin, input.IsActiveMax, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.ChangeSetId, input.TimeAssessmentMin, input.TimeAssessmentMax, input.IsVisible);
            var items = await _tbInfoUpdateRepository.GetListAsync(input.FilterText, input.TableName, input.ColumnName, input.ScreenName, input.ScreenIdMin, input.ScreenIdMax, input.RowIdMin, input.RowIdMax, input.Command, input.GroupName, input.LastValue, input.NewValue, input.DocStatusMin, input.DocStatusMax, input.Comment, input.IsActiveMin, input.IsActiveMax, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.ChangeSetId, input.TimeAssessmentMin, input.TimeAssessmentMax, input.IsVisible, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbInfoUpdateDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbInfoUpdate>, List<TbInfoUpdateDto>>(items)
            };
        }

        public virtual async Task<TbInfoUpdateDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbInfoUpdate, TbInfoUpdateDto>(await _tbInfoUpdateRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInfoUpdates.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbInfoUpdateRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInfoUpdates.Create)]
        public virtual async Task<TbInfoUpdateDto> CreateAsync(TbInfoUpdateCreateDto input)
        {

            var tbInfoUpdate = await _tbInfoUpdateManager.CreateAsync(
            input.TableName, input.ColumnName, input.ScreenId, input.RowId, input.Command, input.IsActive, input.IsVisible, input.ScreenName, input.GroupName, input.LastValue, input.NewValue, input.DocStatus, input.Comment, input.crt_user, input.crt_date, input.mod_user, input.mod_date, input.ChangeSetId, input.TimeAssessment
            );

            return ObjectMapper.Map<TbInfoUpdate, TbInfoUpdateDto>(tbInfoUpdate);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInfoUpdates.Edit)]
        public virtual async Task<TbInfoUpdateDto> UpdateAsync(int id, TbInfoUpdateUpdateDto input)
        {

            var tbInfoUpdate = await _tbInfoUpdateManager.UpdateAsync(
            id,
            input.TableName, input.ColumnName, input.ScreenId, input.RowId, input.Command, input.IsActive, input.IsVisible, input.ScreenName, input.GroupName, input.LastValue, input.NewValue, input.DocStatus, input.Comment, input.crt_user, input.crt_date, input.mod_user, input.mod_date, input.ChangeSetId, input.TimeAssessment
            );

            return ObjectMapper.Map<TbInfoUpdate, TbInfoUpdateDto>(tbInfoUpdate);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbInfoUpdateExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbInfoUpdateRepository.GetListAsync(input.FilterText, input.TableName, input.ColumnName, input.ScreenName, input.ScreenIdMin, input.ScreenIdMax, input.RowIdMin, input.RowIdMax, input.Command, input.GroupName, input.LastValue, input.NewValue, input.DocStatusMin, input.DocStatusMax, input.Comment, input.IsActiveMin, input.IsActiveMax, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.ChangeSetId, input.TimeAssessmentMin, input.TimeAssessmentMax, input.IsVisible);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbInfoUpdate>, List<TbInfoUpdateExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInfoUpdates.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbinfoupdateIds)
        {
            await _tbInfoUpdateRepository.DeleteManyAsync(tbinfoupdateIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInfoUpdates.Delete)]
        public virtual async Task DeleteAllAsync(GetTbInfoUpdatesInput input)
        {
            await _tbInfoUpdateRepository.DeleteAllAsync(input.FilterText, input.TableName, input.ColumnName, input.ScreenName, input.ScreenIdMin, input.ScreenIdMax, input.RowIdMin, input.RowIdMax, input.Command, input.GroupName, input.LastValue, input.NewValue, input.DocStatusMin, input.DocStatusMax, input.Comment, input.IsActiveMin, input.IsActiveMax, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.ChangeSetId, input.TimeAssessmentMin, input.TimeAssessmentMax, input.IsVisible);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbInfoUpdateDownloadTokenCacheItem { Token = token },
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
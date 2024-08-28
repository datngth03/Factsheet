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
using Sabeco_Factsheet.TbFileUploads;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbFileUploads
{

    [Authorize(Sabeco_FactsheetPermissions.TbFileUploads.Default)]
    public abstract class TbFileUploadsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbFileUploadDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbFileUploadRepository _tbFileUploadRepository;
        protected TbFileUploadManager _tbFileUploadManager;

        public TbFileUploadsAppServiceBase(ITbFileUploadRepository tbFileUploadRepository, TbFileUploadManager tbFileUploadManager, IDistributedCache<TbFileUploadDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbFileUploadRepository = tbFileUploadRepository;
            _tbFileUploadManager = tbFileUploadManager;

        }

        public virtual async Task<PagedResultDto<TbFileUploadDto>> GetListAsync(GetTbFileUploadsInput input)
        {
            var totalCount = await _tbFileUploadRepository.GetCountAsync(input.FilterText, input.companyIdMin, input.companyIdMax, input.personIdMin, input.personIdMax, input.fileName, input.fullFileName, input.fileLink, input.uploadDateMin, input.uploadDateMax, input.UserUploadMin, input.UserUploadMax, input.note, input.IsActive, input.DownloadCountMin, input.DownloadCountMax, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
            var items = await _tbFileUploadRepository.GetListAsync(input.FilterText, input.companyIdMin, input.companyIdMax, input.personIdMin, input.personIdMax, input.fileName, input.fullFileName, input.fileLink, input.uploadDateMin, input.uploadDateMax, input.UserUploadMin, input.UserUploadMax, input.note, input.IsActive, input.DownloadCountMin, input.DownloadCountMax, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbFileUploadDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbFileUpload>, List<TbFileUploadDto>>(items)
            };
        }

        public virtual async Task<TbFileUploadDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbFileUpload, TbFileUploadDto>(await _tbFileUploadRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbFileUploads.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbFileUploadRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbFileUploads.Create)]
        public virtual async Task<TbFileUploadDto> CreateAsync(TbFileUploadCreateDto input)
        {

            var tbFileUpload = await _tbFileUploadManager.CreateAsync(
            input.DownloadCount, input.companyId, input.personId, input.fileName, input.fullFileName, input.fileLink, input.uploadDate, input.UserUpload, input.note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbFileUpload, TbFileUploadDto>(tbFileUpload);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbFileUploads.Edit)]
        public virtual async Task<TbFileUploadDto> UpdateAsync(int id, TbFileUploadUpdateDto input)
        {

            var tbFileUpload = await _tbFileUploadManager.UpdateAsync(
            id,
            input.DownloadCount, input.companyId, input.personId, input.fileName, input.fullFileName, input.fileLink, input.uploadDate, input.UserUpload, input.note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbFileUpload, TbFileUploadDto>(tbFileUpload);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbFileUploadExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbFileUploadRepository.GetListAsync(input.FilterText, input.companyIdMin, input.companyIdMax, input.personIdMin, input.personIdMax, input.fileName, input.fullFileName, input.fileLink, input.uploadDateMin, input.uploadDateMax, input.UserUploadMin, input.UserUploadMax, input.note, input.IsActive, input.DownloadCountMin, input.DownloadCountMax, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbFileUpload>, List<TbFileUploadExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbFileUploads.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbfileuploadIds)
        {
            await _tbFileUploadRepository.DeleteManyAsync(tbfileuploadIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbFileUploads.Delete)]
        public virtual async Task DeleteAllAsync(GetTbFileUploadsInput input)
        {
            await _tbFileUploadRepository.DeleteAllAsync(input.FilterText, input.companyIdMin, input.companyIdMax, input.personIdMin, input.personIdMax, input.fileName, input.fullFileName, input.fileLink, input.uploadDateMin, input.uploadDateMax, input.UserUploadMin, input.UserUploadMax, input.note, input.IsActive, input.DownloadCountMin, input.DownloadCountMax, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbFileUploadDownloadTokenCacheItem { Token = token },
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
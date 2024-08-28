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
using Sabeco_Factsheet.TbFileUploadTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbFileUploadTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbFileUploadTemps.Default)]
    public abstract class TbFileUploadTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbFileUploadTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbFileUploadTempRepository _tbFileUploadTempRepository;
        protected TbFileUploadTempManager _tbFileUploadTempManager;

        public TbFileUploadTempsAppServiceBase(ITbFileUploadTempRepository tbFileUploadTempRepository, TbFileUploadTempManager tbFileUploadTempManager, IDistributedCache<TbFileUploadTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbFileUploadTempRepository = tbFileUploadTempRepository;
            _tbFileUploadTempManager = tbFileUploadTempManager;

        }

        public virtual async Task<PagedResultDto<TbFileUploadTempDto>> GetListAsync(GetTbFileUploadTempsInput input)
        {
            var totalCount = await _tbFileUploadTempRepository.GetCountAsync(input.FilterText, input.companyIdMin, input.companyIdMax, input.personIdMin, input.personIdMax, input.fileName, input.fullFileName, input.fileLink, input.uploadDateMin, input.uploadDateMax, input.UserUploadMin, input.UserUploadMax, input.note, input.IsActive, input.DownloadCountMin, input.DownloadCountMax, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
            var items = await _tbFileUploadTempRepository.GetListAsync(input.FilterText, input.companyIdMin, input.companyIdMax, input.personIdMin, input.personIdMax, input.fileName, input.fullFileName, input.fileLink, input.uploadDateMin, input.uploadDateMax, input.UserUploadMin, input.UserUploadMax, input.note, input.IsActive, input.DownloadCountMin, input.DownloadCountMax, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbFileUploadTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbFileUploadTemp>, List<TbFileUploadTempDto>>(items)
            };
        }

        public virtual async Task<TbFileUploadTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbFileUploadTemp, TbFileUploadTempDto>(await _tbFileUploadTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbFileUploadTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbFileUploadTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbFileUploadTemps.Create)]
        public virtual async Task<TbFileUploadTempDto> CreateAsync(TbFileUploadTempCreateDto input)
        {

            var tbFileUploadTemp = await _tbFileUploadTempManager.CreateAsync(
            input.DownloadCount, input.companyId, input.personId, input.fileName, input.fullFileName, input.fileLink, input.uploadDate, input.UserUpload, input.note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbFileUploadTemp, TbFileUploadTempDto>(tbFileUploadTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbFileUploadTemps.Edit)]
        public virtual async Task<TbFileUploadTempDto> UpdateAsync(int id, TbFileUploadTempUpdateDto input)
        {

            var tbFileUploadTemp = await _tbFileUploadTempManager.UpdateAsync(
            id,
            input.companyId, input.personId, input.fileName, input.fullFileName, input.fileLink, input.uploadDate, input.UserUpload, input.note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbFileUploadTemp, TbFileUploadTempDto>(tbFileUploadTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbFileUploadTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbFileUploadTempRepository.GetListAsync(input.FilterText, input.companyIdMin, input.companyIdMax, input.personIdMin, input.personIdMax, input.fileName, input.fullFileName, input.fileLink, input.uploadDateMin, input.uploadDateMax, input.UserUploadMin, input.UserUploadMax, input.note, input.IsActive, input.DownloadCountMin, input.DownloadCountMax, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbFileUploadTemp>, List<TbFileUploadTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbFileUploadTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbfileuploadtempIds)
        {
            await _tbFileUploadTempRepository.DeleteManyAsync(tbfileuploadtempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbFileUploadTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbFileUploadTempsInput input)
        {
            await _tbFileUploadTempRepository.DeleteAllAsync(input.FilterText, input.companyIdMin, input.companyIdMax, input.personIdMin, input.personIdMax, input.fileName, input.fullFileName, input.fileLink, input.uploadDateMin, input.uploadDateMax, input.UserUploadMin, input.UserUploadMax, input.note, input.IsActive, input.DownloadCountMin, input.DownloadCountMax, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbFileUploadTempDownloadTokenCacheItem { Token = token },
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
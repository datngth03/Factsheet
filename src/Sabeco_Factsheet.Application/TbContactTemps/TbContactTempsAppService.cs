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
using Sabeco_Factsheet.TbContactTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbContactTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbContactTemps.Default)]
    public abstract class TbContactTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbContactTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbContactTempRepository _tbContactTempRepository;
        protected TbContactTempManager _tbContactTempManager;

        public TbContactTempsAppServiceBase(ITbContactTempRepository tbContactTempRepository, TbContactTempManager tbContactTempManager, IDistributedCache<TbContactTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbContactTempRepository = tbContactTempRepository;
            _tbContactTempManager = tbContactTempManager;

        }

        public virtual async Task<PagedResultDto<TbContactTempDto>> GetListAsync(GetTbContactTempsInput input)
        {
            var totalCount = await _tbContactTempRepository.GetCountAsync(input.FilterText, input.companyidMin, input.companyidMax, input.ContactName, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.IsDeleted);
            var items = await _tbContactTempRepository.GetListAsync(input.FilterText, input.companyidMin, input.companyidMax, input.ContactName, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbContactTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbContactTemp>, List<TbContactTempDto>>(items)
            };
        }

        public virtual async Task<TbContactTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbContactTemp, TbContactTempDto>(await _tbContactTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbContactTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbContactTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbContactTemps.Create)]
        public virtual async Task<TbContactTempDto> CreateAsync(TbContactTempCreateDto input)
        {

            var tbContactTemp = await _tbContactTempManager.CreateAsync(
            input.companyid, input.ContactName, input.IsActive, input.IsDeleted, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatus, input.crt_user, input.crt_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbContactTemp, TbContactTempDto>(tbContactTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbContactTemps.Edit)]
        public virtual async Task<TbContactTempDto> UpdateAsync(int id, TbContactTempUpdateDto input)
        {

            var tbContactTemp = await _tbContactTempManager.UpdateAsync(
            id,
            input.companyid, input.ContactName, input.IsActive, input.IsDeleted, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatus, input.crt_user, input.crt_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbContactTemp, TbContactTempDto>(tbContactTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbContactTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbContactTempRepository.GetListAsync(input.FilterText, input.companyidMin, input.companyidMax, input.ContactName, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbContactTemp>, List<TbContactTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbContactTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcontacttempIds)
        {
            await _tbContactTempRepository.DeleteManyAsync(tbcontacttempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbContactTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbContactTempsInput input)
        {
            await _tbContactTempRepository.DeleteAllAsync(input.FilterText, input.companyidMin, input.companyidMax, input.ContactName, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbContactTempDownloadTokenCacheItem { Token = token },
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
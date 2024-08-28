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
using Sabeco_Factsheet.TbContacts;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbContacts
{

    [Authorize(Sabeco_FactsheetPermissions.TbContacts.Default)]
    public abstract class TbContactsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbContactDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbContactRepository _tbContactRepository;
        protected TbContactManager _tbContactManager;

        public TbContactsAppServiceBase(ITbContactRepository tbContactRepository, TbContactManager tbContactManager, IDistributedCache<TbContactDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbContactRepository = tbContactRepository;
            _tbContactManager = tbContactManager;

        }

        public virtual async Task<PagedResultDto<TbContactDto>> GetListAsync(GetTbContactsInput input)
        {
            var totalCount = await _tbContactRepository.GetCountAsync(input.FilterText, input.companyidMin, input.companyidMax, input.ContactName, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.IsDeleted);
            var items = await _tbContactRepository.GetListAsync(input.FilterText, input.companyidMin, input.companyidMax, input.ContactName, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbContactDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbContact>, List<TbContactDto>>(items)
            };
        }

        public virtual async Task<TbContactDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbContact, TbContactDto>(await _tbContactRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbContacts.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbContactRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbContacts.Create)]
        public virtual async Task<TbContactDto> CreateAsync(TbContactCreateDto input)
        {

            var tbContact = await _tbContactManager.CreateAsync(
            input.companyid, input.ContactName, input.IsActive, input.IsDeleted, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatus, input.crt_user, input.crt_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbContact, TbContactDto>(tbContact);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbContacts.Edit)]
        public virtual async Task<TbContactDto> UpdateAsync(int id, TbContactUpdateDto input)
        {

            var tbContact = await _tbContactManager.UpdateAsync(
            id,
            input.companyid, input.ContactName, input.IsActive, input.IsDeleted, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatus, input.crt_user, input.crt_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbContact, TbContactDto>(tbContact);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbContactExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbContactRepository.GetListAsync(input.FilterText, input.companyidMin, input.companyidMax, input.ContactName, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbContact>, List<TbContactExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbContacts.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcontactIds)
        {
            await _tbContactRepository.DeleteManyAsync(tbcontactIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbContacts.Delete)]
        public virtual async Task DeleteAllAsync(GetTbContactsInput input)
        {
            await _tbContactRepository.DeleteAllAsync(input.FilterText, input.companyidMin, input.companyidMax, input.ContactName, input.ContactDept, input.ContactPosition, input.ContactEmail, input.ContactPhone, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbContactDownloadTokenCacheItem { Token = token },
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
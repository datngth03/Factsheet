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
using Sabeco_Factsheet.TbUserMappingPersons;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbUserMappingPersons
{

    [Authorize(Sabeco_FactsheetPermissions.TbUserMappingPersons.Default)]
    public abstract class TbUserMappingPersonsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbUserMappingPersonDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbUserMappingPersonRepository _tbUserMappingPersonRepository;
        protected TbUserMappingPersonManager _tbUserMappingPersonManager;

        public TbUserMappingPersonsAppServiceBase(ITbUserMappingPersonRepository tbUserMappingPersonRepository, TbUserMappingPersonManager tbUserMappingPersonManager, IDistributedCache<TbUserMappingPersonDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbUserMappingPersonRepository = tbUserMappingPersonRepository;
            _tbUserMappingPersonManager = tbUserMappingPersonManager;

        }

        public virtual async Task<PagedResultDto<TbUserMappingPersonDto>> GetListAsync(GetTbUserMappingPersonsInput input)
        {
            var totalCount = await _tbUserMappingPersonRepository.GetCountAsync(input.FilterText, input.useridMin, input.useridMax, input.personidMin, input.personidMax, input.IsActive);
            var items = await _tbUserMappingPersonRepository.GetListAsync(input.FilterText, input.useridMin, input.useridMax, input.personidMin, input.personidMax, input.IsActive, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbUserMappingPersonDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbUserMappingPerson>, List<TbUserMappingPersonDto>>(items)
            };
        }

        public virtual async Task<TbUserMappingPersonDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbUserMappingPerson, TbUserMappingPersonDto>(await _tbUserMappingPersonRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingPersons.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbUserMappingPersonRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingPersons.Create)]
        public virtual async Task<TbUserMappingPersonDto> CreateAsync(TbUserMappingPersonCreateDto input)
        {

            var tbUserMappingPerson = await _tbUserMappingPersonManager.CreateAsync(
            input.userid, input.personid, input.IsActive
            );

            return ObjectMapper.Map<TbUserMappingPerson, TbUserMappingPersonDto>(tbUserMappingPerson);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingPersons.Edit)]
        public virtual async Task<TbUserMappingPersonDto> UpdateAsync(int id, TbUserMappingPersonUpdateDto input)
        {

            var tbUserMappingPerson = await _tbUserMappingPersonManager.UpdateAsync(
            id,
            input.userid, input.personid, input.IsActive
            );

            return ObjectMapper.Map<TbUserMappingPerson, TbUserMappingPersonDto>(tbUserMappingPerson);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbUserMappingPersonExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbUserMappingPersonRepository.GetListAsync(input.FilterText, input.useridMin, input.useridMax, input.personidMin, input.personidMax, input.IsActive);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbUserMappingPerson>, List<TbUserMappingPersonExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingPersons.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbusermappingpersonIds)
        {
            await _tbUserMappingPersonRepository.DeleteManyAsync(tbusermappingpersonIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingPersons.Delete)]
        public virtual async Task DeleteAllAsync(GetTbUserMappingPersonsInput input)
        {
            await _tbUserMappingPersonRepository.DeleteAllAsync(input.FilterText, input.useridMin, input.useridMax, input.personidMin, input.personidMax, input.IsActive);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbUserMappingPersonDownloadTokenCacheItem { Token = token },
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
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
using Sabeco_Factsheet.TbCompanyMappings;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMappings
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappings.Default)]
    public abstract class TbCompanyMappingsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyMappingDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyMappingRepository _tbCompanyMappingRepository;
        protected TbCompanyMappingManager _tbCompanyMappingManager;

        public TbCompanyMappingsAppServiceBase(ITbCompanyMappingRepository tbCompanyMappingRepository, TbCompanyMappingManager tbCompanyMappingManager, IDistributedCache<TbCompanyMappingDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyMappingRepository = tbCompanyMappingRepository;
            _tbCompanyMappingManager = tbCompanyMappingManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyMappingDto>> GetListAsync(GetTbCompanyMappingsInput input)
        {
            var totalCount = await _tbCompanyMappingRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.idCompanyTypeShareholdingCodeMin, input.idCompanyTypeShareholdingCodeMax, input.idCompanyTypesCodeMin, input.idCompanyTypesCodeMax);
            var items = await _tbCompanyMappingRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.idCompanyTypeShareholdingCodeMin, input.idCompanyTypeShareholdingCodeMax, input.idCompanyTypesCodeMin, input.idCompanyTypesCodeMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyMappingDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyMapping>, List<TbCompanyMappingDto>>(items)
            };
        }

        public virtual async Task<TbCompanyMappingDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyMapping, TbCompanyMappingDto>(await _tbCompanyMappingRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappings.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyMappingRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappings.Create)]
        public virtual async Task<TbCompanyMappingDto> CreateAsync(TbCompanyMappingCreateDto input)
        {

            var tbCompanyMapping = await _tbCompanyMappingManager.CreateAsync(
            input.CompanyId, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.idCompanyTypeShareholdingCode, input.idCompanyTypesCode
            );

            return ObjectMapper.Map<TbCompanyMapping, TbCompanyMappingDto>(tbCompanyMapping);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappings.Edit)]
        public virtual async Task<TbCompanyMappingDto> UpdateAsync(int id, TbCompanyMappingUpdateDto input)
        {

            var tbCompanyMapping = await _tbCompanyMappingManager.UpdateAsync(
            id,
            input.CompanyId, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.idCompanyTypeShareholdingCode, input.idCompanyTypesCode
            );

            return ObjectMapper.Map<TbCompanyMapping, TbCompanyMappingDto>(tbCompanyMapping);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyMappingExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyMappingRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.idCompanyTypeShareholdingCodeMin, input.idCompanyTypeShareholdingCodeMax, input.idCompanyTypesCodeMin, input.idCompanyTypesCodeMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyMapping>, List<TbCompanyMappingExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappings.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanymappingIds)
        {
            await _tbCompanyMappingRepository.DeleteManyAsync(tbcompanymappingIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappings.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyMappingsInput input)
        {
            await _tbCompanyMappingRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.idCompanyTypeShareholdingCodeMin, input.idCompanyTypeShareholdingCodeMax, input.idCompanyTypesCodeMin, input.idCompanyTypesCodeMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyMappingDownloadTokenCacheItem { Token = token },
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
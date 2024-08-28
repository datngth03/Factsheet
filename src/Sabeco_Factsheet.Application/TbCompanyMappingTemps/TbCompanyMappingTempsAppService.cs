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
using Sabeco_Factsheet.TbCompanyMappingTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMappingTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappingTemps.Default)]
    public abstract class TbCompanyMappingTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyMappingTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyMappingTempRepository _tbCompanyMappingTempRepository;
        protected TbCompanyMappingTempManager _tbCompanyMappingTempManager;

        public TbCompanyMappingTempsAppServiceBase(ITbCompanyMappingTempRepository tbCompanyMappingTempRepository, TbCompanyMappingTempManager tbCompanyMappingTempManager, IDistributedCache<TbCompanyMappingTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyMappingTempRepository = tbCompanyMappingTempRepository;
            _tbCompanyMappingTempManager = tbCompanyMappingTempManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyMappingTempDto>> GetListAsync(GetTbCompanyMappingTempsInput input)
        {
            var totalCount = await _tbCompanyMappingTempRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.idCompanyTypeShareholdingCodeMin, input.idCompanyTypeShareholdingCodeMax, input.idCompanyTypesCodeMin, input.idCompanyTypesCodeMax);
            var items = await _tbCompanyMappingTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.idCompanyTypeShareholdingCodeMin, input.idCompanyTypeShareholdingCodeMax, input.idCompanyTypesCodeMin, input.idCompanyTypesCodeMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyMappingTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyMappingTemp>, List<TbCompanyMappingTempDto>>(items)
            };
        }

        public virtual async Task<TbCompanyMappingTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyMappingTemp, TbCompanyMappingTempDto>(await _tbCompanyMappingTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappingTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyMappingTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappingTemps.Create)]
        public virtual async Task<TbCompanyMappingTempDto> CreateAsync(TbCompanyMappingTempCreateDto input)
        {

            var tbCompanyMappingTemp = await _tbCompanyMappingTempManager.CreateAsync(
            input.CompanyId, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.idCompanyTypeShareholdingCode, input.idCompanyTypesCode
            );

            return ObjectMapper.Map<TbCompanyMappingTemp, TbCompanyMappingTempDto>(tbCompanyMappingTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappingTemps.Edit)]
        public virtual async Task<TbCompanyMappingTempDto> UpdateAsync(int id, TbCompanyMappingTempUpdateDto input)
        {

            var tbCompanyMappingTemp = await _tbCompanyMappingTempManager.UpdateAsync(
            id,
            input.CompanyId, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.idCompanyTypeShareholdingCode, input.idCompanyTypesCode
            );

            return ObjectMapper.Map<TbCompanyMappingTemp, TbCompanyMappingTempDto>(tbCompanyMappingTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyMappingTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyMappingTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.idCompanyTypeShareholdingCodeMin, input.idCompanyTypeShareholdingCodeMax, input.idCompanyTypesCodeMin, input.idCompanyTypesCodeMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyMappingTemp>, List<TbCompanyMappingTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappingTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanymappingtempIds)
        {
            await _tbCompanyMappingTempRepository.DeleteManyAsync(tbcompanymappingtempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMappingTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyMappingTempsInput input)
        {
            await _tbCompanyMappingTempRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.idCompanyTypeShareholdingCodeMin, input.idCompanyTypeShareholdingCodeMax, input.idCompanyTypesCodeMin, input.idCompanyTypesCodeMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyMappingTempDownloadTokenCacheItem { Token = token },
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
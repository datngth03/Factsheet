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
using Sabeco_Factsheet.TbCompanyBusinessDetailTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBusinessDetailTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetailTemps.Default)]
    public abstract class TbCompanyBusinessDetailTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyBusinessDetailTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyBusinessDetailTempRepository _tbCompanyBusinessDetailTempRepository;
        protected TbCompanyBusinessDetailTempManager _tbCompanyBusinessDetailTempManager;

        public TbCompanyBusinessDetailTempsAppServiceBase(ITbCompanyBusinessDetailTempRepository tbCompanyBusinessDetailTempRepository, TbCompanyBusinessDetailTempManager tbCompanyBusinessDetailTempManager, IDistributedCache<TbCompanyBusinessDetailTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyBusinessDetailTempRepository = tbCompanyBusinessDetailTempRepository;
            _tbCompanyBusinessDetailTempManager = tbCompanyBusinessDetailTempManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyBusinessDetailTempDto>> GetListAsync(GetTbCompanyBusinessDetailTempsInput input)
        {
            var totalCount = await _tbCompanyBusinessDetailTempRepository.GetCountAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
            var items = await _tbCompanyBusinessDetailTempRepository.GetListAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyBusinessDetailTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyBusinessDetailTemp>, List<TbCompanyBusinessDetailTempDto>>(items)
            };
        }

        public virtual async Task<TbCompanyBusinessDetailTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyBusinessDetailTemp, TbCompanyBusinessDetailTempDto>(await _tbCompanyBusinessDetailTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetailTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyBusinessDetailTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetailTemps.Create)]
        public virtual async Task<TbCompanyBusinessDetailTempDto> CreateAsync(TbCompanyBusinessDetailTempCreateDto input)
        {

            var tbCompanyBusinessDetailTemp = await _tbCompanyBusinessDetailTempManager.CreateAsync(
            input.ParentId, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyBusinessDetailTemp, TbCompanyBusinessDetailTempDto>(tbCompanyBusinessDetailTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetailTemps.Edit)]
        public virtual async Task<TbCompanyBusinessDetailTempDto> UpdateAsync(int id, TbCompanyBusinessDetailTempUpdateDto input)
        {

            var tbCompanyBusinessDetailTemp = await _tbCompanyBusinessDetailTempManager.UpdateAsync(
            id,
            input.ParentId, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyBusinessDetailTemp, TbCompanyBusinessDetailTempDto>(tbCompanyBusinessDetailTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBusinessDetailTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyBusinessDetailTempRepository.GetListAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyBusinessDetailTemp>, List<TbCompanyBusinessDetailTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetailTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanybusinessdetailtempIds)
        {
            await _tbCompanyBusinessDetailTempRepository.DeleteManyAsync(tbcompanybusinessdetailtempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetailTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyBusinessDetailTempsInput input)
        {
            await _tbCompanyBusinessDetailTempRepository.DeleteAllAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyBusinessDetailTempDownloadTokenCacheItem { Token = token },
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
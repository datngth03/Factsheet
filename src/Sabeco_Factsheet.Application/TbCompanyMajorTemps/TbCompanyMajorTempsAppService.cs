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
using Sabeco_Factsheet.TbCompanyMajorTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMajorTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajorTemps.Default)]
    public abstract class TbCompanyMajorTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyMajorTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyMajorTempRepository _tbCompanyMajorTempRepository;
        protected TbCompanyMajorTempManager _tbCompanyMajorTempManager;

        public TbCompanyMajorTempsAppServiceBase(ITbCompanyMajorTempRepository tbCompanyMajorTempRepository, TbCompanyMajorTempManager tbCompanyMajorTempManager, IDistributedCache<TbCompanyMajorTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyMajorTempRepository = tbCompanyMajorTempRepository;
            _tbCompanyMajorTempManager = tbCompanyMajorTempManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyMajorTempDto>> GetListAsync(GetTbCompanyMajorTempsInput input)
        {
            var totalCount = await _tbCompanyMajorTempRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.ShareHolderMajor, input.ShareHolderType, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.ShareHolderValueMin, input.ShareHolderValueMax, input.ShareHolderRateMin, input.ShareHolderRateMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.ClassIdMin, input.ClassIdMax, input.IsDeleted);
            var items = await _tbCompanyMajorTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.ShareHolderMajor, input.ShareHolderType, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.ShareHolderValueMin, input.ShareHolderValueMax, input.ShareHolderRateMin, input.ShareHolderRateMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.ClassIdMin, input.ClassIdMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyMajorTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyMajorTemp>, List<TbCompanyMajorTempDto>>(items)
            };
        }

        public virtual async Task<TbCompanyMajorTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyMajorTemp, TbCompanyMajorTempDto>(await _tbCompanyMajorTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajorTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyMajorTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajorTemps.Create)]
        public virtual async Task<TbCompanyMajorTempDto> CreateAsync(TbCompanyMajorTempCreateDto input)
        {

            var tbCompanyMajorTemp = await _tbCompanyMajorTempManager.CreateAsync(
            input.CompanyId, input.ShareHolderMajor, input.ShareHolderType, input.IsActive, input.IsDeleted, input.FromDate, input.ToDate, input.ShareHolderValue, input.ShareHolderRate, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.ClassId
            );

            return ObjectMapper.Map<TbCompanyMajorTemp, TbCompanyMajorTempDto>(tbCompanyMajorTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajorTemps.Edit)]
        public virtual async Task<TbCompanyMajorTempDto> UpdateAsync(int id, TbCompanyMajorTempUpdateDto input)
        {

            var tbCompanyMajorTemp = await _tbCompanyMajorTempManager.UpdateAsync(
            id,
            input.CompanyId, input.ShareHolderMajor, input.ShareHolderType, input.IsActive, input.IsDeleted, input.FromDate, input.ToDate, input.ShareHolderValue, input.ShareHolderRate, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.ClassId
            );

            return ObjectMapper.Map<TbCompanyMajorTemp, TbCompanyMajorTempDto>(tbCompanyMajorTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyMajorTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyMajorTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.ShareHolderMajor, input.ShareHolderType, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.ShareHolderValueMin, input.ShareHolderValueMax, input.ShareHolderRateMin, input.ShareHolderRateMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.ClassIdMin, input.ClassIdMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyMajorTemp>, List<TbCompanyMajorTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajorTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanymajortempIds)
        {
            await _tbCompanyMajorTempRepository.DeleteManyAsync(tbcompanymajortempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajorTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyMajorTempsInput input)
        {
            await _tbCompanyMajorTempRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.ShareHolderMajor, input.ShareHolderType, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.ShareHolderValueMin, input.ShareHolderValueMax, input.ShareHolderRateMin, input.ShareHolderRateMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.ClassIdMin, input.ClassIdMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyMajorTempDownloadTokenCacheItem { Token = token },
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
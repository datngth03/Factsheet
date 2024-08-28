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
using Sabeco_Factsheet.TbCompanyBranchTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBranchTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchTemps.Default)]
    public abstract class TbCompanyBranchTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyBranchTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyBranchTempRepository _tbCompanyBranchTempRepository;
        protected TbCompanyBranchTempManager _tbCompanyBranchTempManager;

        public TbCompanyBranchTempsAppServiceBase(ITbCompanyBranchTempRepository tbCompanyBranchTempRepository, TbCompanyBranchTempManager tbCompanyBranchTempManager, IDistributedCache<TbCompanyBranchTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyBranchTempRepository = tbCompanyBranchTempRepository;
            _tbCompanyBranchTempManager = tbCompanyBranchTempManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyBranchTempDto>> GetListAsync(GetTbCompanyBranchTempsInput input)
        {
            var totalCount = await _tbCompanyBranchTempRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbCompanyBranchTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyBranchTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyBranchTemp>, List<TbCompanyBranchTempDto>>(items)
            };
        }

        public virtual async Task<TbCompanyBranchTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyBranchTemp, TbCompanyBranchTempDto>(await _tbCompanyBranchTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyBranchTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchTemps.Create)]
        public virtual async Task<TbCompanyBranchTempDto> CreateAsync(TbCompanyBranchTempCreateDto input)
        {

            var tbCompanyBranchTemp = await _tbCompanyBranchTempManager.CreateAsync(
            input.CompanyId, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbCompanyBranchTemp, TbCompanyBranchTempDto>(tbCompanyBranchTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchTemps.Edit)]
        public virtual async Task<TbCompanyBranchTempDto> UpdateAsync(int id, TbCompanyBranchTempUpdateDto input)
        {

            var tbCompanyBranchTemp = await _tbCompanyBranchTempManager.UpdateAsync(
            id,
            input.CompanyId, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbCompanyBranchTemp, TbCompanyBranchTempDto>(tbCompanyBranchTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBranchTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyBranchTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyBranchTemp>, List<TbCompanyBranchTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanybranchtempIds)
        {
            await _tbCompanyBranchTempRepository.DeleteManyAsync(tbcompanybranchtempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyBranchTempsInput input)
        {
            await _tbCompanyBranchTempRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyBranchTempDownloadTokenCacheItem { Token = token },
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
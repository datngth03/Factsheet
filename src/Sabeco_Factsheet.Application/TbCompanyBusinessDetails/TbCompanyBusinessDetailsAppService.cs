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
using Sabeco_Factsheet.TbCompanyBusinessDetails;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBusinessDetails
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetails.Default)]
    public abstract class TbCompanyBusinessDetailsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyBusinessDetailDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyBusinessDetailRepository _tbCompanyBusinessDetailRepository;
        protected TbCompanyBusinessDetailManager _tbCompanyBusinessDetailManager;

        public TbCompanyBusinessDetailsAppServiceBase(ITbCompanyBusinessDetailRepository tbCompanyBusinessDetailRepository, TbCompanyBusinessDetailManager tbCompanyBusinessDetailManager, IDistributedCache<TbCompanyBusinessDetailDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyBusinessDetailRepository = tbCompanyBusinessDetailRepository;
            _tbCompanyBusinessDetailManager = tbCompanyBusinessDetailManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyBusinessDetailDto>> GetListAsync(GetTbCompanyBusinessDetailsInput input)
        {
            var totalCount = await _tbCompanyBusinessDetailRepository.GetCountAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
            var items = await _tbCompanyBusinessDetailRepository.GetListAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyBusinessDetailDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyBusinessDetail>, List<TbCompanyBusinessDetailDto>>(items)
            };
        }

        public virtual async Task<TbCompanyBusinessDetailDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyBusinessDetail, TbCompanyBusinessDetailDto>(await _tbCompanyBusinessDetailRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetails.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyBusinessDetailRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetails.Create)]
        public virtual async Task<TbCompanyBusinessDetailDto> CreateAsync(TbCompanyBusinessDetailCreateDto input)
        {

            var tbCompanyBusinessDetail = await _tbCompanyBusinessDetailManager.CreateAsync(
            input.ParentId, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyBusinessDetail, TbCompanyBusinessDetailDto>(tbCompanyBusinessDetail);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetails.Edit)]
        public virtual async Task<TbCompanyBusinessDetailDto> UpdateAsync(int id, TbCompanyBusinessDetailUpdateDto input)
        {

            var tbCompanyBusinessDetail = await _tbCompanyBusinessDetailManager.UpdateAsync(
            id,
            input.ParentId, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyBusinessDetail, TbCompanyBusinessDetailDto>(tbCompanyBusinessDetail);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBusinessDetailExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyBusinessDetailRepository.GetListAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyBusinessDetail>, List<TbCompanyBusinessDetailExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetails.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanybusinessdetailIds)
        {
            await _tbCompanyBusinessDetailRepository.DeleteManyAsync(tbcompanybusinessdetailIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessDetails.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyBusinessDetailsInput input)
        {
            await _tbCompanyBusinessDetailRepository.DeleteAllAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.RegistrationCode, input.RegistrationName, input.RegistrationName_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyBusinessDetailDownloadTokenCacheItem { Token = token },
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
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
using Sabeco_Factsheet.TbCompanyMajors;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMajors
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajors.Default)]
    public abstract class TbCompanyMajorsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyMajorDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyMajorRepository _tbCompanyMajorRepository;
        protected TbCompanyMajorManager _tbCompanyMajorManager;

        public TbCompanyMajorsAppServiceBase(ITbCompanyMajorRepository tbCompanyMajorRepository, TbCompanyMajorManager tbCompanyMajorManager, IDistributedCache<TbCompanyMajorDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyMajorRepository = tbCompanyMajorRepository;
            _tbCompanyMajorManager = tbCompanyMajorManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyMajorDto>> GetListAsync(GetTbCompanyMajorsInput input)
        {
            var totalCount = await _tbCompanyMajorRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.ShareHolderMajor, input.ShareHolderType, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.ShareHolderValueMin, input.ShareHolderValueMax, input.ShareHolderRateMin, input.ShareHolderRateMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.ClassIdMin, input.ClassIdMax, input.IsDeleted);
            var items = await _tbCompanyMajorRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.ShareHolderMajor, input.ShareHolderType, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.ShareHolderValueMin, input.ShareHolderValueMax, input.ShareHolderRateMin, input.ShareHolderRateMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.ClassIdMin, input.ClassIdMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyMajorDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyMajor>, List<TbCompanyMajorDto>>(items)
            };
        }

        public virtual async Task<TbCompanyMajorDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyMajor, TbCompanyMajorDto>(await _tbCompanyMajorRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajors.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyMajorRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajors.Create)]
        public virtual async Task<TbCompanyMajorDto> CreateAsync(TbCompanyMajorCreateDto input)
        {

            var tbCompanyMajor = await _tbCompanyMajorManager.CreateAsync(
            input.CompanyId, input.ShareHolderMajor, input.ShareHolderType, input.IsActive, input.IsDeleted, input.FromDate, input.ToDate, input.ShareHolderValue, input.ShareHolderRate, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.ClassId
            );

            return ObjectMapper.Map<TbCompanyMajor, TbCompanyMajorDto>(tbCompanyMajor);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajors.Edit)]
        public virtual async Task<TbCompanyMajorDto> UpdateAsync(int id, TbCompanyMajorUpdateDto input)
        {

            var tbCompanyMajor = await _tbCompanyMajorManager.UpdateAsync(
            id,
            input.CompanyId, input.ShareHolderMajor, input.ShareHolderType, input.IsActive, input.IsDeleted, input.FromDate, input.ToDate, input.ShareHolderValue, input.ShareHolderRate, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.ClassId
            );

            return ObjectMapper.Map<TbCompanyMajor, TbCompanyMajorDto>(tbCompanyMajor);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyMajorExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyMajorRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.ShareHolderMajor, input.ShareHolderType, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.ShareHolderValueMin, input.ShareHolderValueMax, input.ShareHolderRateMin, input.ShareHolderRateMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.ClassIdMin, input.ClassIdMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyMajor>, List<TbCompanyMajorExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajors.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanymajorIds)
        {
            await _tbCompanyMajorRepository.DeleteManyAsync(tbcompanymajorIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMajors.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyMajorsInput input)
        {
            await _tbCompanyMajorRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.ShareHolderMajor, input.ShareHolderType, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.ShareHolderValueMin, input.ShareHolderValueMax, input.ShareHolderRateMin, input.ShareHolderRateMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.ClassIdMin, input.ClassIdMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyMajorDownloadTokenCacheItem { Token = token },
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
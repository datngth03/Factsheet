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
using Sabeco_Factsheet.TbCompanyBusinessTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBusinessTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessTemps.Default)]
    public abstract class TbCompanyBusinessTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyBusinessTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyBusinessTempRepository _tbCompanyBusinessTempRepository;
        protected TbCompanyBusinessTempManager _tbCompanyBusinessTempManager;

        public TbCompanyBusinessTempsAppServiceBase(ITbCompanyBusinessTempRepository tbCompanyBusinessTempRepository, TbCompanyBusinessTempManager tbCompanyBusinessTempManager, IDistributedCache<TbCompanyBusinessTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyBusinessTempRepository = tbCompanyBusinessTempRepository;
            _tbCompanyBusinessTempManager = tbCompanyBusinessTempManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyBusinessTempDto>> GetListAsync(GetTbCompanyBusinessTempsInput input)
        {
            var totalCount = await _tbCompanyBusinessTempRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.License, input.RegistrationNoMin, input.RegistrationNoMax, input.RegistrationDateMin, input.RegistrationDateMax, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.LatestAmendmentMin, input.LatestAmendmentMax);
            var items = await _tbCompanyBusinessTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.License, input.RegistrationNoMin, input.RegistrationNoMax, input.RegistrationDateMin, input.RegistrationDateMax, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyBusinessTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyBusinessTemp>, List<TbCompanyBusinessTempDto>>(items)
            };
        }

        public virtual async Task<TbCompanyBusinessTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyBusinessTemp, TbCompanyBusinessTempDto>(await _tbCompanyBusinessTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyBusinessTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessTemps.Create)]
        public virtual async Task<TbCompanyBusinessTempDto> CreateAsync(TbCompanyBusinessTempCreateDto input)
        {

            var tbCompanyBusinessTemp = await _tbCompanyBusinessTempManager.CreateAsync(
            input.CompanyId, input.RegistrationNo, input.RegistrationDate, input.License, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.LatestAmendment
            );

            return ObjectMapper.Map<TbCompanyBusinessTemp, TbCompanyBusinessTempDto>(tbCompanyBusinessTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessTemps.Edit)]
        public virtual async Task<TbCompanyBusinessTempDto> UpdateAsync(int id, TbCompanyBusinessTempUpdateDto input)
        {

            var tbCompanyBusinessTemp = await _tbCompanyBusinessTempManager.UpdateAsync(
            id,
            input.CompanyId, input.RegistrationNo, input.RegistrationDate, input.License, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.LatestAmendment
            );

            return ObjectMapper.Map<TbCompanyBusinessTemp, TbCompanyBusinessTempDto>(tbCompanyBusinessTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBusinessTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyBusinessTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.License, input.RegistrationNoMin, input.RegistrationNoMax, input.RegistrationDateMin, input.RegistrationDateMax, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.LatestAmendmentMin, input.LatestAmendmentMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyBusinessTemp>, List<TbCompanyBusinessTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanybusinesstempIds)
        {
            await _tbCompanyBusinessTempRepository.DeleteManyAsync(tbcompanybusinesstempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinessTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyBusinessTempsInput input)
        {
            await _tbCompanyBusinessTempRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.License, input.RegistrationNoMin, input.RegistrationNoMax, input.RegistrationDateMin, input.RegistrationDateMax, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.LatestAmendmentMin, input.LatestAmendmentMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyBusinessTempDownloadTokenCacheItem { Token = token },
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
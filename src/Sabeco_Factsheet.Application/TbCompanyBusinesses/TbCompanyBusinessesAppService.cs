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
using Sabeco_Factsheet.TbCompanyBusinesses;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBusinesses
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinesses.Default)]
    public abstract class TbCompanyBusinessesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyBusinessDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyBusinessRepository _tbCompanyBusinessRepository;
        protected TbCompanyBusinessManager _tbCompanyBusinessManager;

        public TbCompanyBusinessesAppServiceBase(ITbCompanyBusinessRepository tbCompanyBusinessRepository, TbCompanyBusinessManager tbCompanyBusinessManager, IDistributedCache<TbCompanyBusinessDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyBusinessRepository = tbCompanyBusinessRepository;
            _tbCompanyBusinessManager = tbCompanyBusinessManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyBusinessDto>> GetListAsync(GetTbCompanyBusinessesInput input)
        {
            var totalCount = await _tbCompanyBusinessRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.License, input.RegistrationNoMin, input.RegistrationNoMax, input.RegistrationDateMin, input.RegistrationDateMax, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.LatestAmendmentMin, input.LatestAmendmentMax);
            var items = await _tbCompanyBusinessRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.License, input.RegistrationNoMin, input.RegistrationNoMax, input.RegistrationDateMin, input.RegistrationDateMax, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyBusinessDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyBusiness>, List<TbCompanyBusinessDto>>(items)
            };
        }

        public virtual async Task<TbCompanyBusinessDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyBusiness, TbCompanyBusinessDto>(await _tbCompanyBusinessRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinesses.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyBusinessRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinesses.Create)]
        public virtual async Task<TbCompanyBusinessDto> CreateAsync(TbCompanyBusinessCreateDto input)
        {

            var tbCompanyBusiness = await _tbCompanyBusinessManager.CreateAsync(
            input.CompanyId, input.RegistrationNo, input.RegistrationDate, input.License, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.LatestAmendment
            );

            return ObjectMapper.Map<TbCompanyBusiness, TbCompanyBusinessDto>(tbCompanyBusiness);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinesses.Edit)]
        public virtual async Task<TbCompanyBusinessDto> UpdateAsync(int id, TbCompanyBusinessUpdateDto input)
        {

            var tbCompanyBusiness = await _tbCompanyBusinessManager.UpdateAsync(
            id,
            input.CompanyId, input.RegistrationNo, input.RegistrationDate, input.License, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.LatestAmendment
            );

            return ObjectMapper.Map<TbCompanyBusiness, TbCompanyBusinessDto>(tbCompanyBusiness);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBusinessExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyBusinessRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.License, input.RegistrationNoMin, input.RegistrationNoMax, input.RegistrationDateMin, input.RegistrationDateMax, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.LatestAmendmentMin, input.LatestAmendmentMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyBusiness>, List<TbCompanyBusinessExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinesses.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanybusinessIds)
        {
            await _tbCompanyBusinessRepository.DeleteManyAsync(tbcompanybusinessIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBusinesses.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyBusinessesInput input)
        {
            await _tbCompanyBusinessRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.License, input.RegistrationNoMin, input.RegistrationNoMax, input.RegistrationDateMin, input.RegistrationDateMax, input.CompanyName, input.CompanyAddress, input.LegalRepresent, input.CompanyType, input.MajorBusiness, input.OtherActivity, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.LatestAmendmentMin, input.LatestAmendmentMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyBusinessDownloadTokenCacheItem { Token = token },
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
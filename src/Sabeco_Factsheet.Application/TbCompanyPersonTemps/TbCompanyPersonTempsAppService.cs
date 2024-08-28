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
using Sabeco_Factsheet.TbCompanyPersonTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyPersonTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersonTemps.Default)]
    public abstract class TbCompanyPersonTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyPersonTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyPersonTempRepository _tbCompanyPersonTempRepository;
        protected TbCompanyPersonTempManager _tbCompanyPersonTempManager;

        public TbCompanyPersonTempsAppServiceBase(ITbCompanyPersonTempRepository tbCompanyPersonTempRepository, TbCompanyPersonTempManager tbCompanyPersonTempManager, IDistributedCache<TbCompanyPersonTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyPersonTempRepository = tbCompanyPersonTempRepository;
            _tbCompanyPersonTempManager = tbCompanyPersonTempManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyPersonTempDto>> GetListAsync(GetTbCompanyPersonTempsInput input)
        {
            var totalCount = await _tbCompanyPersonTempRepository.GetCountAsync(input.FilterText, input.idCompanyPersonMin, input.idCompanyPersonMax, input.BranchCode, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.PositionIdMin, input.PositionIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionTypeMin, input.PositionTypeMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
            var items = await _tbCompanyPersonTempRepository.GetListAsync(input.FilterText, input.idCompanyPersonMin, input.idCompanyPersonMax, input.BranchCode, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.PositionIdMin, input.PositionIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionTypeMin, input.PositionTypeMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyPersonTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyPersonTemp>, List<TbCompanyPersonTempDto>>(items)
            };
        }

        public virtual async Task<TbCompanyPersonTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyPersonTemp, TbCompanyPersonTempDto>(await _tbCompanyPersonTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersonTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyPersonTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersonTemps.Create)]
        public virtual async Task<TbCompanyPersonTempDto> CreateAsync(TbCompanyPersonTempCreateDto input)
        {

            var tbCompanyPersonTemp = await _tbCompanyPersonTempManager.CreateAsync(
            input.CompanyId, input.PersonId, input.IsActive, input.IsDeleted, input.idCompanyPerson, input.BranchCode, input.PositionId, input.FromDate, input.ToDate, input.PositionType, input.PositionCode, input.PersonalValue, input.PersonalSharePercentage, input.OwnerValue, input.RepresentativePercentage, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyPersonTemp, TbCompanyPersonTempDto>(tbCompanyPersonTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersonTemps.Edit)]
        public virtual async Task<TbCompanyPersonTempDto> UpdateAsync(int id, TbCompanyPersonTempUpdateDto input)
        {

            var tbCompanyPersonTemp = await _tbCompanyPersonTempManager.UpdateAsync(
            id,
            input.CompanyId, input.PersonId, input.IsActive, input.IsDeleted, input.idCompanyPerson, input.BranchCode, input.PositionId, input.FromDate, input.ToDate, input.PositionType, input.PositionCode, input.PersonalValue, input.PersonalSharePercentage, input.OwnerValue, input.RepresentativePercentage, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyPersonTemp, TbCompanyPersonTempDto>(tbCompanyPersonTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyPersonTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyPersonTempRepository.GetListAsync(input.FilterText, input.idCompanyPersonMin, input.idCompanyPersonMax, input.BranchCode, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.PositionIdMin, input.PositionIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionTypeMin, input.PositionTypeMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyPersonTemp>, List<TbCompanyPersonTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersonTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanypersontempIds)
        {
            await _tbCompanyPersonTempRepository.DeleteManyAsync(tbcompanypersontempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersonTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyPersonTempsInput input)
        {
            await _tbCompanyPersonTempRepository.DeleteAllAsync(input.FilterText, input.idCompanyPersonMin, input.idCompanyPersonMax, input.BranchCode, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.PositionIdMin, input.PositionIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionTypeMin, input.PositionTypeMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyPersonTempDownloadTokenCacheItem { Token = token },
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
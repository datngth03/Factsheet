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
using Sabeco_Factsheet.TbCompanyPersons;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyPersons
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersons.Default)]
    public abstract class TbCompanyPersonsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyPersonDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyPersonRepository _tbCompanyPersonRepository;
        protected TbCompanyPersonManager _tbCompanyPersonManager;

        public TbCompanyPersonsAppServiceBase(ITbCompanyPersonRepository tbCompanyPersonRepository, TbCompanyPersonManager tbCompanyPersonManager, IDistributedCache<TbCompanyPersonDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyPersonRepository = tbCompanyPersonRepository;
            _tbCompanyPersonManager = tbCompanyPersonManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyPersonDto>> GetListAsync(GetTbCompanyPersonsInput input)
        {
            var totalCount = await _tbCompanyPersonRepository.GetCountAsync(input.FilterText, input.BranchCode, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.PositionIdMin, input.PositionIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionCode, input.PostionTypeMin, input.PostionTypeMax, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
            var items = await _tbCompanyPersonRepository.GetListAsync(input.FilterText, input.BranchCode, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.PositionIdMin, input.PositionIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionCode, input.PostionTypeMin, input.PostionTypeMax, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyPersonDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyPerson>, List<TbCompanyPersonDto>>(items)
            };
        }

        public virtual async Task<TbCompanyPersonDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyPerson, TbCompanyPersonDto>(await _tbCompanyPersonRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersons.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyPersonRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersons.Create)]
        public virtual async Task<TbCompanyPersonDto> CreateAsync(TbCompanyPersonCreateDto input)
        {

            var tbCompanyPerson = await _tbCompanyPersonManager.CreateAsync(
            input.CompanyId, input.PersonId, input.IsActive, input.IsDeleted, input.BranchCode, input.PositionId, input.FromDate, input.ToDate, input.PositionCode, input.PostionType, input.PersonalValue, input.PersonalSharePercentage, input.OwnerValue, input.RepresentativePercentage, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyPerson, TbCompanyPersonDto>(tbCompanyPerson);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersons.Edit)]
        public virtual async Task<TbCompanyPersonDto> UpdateAsync(int id, TbCompanyPersonUpdateDto input)
        {

            var tbCompanyPerson = await _tbCompanyPersonManager.UpdateAsync(
            id,
            input.CompanyId, input.PersonId, input.IsActive, input.IsDeleted, input.BranchCode, input.PositionId, input.FromDate, input.ToDate, input.PositionCode, input.PostionType, input.PersonalValue, input.PersonalSharePercentage, input.OwnerValue, input.RepresentativePercentage, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyPerson, TbCompanyPersonDto>(tbCompanyPerson);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyPersonExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyPersonRepository.GetListAsync(input.FilterText, input.BranchCode, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.PositionIdMin, input.PositionIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionCode, input.PostionTypeMin, input.PostionTypeMax, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyPerson>, List<TbCompanyPersonExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersons.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanypersonIds)
        {
            await _tbCompanyPersonRepository.DeleteManyAsync(tbcompanypersonIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyPersons.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyPersonsInput input)
        {
            await _tbCompanyPersonRepository.DeleteAllAsync(input.FilterText, input.BranchCode, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.PositionIdMin, input.PositionIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionCode, input.PostionTypeMin, input.PostionTypeMax, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyPersonDownloadTokenCacheItem { Token = token },
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
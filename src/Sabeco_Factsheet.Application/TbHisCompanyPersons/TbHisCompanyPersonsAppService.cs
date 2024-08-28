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
using Sabeco_Factsheet.TbHisCompanyPersons;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisCompanyPersons
{

    [Authorize(Sabeco_FactsheetPermissions.TbHisCompanyPersons.Default)]
    public abstract class TbHisCompanyPersonsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbHisCompanyPersonDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbHisCompanyPersonRepository _tbHisCompanyPersonRepository;
        protected TbHisCompanyPersonManager _tbHisCompanyPersonManager;

        public TbHisCompanyPersonsAppServiceBase(ITbHisCompanyPersonRepository tbHisCompanyPersonRepository, TbHisCompanyPersonManager tbHisCompanyPersonManager, IDistributedCache<TbHisCompanyPersonDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbHisCompanyPersonRepository = tbHisCompanyPersonRepository;
            _tbHisCompanyPersonManager = tbHisCompanyPersonManager;

        }

        public virtual async Task<PagedResultDto<TbHisCompanyPersonDto>> GetListAsync(GetTbHisCompanyPersonsInput input)
        {
            var totalCount = await _tbHisCompanyPersonRepository.GetCountAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.BranchCode, input.IdCompanyPersonMin, input.IdCompanyPersonMax, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionIdMin, input.PositionIdMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
            var items = await _tbHisCompanyPersonRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.BranchCode, input.IdCompanyPersonMin, input.IdCompanyPersonMax, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionIdMin, input.PositionIdMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbHisCompanyPersonDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbHisCompanyPerson>, List<TbHisCompanyPersonDto>>(items)
            };
        }

        public virtual async Task<TbHisCompanyPersonDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbHisCompanyPerson, TbHisCompanyPersonDto>(await _tbHisCompanyPersonRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisCompanyPersons.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbHisCompanyPersonRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisCompanyPersons.Create)]
        public virtual async Task<TbHisCompanyPersonDto> CreateAsync(TbHisCompanyPersonCreateDto input)
        {

            var tbHisCompanyPerson = await _tbHisCompanyPersonManager.CreateAsync(
            input.Type, input.IdCompanyPerson, input.CompanyId, input.PersonId, input.IsActive, input.IsSendMail, input.DateSendMail, input.InsertDate, input.BranchCode, input.FromDate, input.ToDate, input.PositionId, input.PositionCode, input.PersonalValue, input.PersonalSharePercentage, input.OwnerValue, input.RepresentativePercentage, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbHisCompanyPerson, TbHisCompanyPersonDto>(tbHisCompanyPerson);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisCompanyPersons.Edit)]
        public virtual async Task<TbHisCompanyPersonDto> UpdateAsync(int id, TbHisCompanyPersonUpdateDto input)
        {

            var tbHisCompanyPerson = await _tbHisCompanyPersonManager.UpdateAsync(
            id,
            input.Type, input.IdCompanyPerson, input.CompanyId, input.PersonId, input.IsActive, input.IsSendMail, input.DateSendMail, input.InsertDate, input.BranchCode, input.FromDate, input.ToDate, input.PositionId, input.PositionCode, input.PersonalValue, input.PersonalSharePercentage, input.OwnerValue, input.RepresentativePercentage, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbHisCompanyPerson, TbHisCompanyPersonDto>(tbHisCompanyPerson);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisCompanyPersonExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbHisCompanyPersonRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.BranchCode, input.IdCompanyPersonMin, input.IdCompanyPersonMax, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionIdMin, input.PositionIdMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbHisCompanyPerson>, List<TbHisCompanyPersonExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisCompanyPersons.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbhiscompanypersonIds)
        {
            await _tbHisCompanyPersonRepository.DeleteManyAsync(tbhiscompanypersonIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisCompanyPersons.Delete)]
        public virtual async Task DeleteAllAsync(GetTbHisCompanyPersonsInput input)
        {
            await _tbHisCompanyPersonRepository.DeleteAllAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.BranchCode, input.IdCompanyPersonMin, input.IdCompanyPersonMax, input.CompanyIdMin, input.CompanyIdMax, input.PersonIdMin, input.PersonIdMax, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionIdMin, input.PositionIdMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.PersonalSharePercentageMin, input.PersonalSharePercentageMax, input.OwnerValueMin, input.OwnerValueMax, input.RepresentativePercentageMin, input.RepresentativePercentageMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbHisCompanyPersonDownloadTokenCacheItem { Token = token },
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
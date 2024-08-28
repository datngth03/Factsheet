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
using Sabeco_Factsheet.TbPersons;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbPersons
{

    [Authorize(Sabeco_FactsheetPermissions.TbPersons.Default)]
    public abstract class TbPersonsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbPersonDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbPersonRepository _tbPersonRepository;
        protected TbPersonManager _tbPersonManager;

        public TbPersonsAppServiceBase(ITbPersonRepository tbPersonRepository, TbPersonManager tbPersonManager, IDistributedCache<TbPersonDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbPersonRepository = tbPersonRepository;
            _tbPersonManager = tbPersonManager;

        }

        public virtual async Task<PagedResultDto<TbPersonDto>> GetListAsync(GetTbPersonsInput input)
        {
            var totalCount = await _tbPersonRepository.GetCountAsync(input.FilterText, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode, input.IsDeleted);
            var items = await _tbPersonRepository.GetListAsync(input.FilterText, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbPersonDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbPerson>, List<TbPersonDto>>(items)
            };
        }

        public virtual async Task<TbPersonDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbPerson, TbPersonDto>(await _tbPersonRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPersons.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbPersonRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPersons.Create)]
        public virtual async Task<TbPersonDto> CreateAsync(TbPersonCreateDto input)
        {

            var tbPerson = await _tbPersonManager.CreateAsync(
            input.Code, input.FullName, input.BirthDate, input.IsDeleted, input.CompanyId, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDate, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatus, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.OldCode
            );

            return ObjectMapper.Map<TbPerson, TbPersonDto>(tbPerson);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPersons.Edit)]
        public virtual async Task<TbPersonDto> UpdateAsync(int id, TbPersonUpdateDto input)
        {

            var tbPerson = await _tbPersonManager.UpdateAsync(
            id,
            input.Code, input.FullName, input.BirthDate, input.IsDeleted, input.CompanyId, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDate, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatus, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.OldCode
            );

            return ObjectMapper.Map<TbPerson, TbPersonDto>(tbPerson);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbPersonExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbPersonRepository.GetListAsync(input.FilterText, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbPerson>, List<TbPersonExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPersons.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbpersonIds)
        {
            await _tbPersonRepository.DeleteManyAsync(tbpersonIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPersons.Delete)]
        public virtual async Task DeleteAllAsync(GetTbPersonsInput input)
        {
            await _tbPersonRepository.DeleteAllAsync(input.FilterText, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbPersonDownloadTokenCacheItem { Token = token },
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
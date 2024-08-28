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
using Sabeco_Factsheet.TbHisPersons;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisPersons
{

    [Authorize(Sabeco_FactsheetPermissions.TbHisPersons.Default)]
    public abstract class TbHisPersonsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbHisPersonDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbHisPersonRepository _tbHisPersonRepository;
        protected TbHisPersonManager _tbHisPersonManager;

        public TbHisPersonsAppServiceBase(ITbHisPersonRepository tbHisPersonRepository, TbHisPersonManager tbHisPersonManager, IDistributedCache<TbHisPersonDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbHisPersonRepository = tbHisPersonRepository;
            _tbHisPersonManager = tbHisPersonManager;

        }

        public virtual async Task<PagedResultDto<TbHisPersonDto>> GetListAsync(GetTbHisPersonsInput input)
        {
            var totalCount = await _tbHisPersonRepository.GetCountAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdPersonMin, input.IdPersonMax, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode);
            var items = await _tbHisPersonRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdPersonMin, input.IdPersonMax, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbHisPersonDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbHisPerson>, List<TbHisPersonDto>>(items)
            };
        }

        public virtual async Task<TbHisPersonDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbHisPerson, TbHisPersonDto>(await _tbHisPersonRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisPersons.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbHisPersonRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisPersons.Create)]
        public virtual async Task<TbHisPersonDto> CreateAsync(TbHisPersonCreateDto input)
        {

            var tbHisPerson = await _tbHisPersonManager.CreateAsync(
            input.Type, input.IdPerson, input.Code, input.FullName, input.BirthDate, input.IsSendMail, input.DateSendMail, input.InsertDate, input.CompanyId, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDate, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatus, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.OldCode
            );

            return ObjectMapper.Map<TbHisPerson, TbHisPersonDto>(tbHisPerson);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisPersons.Edit)]
        public virtual async Task<TbHisPersonDto> UpdateAsync(int id, TbHisPersonUpdateDto input)
        {

            var tbHisPerson = await _tbHisPersonManager.UpdateAsync(
            id,
            input.Type, input.IdPerson, input.Code, input.FullName, input.BirthDate, input.IsSendMail, input.DateSendMail, input.InsertDate, input.CompanyId, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDate, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatus, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.OldCode
            );

            return ObjectMapper.Map<TbHisPerson, TbHisPersonDto>(tbHisPerson);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisPersonExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbHisPersonRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdPersonMin, input.IdPersonMax, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbHisPerson>, List<TbHisPersonExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisPersons.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbhispersonIds)
        {
            await _tbHisPersonRepository.DeleteManyAsync(tbhispersonIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisPersons.Delete)]
        public virtual async Task DeleteAllAsync(GetTbHisPersonsInput input)
        {
            await _tbHisPersonRepository.DeleteAllAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdPersonMin, input.IdPersonMax, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbHisPersonDownloadTokenCacheItem { Token = token },
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
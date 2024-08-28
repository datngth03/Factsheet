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
using Sabeco_Factsheet.TbPersonTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbPersonTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbPersonTemps.Default)]
    public abstract class TbPersonTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbPersonTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbPersonTempRepository _tbPersonTempRepository;
        protected TbPersonTempManager _tbPersonTempManager;

        public TbPersonTempsAppServiceBase(ITbPersonTempRepository tbPersonTempRepository, TbPersonTempManager tbPersonTempManager, IDistributedCache<TbPersonTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbPersonTempRepository = tbPersonTempRepository;
            _tbPersonTempManager = tbPersonTempManager;

        }

        public virtual async Task<PagedResultDto<TbPersonTempDto>> GetListAsync(GetTbPersonTempsInput input)
        {
            var totalCount = await _tbPersonTempRepository.GetCountAsync(input.FilterText, input.idPersonMin, input.idPersonMax, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode);
            var items = await _tbPersonTempRepository.GetListAsync(input.FilterText, input.idPersonMin, input.idPersonMax, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbPersonTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbPersonTemp>, List<TbPersonTempDto>>(items)
            };
        }

        public virtual async Task<TbPersonTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbPersonTemp, TbPersonTempDto>(await _tbPersonTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPersonTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbPersonTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPersonTemps.Create)]
        public virtual async Task<TbPersonTempDto> CreateAsync(TbPersonTempCreateDto input)
        {

            var tbPersonTemp = await _tbPersonTempManager.CreateAsync(
            input.Code, input.FullName, input.BirthDate, input.idPerson, input.CompanyId, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDate, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatus, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.OldCode
            );

            return ObjectMapper.Map<TbPersonTemp, TbPersonTempDto>(tbPersonTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPersonTemps.Edit)]
        public virtual async Task<TbPersonTempDto> UpdateAsync(int id, TbPersonTempUpdateDto input)
        {

            var tbPersonTemp = await _tbPersonTempManager.UpdateAsync(
            id,
            input.Code, input.FullName, input.BirthDate, input.idPerson, input.CompanyId, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDate, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatus, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.OldCode
            );

            return ObjectMapper.Map<TbPersonTemp, TbPersonTempDto>(tbPersonTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbPersonTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbPersonTempRepository.GetListAsync(input.FilterText, input.idPersonMin, input.idPersonMax, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbPersonTemp>, List<TbPersonTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPersonTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbpersontempIds)
        {
            await _tbPersonTempRepository.DeleteManyAsync(tbpersontempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPersonTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbPersonTempsInput input)
        {
            await _tbPersonTempRepository.DeleteAllAsync(input.FilterText, input.idPersonMin, input.idPersonMax, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbPersonTempDownloadTokenCacheItem { Token = token },
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
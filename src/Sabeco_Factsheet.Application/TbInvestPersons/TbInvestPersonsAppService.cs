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
using Sabeco_Factsheet.TbInvestPersons;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbInvestPersons
{

    [Authorize(Sabeco_FactsheetPermissions.TbInvestPersons.Default)]
    public abstract class TbInvestPersonsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbInvestPersonDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbInvestPersonRepository _tbInvestPersonRepository;
        protected TbInvestPersonManager _tbInvestPersonManager;

        public TbInvestPersonsAppServiceBase(ITbInvestPersonRepository tbInvestPersonRepository, TbInvestPersonManager tbInvestPersonManager, IDistributedCache<TbInvestPersonDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbInvestPersonRepository = tbInvestPersonRepository;
            _tbInvestPersonManager = tbInvestPersonManager;

        }

        public virtual async Task<PagedResultDto<TbInvestPersonDto>> GetListAsync(GetTbInvestPersonsInput input)
        {
            var totalCount = await _tbInvestPersonRepository.GetCountAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.PersonIdMin, input.PersonIdMax, input.FromDateMin, input.FromDateMax, input.PersonalValueMin, input.PersonalValueMax, input.OwnerValueMin, input.OwnerValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
            var items = await _tbInvestPersonRepository.GetListAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.PersonIdMin, input.PersonIdMax, input.FromDateMin, input.FromDateMax, input.PersonalValueMin, input.PersonalValueMax, input.OwnerValueMin, input.OwnerValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbInvestPersonDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbInvestPerson>, List<TbInvestPersonDto>>(items)
            };
        }

        public virtual async Task<TbInvestPersonDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbInvestPerson, TbInvestPersonDto>(await _tbInvestPersonRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvestPersons.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbInvestPersonRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvestPersons.Create)]
        public virtual async Task<TbInvestPersonDto> CreateAsync(TbInvestPersonCreateDto input)
        {

            var tbInvestPerson = await _tbInvestPersonManager.CreateAsync(
            input.ParentId, input.PersonId, input.FromDate, input.IsDeleted, input.PersonalValue, input.OwnerValue, input.Note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbInvestPerson, TbInvestPersonDto>(tbInvestPerson);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvestPersons.Edit)]
        public virtual async Task<TbInvestPersonDto> UpdateAsync(int id, TbInvestPersonUpdateDto input)
        {

            var tbInvestPerson = await _tbInvestPersonManager.UpdateAsync(
            id,
            input.ParentId, input.PersonId, input.FromDate, input.IsDeleted, input.PersonalValue, input.OwnerValue, input.Note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbInvestPerson, TbInvestPersonDto>(tbInvestPerson);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbInvestPersonExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbInvestPersonRepository.GetListAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.PersonIdMin, input.PersonIdMax, input.FromDateMin, input.FromDateMax, input.PersonalValueMin, input.PersonalValueMax, input.OwnerValueMin, input.OwnerValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbInvestPerson>, List<TbInvestPersonExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvestPersons.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbinvestpersonIds)
        {
            await _tbInvestPersonRepository.DeleteManyAsync(tbinvestpersonIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvestPersons.Delete)]
        public virtual async Task DeleteAllAsync(GetTbInvestPersonsInput input)
        {
            await _tbInvestPersonRepository.DeleteAllAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.PersonIdMin, input.PersonIdMax, input.FromDateMin, input.FromDateMax, input.PersonalValueMin, input.PersonalValueMax, input.OwnerValueMin, input.OwnerValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbInvestPersonDownloadTokenCacheItem { Token = token },
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
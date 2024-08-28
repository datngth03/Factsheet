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
using Sabeco_Factsheet.TbCompanyMemberCouncilTerms;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyMemberCouncilTerms.Default)]
    public abstract class TbCompanyMemberCouncilTermsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyMemberCouncilTermDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyMemberCouncilTermRepository _tbCompanyMemberCouncilTermRepository;
        protected TbCompanyMemberCouncilTermManager _tbCompanyMemberCouncilTermManager;

        public TbCompanyMemberCouncilTermsAppServiceBase(ITbCompanyMemberCouncilTermRepository tbCompanyMemberCouncilTermRepository, TbCompanyMemberCouncilTermManager tbCompanyMemberCouncilTermManager, IDistributedCache<TbCompanyMemberCouncilTermDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyMemberCouncilTermRepository = tbCompanyMemberCouncilTermRepository;
            _tbCompanyMemberCouncilTermManager = tbCompanyMemberCouncilTermManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyMemberCouncilTermDto>> GetListAsync(GetTbCompanyMemberCouncilTermsInput input)
        {
            var totalCount = await _tbCompanyMemberCouncilTermRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.TermFromMin, input.TermFromMax, input.TermEndMin, input.TermEndMax);
            var items = await _tbCompanyMemberCouncilTermRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.TermFromMin, input.TermFromMax, input.TermEndMin, input.TermEndMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyMemberCouncilTermDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyMemberCouncilTerm>, List<TbCompanyMemberCouncilTermDto>>(items)
            };
        }

        public virtual async Task<TbCompanyMemberCouncilTermDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyMemberCouncilTerm, TbCompanyMemberCouncilTermDto>(await _tbCompanyMemberCouncilTermRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMemberCouncilTerms.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyMemberCouncilTermRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMemberCouncilTerms.Create)]
        public virtual async Task<TbCompanyMemberCouncilTermDto> CreateAsync(TbCompanyMemberCouncilTermCreateDto input)
        {

            var tbCompanyMemberCouncilTerm = await _tbCompanyMemberCouncilTermManager.CreateAsync(
            input.CompanyId, input.TermFrom, input.TermEnd
            );

            return ObjectMapper.Map<TbCompanyMemberCouncilTerm, TbCompanyMemberCouncilTermDto>(tbCompanyMemberCouncilTerm);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMemberCouncilTerms.Edit)]
        public virtual async Task<TbCompanyMemberCouncilTermDto> UpdateAsync(int id, TbCompanyMemberCouncilTermUpdateDto input)
        {

            var tbCompanyMemberCouncilTerm = await _tbCompanyMemberCouncilTermManager.UpdateAsync(
            id,
            input.CompanyId, input.TermFrom, input.TermEnd
            );

            return ObjectMapper.Map<TbCompanyMemberCouncilTerm, TbCompanyMemberCouncilTermDto>(tbCompanyMemberCouncilTerm);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyMemberCouncilTermExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyMemberCouncilTermRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.TermFromMin, input.TermFromMax, input.TermEndMin, input.TermEndMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyMemberCouncilTerm>, List<TbCompanyMemberCouncilTermExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMemberCouncilTerms.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanymembercounciltermIds)
        {
            await _tbCompanyMemberCouncilTermRepository.DeleteManyAsync(tbcompanymembercounciltermIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyMemberCouncilTerms.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyMemberCouncilTermsInput input)
        {
            await _tbCompanyMemberCouncilTermRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.TermFromMin, input.TermFromMax, input.TermEndMin, input.TermEndMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyMemberCouncilTermDownloadTokenCacheItem { Token = token },
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
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
using Sabeco_Factsheet.TbTerms;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbTerms
{

    [Authorize(Sabeco_FactsheetPermissions.TbTerms.Default)]
    public abstract class TbTermsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbTermDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbTermRepository _tbTermRepository;
        protected TbTermManager _tbTermManager;

        public TbTermsAppServiceBase(ITbTermRepository tbTermRepository, TbTermManager tbTermManager, IDistributedCache<TbTermDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbTermRepository = tbTermRepository;
            _tbTermManager = tbTermManager;

        }

        public virtual async Task<PagedResultDto<TbTermDto>> GetListAsync(GetTbTermsInput input)
        {
            var totalCount = await _tbTermRepository.GetCountAsync(input.FilterText, input.BranchIdMin, input.BranchIdMax, input.TermCode, input.FromYearMin, input.FromYearMax, input.ToYearMin, input.ToYearMax, input.Description);
            var items = await _tbTermRepository.GetListAsync(input.FilterText, input.BranchIdMin, input.BranchIdMax, input.TermCode, input.FromYearMin, input.FromYearMax, input.ToYearMin, input.ToYearMax, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbTermDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbTerm>, List<TbTermDto>>(items)
            };
        }

        public virtual async Task<TbTermDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbTerm, TbTermDto>(await _tbTermRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbTerms.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbTermRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbTerms.Create)]
        public virtual async Task<TbTermDto> CreateAsync(TbTermCreateDto input)
        {

            var tbTerm = await _tbTermManager.CreateAsync(
            input.BranchId, input.TermCode, input.FromYear, input.ToYear, input.Description
            );

            return ObjectMapper.Map<TbTerm, TbTermDto>(tbTerm);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbTerms.Edit)]
        public virtual async Task<TbTermDto> UpdateAsync(int id, TbTermUpdateDto input)
        {

            var tbTerm = await _tbTermManager.UpdateAsync(
            id,
            input.BranchId, input.TermCode, input.FromYear, input.ToYear, input.Description
            );

            return ObjectMapper.Map<TbTerm, TbTermDto>(tbTerm);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbTermExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbTermRepository.GetListAsync(input.FilterText, input.BranchIdMin, input.BranchIdMax, input.TermCode, input.FromYearMin, input.FromYearMax, input.ToYearMin, input.ToYearMax, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbTerm>, List<TbTermExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbTerms.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbtermIds)
        {
            await _tbTermRepository.DeleteManyAsync(tbtermIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbTerms.Delete)]
        public virtual async Task DeleteAllAsync(GetTbTermsInput input)
        {
            await _tbTermRepository.DeleteAllAsync(input.FilterText, input.BranchIdMin, input.BranchIdMax, input.TermCode, input.FromYearMin, input.FromYearMax, input.ToYearMin, input.ToYearMax, input.Description);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbTermDownloadTokenCacheItem { Token = token },
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
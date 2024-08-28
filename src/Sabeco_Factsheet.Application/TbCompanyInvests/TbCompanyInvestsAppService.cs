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
using Sabeco_Factsheet.TbCompanyInvests;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyInvests
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvests.Default)]
    public abstract class TbCompanyInvestsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyInvestDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyInvestRepository _tbCompanyInvestRepository;
        protected TbCompanyInvestManager _tbCompanyInvestManager;

        public TbCompanyInvestsAppServiceBase(ITbCompanyInvestRepository tbCompanyInvestRepository, TbCompanyInvestManager tbCompanyInvestManager, IDistributedCache<TbCompanyInvestDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyInvestRepository = tbCompanyInvestRepository;
            _tbCompanyInvestManager = tbCompanyInvestManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyInvestDto>> GetListAsync(GetTbCompanyInvestsInput input)
        {
            var totalCount = await _tbCompanyInvestRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyName, input.SharesMin, input.SharesMax, input.HoldingMin, input.HoldingMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
            var items = await _tbCompanyInvestRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyName, input.SharesMin, input.SharesMax, input.HoldingMin, input.HoldingMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyInvestDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyInvest>, List<TbCompanyInvestDto>>(items)
            };
        }

        public virtual async Task<TbCompanyInvestDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyInvest, TbCompanyInvestDto>(await _tbCompanyInvestRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvests.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyInvestRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvests.Create)]
        public virtual async Task<TbCompanyInvestDto> CreateAsync(TbCompanyInvestCreateDto input)
        {

            var tbCompanyInvest = await _tbCompanyInvestManager.CreateAsync(
            input.CompanyId, input.IsActive, input.IsDeleted, input.CompanyName, input.Shares, input.Holding, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyInvest, TbCompanyInvestDto>(tbCompanyInvest);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvests.Edit)]
        public virtual async Task<TbCompanyInvestDto> UpdateAsync(int id, TbCompanyInvestUpdateDto input)
        {

            var tbCompanyInvest = await _tbCompanyInvestManager.UpdateAsync(
            id,
            input.CompanyId, input.IsActive, input.IsDeleted, input.CompanyName, input.Shares, input.Holding, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyInvest, TbCompanyInvestDto>(tbCompanyInvest);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyInvestExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyInvestRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyName, input.SharesMin, input.SharesMax, input.HoldingMin, input.HoldingMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyInvest>, List<TbCompanyInvestExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvests.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanyinvestIds)
        {
            await _tbCompanyInvestRepository.DeleteManyAsync(tbcompanyinvestIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvests.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyInvestsInput input)
        {
            await _tbCompanyInvestRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyName, input.SharesMin, input.SharesMax, input.HoldingMin, input.HoldingMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyInvestDownloadTokenCacheItem { Token = token },
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
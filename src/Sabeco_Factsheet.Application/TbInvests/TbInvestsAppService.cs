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
using Sabeco_Factsheet.TbInvests;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbInvests
{

    [Authorize(Sabeco_FactsheetPermissions.TbInvests.Default)]
    public abstract class TbInvestsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbInvestDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbInvestRepository _tbInvestRepository;
        protected TbInvestManager _tbInvestManager;

        public TbInvestsAppServiceBase(ITbInvestRepository tbInvestRepository, TbInvestManager tbInvestManager, IDistributedCache<TbInvestDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbInvestRepository = tbInvestRepository;
            _tbInvestManager = tbInvestManager;

        }

        public virtual async Task<PagedResultDto<TbInvestDto>> GetListAsync(GetTbInvestsInput input)
        {
            var totalCount = await _tbInvestRepository.GetCountAsync(input.FilterText, input.BranchCode, input.BranchIdMin, input.BranchIdMax, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.ShareNumTotalMin, input.ShareNumTotalMax, input.ShareValueTotalMin, input.ShareValueTotalMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.InvestGroup, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
            var items = await _tbInvestRepository.GetListAsync(input.FilterText, input.BranchCode, input.BranchIdMin, input.BranchIdMax, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.ShareNumTotalMin, input.ShareNumTotalMax, input.ShareValueTotalMin, input.ShareValueTotalMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.InvestGroup, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbInvestDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbInvest>, List<TbInvestDto>>(items)
            };
        }

        public virtual async Task<TbInvestDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbInvest, TbInvestDto>(await _tbInvestRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvests.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbInvestRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvests.Create)]
        public virtual async Task<TbInvestDto> CreateAsync(TbInvestCreateDto input)
        {

            var tbInvest = await _tbInvestManager.CreateAsync(
            input.BranchCode, input.CompanyCode, input.IsDeleted, input.BranchId, input.CompanyId, input.ShareNumTotal, input.ShareValueTotal, input.Note, input.DocStatus, input.InvestGroup, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbInvest, TbInvestDto>(tbInvest);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvests.Edit)]
        public virtual async Task<TbInvestDto> UpdateAsync(int id, TbInvestUpdateDto input)
        {

            var tbInvest = await _tbInvestManager.UpdateAsync(
            id,
            input.BranchCode, input.CompanyCode, input.IsDeleted, input.BranchId, input.CompanyId, input.ShareNumTotal, input.ShareValueTotal, input.Note, input.DocStatus, input.InvestGroup, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbInvest, TbInvestDto>(tbInvest);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbInvestExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbInvestRepository.GetListAsync(input.FilterText, input.BranchCode, input.BranchIdMin, input.BranchIdMax, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.ShareNumTotalMin, input.ShareNumTotalMax, input.ShareValueTotalMin, input.ShareValueTotalMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.InvestGroup, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbInvest>, List<TbInvestExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvests.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbinvestIds)
        {
            await _tbInvestRepository.DeleteManyAsync(tbinvestIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvests.Delete)]
        public virtual async Task DeleteAllAsync(GetTbInvestsInput input)
        {
            await _tbInvestRepository.DeleteAllAsync(input.FilterText, input.BranchCode, input.BranchIdMin, input.BranchIdMax, input.CompanyIdMin, input.CompanyIdMax, input.CompanyCode, input.ShareNumTotalMin, input.ShareNumTotalMax, input.ShareValueTotalMin, input.ShareValueTotalMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.InvestGroup, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbInvestDownloadTokenCacheItem { Token = token },
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
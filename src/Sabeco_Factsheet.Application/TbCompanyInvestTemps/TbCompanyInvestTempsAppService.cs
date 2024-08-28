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
using Sabeco_Factsheet.TbCompanyInvestTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyInvestTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvestTemps.Default)]
    public abstract class TbCompanyInvestTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyInvestTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyInvestTempRepository _tbCompanyInvestTempRepository;
        protected TbCompanyInvestTempManager _tbCompanyInvestTempManager;

        public TbCompanyInvestTempsAppServiceBase(ITbCompanyInvestTempRepository tbCompanyInvestTempRepository, TbCompanyInvestTempManager tbCompanyInvestTempManager, IDistributedCache<TbCompanyInvestTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyInvestTempRepository = tbCompanyInvestTempRepository;
            _tbCompanyInvestTempManager = tbCompanyInvestTempManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyInvestTempDto>> GetListAsync(GetTbCompanyInvestTempsInput input)
        {
            var totalCount = await _tbCompanyInvestTempRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyName, input.SharesMin, input.SharesMax, input.HoldingMin, input.HoldingMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
            var items = await _tbCompanyInvestTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyName, input.SharesMin, input.SharesMax, input.HoldingMin, input.HoldingMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyInvestTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyInvestTemp>, List<TbCompanyInvestTempDto>>(items)
            };
        }

        public virtual async Task<TbCompanyInvestTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyInvestTemp, TbCompanyInvestTempDto>(await _tbCompanyInvestTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvestTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyInvestTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvestTemps.Create)]
        public virtual async Task<TbCompanyInvestTempDto> CreateAsync(TbCompanyInvestTempCreateDto input)
        {

            var tbCompanyInvestTemp = await _tbCompanyInvestTempManager.CreateAsync(
            input.CompanyId, input.IsActive, input.CompanyName, input.Shares, input.Holding, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyInvestTemp, TbCompanyInvestTempDto>(tbCompanyInvestTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvestTemps.Edit)]
        public virtual async Task<TbCompanyInvestTempDto> UpdateAsync(int id, TbCompanyInvestTempUpdateDto input)
        {

            var tbCompanyInvestTemp = await _tbCompanyInvestTempManager.UpdateAsync(
            id,
            input.CompanyId, input.IsActive, input.CompanyName, input.Shares, input.Holding, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyInvestTemp, TbCompanyInvestTempDto>(tbCompanyInvestTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyInvestTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyInvestTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyName, input.SharesMin, input.SharesMax, input.HoldingMin, input.HoldingMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyInvestTemp>, List<TbCompanyInvestTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvestTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanyinvesttempIds)
        {
            await _tbCompanyInvestTempRepository.DeleteManyAsync(tbcompanyinvesttempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyInvestTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyInvestTempsInput input)
        {
            await _tbCompanyInvestTempRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyName, input.SharesMin, input.SharesMax, input.HoldingMin, input.HoldingMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyInvestTempDownloadTokenCacheItem { Token = token },
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
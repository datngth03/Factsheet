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
using Sabeco_Factsheet.TbInvestDetails;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbInvestDetails
{

    [Authorize(Sabeco_FactsheetPermissions.TbInvestDetails.Default)]
    public abstract class TbInvestDetailsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbInvestDetailDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbInvestDetailRepository _tbInvestDetailRepository;
        protected TbInvestDetailManager _tbInvestDetailManager;

        public TbInvestDetailsAppServiceBase(ITbInvestDetailRepository tbInvestDetailRepository, TbInvestDetailManager tbInvestDetailManager, IDistributedCache<TbInvestDetailDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbInvestDetailRepository = tbInvestDetailRepository;
            _tbInvestDetailManager = tbInvestDetailManager;

        }

        public virtual async Task<PagedResultDto<TbInvestDetailDto>> GetListAsync(GetTbInvestDetailsInput input)
        {
            var totalCount = await _tbInvestDetailRepository.GetCountAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.DocDateMin, input.DocDateMax, input.DocNo, input.InvestTypeMin, input.InvestTypeMax, input.ShareNumMin, input.ShareNumMax, input.ShareValueMin, input.ShareValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
            var items = await _tbInvestDetailRepository.GetListAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.DocDateMin, input.DocDateMax, input.DocNo, input.InvestTypeMin, input.InvestTypeMax, input.ShareNumMin, input.ShareNumMax, input.ShareValueMin, input.ShareValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbInvestDetailDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbInvestDetail>, List<TbInvestDetailDto>>(items)
            };
        }

        public virtual async Task<TbInvestDetailDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbInvestDetail, TbInvestDetailDto>(await _tbInvestDetailRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvestDetails.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbInvestDetailRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvestDetails.Create)]
        public virtual async Task<TbInvestDetailDto> CreateAsync(TbInvestDetailCreateDto input)
        {

            var tbInvestDetail = await _tbInvestDetailManager.CreateAsync(
            input.ParentId, input.InvestType, input.IsDeleted, input.DocDate, input.DocNo, input.ShareNum, input.ShareValue, input.Note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbInvestDetail, TbInvestDetailDto>(tbInvestDetail);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvestDetails.Edit)]
        public virtual async Task<TbInvestDetailDto> UpdateAsync(int id, TbInvestDetailUpdateDto input)
        {

            var tbInvestDetail = await _tbInvestDetailManager.UpdateAsync(
            id,
            input.ParentId, input.InvestType, input.IsDeleted, input.DocDate, input.DocNo, input.ShareNum, input.ShareValue, input.Note, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbInvestDetail, TbInvestDetailDto>(tbInvestDetail);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbInvestDetailExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbInvestDetailRepository.GetListAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.DocDateMin, input.DocDateMax, input.DocNo, input.InvestTypeMin, input.InvestTypeMax, input.ShareNumMin, input.ShareNumMax, input.ShareValueMin, input.ShareValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbInvestDetail>, List<TbInvestDetailExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvestDetails.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbinvestdetailIds)
        {
            await _tbInvestDetailRepository.DeleteManyAsync(tbinvestdetailIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbInvestDetails.Delete)]
        public virtual async Task DeleteAllAsync(GetTbInvestDetailsInput input)
        {
            await _tbInvestDetailRepository.DeleteAllAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.DocDateMin, input.DocDateMax, input.DocNo, input.InvestTypeMin, input.InvestTypeMax, input.ShareNumMin, input.ShareNumMax, input.ShareValueMin, input.ShareValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbInvestDetailDownloadTokenCacheItem { Token = token },
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
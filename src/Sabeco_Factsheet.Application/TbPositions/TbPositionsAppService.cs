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
using Sabeco_Factsheet.TbPositions;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbPositions
{

    [Authorize(Sabeco_FactsheetPermissions.TbPositions.Default)]
    public abstract class TbPositionsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbPositionDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbPositionRepository _tbPositionRepository;
        protected TbPositionManager _tbPositionManager;

        public TbPositionsAppServiceBase(ITbPositionRepository tbPositionRepository, TbPositionManager tbPositionManager, IDistributedCache<TbPositionDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbPositionRepository = tbPositionRepository;
            _tbPositionManager = tbPositionManager;

        }

        public virtual async Task<PagedResultDto<TbPositionDto>> GetListAsync(GetTbPositionsInput input)
        {
            var totalCount = await _tbPositionRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Name_EN, input.PositionTypeMin, input.PositionTypeMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.ctr_dateMin, input.ctr_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.OrderNumbMin, input.OrderNumbMax, input.IsDeleted);
            var items = await _tbPositionRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Name_EN, input.PositionTypeMin, input.PositionTypeMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.ctr_dateMin, input.ctr_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.OrderNumbMin, input.OrderNumbMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbPositionDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbPosition>, List<TbPositionDto>>(items)
            };
        }

        public virtual async Task<TbPositionDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbPosition, TbPositionDto>(await _tbPositionRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPositions.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbPositionRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPositions.Create)]
        public virtual async Task<TbPositionDto> CreateAsync(TbPositionCreateDto input)
        {

            var tbPosition = await _tbPositionManager.CreateAsync(
            input.Code, input.Name, input.Name_EN, input.IsActive, input.IsDeleted, input.PositionType, input.crt_user, input.ctr_date, input.mod_user, input.mod_date, input.OrderNumb
            );

            return ObjectMapper.Map<TbPosition, TbPositionDto>(tbPosition);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPositions.Edit)]
        public virtual async Task<TbPositionDto> UpdateAsync(int id, TbPositionUpdateDto input)
        {

            var tbPosition = await _tbPositionManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Name_EN, input.IsActive, input.IsDeleted, input.PositionType, input.crt_user, input.ctr_date, input.mod_user, input.mod_date, input.OrderNumb
            );

            return ObjectMapper.Map<TbPosition, TbPositionDto>(tbPosition);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbPositionExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbPositionRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Name_EN, input.PositionTypeMin, input.PositionTypeMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.ctr_dateMin, input.ctr_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.OrderNumbMin, input.OrderNumbMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbPosition>, List<TbPositionExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPositions.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbpositionIds)
        {
            await _tbPositionRepository.DeleteManyAsync(tbpositionIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbPositions.Delete)]
        public virtual async Task DeleteAllAsync(GetTbPositionsInput input)
        {
            await _tbPositionRepository.DeleteAllAsync(input.FilterText, input.Code, input.Name, input.Name_EN, input.PositionTypeMin, input.PositionTypeMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.ctr_dateMin, input.ctr_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.OrderNumbMin, input.OrderNumbMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbPositionDownloadTokenCacheItem { Token = token },
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
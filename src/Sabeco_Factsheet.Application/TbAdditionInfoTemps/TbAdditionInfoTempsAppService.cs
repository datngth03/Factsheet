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
using Sabeco_Factsheet.TbAdditionInfoTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbAdditionInfoTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfoTemps.Default)]
    public abstract class TbAdditionInfoTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbAdditionInfoTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbAdditionInfoTempRepository _tbAdditionInfoTempRepository;
        protected TbAdditionInfoTempManager _tbAdditionInfoTempManager;

        public TbAdditionInfoTempsAppServiceBase(ITbAdditionInfoTempRepository tbAdditionInfoTempRepository, TbAdditionInfoTempManager tbAdditionInfoTempManager, IDistributedCache<TbAdditionInfoTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbAdditionInfoTempRepository = tbAdditionInfoTempRepository;
            _tbAdditionInfoTempManager = tbAdditionInfoTempManager;

        }

        public virtual async Task<PagedResultDto<TbAdditionInfoTempDto>> GetListAsync(GetTbAdditionInfoTempsInput input)
        {
            var totalCount = await _tbAdditionInfoTempRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.DocDateMin, input.DocDateMax, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbAdditionInfoTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.DocDateMin, input.DocDateMax, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbAdditionInfoTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbAdditionInfoTemp>, List<TbAdditionInfoTempDto>>(items)
            };
        }

        public virtual async Task<TbAdditionInfoTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbAdditionInfoTemp, TbAdditionInfoTempDto>(await _tbAdditionInfoTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfoTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbAdditionInfoTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfoTemps.Create)]
        public virtual async Task<TbAdditionInfoTempDto> CreateAsync(TbAdditionInfoTempCreateDto input)
        {

            var tbAdditionInfoTemp = await _tbAdditionInfoTempManager.CreateAsync(
            input.CompanyId, input.DocDate, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbAdditionInfoTemp, TbAdditionInfoTempDto>(tbAdditionInfoTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfoTemps.Edit)]
        public virtual async Task<TbAdditionInfoTempDto> UpdateAsync(int id, TbAdditionInfoTempUpdateDto input)
        {

            var tbAdditionInfoTemp = await _tbAdditionInfoTempManager.UpdateAsync(
            id,
            input.CompanyId, input.DocDate, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbAdditionInfoTemp, TbAdditionInfoTempDto>(tbAdditionInfoTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbAdditionInfoTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbAdditionInfoTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.DocDateMin, input.DocDateMax, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbAdditionInfoTemp>, List<TbAdditionInfoTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfoTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbadditioninfotempIds)
        {
            await _tbAdditionInfoTempRepository.DeleteManyAsync(tbadditioninfotempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfoTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbAdditionInfoTempsInput input)
        {
            await _tbAdditionInfoTempRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.DocDateMin, input.DocDateMax, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbAdditionInfoTempDownloadTokenCacheItem { Token = token },
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
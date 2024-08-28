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
using Sabeco_Factsheet.TbAdditionInfos;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbAdditionInfos
{

    [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfos.Default)]
    public abstract class TbAdditionInfosAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbAdditionInfoDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbAdditionInfoRepository _tbAdditionInfoRepository;
        protected TbAdditionInfoManager _tbAdditionInfoManager;

        public TbAdditionInfosAppServiceBase(ITbAdditionInfoRepository tbAdditionInfoRepository, TbAdditionInfoManager tbAdditionInfoManager, IDistributedCache<TbAdditionInfoDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbAdditionInfoRepository = tbAdditionInfoRepository;
            _tbAdditionInfoManager = tbAdditionInfoManager;

        }

        public virtual async Task<PagedResultDto<TbAdditionInfoDto>> GetListAsync(GetTbAdditionInfosInput input)
        {
            var totalCount = await _tbAdditionInfoRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.DocDateMin, input.DocDateMax, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbAdditionInfoRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.DocDateMin, input.DocDateMax, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbAdditionInfoDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbAdditionInfo>, List<TbAdditionInfoDto>>(items)
            };
        }

        public virtual async Task<TbAdditionInfoDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbAdditionInfo, TbAdditionInfoDto>(await _tbAdditionInfoRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfos.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbAdditionInfoRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfos.Create)]
        public virtual async Task<TbAdditionInfoDto> CreateAsync(TbAdditionInfoCreateDto input)
        {

            var tbAdditionInfo = await _tbAdditionInfoManager.CreateAsync(
            input.CompanyId, input.DocDate, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbAdditionInfo, TbAdditionInfoDto>(tbAdditionInfo);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfos.Edit)]
        public virtual async Task<TbAdditionInfoDto> UpdateAsync(int id, TbAdditionInfoUpdateDto input)
        {

            var tbAdditionInfo = await _tbAdditionInfoManager.UpdateAsync(
            id,
            input.CompanyId, input.DocDate, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbAdditionInfo, TbAdditionInfoDto>(tbAdditionInfo);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbAdditionInfoExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbAdditionInfoRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.DocDateMin, input.DocDateMax, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbAdditionInfo>, List<TbAdditionInfoExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfos.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbadditioninfoIds)
        {
            await _tbAdditionInfoRepository.DeleteManyAsync(tbadditioninfoIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAdditionInfos.Delete)]
        public virtual async Task DeleteAllAsync(GetTbAdditionInfosInput input)
        {
            await _tbAdditionInfoRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.DocDateMin, input.DocDateMax, input.TypeOfGroup, input.TypeOfEvent, input.Description, input.NoOfDocument, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbAdditionInfoDownloadTokenCacheItem { Token = token },
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
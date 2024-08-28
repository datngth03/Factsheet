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
using Sabeco_Factsheet.TbLandInfos;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLandInfos
{

    [Authorize(Sabeco_FactsheetPermissions.TbLandInfos.Default)]
    public abstract class TbLandInfosAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbLandInfoDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbLandInfoRepository _tbLandInfoRepository;
        protected TbLandInfoManager _tbLandInfoManager;

        public TbLandInfosAppServiceBase(ITbLandInfoRepository tbLandInfoRepository, TbLandInfoManager tbLandInfoManager, IDistributedCache<TbLandInfoDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbLandInfoRepository = tbLandInfoRepository;
            _tbLandInfoManager = tbLandInfoManager;

        }

        public virtual async Task<PagedResultDto<TbLandInfoDto>> GetListAsync(GetTbLandInfosInput input)
        {
            var totalCount = await _tbLandInfoRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.Description, input.Address, input.TypeOfLand, input.AreaMin, input.AreaMax, input.SupportingDocument, input.IssueDateMin, input.IssueDateMax, input.ExpiryDateMin, input.ExpiryDateMax, input.Payment, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbLandInfoRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.Description, input.Address, input.TypeOfLand, input.AreaMin, input.AreaMax, input.SupportingDocument, input.IssueDateMin, input.IssueDateMax, input.ExpiryDateMin, input.ExpiryDateMax, input.Payment, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbLandInfoDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbLandInfo>, List<TbLandInfoDto>>(items)
            };
        }

        public virtual async Task<TbLandInfoDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbLandInfo, TbLandInfoDto>(await _tbLandInfoRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLandInfos.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbLandInfoRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLandInfos.Create)]
        public virtual async Task<TbLandInfoDto> CreateAsync(TbLandInfoCreateDto input)
        {

            var tbLandInfo = await _tbLandInfoManager.CreateAsync(
            input.CompanyId, input.TypeOfLand, input.Description, input.Address, input.Area, input.SupportingDocument, input.IssueDate, input.ExpiryDate, input.Payment, input.Remark, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbLandInfo, TbLandInfoDto>(tbLandInfo);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLandInfos.Edit)]
        public virtual async Task<TbLandInfoDto> UpdateAsync(int id, TbLandInfoUpdateDto input)
        {

            var tbLandInfo = await _tbLandInfoManager.UpdateAsync(
            id,
            input.CompanyId, input.TypeOfLand, input.Description, input.Address, input.Area, input.SupportingDocument, input.IssueDate, input.ExpiryDate, input.Payment, input.Remark, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbLandInfo, TbLandInfoDto>(tbLandInfo);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLandInfoExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbLandInfoRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.Description, input.Address, input.TypeOfLand, input.AreaMin, input.AreaMax, input.SupportingDocument, input.IssueDateMin, input.IssueDateMax, input.ExpiryDateMin, input.ExpiryDateMax, input.Payment, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbLandInfo>, List<TbLandInfoExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLandInfos.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tblandinfoIds)
        {
            await _tbLandInfoRepository.DeleteManyAsync(tblandinfoIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLandInfos.Delete)]
        public virtual async Task DeleteAllAsync(GetTbLandInfosInput input)
        {
            await _tbLandInfoRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.Description, input.Address, input.TypeOfLand, input.AreaMin, input.AreaMax, input.SupportingDocument, input.IssueDateMin, input.IssueDateMax, input.ExpiryDateMin, input.ExpiryDateMax, input.Payment, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbLandInfoDownloadTokenCacheItem { Token = token },
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
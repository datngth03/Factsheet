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
using Sabeco_Factsheet.TbLandInfoTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLandInfoTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbLandInfoTemps.Default)]
    public abstract class TbLandInfoTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbLandInfoTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbLandInfoTempRepository _tbLandInfoTempRepository;
        protected TbLandInfoTempManager _tbLandInfoTempManager;

        public TbLandInfoTempsAppServiceBase(ITbLandInfoTempRepository tbLandInfoTempRepository, TbLandInfoTempManager tbLandInfoTempManager, IDistributedCache<TbLandInfoTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbLandInfoTempRepository = tbLandInfoTempRepository;
            _tbLandInfoTempManager = tbLandInfoTempManager;

        }

        public virtual async Task<PagedResultDto<TbLandInfoTempDto>> GetListAsync(GetTbLandInfoTempsInput input)
        {
            var totalCount = await _tbLandInfoTempRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.Description, input.Address, input.TypeOfLand, input.AreaMin, input.AreaMax, input.SupportingDocument, input.IssueDateMin, input.IssueDateMax, input.ExpiryDateMin, input.ExpiryDateMax, input.Payment, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbLandInfoTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.Description, input.Address, input.TypeOfLand, input.AreaMin, input.AreaMax, input.SupportingDocument, input.IssueDateMin, input.IssueDateMax, input.ExpiryDateMin, input.ExpiryDateMax, input.Payment, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbLandInfoTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbLandInfoTemp>, List<TbLandInfoTempDto>>(items)
            };
        }

        public virtual async Task<TbLandInfoTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbLandInfoTemp, TbLandInfoTempDto>(await _tbLandInfoTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLandInfoTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbLandInfoTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLandInfoTemps.Create)]
        public virtual async Task<TbLandInfoTempDto> CreateAsync(TbLandInfoTempCreateDto input)
        {

            var tbLandInfoTemp = await _tbLandInfoTempManager.CreateAsync(
            input.CompanyId, input.TypeOfLand, input.Description, input.Address, input.Area, input.SupportingDocument, input.IssueDate, input.ExpiryDate, input.Payment, input.Remark, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbLandInfoTemp, TbLandInfoTempDto>(tbLandInfoTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLandInfoTemps.Edit)]
        public virtual async Task<TbLandInfoTempDto> UpdateAsync(int id, TbLandInfoTempUpdateDto input)
        {

            var tbLandInfoTemp = await _tbLandInfoTempManager.UpdateAsync(
            id,
            input.CompanyId, input.TypeOfLand, input.Description, input.Address, input.Area, input.SupportingDocument, input.IssueDate, input.ExpiryDate, input.Payment, input.Remark, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbLandInfoTemp, TbLandInfoTempDto>(tbLandInfoTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLandInfoTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbLandInfoTempRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.Description, input.Address, input.TypeOfLand, input.AreaMin, input.AreaMax, input.SupportingDocument, input.IssueDateMin, input.IssueDateMax, input.ExpiryDateMin, input.ExpiryDateMax, input.Payment, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbLandInfoTemp>, List<TbLandInfoTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLandInfoTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tblandinfotempIds)
        {
            await _tbLandInfoTempRepository.DeleteManyAsync(tblandinfotempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLandInfoTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbLandInfoTempsInput input)
        {
            await _tbLandInfoTempRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.Description, input.Address, input.TypeOfLand, input.AreaMin, input.AreaMax, input.SupportingDocument, input.IssueDateMin, input.IssueDateMax, input.ExpiryDateMin, input.ExpiryDateMax, input.Payment, input.Remark, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbLandInfoTempDownloadTokenCacheItem { Token = token },
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
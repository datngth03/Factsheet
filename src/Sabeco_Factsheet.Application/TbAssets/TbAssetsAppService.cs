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
using Sabeco_Factsheet.TbAssets;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbAssets
{

    [Authorize(Sabeco_FactsheetPermissions.TbAssets.Default)]
    public abstract class TbAssetsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbAssetDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbAssetRepository _tbAssetRepository;
        protected TbAssetManager _tbAssetManager;

        public TbAssetsAppServiceBase(ITbAssetRepository tbAssetRepository, TbAssetManager tbAssetManager, IDistributedCache<TbAssetDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbAssetRepository = tbAssetRepository;
            _tbAssetManager = tbAssetManager;

        }

        public virtual async Task<PagedResultDto<TbAssetDto>> GetListAsync(GetTbAssetsInput input)
        {
            var totalCount = await _tbAssetRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.AssetType, input.AssetItem, input.AssetAddress, input.QuantityMin, input.QuantityMax, input.DocNo, input.DocDateMin, input.DocDateMax, input.ExpireDateMin, input.ExpireDateMax, input.Description, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.IsDeleted, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
            var items = await _tbAssetRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.AssetType, input.AssetItem, input.AssetAddress, input.QuantityMin, input.QuantityMax, input.DocNo, input.DocDateMin, input.DocDateMax, input.ExpireDateMin, input.ExpireDateMax, input.Description, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.IsDeleted, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbAssetDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbAsset>, List<TbAssetDto>>(items)
            };
        }

        public virtual async Task<TbAssetDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbAsset, TbAssetDto>(await _tbAssetRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAssets.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbAssetRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAssets.Create)]
        public virtual async Task<TbAssetDto> CreateAsync(TbAssetCreateDto input)
        {

            var tbAsset = await _tbAssetManager.CreateAsync(
            input.CompanyId, input.IsDeleted, input.AssetType, input.AssetItem, input.AssetAddress, input.Quantity, input.DocNo, input.DocDate, input.ExpireDate, input.Description, input.DocStatus, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbAsset, TbAssetDto>(tbAsset);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAssets.Edit)]
        public virtual async Task<TbAssetDto> UpdateAsync(int id, TbAssetUpdateDto input)
        {

            var tbAsset = await _tbAssetManager.UpdateAsync(
            id,
            input.CompanyId, input.IsDeleted, input.AssetType, input.AssetItem, input.AssetAddress, input.Quantity, input.DocNo, input.DocDate, input.ExpireDate, input.Description, input.DocStatus, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbAsset, TbAssetDto>(tbAsset);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbAssetExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbAssetRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.AssetType, input.AssetItem, input.AssetAddress, input.QuantityMin, input.QuantityMax, input.DocNo, input.DocDateMin, input.DocDateMax, input.ExpireDateMin, input.ExpireDateMax, input.Description, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.IsDeleted, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbAsset>, List<TbAssetExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAssets.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbassetIds)
        {
            await _tbAssetRepository.DeleteManyAsync(tbassetIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbAssets.Delete)]
        public virtual async Task DeleteAllAsync(GetTbAssetsInput input)
        {
            await _tbAssetRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.AssetType, input.AssetItem, input.AssetAddress, input.QuantityMin, input.QuantityMax, input.DocNo, input.DocDateMin, input.DocDateMax, input.ExpireDateMin, input.ExpireDateMax, input.Description, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.IsDeleted, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbAssetDownloadTokenCacheItem { Token = token },
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
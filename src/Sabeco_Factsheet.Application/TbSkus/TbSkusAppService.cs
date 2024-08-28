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
using Sabeco_Factsheet.TbSkus;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbSkus
{

    [Authorize(Sabeco_FactsheetPermissions.TbSkus.Default)]
    public abstract class TbSkusAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbSkuDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbSkuRepository _tbSkuRepository;
        protected TbSkuManager _tbSkuManager;

        public TbSkusAppServiceBase(ITbSkuRepository tbSkuRepository, TbSkuManager tbSkuManager, IDistributedCache<TbSkuDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbSkuRepository = tbSkuRepository;
            _tbSkuManager = tbSkuManager;

        }

        public virtual async Task<PagedResultDto<TbSkuDto>> GetListAsync(GetTbSkusInput input)
        {
            var totalCount = await _tbSkuRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Name_EN, input.BrandCode, input.Unit, input.ItemBaseType, input.PackSizeMin, input.PackSizeMax, input.PackQuantityMin, input.PackQuantityMax, input.WeightMin, input.WeightMax, input.ExpiryDateMin, input.ExpiryDateMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbSkuRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Name_EN, input.BrandCode, input.Unit, input.ItemBaseType, input.PackSizeMin, input.PackSizeMax, input.PackQuantityMin, input.PackQuantityMax, input.WeightMin, input.WeightMax, input.ExpiryDateMin, input.ExpiryDateMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbSkuDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbSku>, List<TbSkuDto>>(items)
            };
        }

        public virtual async Task<TbSkuDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbSku, TbSkuDto>(await _tbSkuRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbSkus.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbSkuRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbSkus.Create)]
        public virtual async Task<TbSkuDto> CreateAsync(TbSkuCreateDto input)
        {

            var tbSku = await _tbSkuManager.CreateAsync(
            input.Code, input.Name, input.Name_EN, input.BrandCode, input.Unit, input.ItemBaseType, input.PackSize, input.PackQuantity, input.Weight, input.ExpiryDate, input.IsActive, input.crt_user, input.crt_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbSku, TbSkuDto>(tbSku);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbSkus.Edit)]
        public virtual async Task<TbSkuDto> UpdateAsync(int id, TbSkuUpdateDto input)
        {

            var tbSku = await _tbSkuManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Name_EN, input.BrandCode, input.Unit, input.ItemBaseType, input.PackSize, input.PackQuantity, input.Weight, input.ExpiryDate, input.IsActive, input.crt_user, input.crt_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbSku, TbSkuDto>(tbSku);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbSkuExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbSkuRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Name_EN, input.BrandCode, input.Unit, input.ItemBaseType, input.PackSizeMin, input.PackSizeMax, input.PackQuantityMin, input.PackQuantityMax, input.WeightMin, input.WeightMax, input.ExpiryDateMin, input.ExpiryDateMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbSku>, List<TbSkuExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbSkus.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbskuIds)
        {
            await _tbSkuRepository.DeleteManyAsync(tbskuIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbSkus.Delete)]
        public virtual async Task DeleteAllAsync(GetTbSkusInput input)
        {
            await _tbSkuRepository.DeleteAllAsync(input.FilterText, input.Code, input.Name, input.Name_EN, input.BrandCode, input.Unit, input.ItemBaseType, input.PackSizeMin, input.PackSizeMax, input.PackQuantityMin, input.PackQuantityMax, input.WeightMin, input.WeightMax, input.ExpiryDateMin, input.ExpiryDateMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.crt_dateMin, input.crt_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbSkuDownloadTokenCacheItem { Token = token },
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
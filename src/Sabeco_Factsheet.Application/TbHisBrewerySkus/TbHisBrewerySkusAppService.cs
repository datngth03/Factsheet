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
using Sabeco_Factsheet.TbHisBrewerySkus;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisBrewerySkus
{

    [Authorize(Sabeco_FactsheetPermissions.TbHisBrewerySkus.Default)]
    public abstract class TbHisBrewerySkusAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbHisBrewerySkuDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbHisBrewerySkuRepository _tbHisBrewerySkuRepository;
        protected TbHisBrewerySkuManager _tbHisBrewerySkuManager;

        public TbHisBrewerySkusAppServiceBase(ITbHisBrewerySkuRepository tbHisBrewerySkuRepository, TbHisBrewerySkuManager tbHisBrewerySkuManager, IDistributedCache<TbHisBrewerySkuDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbHisBrewerySkuRepository = tbHisBrewerySkuRepository;
            _tbHisBrewerySkuManager = tbHisBrewerySkuManager;

        }

        public virtual async Task<PagedResultDto<TbHisBrewerySkuDto>> GetListAsync(GetTbHisBrewerySkusInput input)
        {
            var totalCount = await _tbHisBrewerySkuRepository.GetCountAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBrewerySKUMin, input.IdBrewerySKUMax, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax);
            var items = await _tbHisBrewerySkuRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBrewerySKUMin, input.IdBrewerySKUMax, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbHisBrewerySkuDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbHisBrewerySku>, List<TbHisBrewerySkuDto>>(items)
            };
        }

        public virtual async Task<TbHisBrewerySkuDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbHisBrewerySku, TbHisBrewerySkuDto>(await _tbHisBrewerySkuRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBrewerySkus.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbHisBrewerySkuRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBrewerySkus.Create)]
        public virtual async Task<TbHisBrewerySkuDto> CreateAsync(TbHisBrewerySkuCreateDto input)
        {

            var tbHisBrewerySku = await _tbHisBrewerySkuManager.CreateAsync(
            input.Type, input.IdBrewerySKU, input.IsSendMail, input.DateSendMail, input.InsertDate, input.Year, input.BreweryCode, input.SKUCode, input.ProductionVolume, input.DocStatus, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.BreweryId, input.SKUId
            );

            return ObjectMapper.Map<TbHisBrewerySku, TbHisBrewerySkuDto>(tbHisBrewerySku);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBrewerySkus.Edit)]
        public virtual async Task<TbHisBrewerySkuDto> UpdateAsync(int id, TbHisBrewerySkuUpdateDto input)
        {

            var tbHisBrewerySku = await _tbHisBrewerySkuManager.UpdateAsync(
            id,
            input.Type, input.IdBrewerySKU, input.IsSendMail, input.DateSendMail, input.InsertDate, input.Year, input.BreweryCode, input.SKUCode, input.ProductionVolume, input.DocStatus, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.BreweryId, input.SKUId
            );

            return ObjectMapper.Map<TbHisBrewerySku, TbHisBrewerySkuDto>(tbHisBrewerySku);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisBrewerySkuExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbHisBrewerySkuRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBrewerySKUMin, input.IdBrewerySKUMax, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbHisBrewerySku>, List<TbHisBrewerySkuExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBrewerySkus.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbhisbreweryskuIds)
        {
            await _tbHisBrewerySkuRepository.DeleteManyAsync(tbhisbreweryskuIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBrewerySkus.Delete)]
        public virtual async Task DeleteAllAsync(GetTbHisBrewerySkusInput input)
        {
            await _tbHisBrewerySkuRepository.DeleteAllAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBrewerySKUMin, input.IdBrewerySKUMax, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbHisBrewerySkuDownloadTokenCacheItem { Token = token },
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
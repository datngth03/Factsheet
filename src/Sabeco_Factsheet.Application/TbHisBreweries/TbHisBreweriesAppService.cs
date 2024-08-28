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
using Sabeco_Factsheet.TbHisBreweries;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisBreweries
{

    [Authorize(Sabeco_FactsheetPermissions.TbHisBreweries.Default)]
    public abstract class TbHisBreweriesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbHisBreweryDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbHisBreweryRepository _tbHisBreweryRepository;
        protected TbHisBreweryManager _tbHisBreweryManager;

        public TbHisBreweriesAppServiceBase(ITbHisBreweryRepository tbHisBreweryRepository, TbHisBreweryManager tbHisBreweryManager, IDistributedCache<TbHisBreweryDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbHisBreweryRepository = tbHisBreweryRepository;
            _tbHisBreweryManager = tbHisBreweryManager;

        }

        public virtual async Task<PagedResultDto<TbHisBreweryDto>> GetListAsync(GetTbHisBreweriesInput input)
        {
            var totalCount = await _tbHisBreweryRepository.GetCountAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBreweryMin, input.IdBreweryMax, input.BreweryName, input.BreweryName_EN, input.BreweryAdress, input.BriefName, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbHisBreweryRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBreweryMin, input.IdBreweryMax, input.BreweryName, input.BreweryName_EN, input.BreweryAdress, input.BriefName, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbHisBreweryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbHisBrewery>, List<TbHisBreweryDto>>(items)
            };
        }

        public virtual async Task<TbHisBreweryDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbHisBrewery, TbHisBreweryDto>(await _tbHisBreweryRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBreweries.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbHisBreweryRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBreweries.Create)]
        public virtual async Task<TbHisBreweryDto> CreateAsync(TbHisBreweryCreateDto input)
        {

            var tbHisBrewery = await _tbHisBreweryManager.CreateAsync(
            input.InsertDate, input.Type, input.IdBrewery, input.BreweryName, input.CompanyId, input.IsSendMail, input.DateSendMail, input.BreweryName_EN, input.BreweryAdress, input.BriefName, input.CapacityVolume, input.DeliveryVolume, input.Note, input.DocStatus, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbHisBrewery, TbHisBreweryDto>(tbHisBrewery);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBreweries.Edit)]
        public virtual async Task<TbHisBreweryDto> UpdateAsync(int id, TbHisBreweryUpdateDto input)
        {

            var tbHisBrewery = await _tbHisBreweryManager.UpdateAsync(
            id,
            input.InsertDate, input.Type, input.IdBrewery, input.BreweryName, input.CompanyId, input.IsSendMail, input.DateSendMail, input.BreweryName_EN, input.BreweryAdress, input.BriefName, input.CapacityVolume, input.DeliveryVolume, input.Note, input.DocStatus, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbHisBrewery, TbHisBreweryDto>(tbHisBrewery);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisBreweryExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbHisBreweryRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBreweryMin, input.IdBreweryMax, input.BreweryName, input.BreweryName_EN, input.BreweryAdress, input.BriefName, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbHisBrewery>, List<TbHisBreweryExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBreweries.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbhisbreweryIds)
        {
            await _tbHisBreweryRepository.DeleteManyAsync(tbhisbreweryIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisBreweries.Delete)]
        public virtual async Task DeleteAllAsync(GetTbHisBreweriesInput input)
        {
            await _tbHisBreweryRepository.DeleteAllAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBreweryMin, input.IdBreweryMax, input.BreweryName, input.BreweryName_EN, input.BreweryAdress, input.BriefName, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbHisBreweryDownloadTokenCacheItem { Token = token },
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
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
using Sabeco_Factsheet.TbBreweryImages;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweryImages
{

    [Authorize(Sabeco_FactsheetPermissions.TbBreweryImages.Default)]
    public abstract class TbBreweryImagesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbBreweryImageDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbBreweryImageRepository _tbBreweryImageRepository;
        protected TbBreweryImageManager _tbBreweryImageManager;

        public TbBreweryImagesAppServiceBase(ITbBreweryImageRepository tbBreweryImageRepository, TbBreweryImageManager tbBreweryImageManager, IDistributedCache<TbBreweryImageDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbBreweryImageRepository = tbBreweryImageRepository;
            _tbBreweryImageManager = tbBreweryImageManager;

        }

        public virtual async Task<PagedResultDto<TbBreweryImageDto>> GetListAsync(GetTbBreweryImagesInput input)
        {
            var totalCount = await _tbBreweryImageRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BreweryImage, input.ImageLink, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbBreweryImageRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BreweryImage, input.ImageLink, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbBreweryImageDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbBreweryImage>, List<TbBreweryImageDto>>(items)
            };
        }

        public virtual async Task<TbBreweryImageDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbBreweryImage, TbBreweryImageDto>(await _tbBreweryImageRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryImages.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbBreweryImageRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryImages.Create)]
        public virtual async Task<TbBreweryImageDto> CreateAsync(TbBreweryImageCreateDto input)
        {

            var tbBreweryImage = await _tbBreweryImageManager.CreateAsync(
            input.CompanyId, input.BreweryImage, input.ImageLink, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbBreweryImage, TbBreweryImageDto>(tbBreweryImage);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryImages.Edit)]
        public virtual async Task<TbBreweryImageDto> UpdateAsync(int id, TbBreweryImageUpdateDto input)
        {

            var tbBreweryImage = await _tbBreweryImageManager.UpdateAsync(
            id,
            input.CompanyId, input.BreweryImage, input.ImageLink, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbBreweryImage, TbBreweryImageDto>(tbBreweryImage);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBreweryImageExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbBreweryImageRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BreweryImage, input.ImageLink, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbBreweryImage>, List<TbBreweryImageExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryImages.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbbreweryimageIds)
        {
            await _tbBreweryImageRepository.DeleteManyAsync(tbbreweryimageIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBreweryImages.Delete)]
        public virtual async Task DeleteAllAsync(GetTbBreweryImagesInput input)
        {
            await _tbBreweryImageRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BreweryImage, input.ImageLink, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbBreweryImageDownloadTokenCacheItem { Token = token },
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
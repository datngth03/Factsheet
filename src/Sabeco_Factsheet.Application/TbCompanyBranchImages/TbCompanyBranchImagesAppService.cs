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
using Sabeco_Factsheet.TbCompanyBranchImages;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBranchImages
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchImages.Default)]
    public abstract class TbCompanyBranchImagesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyBranchImageDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyBranchImageRepository _tbCompanyBranchImageRepository;
        protected TbCompanyBranchImageManager _tbCompanyBranchImageManager;

        public TbCompanyBranchImagesAppServiceBase(ITbCompanyBranchImageRepository tbCompanyBranchImageRepository, TbCompanyBranchImageManager tbCompanyBranchImageManager, IDistributedCache<TbCompanyBranchImageDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyBranchImageRepository = tbCompanyBranchImageRepository;
            _tbCompanyBranchImageManager = tbCompanyBranchImageManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyBranchImageDto>> GetListAsync(GetTbCompanyBranchImagesInput input)
        {
            var totalCount = await _tbCompanyBranchImageRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchImage, input.ImageLink, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbCompanyBranchImageRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchImage, input.ImageLink, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyBranchImageDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyBranchImage>, List<TbCompanyBranchImageDto>>(items)
            };
        }

        public virtual async Task<TbCompanyBranchImageDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyBranchImage, TbCompanyBranchImageDto>(await _tbCompanyBranchImageRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchImages.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyBranchImageRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchImages.Create)]
        public virtual async Task<TbCompanyBranchImageDto> CreateAsync(TbCompanyBranchImageCreateDto input)
        {

            var tbCompanyBranchImage = await _tbCompanyBranchImageManager.CreateAsync(
            input.CompanyId, input.BranchImage, input.ImageLink, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbCompanyBranchImage, TbCompanyBranchImageDto>(tbCompanyBranchImage);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchImages.Edit)]
        public virtual async Task<TbCompanyBranchImageDto> UpdateAsync(int id, TbCompanyBranchImageUpdateDto input)
        {

            var tbCompanyBranchImage = await _tbCompanyBranchImageManager.UpdateAsync(
            id,
            input.CompanyId, input.BranchImage, input.ImageLink, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbCompanyBranchImage, TbCompanyBranchImageDto>(tbCompanyBranchImage);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBranchImageExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyBranchImageRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchImage, input.ImageLink, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyBranchImage>, List<TbCompanyBranchImageExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchImages.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanybranchimageIds)
        {
            await _tbCompanyBranchImageRepository.DeleteManyAsync(tbcompanybranchimageIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchImages.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyBranchImagesInput input)
        {
            await _tbCompanyBranchImageRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchImage, input.ImageLink, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyBranchImageDownloadTokenCacheItem { Token = token },
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
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
using Sabeco_Factsheet.TsClasses;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TsClasses
{

    [Authorize(Sabeco_FactsheetPermissions.TsClasses.Default)]
    public abstract class TsClassesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TsClassDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITsClassRepository _tsClassRepository;
        protected TsClassManager _tsClassManager;

        public TsClassesAppServiceBase(ITsClassRepository tsClassRepository, TsClassManager tsClassManager, IDistributedCache<TsClassDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tsClassRepository = tsClassRepository;
            _tsClassManager = tsClassManager;

        }

        public virtual async Task<PagedResultDto<TsClassDto>> GetListAsync(GetTsClassesInput input)
        {
            var totalCount = await _tsClassRepository.GetCountAsync(input.FilterText, input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Code_Type);
            var items = await _tsClassRepository.GetListAsync(input.FilterText, input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Code_Type, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TsClassDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TsClass>, List<TsClassDto>>(items)
            };
        }

        public virtual async Task<TsClassDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TsClass, TsClassDto>(await _tsClassRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TsClasses.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tsClassRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TsClasses.Create)]
        public virtual async Task<TsClassDto> CreateAsync(TsClassCreateDto input)
        {

            var tsClass = await _tsClassManager.CreateAsync(
            input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.Code_Type
            );

            return ObjectMapper.Map<TsClass, TsClassDto>(tsClass);
        }

        [Authorize(Sabeco_FactsheetPermissions.TsClasses.Edit)]
        public virtual async Task<TsClassDto> UpdateAsync(int id, TsClassUpdateDto input)
        {

            var tsClass = await _tsClassManager.UpdateAsync(
            id,
            input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.Code_Type
            );

            return ObjectMapper.Map<TsClass, TsClassDto>(tsClass);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TsClassExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tsClassRepository.GetListAsync(input.FilterText, input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Code_Type);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TsClass>, List<TsClassExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TsClasses.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tsclassIds)
        {
            await _tsClassRepository.DeleteManyAsync(tsclassIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TsClasses.Delete)]
        public virtual async Task DeleteAllAsync(GetTsClassesInput input)
        {
            await _tsClassRepository.DeleteAllAsync(input.FilterText, input.ParentCode, input.Code, input.Name, input.Name_EN, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Code_Type);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TsClassDownloadTokenCacheItem { Token = token },
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
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
using Sabeco_Factsheet.TbMenus;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbMenus
{

    [Authorize(Sabeco_FactsheetPermissions.TbMenus.Default)]
    public abstract class TbMenusAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbMenuDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbMenuRepository _tbMenuRepository;
        protected TbMenuManager _tbMenuManager;

        public TbMenusAppServiceBase(ITbMenuRepository tbMenuRepository, TbMenuManager tbMenuManager, IDistributedCache<TbMenuDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbMenuRepository = tbMenuRepository;
            _tbMenuManager = tbMenuManager;

        }

        public virtual async Task<PagedResultDto<TbMenuDto>> GetListAsync(GetTbMenusInput input)
        {
            var totalCount = await _tbMenuRepository.GetCountAsync(input.FilterText, input.ControlName, input.Description, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbMenuRepository.GetListAsync(input.FilterText, input.ControlName, input.Description, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbMenuDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbMenu>, List<TbMenuDto>>(items)
            };
        }

        public virtual async Task<TbMenuDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbMenu, TbMenuDto>(await _tbMenuRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbMenus.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbMenuRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbMenus.Create)]
        public virtual async Task<TbMenuDto> CreateAsync(TbMenuCreateDto input)
        {

            var tbMenu = await _tbMenuManager.CreateAsync(
            input.ControlName, input.Description, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbMenu, TbMenuDto>(tbMenu);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbMenus.Edit)]
        public virtual async Task<TbMenuDto> UpdateAsync(int id, TbMenuUpdateDto input)
        {

            var tbMenu = await _tbMenuManager.UpdateAsync(
            id,
            input.ControlName, input.Description, input.IsActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbMenu, TbMenuDto>(tbMenu);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbMenuExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbMenuRepository.GetListAsync(input.FilterText, input.ControlName, input.Description, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbMenu>, List<TbMenuExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbMenus.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbmenuIds)
        {
            await _tbMenuRepository.DeleteManyAsync(tbmenuIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbMenus.Delete)]
        public virtual async Task DeleteAllAsync(GetTbMenusInput input)
        {
            await _tbMenuRepository.DeleteAllAsync(input.FilterText, input.ControlName, input.Description, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbMenuDownloadTokenCacheItem { Token = token },
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
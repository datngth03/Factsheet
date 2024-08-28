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
using Sabeco_Factsheet.TbRoles;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbRoles
{

    [Authorize(Sabeco_FactsheetPermissions.TbRoles.Default)]
    public abstract class TbRolesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbRoleDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbRoleRepository _tbRoleRepository;
        protected TbRoleManager _tbRoleManager;

        public TbRolesAppServiceBase(ITbRoleRepository tbRoleRepository, TbRoleManager tbRoleManager, IDistributedCache<TbRoleDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbRoleRepository = tbRoleRepository;
            _tbRoleManager = tbRoleManager;

        }

        public virtual async Task<PagedResultDto<TbRoleDto>> GetListAsync(GetTbRolesInput input)
        {
            var totalCount = await _tbRoleRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
            var items = await _tbRoleRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbRoleDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbRole>, List<TbRoleDto>>(items)
            };
        }

        public virtual async Task<TbRoleDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbRole, TbRoleDto>(await _tbRoleRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbRoles.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbRoleRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbRoles.Create)]
        public virtual async Task<TbRoleDto> CreateAsync(TbRoleCreateDto input)
        {

            var tbRole = await _tbRoleManager.CreateAsync(
            input.Code, input.Name, input.Description, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbRole, TbRoleDto>(tbRole);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbRoles.Edit)]
        public virtual async Task<TbRoleDto> UpdateAsync(int id, TbRoleUpdateDto input)
        {

            var tbRole = await _tbRoleManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbRole, TbRoleDto>(tbRole);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbRoleExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbRoleRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbRole>, List<TbRoleExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbRoles.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbroleIds)
        {
            await _tbRoleRepository.DeleteManyAsync(tbroleIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbRoles.Delete)]
        public virtual async Task DeleteAllAsync(GetTbRolesInput input)
        {
            await _tbRoleRepository.DeleteAllAsync(input.FilterText, input.Code, input.Name, input.Description, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbRoleDownloadTokenCacheItem { Token = token },
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
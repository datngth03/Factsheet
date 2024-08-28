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
using Sabeco_Factsheet.TbUserInRoles;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbUserInRoles
{

    [Authorize(Sabeco_FactsheetPermissions.TbUserInRoles.Default)]
    public abstract class TbUserInRolesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbUserInRoleDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbUserInRoleRepository _tbUserInRoleRepository;
        protected TbUserInRoleManager _tbUserInRoleManager;

        public TbUserInRolesAppServiceBase(ITbUserInRoleRepository tbUserInRoleRepository, TbUserInRoleManager tbUserInRoleManager, IDistributedCache<TbUserInRoleDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbUserInRoleRepository = tbUserInRoleRepository;
            _tbUserInRoleManager = tbUserInRoleManager;

        }

        public virtual async Task<PagedResultDto<TbUserInRoleDto>> GetListAsync(GetTbUserInRolesInput input)
        {
            var totalCount = await _tbUserInRoleRepository.GetCountAsync(input.FilterText, input.RoleIdMin, input.RoleIdMax, input.UserIdMin, input.UserIdMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
            var items = await _tbUserInRoleRepository.GetListAsync(input.FilterText, input.RoleIdMin, input.RoleIdMax, input.UserIdMin, input.UserIdMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbUserInRoleDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbUserInRole>, List<TbUserInRoleDto>>(items)
            };
        }

        public virtual async Task<TbUserInRoleDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbUserInRole, TbUserInRoleDto>(await _tbUserInRoleRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserInRoles.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbUserInRoleRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserInRoles.Create)]
        public virtual async Task<TbUserInRoleDto> CreateAsync(TbUserInRoleCreateDto input)
        {

            var tbUserInRole = await _tbUserInRoleManager.CreateAsync(
            input.RoleId, input.UserId, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbUserInRole, TbUserInRoleDto>(tbUserInRole);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserInRoles.Edit)]
        public virtual async Task<TbUserInRoleDto> UpdateAsync(int id, TbUserInRoleUpdateDto input)
        {

            var tbUserInRole = await _tbUserInRoleManager.UpdateAsync(
            id,
            input.RoleId, input.UserId, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbUserInRole, TbUserInRoleDto>(tbUserInRole);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbUserInRoleExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbUserInRoleRepository.GetListAsync(input.FilterText, input.RoleIdMin, input.RoleIdMax, input.UserIdMin, input.UserIdMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbUserInRole>, List<TbUserInRoleExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserInRoles.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbuserinroleIds)
        {
            await _tbUserInRoleRepository.DeleteManyAsync(tbuserinroleIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserInRoles.Delete)]
        public virtual async Task DeleteAllAsync(GetTbUserInRolesInput input)
        {
            await _tbUserInRoleRepository.DeleteAllAsync(input.FilterText, input.RoleIdMin, input.RoleIdMax, input.UserIdMin, input.UserIdMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbUserInRoleDownloadTokenCacheItem { Token = token },
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
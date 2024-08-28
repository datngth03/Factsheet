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
using Sabeco_Factsheet.TbUsers;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbUsers
{

    [Authorize(Sabeco_FactsheetPermissions.TbUsers.Default)]
    public abstract class TbUsersAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbUserDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbUserRepository _tbUserRepository;
        protected TbUserManager _tbUserManager;

        public TbUsersAppServiceBase(ITbUserRepository tbUserRepository, TbUserManager tbUserManager, IDistributedCache<TbUserDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbUserRepository = tbUserRepository;
            _tbUserManager = tbUserManager;

        }

        public virtual async Task<PagedResultDto<TbUserDto>> GetListAsync(GetTbUsersInput input)
        {
            var totalCount = await _tbUserRepository.GetCountAsync(input.FilterText, input.UserPrincipalName, input.UserName, input.FullName, input.Email, input.CompanyIdMin, input.CompanyIdMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.AbpUserId);
            var items = await _tbUserRepository.GetListAsync(input.FilterText, input.UserPrincipalName, input.UserName, input.FullName, input.Email, input.CompanyIdMin, input.CompanyIdMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.AbpUserId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbUserDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbUser>, List<TbUserDto>>(items)
            };
        }

        public virtual async Task<TbUserDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbUser, TbUserDto>(await _tbUserRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUsers.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbUserRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUsers.Create)]
        public virtual async Task<TbUserDto> CreateAsync(TbUserCreateDto input)
        {

            var tbUser = await _tbUserManager.CreateAsync(
            input.UserPrincipalName, input.UserName, input.FullName, input.IsActive, input.Email, input.CompanyId, input.DocStatus, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.AbpUserId
            );

            return ObjectMapper.Map<TbUser, TbUserDto>(tbUser);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUsers.Edit)]
        public virtual async Task<TbUserDto> UpdateAsync(int id, TbUserUpdateDto input)
        {

            var tbUser = await _tbUserManager.UpdateAsync(
            id,
            input.UserPrincipalName, input.UserName, input.FullName, input.IsActive, input.Email, input.CompanyId, input.DocStatus, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.AbpUserId
            );

            return ObjectMapper.Map<TbUser, TbUserDto>(tbUser);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbUserExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbUserRepository.GetListAsync(input.FilterText, input.UserPrincipalName, input.UserName, input.FullName, input.Email, input.CompanyIdMin, input.CompanyIdMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.AbpUserId);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbUser>, List<TbUserExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUsers.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbuserIds)
        {
            await _tbUserRepository.DeleteManyAsync(tbuserIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUsers.Delete)]
        public virtual async Task DeleteAllAsync(GetTbUsersInput input)
        {
            await _tbUserRepository.DeleteAllAsync(input.FilterText, input.UserPrincipalName, input.UserName, input.FullName, input.Email, input.CompanyIdMin, input.CompanyIdMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.AbpUserId);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbUserDownloadTokenCacheItem { Token = token },
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
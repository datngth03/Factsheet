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
using Sabeco_Factsheet.TbCompanyBranchs;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBranchs
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchs.Default)]
    public abstract class TbCompanyBranchsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyBranchDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyBranchRepository _tbCompanyBranchRepository;
        protected TbCompanyBranchManager _tbCompanyBranchManager;

        public TbCompanyBranchsAppServiceBase(ITbCompanyBranchRepository tbCompanyBranchRepository, TbCompanyBranchManager tbCompanyBranchManager, IDistributedCache<TbCompanyBranchDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyBranchRepository = tbCompanyBranchRepository;
            _tbCompanyBranchManager = tbCompanyBranchManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyBranchDto>> GetListAsync(GetTbCompanyBranchsInput input)
        {
            var totalCount = await _tbCompanyBranchRepository.GetCountAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
            var items = await _tbCompanyBranchRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyBranchDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyBranch>, List<TbCompanyBranchDto>>(items)
            };
        }

        public virtual async Task<TbCompanyBranchDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyBranch, TbCompanyBranchDto>(await _tbCompanyBranchRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchs.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyBranchRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchs.Create)]
        public virtual async Task<TbCompanyBranchDto> CreateAsync(TbCompanyBranchCreateDto input)
        {

            var tbCompanyBranch = await _tbCompanyBranchManager.CreateAsync(
            input.CompanyId, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbCompanyBranch, TbCompanyBranchDto>(tbCompanyBranch);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchs.Edit)]
        public virtual async Task<TbCompanyBranchDto> UpdateAsync(int id, TbCompanyBranchUpdateDto input)
        {

            var tbCompanyBranch = await _tbCompanyBranchManager.UpdateAsync(
            id,
            input.CompanyId, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_user, input.create_date, input.mod_user, input.mod_date
            );

            return ObjectMapper.Map<TbCompanyBranch, TbCompanyBranchDto>(tbCompanyBranch);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBranchExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyBranchRepository.GetListAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyBranch>, List<TbCompanyBranchExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchs.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanybranchIds)
        {
            await _tbCompanyBranchRepository.DeleteManyAsync(tbcompanybranchIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBranchs.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyBranchsInput input)
        {
            await _tbCompanyBranchRepository.DeleteAllAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.BranchName, input.BranchAddress, input.BranchCode, input.ContactPerson, input.ContactPhone, input.Email, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyBranchDownloadTokenCacheItem { Token = token },
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
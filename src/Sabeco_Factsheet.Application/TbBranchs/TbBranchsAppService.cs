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
using Sabeco_Factsheet.TbBranchs;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBranchs
{

    [Authorize(Sabeco_FactsheetPermissions.TbBranchs.Default)]
    public abstract class TbBranchsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbBranchDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbBranchRepository _tbBranchRepository;
        protected TbBranchManager _tbBranchManager;

        public TbBranchsAppServiceBase(ITbBranchRepository tbBranchRepository, TbBranchManager tbBranchManager, IDistributedCache<TbBranchDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbBranchRepository = tbBranchRepository;
            _tbBranchManager = tbBranchManager;

        }

        public virtual async Task<PagedResultDto<TbBranchDto>> GetListAsync(GetTbBranchsInput input)
        {
            var totalCount = await _tbBranchRepository.GetCountAsync(input.FilterText, input.Code, input.BriefName, input.Name, input.Name_EN, input.CompanyCode, input.Description, input.IsActive, input.Crt_DateMin, input.Crt_DateMax);
            var items = await _tbBranchRepository.GetListAsync(input.FilterText, input.Code, input.BriefName, input.Name, input.Name_EN, input.CompanyCode, input.Description, input.IsActive, input.Crt_DateMin, input.Crt_DateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbBranchDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbBranch>, List<TbBranchDto>>(items)
            };
        }

        public virtual async Task<TbBranchDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbBranch, TbBranchDto>(await _tbBranchRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBranchs.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbBranchRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBranchs.Create)]
        public virtual async Task<TbBranchDto> CreateAsync(TbBranchCreateDto input)
        {

            var tbBranch = await _tbBranchManager.CreateAsync(
            input.Code, input.Name, input.IsActive, input.BriefName, input.Name_EN, input.CompanyCode, input.Description, input.Crt_Date
            );

            return ObjectMapper.Map<TbBranch, TbBranchDto>(tbBranch);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBranchs.Edit)]
        public virtual async Task<TbBranchDto> UpdateAsync(int id, TbBranchUpdateDto input)
        {

            var tbBranch = await _tbBranchManager.UpdateAsync(
            id,
            input.Code, input.Name, input.IsActive, input.BriefName, input.Name_EN, input.CompanyCode, input.Description, input.Crt_Date
            );

            return ObjectMapper.Map<TbBranch, TbBranchDto>(tbBranch);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBranchExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbBranchRepository.GetListAsync(input.FilterText, input.Code, input.BriefName, input.Name, input.Name_EN, input.CompanyCode, input.Description, input.IsActive, input.Crt_DateMin, input.Crt_DateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbBranch>, List<TbBranchExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBranchs.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbbranchIds)
        {
            await _tbBranchRepository.DeleteManyAsync(tbbranchIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbBranchs.Delete)]
        public virtual async Task DeleteAllAsync(GetTbBranchsInput input)
        {
            await _tbBranchRepository.DeleteAllAsync(input.FilterText, input.Code, input.BriefName, input.Name, input.Name_EN, input.CompanyCode, input.Description, input.IsActive, input.Crt_DateMin, input.Crt_DateMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbBranchDownloadTokenCacheItem { Token = token },
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
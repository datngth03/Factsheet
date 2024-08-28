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
using Sabeco_Factsheet.TbUserMappingCompanies;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbUserMappingCompanies
{

    [Authorize(Sabeco_FactsheetPermissions.TbUserMappingCompanies.Default)]
    public abstract class TbUserMappingCompaniesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbUserMappingCompanyDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbUserMappingCompanyRepository _tbUserMappingCompanyRepository;
        protected TbUserMappingCompanyManager _tbUserMappingCompanyManager;

        public TbUserMappingCompaniesAppServiceBase(ITbUserMappingCompanyRepository tbUserMappingCompanyRepository, TbUserMappingCompanyManager tbUserMappingCompanyManager, IDistributedCache<TbUserMappingCompanyDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbUserMappingCompanyRepository = tbUserMappingCompanyRepository;
            _tbUserMappingCompanyManager = tbUserMappingCompanyManager;

        }

        public virtual async Task<PagedResultDto<TbUserMappingCompanyDto>> GetListAsync(GetTbUserMappingCompaniesInput input)
        {
            var totalCount = await _tbUserMappingCompanyRepository.GetCountAsync(input.FilterText, input.useridMin, input.useridMax, input.companyidMin, input.companyidMax, input.IsActive);
            var items = await _tbUserMappingCompanyRepository.GetListAsync(input.FilterText, input.useridMin, input.useridMax, input.companyidMin, input.companyidMax, input.IsActive, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbUserMappingCompanyDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbUserMappingCompany>, List<TbUserMappingCompanyDto>>(items)
            };
        }

        public virtual async Task<TbUserMappingCompanyDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbUserMappingCompany, TbUserMappingCompanyDto>(await _tbUserMappingCompanyRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingCompanies.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbUserMappingCompanyRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingCompanies.Create)]
        public virtual async Task<TbUserMappingCompanyDto> CreateAsync(TbUserMappingCompanyCreateDto input)
        {

            var tbUserMappingCompany = await _tbUserMappingCompanyManager.CreateAsync(
            input.userid, input.companyid, input.IsActive
            );

            return ObjectMapper.Map<TbUserMappingCompany, TbUserMappingCompanyDto>(tbUserMappingCompany);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingCompanies.Edit)]
        public virtual async Task<TbUserMappingCompanyDto> UpdateAsync(int id, TbUserMappingCompanyUpdateDto input)
        {

            var tbUserMappingCompany = await _tbUserMappingCompanyManager.UpdateAsync(
            id,
            input.userid, input.companyid, input.IsActive
            );

            return ObjectMapper.Map<TbUserMappingCompany, TbUserMappingCompanyDto>(tbUserMappingCompany);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbUserMappingCompanyExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbUserMappingCompanyRepository.GetListAsync(input.FilterText, input.useridMin, input.useridMax, input.companyidMin, input.companyidMax, input.IsActive);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbUserMappingCompany>, List<TbUserMappingCompanyExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingCompanies.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbusermappingcompanyIds)
        {
            await _tbUserMappingCompanyRepository.DeleteManyAsync(tbusermappingcompanyIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbUserMappingCompanies.Delete)]
        public virtual async Task DeleteAllAsync(GetTbUserMappingCompaniesInput input)
        {
            await _tbUserMappingCompanyRepository.DeleteAllAsync(input.FilterText, input.useridMin, input.useridMax, input.companyidMin, input.companyidMax, input.IsActive);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbUserMappingCompanyDownloadTokenCacheItem { Token = token },
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
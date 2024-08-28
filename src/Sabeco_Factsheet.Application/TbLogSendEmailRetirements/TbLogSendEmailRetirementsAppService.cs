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
using Sabeco_Factsheet.TbLogSendEmailRetirements;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{

    [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmailRetirements.Default)]
    public abstract class TbLogSendEmailRetirementsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbLogSendEmailRetirementDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbLogSendEmailRetirementRepository _tbLogSendEmailRetirementRepository;
        protected TbLogSendEmailRetirementManager _tbLogSendEmailRetirementManager;

        public TbLogSendEmailRetirementsAppServiceBase(ITbLogSendEmailRetirementRepository tbLogSendEmailRetirementRepository, TbLogSendEmailRetirementManager tbLogSendEmailRetirementManager, IDistributedCache<TbLogSendEmailRetirementDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbLogSendEmailRetirementRepository = tbLogSendEmailRetirementRepository;
            _tbLogSendEmailRetirementManager = tbLogSendEmailRetirementManager;

        }

        public virtual async Task<PagedResultDto<TbLogSendEmailRetirementDto>> GetListAsync(GetTbLogSendEmailRetirementsInput input)
        {
            var totalCount = await _tbLogSendEmailRetirementRepository.GetCountAsync(input.FilterText, input.idCompanyMin, input.idCompanyMax, input.idPersonMin, input.idPersonMax, input.IsSendEmail, input.DateSendEmailMin, input.DateSendEmailMax, input.TypeMin, input.TypeMax);
            var items = await _tbLogSendEmailRetirementRepository.GetListAsync(input.FilterText, input.idCompanyMin, input.idCompanyMax, input.idPersonMin, input.idPersonMax, input.IsSendEmail, input.DateSendEmailMin, input.DateSendEmailMax, input.TypeMin, input.TypeMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbLogSendEmailRetirementDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbLogSendEmailRetirement>, List<TbLogSendEmailRetirementDto>>(items)
            };
        }

        public virtual async Task<TbLogSendEmailRetirementDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbLogSendEmailRetirement, TbLogSendEmailRetirementDto>(await _tbLogSendEmailRetirementRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmailRetirements.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbLogSendEmailRetirementRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmailRetirements.Create)]
        public virtual async Task<TbLogSendEmailRetirementDto> CreateAsync(TbLogSendEmailRetirementCreateDto input)
        {

            var tbLogSendEmailRetirement = await _tbLogSendEmailRetirementManager.CreateAsync(
            input.idCompany, input.idPerson, input.IsSendEmail, input.DateSendEmail, input.Type
            );

            return ObjectMapper.Map<TbLogSendEmailRetirement, TbLogSendEmailRetirementDto>(tbLogSendEmailRetirement);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmailRetirements.Edit)]
        public virtual async Task<TbLogSendEmailRetirementDto> UpdateAsync(int id, TbLogSendEmailRetirementUpdateDto input)
        {

            var tbLogSendEmailRetirement = await _tbLogSendEmailRetirementManager.UpdateAsync(
            id,
            input.idCompany, input.idPerson, input.IsSendEmail, input.DateSendEmail, input.Type
            );

            return ObjectMapper.Map<TbLogSendEmailRetirement, TbLogSendEmailRetirementDto>(tbLogSendEmailRetirement);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogSendEmailRetirementExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbLogSendEmailRetirementRepository.GetListAsync(input.FilterText, input.idCompanyMin, input.idCompanyMax, input.idPersonMin, input.idPersonMax, input.IsSendEmail, input.DateSendEmailMin, input.DateSendEmailMax, input.TypeMin, input.TypeMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbLogSendEmailRetirement>, List<TbLogSendEmailRetirementExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmailRetirements.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tblogsendemailretirementIds)
        {
            await _tbLogSendEmailRetirementRepository.DeleteManyAsync(tblogsendemailretirementIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbLogSendEmailRetirements.Delete)]
        public virtual async Task DeleteAllAsync(GetTbLogSendEmailRetirementsInput input)
        {
            await _tbLogSendEmailRetirementRepository.DeleteAllAsync(input.FilterText, input.idCompanyMin, input.idCompanyMax, input.idPersonMin, input.idPersonMax, input.IsSendEmail, input.DateSendEmailMin, input.DateSendEmailMax, input.TypeMin, input.TypeMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbLogSendEmailRetirementDownloadTokenCacheItem { Token = token },
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
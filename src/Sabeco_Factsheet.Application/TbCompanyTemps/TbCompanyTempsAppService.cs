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
using Sabeco_Factsheet.TbCompanyTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyTemps
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyTemps.Default)]
    public abstract class TbCompanyTempsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyTempDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyTempRepository _tbCompanyTempRepository;
        protected TbCompanyTempManager _tbCompanyTempManager;

        public TbCompanyTempsAppServiceBase(ITbCompanyTempRepository tbCompanyTempRepository, TbCompanyTempManager tbCompanyTempManager, IDistributedCache<TbCompanyTempDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyTempRepository = tbCompanyTempRepository;
            _tbCompanyTempManager = tbCompanyTempManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyTempDto>> GetListAsync(GetTbCompanyTempsInput input)
        {
            var totalCount = await _tbCompanyTempRepository.GetCountAsync(input.FilterText, input.idCompanyMin, input.idCompanyMax, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BravoCode, input.LegacyCode);
            var items = await _tbCompanyTempRepository.GetListAsync(input.FilterText, input.idCompanyMin, input.idCompanyMax, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BravoCode, input.LegacyCode, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyTempDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyTemp>, List<TbCompanyTempDto>>(items)
            };
        }

        public virtual async Task<TbCompanyTempDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyTemp, TbCompanyTempDto>(await _tbCompanyTempRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyTemps.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyTempRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyTemps.Create)]
        public virtual async Task<TbCompanyTempDto> CreateAsync(TbCompanyTempCreateDto input)
        {

            var tbCompanyTemp = await _tbCompanyTempManager.CreateAsync(
            input.idCompany, input.ParentId, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDate, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrder, input.RegistrationDate0, input.RegistrationDate, input.LatestAmendment, input.LegalRepresent, input.CompanyType, input.CharteredCapital, input.TotalShare, input.ListedShare, input.ParValue, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitude, input.latitude, input.Note, input.DocStatus, input.DirectShareholding, input.ConsolidatedShareholding, input.ConsolidateNoted, input.VotingRightDirect, input.VotingRightTotal, input.Image, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.BravoCode, input.LegacyCode
            );

            return ObjectMapper.Map<TbCompanyTemp, TbCompanyTempDto>(tbCompanyTemp);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyTemps.Edit)]
        public virtual async Task<TbCompanyTempDto> UpdateAsync(int id, TbCompanyTempUpdateDto input)
        {

            var tbCompanyTemp = await _tbCompanyTempManager.UpdateAsync(
            id,
            input.idCompany, input.ParentId, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDate, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrder, input.RegistrationDate0, input.RegistrationDate, input.LatestAmendment, input.LegalRepresent, input.CompanyType, input.CharteredCapital, input.TotalShare, input.ListedShare, input.ParValue, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitude, input.latitude, input.Note, input.DocStatus, input.DirectShareholding, input.ConsolidatedShareholding, input.ConsolidateNoted, input.VotingRightDirect, input.VotingRightTotal, input.Image, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.BravoCode, input.LegacyCode
            );

            return ObjectMapper.Map<TbCompanyTemp, TbCompanyTempDto>(tbCompanyTemp);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyTempExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyTempRepository.GetListAsync(input.FilterText, input.idCompanyMin, input.idCompanyMax, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BravoCode, input.LegacyCode);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyTemp>, List<TbCompanyTempExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyTemps.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanytempIds)
        {
            await _tbCompanyTempRepository.DeleteManyAsync(tbcompanytempIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyTemps.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyTempsInput input)
        {
            await _tbCompanyTempRepository.DeleteAllAsync(input.FilterText, input.idCompanyMin, input.idCompanyMax, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BravoCode, input.LegacyCode);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyTempDownloadTokenCacheItem { Token = token },
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
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
using Sabeco_Factsheet.TbCompanies;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanies
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanies.Default)]
    public abstract class TbCompaniesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyRepository _tbCompanyRepository;
        protected TbCompanyManager _tbCompanyManager;

        public TbCompaniesAppServiceBase(ITbCompanyRepository tbCompanyRepository, TbCompanyManager tbCompanyManager, IDistributedCache<TbCompanyDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyRepository = tbCompanyRepository;
            _tbCompanyManager = tbCompanyManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyDto>> GetListAsync(GetTbCompaniesInput input)
        {
            var totalCount = await _tbCompanyRepository.GetCountAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BravoCode, input.LegacyCode, input.idCompanyTypeMin, input.idCompanyTypeMax, input.IsDeleted);
            var items = await _tbCompanyRepository.GetListAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BravoCode, input.LegacyCode, input.idCompanyTypeMin, input.idCompanyTypeMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompany>, List<TbCompanyDto>>(items)
            };
        }

        public virtual async Task<TbCompanyDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompany, TbCompanyDto>(await _tbCompanyRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanies.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanies.Create)]
        public virtual async Task<TbCompanyDto> CreateAsync(TbCompanyCreateDto input)
        {

            var tbCompany = await _tbCompanyManager.CreateAsync(
            input.ParentId, input.IsGroup, input.Code, input.Name, input.IsDeleted, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDate, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrder, input.RegistrationDate0, input.RegistrationDate, input.LatestAmendment, input.LegalRepresent, input.CompanyType, input.CharteredCapital, input.TotalShare, input.ListedShare, input.ParValue, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitude, input.latitude, input.Note, input.DocStatus, input.DirectShareholding, input.ConsolidatedShareholding, input.ConsolidateNoted, input.VotingRightDirect, input.VotingRightTotal, input.Image, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.BravoCode, input.LegacyCode, input.idCompanyType
            );

            return ObjectMapper.Map<TbCompany, TbCompanyDto>(tbCompany);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanies.Edit)]
        public virtual async Task<TbCompanyDto> UpdateAsync(int id, TbCompanyUpdateDto input)
        {

            var tbCompany = await _tbCompanyManager.UpdateAsync(
            id,
            input.ParentId, input.IsGroup, input.Code, input.Name, input.IsDeleted, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDate, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrder, input.RegistrationDate0, input.RegistrationDate, input.LatestAmendment, input.LegalRepresent, input.CompanyType, input.CharteredCapital, input.TotalShare, input.ListedShare, input.ParValue, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitude, input.latitude, input.Note, input.DocStatus, input.DirectShareholding, input.ConsolidatedShareholding, input.ConsolidateNoted, input.VotingRightDirect, input.VotingRightTotal, input.Image, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user, input.BravoCode, input.LegacyCode, input.idCompanyType
            );

            return ObjectMapper.Map<TbCompany, TbCompanyDto>(tbCompany);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyRepository.GetListAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BravoCode, input.LegacyCode, input.idCompanyTypeMin, input.idCompanyTypeMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompany>, List<TbCompanyExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanies.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanyIds)
        {
            await _tbCompanyRepository.DeleteManyAsync(tbcompanyIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanies.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompaniesInput input)
        {
            await _tbCompanyRepository.DeleteAllAsync(input.FilterText, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BravoCode, input.LegacyCode, input.idCompanyTypeMin, input.idCompanyTypeMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyDownloadTokenCacheItem { Token = token },
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
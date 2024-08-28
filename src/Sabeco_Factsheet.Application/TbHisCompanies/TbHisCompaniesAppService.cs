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
using Sabeco_Factsheet.TbHisCompanies;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisCompanies
{

    [Authorize(Sabeco_FactsheetPermissions.TbHisCompanies.Default)]
    public abstract class TbHisCompaniesAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbHisCompanyDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbHisCompanyRepository _tbHisCompanyRepository;
        protected TbHisCompanyManager _tbHisCompanyManager;

        public TbHisCompaniesAppServiceBase(ITbHisCompanyRepository tbHisCompanyRepository, TbHisCompanyManager tbHisCompanyManager, IDistributedCache<TbHisCompanyDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbHisCompanyRepository = tbHisCompanyRepository;
            _tbHisCompanyManager = tbHisCompanyManager;

        }

        public virtual async Task<PagedResultDto<TbHisCompanyDto>> GetListAsync(GetTbHisCompaniesInput input)
        {
            var totalCount = await _tbHisCompanyRepository.GetCountAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdCompanyMin, input.IdCompanyMax, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
            var items = await _tbHisCompanyRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdCompanyMin, input.IdCompanyMax, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbHisCompanyDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbHisCompany>, List<TbHisCompanyDto>>(items)
            };
        }

        public virtual async Task<TbHisCompanyDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbHisCompany, TbHisCompanyDto>(await _tbHisCompanyRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisCompanies.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbHisCompanyRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisCompanies.Create)]
        public virtual async Task<TbHisCompanyDto> CreateAsync(TbHisCompanyCreateDto input)
        {

            var tbHisCompany = await _tbHisCompanyManager.CreateAsync(
            input.Type, input.IdCompany, input.ParentId, input.IsGroup, input.Code, input.Name, input.IsSendMail, input.DateSendMail, input.InsertDate, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDate, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrder, input.RegistrationDate0, input.RegistrationDate, input.LatestAmendment, input.LegalRepresent, input.CompanyType, input.CharteredCapital, input.TotalShare, input.ListedShare, input.ParValue, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitude, input.latitude, input.Note, input.DocStatus, input.DirectShareholding, input.ConsolidatedShareholding, input.ConsolidateNoted, input.VotingRightDirect, input.VotingRightTotal, input.Image, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbHisCompany, TbHisCompanyDto>(tbHisCompany);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisCompanies.Edit)]
        public virtual async Task<TbHisCompanyDto> UpdateAsync(int id, TbHisCompanyUpdateDto input)
        {

            var tbHisCompany = await _tbHisCompanyManager.UpdateAsync(
            id,
            input.Type, input.IdCompany, input.ParentId, input.IsGroup, input.Code, input.Name, input.IsSendMail, input.DateSendMail, input.InsertDate, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDate, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrder, input.RegistrationDate0, input.RegistrationDate, input.LatestAmendment, input.LegalRepresent, input.CompanyType, input.CharteredCapital, input.TotalShare, input.ListedShare, input.ParValue, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitude, input.latitude, input.Note, input.DocStatus, input.DirectShareholding, input.ConsolidatedShareholding, input.ConsolidateNoted, input.VotingRightDirect, input.VotingRightTotal, input.Image, input.IsActive, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbHisCompany, TbHisCompanyDto>(tbHisCompany);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisCompanyExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbHisCompanyRepository.GetListAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdCompanyMin, input.IdCompanyMax, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbHisCompany>, List<TbHisCompanyExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisCompanies.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbhiscompanyIds)
        {
            await _tbHisCompanyRepository.DeleteManyAsync(tbhiscompanyIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbHisCompanies.Delete)]
        public virtual async Task DeleteAllAsync(GetTbHisCompaniesInput input)
        {
            await _tbHisCompanyRepository.DeleteAllAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdCompanyMin, input.IdCompanyMax, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbHisCompanyDownloadTokenCacheItem { Token = token },
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
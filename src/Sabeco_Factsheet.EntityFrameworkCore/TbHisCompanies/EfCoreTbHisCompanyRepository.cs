using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Sabeco_Factsheet.EntityFrameworkCore;

namespace Sabeco_Factsheet.TbHisCompanies
{
    public abstract class EfCoreTbHisCompanyRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbHisCompany, int>
    {
        public EfCoreTbHisCompanyRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idCompanyMin = null,
            int? idCompanyMax = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            bool? isGroup = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            string? briefName = null,
            string? contactInfo_01 = null,
            string? contactInfo_02 = null,
            string? contactInfo_03 = null,
            string? contactInfo_04 = null,
            string? contactInfo_05 = null,
            string? contactInfo_06 = null,
            string? stockCode = null,
            string? stockExchange = null,
            DateTime? stockRegistrationDateMin = null,
            DateTime? stockRegistrationDateMax = null,
            bool? isPublicCompany = null,
            string? licenseNo = null,
            string? license = null,
            byte? registrationOrderMin = null,
            byte? registrationOrderMax = null,
            DateTime? registrationDate0Min = null,
            DateTime? registrationDate0Max = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            DateTime? latestAmendmentMin = null,
            DateTime? latestAmendmentMax = null,
            string? legalRepresent = null,
            string? companyType = null,
            decimal? charteredCapitalMin = null,
            decimal? charteredCapitalMax = null,
            decimal? totalShareMin = null,
            decimal? totalShareMax = null,
            decimal? listedShareMin = null,
            decimal? listedShareMax = null,
            int? parValueMin = null,
            int? parValueMax = null,
            string? contactName1 = null,
            string? contactDept1 = null,
            string? contactMail1 = null,
            string? contactPosition1 = null,
            string? contactPhone1 = null,
            string? contactName2 = null,
            string? contactDept2 = null,
            string? contactMail2 = null,
            string? contactPosition2 = null,
            string? contactPhone2 = null,
            double? longtitudeMin = null,
            double? longtitudeMax = null,
            double? latitudeMin = null,
            double? latitudeMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            decimal? directShareholdingMin = null,
            decimal? directShareholdingMax = null,
            decimal? consolidatedShareholdingMin = null,
            decimal? consolidatedShareholdingMax = null,
            string? consolidateNoted = null,
            decimal? votingRightDirectMin = null,
            decimal? votingRightDirectMax = null,
            decimal? votingRightTotalMin = null,
            decimal? votingRightTotalMax = null,
            string? image = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idCompanyMin, idCompanyMax, parentIdMin, parentIdMax, isGroup, code, name, name_EN, briefName, contactInfo_01, contactInfo_02, contactInfo_03, contactInfo_04, contactInfo_05, contactInfo_06, stockCode, stockExchange, stockRegistrationDateMin, stockRegistrationDateMax, isPublicCompany, licenseNo, license, registrationOrderMin, registrationOrderMax, registrationDate0Min, registrationDate0Max, registrationDateMin, registrationDateMax, latestAmendmentMin, latestAmendmentMax, legalRepresent, companyType, charteredCapitalMin, charteredCapitalMax, totalShareMin, totalShareMax, listedShareMin, listedShareMax, parValueMin, parValueMax, contactName1, contactDept1, contactMail1, contactPosition1, contactPhone1, contactName2, contactDept2, contactMail2, contactPosition2, contactPhone2, longtitudeMin, longtitudeMax, latitudeMin, latitudeMax, note, docStatusMin, docStatusMax, directShareholdingMin, directShareholdingMax, consolidatedShareholdingMin, consolidatedShareholdingMax, consolidateNoted, votingRightDirectMin, votingRightDirectMax, votingRightTotalMin, votingRightTotalMax, image, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbHisCompany>> GetListAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idCompanyMin = null,
            int? idCompanyMax = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            bool? isGroup = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            string? briefName = null,
            string? contactInfo_01 = null,
            string? contactInfo_02 = null,
            string? contactInfo_03 = null,
            string? contactInfo_04 = null,
            string? contactInfo_05 = null,
            string? contactInfo_06 = null,
            string? stockCode = null,
            string? stockExchange = null,
            DateTime? stockRegistrationDateMin = null,
            DateTime? stockRegistrationDateMax = null,
            bool? isPublicCompany = null,
            string? licenseNo = null,
            string? license = null,
            byte? registrationOrderMin = null,
            byte? registrationOrderMax = null,
            DateTime? registrationDate0Min = null,
            DateTime? registrationDate0Max = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            DateTime? latestAmendmentMin = null,
            DateTime? latestAmendmentMax = null,
            string? legalRepresent = null,
            string? companyType = null,
            decimal? charteredCapitalMin = null,
            decimal? charteredCapitalMax = null,
            decimal? totalShareMin = null,
            decimal? totalShareMax = null,
            decimal? listedShareMin = null,
            decimal? listedShareMax = null,
            int? parValueMin = null,
            int? parValueMax = null,
            string? contactName1 = null,
            string? contactDept1 = null,
            string? contactMail1 = null,
            string? contactPosition1 = null,
            string? contactPhone1 = null,
            string? contactName2 = null,
            string? contactDept2 = null,
            string? contactMail2 = null,
            string? contactPosition2 = null,
            string? contactPhone2 = null,
            double? longtitudeMin = null,
            double? longtitudeMax = null,
            double? latitudeMin = null,
            double? latitudeMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            decimal? directShareholdingMin = null,
            decimal? directShareholdingMax = null,
            decimal? consolidatedShareholdingMin = null,
            decimal? consolidatedShareholdingMax = null,
            string? consolidateNoted = null,
            decimal? votingRightDirectMin = null,
            decimal? votingRightDirectMax = null,
            decimal? votingRightTotalMin = null,
            decimal? votingRightTotalMax = null,
            string? image = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idCompanyMin, idCompanyMax, parentIdMin, parentIdMax, isGroup, code, name, name_EN, briefName, contactInfo_01, contactInfo_02, contactInfo_03, contactInfo_04, contactInfo_05, contactInfo_06, stockCode, stockExchange, stockRegistrationDateMin, stockRegistrationDateMax, isPublicCompany, licenseNo, license, registrationOrderMin, registrationOrderMax, registrationDate0Min, registrationDate0Max, registrationDateMin, registrationDateMax, latestAmendmentMin, latestAmendmentMax, legalRepresent, companyType, charteredCapitalMin, charteredCapitalMax, totalShareMin, totalShareMax, listedShareMin, listedShareMax, parValueMin, parValueMax, contactName1, contactDept1, contactMail1, contactPosition1, contactPhone1, contactName2, contactDept2, contactMail2, contactPosition2, contactPhone2, longtitudeMin, longtitudeMax, latitudeMin, latitudeMax, note, docStatusMin, docStatusMax, directShareholdingMin, directShareholdingMax, consolidatedShareholdingMin, consolidatedShareholdingMax, consolidateNoted, votingRightDirectMin, votingRightDirectMax, votingRightTotalMin, votingRightTotalMax, image, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbHisCompanyConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idCompanyMin = null,
            int? idCompanyMax = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            bool? isGroup = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            string? briefName = null,
            string? contactInfo_01 = null,
            string? contactInfo_02 = null,
            string? contactInfo_03 = null,
            string? contactInfo_04 = null,
            string? contactInfo_05 = null,
            string? contactInfo_06 = null,
            string? stockCode = null,
            string? stockExchange = null,
            DateTime? stockRegistrationDateMin = null,
            DateTime? stockRegistrationDateMax = null,
            bool? isPublicCompany = null,
            string? licenseNo = null,
            string? license = null,
            byte? registrationOrderMin = null,
            byte? registrationOrderMax = null,
            DateTime? registrationDate0Min = null,
            DateTime? registrationDate0Max = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            DateTime? latestAmendmentMin = null,
            DateTime? latestAmendmentMax = null,
            string? legalRepresent = null,
            string? companyType = null,
            decimal? charteredCapitalMin = null,
            decimal? charteredCapitalMax = null,
            decimal? totalShareMin = null,
            decimal? totalShareMax = null,
            decimal? listedShareMin = null,
            decimal? listedShareMax = null,
            int? parValueMin = null,
            int? parValueMax = null,
            string? contactName1 = null,
            string? contactDept1 = null,
            string? contactMail1 = null,
            string? contactPosition1 = null,
            string? contactPhone1 = null,
            string? contactName2 = null,
            string? contactDept2 = null,
            string? contactMail2 = null,
            string? contactPosition2 = null,
            string? contactPhone2 = null,
            double? longtitudeMin = null,
            double? longtitudeMax = null,
            double? latitudeMin = null,
            double? latitudeMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            decimal? directShareholdingMin = null,
            decimal? directShareholdingMax = null,
            decimal? consolidatedShareholdingMin = null,
            decimal? consolidatedShareholdingMax = null,
            string? consolidateNoted = null,
            decimal? votingRightDirectMin = null,
            decimal? votingRightDirectMax = null,
            decimal? votingRightTotalMin = null,
            decimal? votingRightTotalMax = null,
            string? image = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idCompanyMin, idCompanyMax, parentIdMin, parentIdMax, isGroup, code, name, name_EN, briefName, contactInfo_01, contactInfo_02, contactInfo_03, contactInfo_04, contactInfo_05, contactInfo_06, stockCode, stockExchange, stockRegistrationDateMin, stockRegistrationDateMax, isPublicCompany, licenseNo, license, registrationOrderMin, registrationOrderMax, registrationDate0Min, registrationDate0Max, registrationDateMin, registrationDateMax, latestAmendmentMin, latestAmendmentMax, legalRepresent, companyType, charteredCapitalMin, charteredCapitalMax, totalShareMin, totalShareMax, listedShareMin, listedShareMax, parValueMin, parValueMax, contactName1, contactDept1, contactMail1, contactPosition1, contactPhone1, contactName2, contactDept2, contactMail2, contactPosition2, contactPhone2, longtitudeMin, longtitudeMax, latitudeMin, latitudeMax, note, docStatusMin, docStatusMax, directShareholdingMin, directShareholdingMax, consolidatedShareholdingMin, consolidatedShareholdingMax, consolidateNoted, votingRightDirectMin, votingRightDirectMax, votingRightTotalMin, votingRightTotalMax, image, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbHisCompany> ApplyFilter(
            IQueryable<TbHisCompany> query,
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idCompanyMin = null,
            int? idCompanyMax = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            bool? isGroup = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            string? briefName = null,
            string? contactInfo_01 = null,
            string? contactInfo_02 = null,
            string? contactInfo_03 = null,
            string? contactInfo_04 = null,
            string? contactInfo_05 = null,
            string? contactInfo_06 = null,
            string? stockCode = null,
            string? stockExchange = null,
            DateTime? stockRegistrationDateMin = null,
            DateTime? stockRegistrationDateMax = null,
            bool? isPublicCompany = null,
            string? licenseNo = null,
            string? license = null,
            byte? registrationOrderMin = null,
            byte? registrationOrderMax = null,
            DateTime? registrationDate0Min = null,
            DateTime? registrationDate0Max = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            DateTime? latestAmendmentMin = null,
            DateTime? latestAmendmentMax = null,
            string? legalRepresent = null,
            string? companyType = null,
            decimal? charteredCapitalMin = null,
            decimal? charteredCapitalMax = null,
            decimal? totalShareMin = null,
            decimal? totalShareMax = null,
            decimal? listedShareMin = null,
            decimal? listedShareMax = null,
            int? parValueMin = null,
            int? parValueMax = null,
            string? contactName1 = null,
            string? contactDept1 = null,
            string? contactMail1 = null,
            string? contactPosition1 = null,
            string? contactPhone1 = null,
            string? contactName2 = null,
            string? contactDept2 = null,
            string? contactMail2 = null,
            string? contactPosition2 = null,
            string? contactPhone2 = null,
            double? longtitudeMin = null,
            double? longtitudeMax = null,
            double? latitudeMin = null,
            double? latitudeMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            decimal? directShareholdingMin = null,
            decimal? directShareholdingMax = null,
            decimal? consolidatedShareholdingMin = null,
            decimal? consolidatedShareholdingMax = null,
            string? consolidateNoted = null,
            decimal? votingRightDirectMin = null,
            decimal? votingRightDirectMax = null,
            decimal? votingRightTotalMin = null,
            decimal? votingRightTotalMax = null,
            string? image = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.ToLower().Contains(filterText.ToLower()) || e.Name.ToLower().Contains(filterText.ToLower()) || e.Name_EN.ToLower().Contains(filterText.ToLower()) || e.BriefName.ToLower().Contains(filterText.ToLower()) || e.ContactInfo_01.ToLower().Contains(filterText.ToLower()) || e.ContactInfo_02.ToLower().Contains(filterText.ToLower()) || e.ContactInfo_03.ToLower().Contains(filterText.ToLower()) || e.ContactInfo_04.ToLower().Contains(filterText.ToLower()) || e.ContactInfo_05.ToLower().Contains(filterText.ToLower()) || e.ContactInfo_06.ToLower().Contains(filterText.ToLower()) || e.StockCode.ToLower().Contains(filterText.ToLower()) || e.StockExchange.ToLower().Contains(filterText.ToLower()) || e.LicenseNo.ToLower().Contains(filterText.ToLower()) || e.License.ToLower().Contains(filterText.ToLower()) || e.LegalRepresent.ToLower().Contains(filterText.ToLower()) || e.CompanyType.ToLower().Contains(filterText.ToLower()) || e.ContactName1.ToLower().Contains(filterText.ToLower()) || e.ContactDept1.ToLower().Contains(filterText.ToLower()) || e.ContactMail1.ToLower().Contains(filterText.ToLower()) || e.ContactPosition1.ToLower().Contains(filterText.ToLower()) || e.ContactPhone1.ToLower().Contains(filterText.ToLower()) || e.ContactName2.ToLower().Contains(filterText.ToLower()) || e.ContactDept2.ToLower().Contains(filterText.ToLower()) || e.ContactMail2.ToLower().Contains(filterText.ToLower()) || e.ContactPosition2.ToLower().Contains(filterText.ToLower()) || e.ContactPhone2.ToLower().Contains(filterText.ToLower()) || e.Note.ToLower().Contains(filterText.ToLower()) || e.ConsolidateNoted.ToLower().Contains(filterText.ToLower()) || e.Image.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(isSendMail.HasValue, e => e.IsSendMail == isSendMail)
                    .WhereIf(dateSendMailMin.HasValue, e => e.DateSendMail >= dateSendMailMin!.Value)
                    .WhereIf(dateSendMailMax.HasValue, e => e.DateSendMail <= dateSendMailMax!.Value)
                    .WhereIf(insertDateMin.HasValue, e => e.InsertDate >= insertDateMin!.Value)
                    .WhereIf(insertDateMax.HasValue, e => e.InsertDate <= insertDateMax!.Value)
                    .WhereIf(typeMin.HasValue, e => e.Type >= typeMin!.Value)
                    .WhereIf(typeMax.HasValue, e => e.Type <= typeMax!.Value)
                    .WhereIf(idCompanyMin.HasValue, e => e.IdCompany >= idCompanyMin!.Value)
                    .WhereIf(idCompanyMax.HasValue, e => e.IdCompany <= idCompanyMax!.Value)
                    .WhereIf(parentIdMin.HasValue, e => e.ParentId >= parentIdMin!.Value)
                    .WhereIf(parentIdMax.HasValue, e => e.ParentId <= parentIdMax!.Value)
                    .WhereIf(isGroup.HasValue, e => e.IsGroup == isGroup)
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.ToLower().Contains(code.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.ToLower().Contains(name.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(name_EN), e => e.Name_EN.ToLower().Contains(name_EN.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(briefName), e => e.BriefName.ToLower().Contains(briefName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactInfo_01), e => e.ContactInfo_01.ToLower().Contains(contactInfo_01.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactInfo_02), e => e.ContactInfo_02.ToLower().Contains(contactInfo_02.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactInfo_03), e => e.ContactInfo_03.ToLower().Contains(contactInfo_03.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactInfo_04), e => e.ContactInfo_04.ToLower().Contains(contactInfo_04.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactInfo_05), e => e.ContactInfo_05.ToLower().Contains(contactInfo_05.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactInfo_06), e => e.ContactInfo_06.ToLower().Contains(contactInfo_06.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(stockCode), e => e.StockCode.ToLower().Contains(stockCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(stockExchange), e => e.StockExchange.ToLower().Contains(stockExchange.ToLower()))
                    .WhereIf(stockRegistrationDateMin.HasValue, e => e.StockRegistrationDate >= stockRegistrationDateMin!.Value)
                    .WhereIf(stockRegistrationDateMax.HasValue, e => e.StockRegistrationDate <= stockRegistrationDateMax!.Value)
                    .WhereIf(isPublicCompany.HasValue, e => e.IsPublicCompany == isPublicCompany)
                    .WhereIf(!string.IsNullOrWhiteSpace(licenseNo), e => e.LicenseNo.ToLower().Contains(licenseNo.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(license), e => e.License.ToLower().Contains(license.ToLower()))

                    .WhereIf(registrationDate0Min.HasValue, e => e.RegistrationDate0 >= registrationDate0Min!.Value)
                    .WhereIf(registrationDate0Max.HasValue, e => e.RegistrationDate0 <= registrationDate0Max!.Value)
                    .WhereIf(registrationDateMin.HasValue, e => e.RegistrationDate >= registrationDateMin!.Value)
                    .WhereIf(registrationDateMax.HasValue, e => e.RegistrationDate <= registrationDateMax!.Value)
                    .WhereIf(latestAmendmentMin.HasValue, e => e.LatestAmendment >= latestAmendmentMin!.Value)
                    .WhereIf(latestAmendmentMax.HasValue, e => e.LatestAmendment <= latestAmendmentMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(legalRepresent), e => e.LegalRepresent.ToLower().Contains(legalRepresent.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyType), e => e.CompanyType.ToLower().Contains(companyType.ToLower()))
                    .WhereIf(charteredCapitalMin.HasValue, e => e.CharteredCapital >= charteredCapitalMin!.Value)
                    .WhereIf(charteredCapitalMax.HasValue, e => e.CharteredCapital <= charteredCapitalMax!.Value)
                    .WhereIf(totalShareMin.HasValue, e => e.TotalShare >= totalShareMin!.Value)
                    .WhereIf(totalShareMax.HasValue, e => e.TotalShare <= totalShareMax!.Value)
                    .WhereIf(listedShareMin.HasValue, e => e.ListedShare >= listedShareMin!.Value)
                    .WhereIf(listedShareMax.HasValue, e => e.ListedShare <= listedShareMax!.Value)
                    .WhereIf(parValueMin.HasValue, e => e.ParValue >= parValueMin!.Value)
                    .WhereIf(parValueMax.HasValue, e => e.ParValue <= parValueMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(contactName1), e => e.ContactName1.ToLower().Contains(contactName1.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactDept1), e => e.ContactDept1.ToLower().Contains(contactDept1.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactMail1), e => e.ContactMail1.ToLower().Contains(contactMail1.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactPosition1), e => e.ContactPosition1.ToLower().Contains(contactPosition1.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactPhone1), e => e.ContactPhone1.ToLower().Contains(contactPhone1.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactName2), e => e.ContactName2.ToLower().Contains(contactName2.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactDept2), e => e.ContactDept2.ToLower().Contains(contactDept2.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactMail2), e => e.ContactMail2.ToLower().Contains(contactMail2.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactPosition2), e => e.ContactPosition2.ToLower().Contains(contactPosition2.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactPhone2), e => e.ContactPhone2.ToLower().Contains(contactPhone2.ToLower()))
                    .WhereIf(longtitudeMin.HasValue, e => e.longtitude >= longtitudeMin!.Value)
                    .WhereIf(longtitudeMax.HasValue, e => e.longtitude <= longtitudeMax!.Value)
                    .WhereIf(latitudeMin.HasValue, e => e.latitude >= latitudeMin!.Value)
                    .WhereIf(latitudeMax.HasValue, e => e.latitude <= latitudeMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.ToLower().Contains(note.ToLower()))

                    .WhereIf(directShareholdingMin.HasValue, e => e.DirectShareholding >= directShareholdingMin!.Value)
                    .WhereIf(directShareholdingMax.HasValue, e => e.DirectShareholding <= directShareholdingMax!.Value)
                    .WhereIf(consolidatedShareholdingMin.HasValue, e => e.ConsolidatedShareholding >= consolidatedShareholdingMin!.Value)
                    .WhereIf(consolidatedShareholdingMax.HasValue, e => e.ConsolidatedShareholding <= consolidatedShareholdingMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(consolidateNoted), e => e.ConsolidateNoted.ToLower().Contains(consolidateNoted.ToLower()))
                    .WhereIf(votingRightDirectMin.HasValue, e => e.VotingRightDirect >= votingRightDirectMin!.Value)
                    .WhereIf(votingRightDirectMax.HasValue, e => e.VotingRightDirect <= votingRightDirectMax!.Value)
                    .WhereIf(votingRightTotalMin.HasValue, e => e.VotingRightTotal >= votingRightTotalMin!.Value)
                    .WhereIf(votingRightTotalMax.HasValue, e => e.VotingRightTotal <= votingRightTotalMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(image), e => e.Image.ToLower().Contains(image.ToLower()))
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value);
        }
    }
}
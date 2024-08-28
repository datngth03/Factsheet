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

namespace Sabeco_Factsheet.TbHisPersons
{
    public abstract class EfCoreTbHisPersonRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbHisPerson, int>
    {
        public EfCoreTbHisPersonRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
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
            int? idPersonMin = null,
            int? idPersonMax = null,
            string? code = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? fullName = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string? birthPlace = null,
            string? address = null,
            string? iDCardNo = null,
            DateTime? iDCardDateMin = null,
            DateTime? iDCardDateMax = null,
            string? idCardIssuePlace = null,
            string? ethnicity = null,
            string? religion = null,
            string? nationalityCode = null,
            string? gender = null,
            string? phone = null,
            string? email = null,
            string? note = null,
            string? image = null,
            bool? isActive = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isCheckRetirement = null,
            bool? isCheckTermEnd = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            string? oldCode = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idPersonMin, idPersonMax, code, companyIdMin, companyIdMax, fullName, birthDateMin, birthDateMax, birthPlace, address, iDCardNo, iDCardDateMin, iDCardDateMax, idCardIssuePlace, ethnicity, religion, nationalityCode, gender, phone, email, note, image, isActive, docStatusMin, docStatusMax, isCheckRetirement, isCheckTermEnd, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, oldCode);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbHisPerson>> GetListAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idPersonMin = null,
            int? idPersonMax = null,
            string? code = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? fullName = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string? birthPlace = null,
            string? address = null,
            string? iDCardNo = null,
            DateTime? iDCardDateMin = null,
            DateTime? iDCardDateMax = null,
            string? idCardIssuePlace = null,
            string? ethnicity = null,
            string? religion = null,
            string? nationalityCode = null,
            string? gender = null,
            string? phone = null,
            string? email = null,
            string? note = null,
            string? image = null,
            bool? isActive = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isCheckRetirement = null,
            bool? isCheckTermEnd = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            string? oldCode = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idPersonMin, idPersonMax, code, companyIdMin, companyIdMax, fullName, birthDateMin, birthDateMax, birthPlace, address, iDCardNo, iDCardDateMin, iDCardDateMax, idCardIssuePlace, ethnicity, religion, nationalityCode, gender, phone, email, note, image, isActive, docStatusMin, docStatusMax, isCheckRetirement, isCheckTermEnd, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, oldCode);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbHisPersonConsts.GetDefaultSorting(false) : sorting);
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
            int? idPersonMin = null,
            int? idPersonMax = null,
            string? code = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? fullName = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string? birthPlace = null,
            string? address = null,
            string? iDCardNo = null,
            DateTime? iDCardDateMin = null,
            DateTime? iDCardDateMax = null,
            string? idCardIssuePlace = null,
            string? ethnicity = null,
            string? religion = null,
            string? nationalityCode = null,
            string? gender = null,
            string? phone = null,
            string? email = null,
            string? note = null,
            string? image = null,
            bool? isActive = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isCheckRetirement = null,
            bool? isCheckTermEnd = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            string? oldCode = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idPersonMin, idPersonMax, code, companyIdMin, companyIdMax, fullName, birthDateMin, birthDateMax, birthPlace, address, iDCardNo, iDCardDateMin, iDCardDateMax, idCardIssuePlace, ethnicity, religion, nationalityCode, gender, phone, email, note, image, isActive, docStatusMin, docStatusMax, isCheckRetirement, isCheckTermEnd, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, oldCode);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbHisPerson> ApplyFilter(
            IQueryable<TbHisPerson> query,
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idPersonMin = null,
            int? idPersonMax = null,
            string? code = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? fullName = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string? birthPlace = null,
            string? address = null,
            string? iDCardNo = null,
            DateTime? iDCardDateMin = null,
            DateTime? iDCardDateMax = null,
            string? idCardIssuePlace = null,
            string? ethnicity = null,
            string? religion = null,
            string? nationalityCode = null,
            string? gender = null,
            string? phone = null,
            string? email = null,
            string? note = null,
            string? image = null,
            bool? isActive = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isCheckRetirement = null,
            bool? isCheckTermEnd = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            string? oldCode = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.ToLower().Contains(filterText.ToLower()) || e.FullName.ToLower().Contains(filterText.ToLower()) || e.BirthPlace.ToLower().Contains(filterText.ToLower()) || e.Address.ToLower().Contains(filterText.ToLower()) || e.IDCardNo.ToLower().Contains(filterText.ToLower()) || e.IdCardIssuePlace.ToLower().Contains(filterText.ToLower()) || e.Ethnicity.ToLower().Contains(filterText.ToLower()) || e.Religion.ToLower().Contains(filterText.ToLower()) || e.NationalityCode.ToLower().Contains(filterText.ToLower()) || e.Gender.ToLower().Contains(filterText.ToLower()) || e.Phone.ToLower().Contains(filterText.ToLower()) || e.Email.ToLower().Contains(filterText.ToLower()) || e.Note.ToLower().Contains(filterText.ToLower()) || e.Image.ToLower().Contains(filterText.ToLower()) || e.OldCode.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(isSendMail.HasValue, e => e.IsSendMail == isSendMail)
                    .WhereIf(dateSendMailMin.HasValue, e => e.DateSendMail >= dateSendMailMin!.Value)
                    .WhereIf(dateSendMailMax.HasValue, e => e.DateSendMail <= dateSendMailMax!.Value)
                    .WhereIf(insertDateMin.HasValue, e => e.InsertDate >= insertDateMin!.Value)
                    .WhereIf(insertDateMax.HasValue, e => e.InsertDate <= insertDateMax!.Value)
                    .WhereIf(typeMin.HasValue, e => e.Type >= typeMin!.Value)
                    .WhereIf(typeMax.HasValue, e => e.Type <= typeMax!.Value)
                    .WhereIf(idPersonMin.HasValue, e => e.IdPerson >= idPersonMin!.Value)
                    .WhereIf(idPersonMax.HasValue, e => e.IdPerson <= idPersonMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.ToLower().Contains(code.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(fullName), e => e.FullName.ToLower().Contains(fullName.ToLower()))
                    .WhereIf(birthDateMin.HasValue, e => e.BirthDate >= birthDateMin!.Value)
                    .WhereIf(birthDateMax.HasValue, e => e.BirthDate <= birthDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(birthPlace), e => e.BirthPlace.ToLower().Contains(birthPlace.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.ToLower().Contains(address.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(iDCardNo), e => e.IDCardNo.ToLower().Contains(iDCardNo.ToLower()))
                    .WhereIf(iDCardDateMin.HasValue, e => e.IDCardDate >= iDCardDateMin!.Value)
                    .WhereIf(iDCardDateMax.HasValue, e => e.IDCardDate <= iDCardDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(idCardIssuePlace), e => e.IdCardIssuePlace.ToLower().Contains(idCardIssuePlace.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(ethnicity), e => e.Ethnicity.ToLower().Contains(ethnicity.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(religion), e => e.Religion.ToLower().Contains(religion.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(nationalityCode), e => e.NationalityCode.ToLower().Contains(nationalityCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(gender), e => e.Gender.ToLower().Contains(gender.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(phone), e => e.Phone.ToLower().Contains(phone.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.ToLower().Contains(email.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.ToLower().Contains(note.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(image), e => e.Image.ToLower().Contains(image.ToLower()))
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)

                    .WhereIf(isCheckRetirement.HasValue, e => e.IsCheckRetirement == isCheckRetirement)
                    .WhereIf(isCheckTermEnd.HasValue, e => e.IsCheckTermEnd == isCheckTermEnd)
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(oldCode), e => e.OldCode.ToLower().Contains(oldCode.ToLower()));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyBusinessTemps
{
    public abstract class TbCompanyBusinessTempManagerBase : DomainService
    {
        public ITbCompanyBusinessTempRepository _tbCompanyBusinessTempRepository;

        public TbCompanyBusinessTempManagerBase(ITbCompanyBusinessTempRepository tbCompanyBusinessTempRepository)
        {
            _tbCompanyBusinessTempRepository = tbCompanyBusinessTempRepository;
        }

        public virtual async Task<TbCompanyBusinessTemp> CreateAsync(
        int companyId, byte registrationNo, DateTime registrationDate, string? license = null, string? companyName = null, string? companyAddress = null, string? legalRepresent = null, string? companyType = null, string? majorBusiness = null, string? otherActivity = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, DateTime? latestAmendment = null)
        {
            Check.NotNull(registrationDate, nameof(registrationDate));
            Check.Length(license, nameof(license), TbCompanyBusinessTempConsts.LicenseMaxLength);
            Check.Length(companyName, nameof(companyName), TbCompanyBusinessTempConsts.CompanyNameMaxLength);
            Check.Length(companyAddress, nameof(companyAddress), TbCompanyBusinessTempConsts.CompanyAddressMaxLength);
            Check.Length(legalRepresent, nameof(legalRepresent), TbCompanyBusinessTempConsts.LegalRepresentMaxLength);
            Check.Length(companyType, nameof(companyType), TbCompanyBusinessTempConsts.CompanyTypeMaxLength);
            Check.Length(majorBusiness, nameof(majorBusiness), TbCompanyBusinessTempConsts.MajorBusinessMaxLength);
            Check.Length(otherActivity, nameof(otherActivity), TbCompanyBusinessTempConsts.OtherActivityMaxLength);
            Check.Length(note, nameof(note), TbCompanyBusinessTempConsts.NoteMaxLength);

            var tbCompanyBusinessTemp = new TbCompanyBusinessTemp(

             companyId, registrationNo, registrationDate, license, companyName, companyAddress, legalRepresent, companyType, majorBusiness, otherActivity, note, isActive, crt_date, crt_user, mod_date, mod_user, latestAmendment
             );

            return await _tbCompanyBusinessTempRepository.InsertAsync(tbCompanyBusinessTemp);
        }

        public virtual async Task<TbCompanyBusinessTemp> UpdateAsync(
            int id,
            int companyId, byte registrationNo, DateTime registrationDate, string? license = null, string? companyName = null, string? companyAddress = null, string? legalRepresent = null, string? companyType = null, string? majorBusiness = null, string? otherActivity = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, DateTime? latestAmendment = null
        )
        {
            Check.NotNull(registrationDate, nameof(registrationDate));
            Check.Length(license, nameof(license), TbCompanyBusinessTempConsts.LicenseMaxLength);
            Check.Length(companyName, nameof(companyName), TbCompanyBusinessTempConsts.CompanyNameMaxLength);
            Check.Length(companyAddress, nameof(companyAddress), TbCompanyBusinessTempConsts.CompanyAddressMaxLength);
            Check.Length(legalRepresent, nameof(legalRepresent), TbCompanyBusinessTempConsts.LegalRepresentMaxLength);
            Check.Length(companyType, nameof(companyType), TbCompanyBusinessTempConsts.CompanyTypeMaxLength);
            Check.Length(majorBusiness, nameof(majorBusiness), TbCompanyBusinessTempConsts.MajorBusinessMaxLength);
            Check.Length(otherActivity, nameof(otherActivity), TbCompanyBusinessTempConsts.OtherActivityMaxLength);
            Check.Length(note, nameof(note), TbCompanyBusinessTempConsts.NoteMaxLength);

            var tbCompanyBusinessTemp = await _tbCompanyBusinessTempRepository.GetAsync(id);

            tbCompanyBusinessTemp.CompanyId = companyId;
            tbCompanyBusinessTemp.RegistrationNo = registrationNo;
            tbCompanyBusinessTemp.RegistrationDate = registrationDate;
            tbCompanyBusinessTemp.License = license;
            tbCompanyBusinessTemp.CompanyName = companyName;
            tbCompanyBusinessTemp.CompanyAddress = companyAddress;
            tbCompanyBusinessTemp.LegalRepresent = legalRepresent;
            tbCompanyBusinessTemp.CompanyType = companyType;
            tbCompanyBusinessTemp.MajorBusiness = majorBusiness;
            tbCompanyBusinessTemp.OtherActivity = otherActivity;
            tbCompanyBusinessTemp.Note = note;
            tbCompanyBusinessTemp.IsActive = isActive;
            tbCompanyBusinessTemp.crt_date = crt_date;
            tbCompanyBusinessTemp.crt_user = crt_user;
            tbCompanyBusinessTemp.mod_date = mod_date;
            tbCompanyBusinessTemp.mod_user = mod_user;
            tbCompanyBusinessTemp.LatestAmendment = latestAmendment;

            return await _tbCompanyBusinessTempRepository.UpdateAsync(tbCompanyBusinessTemp);
        }

    }
}
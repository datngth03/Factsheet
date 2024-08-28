using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyBusinesses
{
    public abstract class TbCompanyBusinessManagerBase : DomainService
    {
        public ITbCompanyBusinessRepository _tbCompanyBusinessRepository;

        public TbCompanyBusinessManagerBase(ITbCompanyBusinessRepository tbCompanyBusinessRepository)
        {
            _tbCompanyBusinessRepository = tbCompanyBusinessRepository;
        }

        public virtual async Task<TbCompanyBusiness> CreateAsync(
        int companyId, byte registrationNo, DateTime registrationDate, string? license = null, string? companyName = null, string? companyAddress = null, string? legalRepresent = null, string? companyType = null, string? majorBusiness = null, string? otherActivity = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, DateTime? latestAmendment = null)
        {
            Check.NotNull(registrationDate, nameof(registrationDate));
            Check.Length(license, nameof(license), TbCompanyBusinessConsts.LicenseMaxLength);
            Check.Length(companyName, nameof(companyName), TbCompanyBusinessConsts.CompanyNameMaxLength);
            Check.Length(companyAddress, nameof(companyAddress), TbCompanyBusinessConsts.CompanyAddressMaxLength);
            Check.Length(legalRepresent, nameof(legalRepresent), TbCompanyBusinessConsts.LegalRepresentMaxLength);
            Check.Length(companyType, nameof(companyType), TbCompanyBusinessConsts.CompanyTypeMaxLength);
            Check.Length(majorBusiness, nameof(majorBusiness), TbCompanyBusinessConsts.MajorBusinessMaxLength);
            Check.Length(otherActivity, nameof(otherActivity), TbCompanyBusinessConsts.OtherActivityMaxLength);
            Check.Length(note, nameof(note), TbCompanyBusinessConsts.NoteMaxLength);

            var tbCompanyBusiness = new TbCompanyBusiness(

             companyId, registrationNo, registrationDate, license, companyName, companyAddress, legalRepresent, companyType, majorBusiness, otherActivity, note, isActive, crt_date, crt_user, mod_date, mod_user, latestAmendment
             );

            return await _tbCompanyBusinessRepository.InsertAsync(tbCompanyBusiness);
        }

        public virtual async Task<TbCompanyBusiness> UpdateAsync(
            int id,
            int companyId, byte registrationNo, DateTime registrationDate, string? license = null, string? companyName = null, string? companyAddress = null, string? legalRepresent = null, string? companyType = null, string? majorBusiness = null, string? otherActivity = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, DateTime? latestAmendment = null
        )
        {
            Check.NotNull(registrationDate, nameof(registrationDate));
            Check.Length(license, nameof(license), TbCompanyBusinessConsts.LicenseMaxLength);
            Check.Length(companyName, nameof(companyName), TbCompanyBusinessConsts.CompanyNameMaxLength);
            Check.Length(companyAddress, nameof(companyAddress), TbCompanyBusinessConsts.CompanyAddressMaxLength);
            Check.Length(legalRepresent, nameof(legalRepresent), TbCompanyBusinessConsts.LegalRepresentMaxLength);
            Check.Length(companyType, nameof(companyType), TbCompanyBusinessConsts.CompanyTypeMaxLength);
            Check.Length(majorBusiness, nameof(majorBusiness), TbCompanyBusinessConsts.MajorBusinessMaxLength);
            Check.Length(otherActivity, nameof(otherActivity), TbCompanyBusinessConsts.OtherActivityMaxLength);
            Check.Length(note, nameof(note), TbCompanyBusinessConsts.NoteMaxLength);

            var tbCompanyBusiness = await _tbCompanyBusinessRepository.GetAsync(id);

            tbCompanyBusiness.CompanyId = companyId;
            tbCompanyBusiness.RegistrationNo = registrationNo;
            tbCompanyBusiness.RegistrationDate = registrationDate;
            tbCompanyBusiness.License = license;
            tbCompanyBusiness.CompanyName = companyName;
            tbCompanyBusiness.CompanyAddress = companyAddress;
            tbCompanyBusiness.LegalRepresent = legalRepresent;
            tbCompanyBusiness.CompanyType = companyType;
            tbCompanyBusiness.MajorBusiness = majorBusiness;
            tbCompanyBusiness.OtherActivity = otherActivity;
            tbCompanyBusiness.Note = note;
            tbCompanyBusiness.IsActive = isActive;
            tbCompanyBusiness.crt_date = crt_date;
            tbCompanyBusiness.crt_user = crt_user;
            tbCompanyBusiness.mod_date = mod_date;
            tbCompanyBusiness.mod_user = mod_user;
            tbCompanyBusiness.LatestAmendment = latestAmendment;

            return await _tbCompanyBusinessRepository.UpdateAsync(tbCompanyBusiness);
        }

    }
}
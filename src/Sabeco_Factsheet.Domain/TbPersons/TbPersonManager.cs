using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbPersons
{
    public abstract class TbPersonManagerBase : DomainService
    {
        public ITbPersonRepository _tbPersonRepository;

        public TbPersonManagerBase(ITbPersonRepository tbPersonRepository)
        {
            _tbPersonRepository = tbPersonRepository;
        }

        public virtual async Task<TbPerson> CreateAsync(
        string code, string fullName, DateTime birthDate, bool isDeleted, int? companyId = null, string? birthPlace = null, string? address = null, string? iDCardNo = null, DateTime? iDCardDate = null, string? idCardIssuePlace = null, string? ethnicity = null, string? religion = null, string? nationalityCode = null, string? gender = null, string? phone = null, string? email = null, string? note = null, string? image = null, bool? isActive = null, byte? docStatus = null, bool? isCheckRetirement = null, bool? isCheckTermEnd = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? oldCode = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbPersonConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
            Check.Length(fullName, nameof(fullName), TbPersonConsts.FullNameMaxLength);
            Check.NotNull(birthDate, nameof(birthDate));
            Check.Length(birthPlace, nameof(birthPlace), TbPersonConsts.BirthPlaceMaxLength);
            Check.Length(address, nameof(address), TbPersonConsts.AddressMaxLength);
            Check.Length(iDCardNo, nameof(iDCardNo), TbPersonConsts.IDCardNoMaxLength);
            Check.Length(idCardIssuePlace, nameof(idCardIssuePlace), TbPersonConsts.IdCardIssuePlaceMaxLength);
            Check.Length(ethnicity, nameof(ethnicity), TbPersonConsts.EthnicityMaxLength);
            Check.Length(religion, nameof(religion), TbPersonConsts.ReligionMaxLength);
            Check.Length(nationalityCode, nameof(nationalityCode), TbPersonConsts.NationalityCodeMaxLength);
            Check.Length(gender, nameof(gender), TbPersonConsts.GenderMaxLength);
            Check.Length(phone, nameof(phone), TbPersonConsts.PhoneMaxLength);
            Check.Length(email, nameof(email), TbPersonConsts.EmailMaxLength);
            Check.Length(note, nameof(note), TbPersonConsts.NoteMaxLength);
            Check.Length(oldCode, nameof(oldCode), TbPersonConsts.OldCodeMaxLength);

            var tbPerson = new TbPerson(

             code, fullName, birthDate, isDeleted, companyId, birthPlace, address, iDCardNo, iDCardDate, idCardIssuePlace, ethnicity, religion, nationalityCode, gender, phone, email, note, image, isActive, docStatus, isCheckRetirement, isCheckTermEnd, crt_date, crt_user, mod_date, mod_user, oldCode
             );

            return await _tbPersonRepository.InsertAsync(tbPerson);
        }

        public virtual async Task<TbPerson> UpdateAsync(
            int id,
            string code, string fullName, DateTime birthDate, bool isDeleted, int? companyId = null, string? birthPlace = null, string? address = null, string? iDCardNo = null, DateTime? iDCardDate = null, string? idCardIssuePlace = null, string? ethnicity = null, string? religion = null, string? nationalityCode = null, string? gender = null, string? phone = null, string? email = null, string? note = null, string? image = null, bool? isActive = null, byte? docStatus = null, bool? isCheckRetirement = null, bool? isCheckTermEnd = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? oldCode = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbPersonConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
            Check.Length(fullName, nameof(fullName), TbPersonConsts.FullNameMaxLength);
            Check.NotNull(birthDate, nameof(birthDate));
            Check.Length(birthPlace, nameof(birthPlace), TbPersonConsts.BirthPlaceMaxLength);
            Check.Length(address, nameof(address), TbPersonConsts.AddressMaxLength);
            Check.Length(iDCardNo, nameof(iDCardNo), TbPersonConsts.IDCardNoMaxLength);
            Check.Length(idCardIssuePlace, nameof(idCardIssuePlace), TbPersonConsts.IdCardIssuePlaceMaxLength);
            Check.Length(ethnicity, nameof(ethnicity), TbPersonConsts.EthnicityMaxLength);
            Check.Length(religion, nameof(religion), TbPersonConsts.ReligionMaxLength);
            Check.Length(nationalityCode, nameof(nationalityCode), TbPersonConsts.NationalityCodeMaxLength);
            Check.Length(gender, nameof(gender), TbPersonConsts.GenderMaxLength);
            Check.Length(phone, nameof(phone), TbPersonConsts.PhoneMaxLength);
            Check.Length(email, nameof(email), TbPersonConsts.EmailMaxLength);
            Check.Length(note, nameof(note), TbPersonConsts.NoteMaxLength);
            Check.Length(oldCode, nameof(oldCode), TbPersonConsts.OldCodeMaxLength);

            var tbPerson = await _tbPersonRepository.GetAsync(id);

            tbPerson.Code = code;
            tbPerson.FullName = fullName;
            tbPerson.BirthDate = birthDate;
            tbPerson.IsDeleted = isDeleted;
            tbPerson.CompanyId = companyId;
            tbPerson.BirthPlace = birthPlace;
            tbPerson.Address = address;
            tbPerson.IDCardNo = iDCardNo;
            tbPerson.IDCardDate = iDCardDate;
            tbPerson.IdCardIssuePlace = idCardIssuePlace;
            tbPerson.Ethnicity = ethnicity;
            tbPerson.Religion = religion;
            tbPerson.NationalityCode = nationalityCode;
            tbPerson.Gender = gender;
            tbPerson.Phone = phone;
            tbPerson.Email = email;
            tbPerson.Note = note;
            tbPerson.Image = image;
            tbPerson.IsActive = isActive;
            tbPerson.DocStatus = docStatus;
            tbPerson.IsCheckRetirement = isCheckRetirement;
            tbPerson.IsCheckTermEnd = isCheckTermEnd;
            tbPerson.crt_date = crt_date;
            tbPerson.crt_user = crt_user;
            tbPerson.mod_date = mod_date;
            tbPerson.mod_user = mod_user;
            tbPerson.OldCode = oldCode;

            return await _tbPersonRepository.UpdateAsync(tbPerson);
        }

    }
}
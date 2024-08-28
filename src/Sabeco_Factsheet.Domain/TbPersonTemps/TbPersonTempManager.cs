using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbPersonTemps
{
    public abstract class TbPersonTempManagerBase : DomainService
    {
        public ITbPersonTempRepository _tbPersonTempRepository;

        public TbPersonTempManagerBase(ITbPersonTempRepository tbPersonTempRepository)
        {
            _tbPersonTempRepository = tbPersonTempRepository;
        }

        public virtual async Task<TbPersonTemp> CreateAsync(
        string code, string fullName, DateTime birthDate, int? idPerson = null, int? companyId = null, string? birthPlace = null, string? address = null, string? iDCardNo = null, DateTime? iDCardDate = null, string? idCardIssuePlace = null, string? ethnicity = null, string? religion = null, string? nationalityCode = null, string? gender = null, string? phone = null, string? email = null, string? note = null, string? image = null, bool? isActive = null, byte? docStatus = null, bool? isCheckRetirement = null, bool? isCheckTermEnd = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? oldCode = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbPersonTempConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
            Check.Length(fullName, nameof(fullName), TbPersonTempConsts.FullNameMaxLength);
            Check.NotNull(birthDate, nameof(birthDate));
            Check.Length(birthPlace, nameof(birthPlace), TbPersonTempConsts.BirthPlaceMaxLength);
            Check.Length(address, nameof(address), TbPersonTempConsts.AddressMaxLength);
            Check.Length(iDCardNo, nameof(iDCardNo), TbPersonTempConsts.IDCardNoMaxLength);
            Check.Length(idCardIssuePlace, nameof(idCardIssuePlace), TbPersonTempConsts.IdCardIssuePlaceMaxLength);
            Check.Length(ethnicity, nameof(ethnicity), TbPersonTempConsts.EthnicityMaxLength);
            Check.Length(religion, nameof(religion), TbPersonTempConsts.ReligionMaxLength);
            Check.Length(nationalityCode, nameof(nationalityCode), TbPersonTempConsts.NationalityCodeMaxLength);
            Check.Length(gender, nameof(gender), TbPersonTempConsts.GenderMaxLength);
            Check.Length(phone, nameof(phone), TbPersonTempConsts.PhoneMaxLength);
            Check.Length(email, nameof(email), TbPersonTempConsts.EmailMaxLength);
            Check.Length(note, nameof(note), TbPersonTempConsts.NoteMaxLength);
            Check.Length(oldCode, nameof(oldCode), TbPersonTempConsts.OldCodeMaxLength);

            var tbPersonTemp = new TbPersonTemp(

             code, fullName, birthDate, idPerson, companyId, birthPlace, address, iDCardNo, iDCardDate, idCardIssuePlace, ethnicity, religion, nationalityCode, gender, phone, email, note, image, isActive, docStatus, isCheckRetirement, isCheckTermEnd, crt_date, crt_user, mod_date, mod_user, oldCode
             );

            return await _tbPersonTempRepository.InsertAsync(tbPersonTemp);
        }

        public virtual async Task<TbPersonTemp> UpdateAsync(
            int id,
            string code, string fullName, DateTime birthDate, int? idPerson = null, int? companyId = null, string? birthPlace = null, string? address = null, string? iDCardNo = null, DateTime? iDCardDate = null, string? idCardIssuePlace = null, string? ethnicity = null, string? religion = null, string? nationalityCode = null, string? gender = null, string? phone = null, string? email = null, string? note = null, string? image = null, bool? isActive = null, byte? docStatus = null, bool? isCheckRetirement = null, bool? isCheckTermEnd = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? oldCode = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbPersonTempConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
            Check.Length(fullName, nameof(fullName), TbPersonTempConsts.FullNameMaxLength);
            Check.NotNull(birthDate, nameof(birthDate));
            Check.Length(birthPlace, nameof(birthPlace), TbPersonTempConsts.BirthPlaceMaxLength);
            Check.Length(address, nameof(address), TbPersonTempConsts.AddressMaxLength);
            Check.Length(iDCardNo, nameof(iDCardNo), TbPersonTempConsts.IDCardNoMaxLength);
            Check.Length(idCardIssuePlace, nameof(idCardIssuePlace), TbPersonTempConsts.IdCardIssuePlaceMaxLength);
            Check.Length(ethnicity, nameof(ethnicity), TbPersonTempConsts.EthnicityMaxLength);
            Check.Length(religion, nameof(religion), TbPersonTempConsts.ReligionMaxLength);
            Check.Length(nationalityCode, nameof(nationalityCode), TbPersonTempConsts.NationalityCodeMaxLength);
            Check.Length(gender, nameof(gender), TbPersonTempConsts.GenderMaxLength);
            Check.Length(phone, nameof(phone), TbPersonTempConsts.PhoneMaxLength);
            Check.Length(email, nameof(email), TbPersonTempConsts.EmailMaxLength);
            Check.Length(note, nameof(note), TbPersonTempConsts.NoteMaxLength);
            Check.Length(oldCode, nameof(oldCode), TbPersonTempConsts.OldCodeMaxLength);

            var tbPersonTemp = await _tbPersonTempRepository.GetAsync(id);

            tbPersonTemp.Code = code;
            tbPersonTemp.FullName = fullName;
            tbPersonTemp.BirthDate = birthDate;
            tbPersonTemp.idPerson = idPerson;
            tbPersonTemp.CompanyId = companyId;
            tbPersonTemp.BirthPlace = birthPlace;
            tbPersonTemp.Address = address;
            tbPersonTemp.IDCardNo = iDCardNo;
            tbPersonTemp.IDCardDate = iDCardDate;
            tbPersonTemp.IdCardIssuePlace = idCardIssuePlace;
            tbPersonTemp.Ethnicity = ethnicity;
            tbPersonTemp.Religion = religion;
            tbPersonTemp.NationalityCode = nationalityCode;
            tbPersonTemp.Gender = gender;
            tbPersonTemp.Phone = phone;
            tbPersonTemp.Email = email;
            tbPersonTemp.Note = note;
            tbPersonTemp.Image = image;
            tbPersonTemp.IsActive = isActive;
            tbPersonTemp.DocStatus = docStatus;
            tbPersonTemp.IsCheckRetirement = isCheckRetirement;
            tbPersonTemp.IsCheckTermEnd = isCheckTermEnd;
            tbPersonTemp.crt_date = crt_date;
            tbPersonTemp.crt_user = crt_user;
            tbPersonTemp.mod_date = mod_date;
            tbPersonTemp.mod_user = mod_user;
            tbPersonTemp.OldCode = oldCode;

            return await _tbPersonTempRepository.UpdateAsync(tbPersonTemp);
        }

    }
}
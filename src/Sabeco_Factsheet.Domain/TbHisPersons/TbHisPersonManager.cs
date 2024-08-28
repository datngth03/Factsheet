using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbHisPersons
{
    public abstract class TbHisPersonManagerBase : DomainService
    {
        public ITbHisPersonRepository _tbHisPersonRepository;

        public TbHisPersonManagerBase(ITbHisPersonRepository tbHisPersonRepository)
        {
            _tbHisPersonRepository = tbHisPersonRepository;
        }

        public virtual async Task<TbHisPerson> CreateAsync(
        int type, int idPerson, string code, string fullName, DateTime birthDate, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, int? companyId = null, string? birthPlace = null, string? address = null, string? iDCardNo = null, DateTime? iDCardDate = null, string? idCardIssuePlace = null, string? ethnicity = null, string? religion = null, string? nationalityCode = null, string? gender = null, string? phone = null, string? email = null, string? note = null, string? image = null, bool? isActive = null, byte? docStatus = null, bool? isCheckRetirement = null, bool? isCheckTermEnd = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? oldCode = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbHisPersonConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
            Check.Length(fullName, nameof(fullName), TbHisPersonConsts.FullNameMaxLength);
            Check.NotNull(birthDate, nameof(birthDate));
            Check.Length(birthPlace, nameof(birthPlace), TbHisPersonConsts.BirthPlaceMaxLength);
            Check.Length(address, nameof(address), TbHisPersonConsts.AddressMaxLength);
            Check.Length(iDCardNo, nameof(iDCardNo), TbHisPersonConsts.IDCardNoMaxLength);
            Check.Length(idCardIssuePlace, nameof(idCardIssuePlace), TbHisPersonConsts.IdCardIssuePlaceMaxLength);
            Check.Length(ethnicity, nameof(ethnicity), TbHisPersonConsts.EthnicityMaxLength);
            Check.Length(religion, nameof(religion), TbHisPersonConsts.ReligionMaxLength);
            Check.Length(nationalityCode, nameof(nationalityCode), TbHisPersonConsts.NationalityCodeMaxLength);
            Check.Length(gender, nameof(gender), TbHisPersonConsts.GenderMaxLength);
            Check.Length(phone, nameof(phone), TbHisPersonConsts.PhoneMaxLength);
            Check.Length(email, nameof(email), TbHisPersonConsts.EmailMaxLength);
            Check.Length(note, nameof(note), TbHisPersonConsts.NoteMaxLength);
            Check.Length(oldCode, nameof(oldCode), TbHisPersonConsts.OldCodeMaxLength);

            var tbHisPerson = new TbHisPerson(

             type, idPerson, code, fullName, birthDate, isSendMail, dateSendMail, insertDate, companyId, birthPlace, address, iDCardNo, iDCardDate, idCardIssuePlace, ethnicity, religion, nationalityCode, gender, phone, email, note, image, isActive, docStatus, isCheckRetirement, isCheckTermEnd, crt_date, crt_user, mod_date, mod_user, oldCode
             );

            return await _tbHisPersonRepository.InsertAsync(tbHisPerson);
        }

        public virtual async Task<TbHisPerson> UpdateAsync(
            int id,
            int type, int idPerson, string code, string fullName, DateTime birthDate, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, int? companyId = null, string? birthPlace = null, string? address = null, string? iDCardNo = null, DateTime? iDCardDate = null, string? idCardIssuePlace = null, string? ethnicity = null, string? religion = null, string? nationalityCode = null, string? gender = null, string? phone = null, string? email = null, string? note = null, string? image = null, bool? isActive = null, byte? docStatus = null, bool? isCheckRetirement = null, bool? isCheckTermEnd = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? oldCode = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbHisPersonConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
            Check.Length(fullName, nameof(fullName), TbHisPersonConsts.FullNameMaxLength);
            Check.NotNull(birthDate, nameof(birthDate));
            Check.Length(birthPlace, nameof(birthPlace), TbHisPersonConsts.BirthPlaceMaxLength);
            Check.Length(address, nameof(address), TbHisPersonConsts.AddressMaxLength);
            Check.Length(iDCardNo, nameof(iDCardNo), TbHisPersonConsts.IDCardNoMaxLength);
            Check.Length(idCardIssuePlace, nameof(idCardIssuePlace), TbHisPersonConsts.IdCardIssuePlaceMaxLength);
            Check.Length(ethnicity, nameof(ethnicity), TbHisPersonConsts.EthnicityMaxLength);
            Check.Length(religion, nameof(religion), TbHisPersonConsts.ReligionMaxLength);
            Check.Length(nationalityCode, nameof(nationalityCode), TbHisPersonConsts.NationalityCodeMaxLength);
            Check.Length(gender, nameof(gender), TbHisPersonConsts.GenderMaxLength);
            Check.Length(phone, nameof(phone), TbHisPersonConsts.PhoneMaxLength);
            Check.Length(email, nameof(email), TbHisPersonConsts.EmailMaxLength);
            Check.Length(note, nameof(note), TbHisPersonConsts.NoteMaxLength);
            Check.Length(oldCode, nameof(oldCode), TbHisPersonConsts.OldCodeMaxLength);

            var tbHisPerson = await _tbHisPersonRepository.GetAsync(id);

            tbHisPerson.Type = type;
            tbHisPerson.IdPerson = idPerson;
            tbHisPerson.Code = code;
            tbHisPerson.FullName = fullName;
            tbHisPerson.BirthDate = birthDate;
            tbHisPerson.IsSendMail = isSendMail;
            tbHisPerson.DateSendMail = dateSendMail;
            tbHisPerson.InsertDate = insertDate;
            tbHisPerson.CompanyId = companyId;
            tbHisPerson.BirthPlace = birthPlace;
            tbHisPerson.Address = address;
            tbHisPerson.IDCardNo = iDCardNo;
            tbHisPerson.IDCardDate = iDCardDate;
            tbHisPerson.IdCardIssuePlace = idCardIssuePlace;
            tbHisPerson.Ethnicity = ethnicity;
            tbHisPerson.Religion = religion;
            tbHisPerson.NationalityCode = nationalityCode;
            tbHisPerson.Gender = gender;
            tbHisPerson.Phone = phone;
            tbHisPerson.Email = email;
            tbHisPerson.Note = note;
            tbHisPerson.Image = image;
            tbHisPerson.IsActive = isActive;
            tbHisPerson.DocStatus = docStatus;
            tbHisPerson.IsCheckRetirement = isCheckRetirement;
            tbHisPerson.IsCheckTermEnd = isCheckTermEnd;
            tbHisPerson.crt_date = crt_date;
            tbHisPerson.crt_user = crt_user;
            tbHisPerson.mod_date = mod_date;
            tbHisPerson.mod_user = mod_user;
            tbHisPerson.OldCode = oldCode;

            return await _tbHisPersonRepository.UpdateAsync(tbHisPerson);
        }

    }
}
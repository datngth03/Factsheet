using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbHisCompanyPersons
{
    public abstract class TbHisCompanyPersonManagerBase : DomainService
    {
        public ITbHisCompanyPersonRepository _tbHisCompanyPersonRepository;

        public TbHisCompanyPersonManagerBase(ITbHisCompanyPersonRepository tbHisCompanyPersonRepository)
        {
            _tbHisCompanyPersonRepository = tbHisCompanyPersonRepository;
        }

        public virtual async Task<TbHisCompanyPerson> CreateAsync(
        int type, int idCompanyPerson, int companyId, int personId, bool isActive, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, string? branchCode = null, DateTime? fromDate = null, DateTime? toDate = null, int? positionId = null, string? positionCode = null, decimal? personalValue = null, decimal? personalSharePercentage = null, decimal? ownerValue = null, decimal? representativePercentage = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.Length(branchCode, nameof(branchCode), TbHisCompanyPersonConsts.BranchCodeMaxLength);
            Check.Length(positionCode, nameof(positionCode), TbHisCompanyPersonConsts.PositionCodeMaxLength);
            Check.Length(note, nameof(note), TbHisCompanyPersonConsts.NoteMaxLength);

            var tbHisCompanyPerson = new TbHisCompanyPerson(

             type, idCompanyPerson, companyId, personId, isActive, isSendMail, dateSendMail, insertDate, branchCode, fromDate, toDate, positionId, positionCode, personalValue, personalSharePercentage, ownerValue, representativePercentage, note, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbHisCompanyPersonRepository.InsertAsync(tbHisCompanyPerson);
        }

        public virtual async Task<TbHisCompanyPerson> UpdateAsync(
            int id,
            int type, int idCompanyPerson, int companyId, int personId, bool isActive, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, string? branchCode = null, DateTime? fromDate = null, DateTime? toDate = null, int? positionId = null, string? positionCode = null, decimal? personalValue = null, decimal? personalSharePercentage = null, decimal? ownerValue = null, decimal? representativePercentage = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.Length(branchCode, nameof(branchCode), TbHisCompanyPersonConsts.BranchCodeMaxLength);
            Check.Length(positionCode, nameof(positionCode), TbHisCompanyPersonConsts.PositionCodeMaxLength);
            Check.Length(note, nameof(note), TbHisCompanyPersonConsts.NoteMaxLength);

            var tbHisCompanyPerson = await _tbHisCompanyPersonRepository.GetAsync(id);

            tbHisCompanyPerson.Type = type;
            tbHisCompanyPerson.IdCompanyPerson = idCompanyPerson;
            tbHisCompanyPerson.CompanyId = companyId;
            tbHisCompanyPerson.PersonId = personId;
            tbHisCompanyPerson.IsActive = isActive;
            tbHisCompanyPerson.IsSendMail = isSendMail;
            tbHisCompanyPerson.DateSendMail = dateSendMail;
            tbHisCompanyPerson.InsertDate = insertDate;
            tbHisCompanyPerson.BranchCode = branchCode;
            tbHisCompanyPerson.FromDate = fromDate;
            tbHisCompanyPerson.ToDate = toDate;
            tbHisCompanyPerson.PositionId = positionId;
            tbHisCompanyPerson.PositionCode = positionCode;
            tbHisCompanyPerson.PersonalValue = personalValue;
            tbHisCompanyPerson.PersonalSharePercentage = personalSharePercentage;
            tbHisCompanyPerson.OwnerValue = ownerValue;
            tbHisCompanyPerson.RepresentativePercentage = representativePercentage;
            tbHisCompanyPerson.Note = note;
            tbHisCompanyPerson.crt_date = crt_date;
            tbHisCompanyPerson.crt_user = crt_user;
            tbHisCompanyPerson.mod_date = mod_date;
            tbHisCompanyPerson.mod_user = mod_user;

            return await _tbHisCompanyPersonRepository.UpdateAsync(tbHisCompanyPerson);
        }

    }
}
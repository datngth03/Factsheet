using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyPersons
{
    public abstract class TbCompanyPersonManagerBase : DomainService
    {
        public ITbCompanyPersonRepository _tbCompanyPersonRepository;

        public TbCompanyPersonManagerBase(ITbCompanyPersonRepository tbCompanyPersonRepository)
        {
            _tbCompanyPersonRepository = tbCompanyPersonRepository;
        }

        public virtual async Task<TbCompanyPerson> CreateAsync(
        int companyId, int personId, bool isActive, bool isDeleted, string? branchCode = null, int? positionId = null, DateTime? fromDate = null, DateTime? toDate = null, string? positionCode = null, byte? postionType = null, decimal? personalValue = null, decimal? personalSharePercentage = null, decimal? ownerValue = null, decimal? representativePercentage = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.Length(branchCode, nameof(branchCode), TbCompanyPersonConsts.BranchCodeMaxLength);
            Check.Length(positionCode, nameof(positionCode), TbCompanyPersonConsts.PositionCodeMaxLength);
            Check.Length(note, nameof(note), TbCompanyPersonConsts.NoteMaxLength);

            var tbCompanyPerson = new TbCompanyPerson(

             companyId, personId, isActive, isDeleted, branchCode, positionId, fromDate, toDate, positionCode, postionType, personalValue, personalSharePercentage, ownerValue, representativePercentage, note, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbCompanyPersonRepository.InsertAsync(tbCompanyPerson);
        }

        public virtual async Task<TbCompanyPerson> UpdateAsync(
            int id,
            int companyId, int personId, bool isActive, bool isDeleted, string? branchCode = null, int? positionId = null, DateTime? fromDate = null, DateTime? toDate = null, string? positionCode = null, byte? postionType = null, decimal? personalValue = null, decimal? personalSharePercentage = null, decimal? ownerValue = null, decimal? representativePercentage = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.Length(branchCode, nameof(branchCode), TbCompanyPersonConsts.BranchCodeMaxLength);
            Check.Length(positionCode, nameof(positionCode), TbCompanyPersonConsts.PositionCodeMaxLength);
            Check.Length(note, nameof(note), TbCompanyPersonConsts.NoteMaxLength);

            var tbCompanyPerson = await _tbCompanyPersonRepository.GetAsync(id);

            tbCompanyPerson.CompanyId = companyId;
            tbCompanyPerson.PersonId = personId;
            tbCompanyPerson.IsActive = isActive;
            tbCompanyPerson.IsDeleted = isDeleted;
            tbCompanyPerson.BranchCode = branchCode;
            tbCompanyPerson.PositionId = positionId;
            tbCompanyPerson.FromDate = fromDate;
            tbCompanyPerson.ToDate = toDate;
            tbCompanyPerson.PositionCode = positionCode;
            tbCompanyPerson.PostionType = postionType;
            tbCompanyPerson.PersonalValue = personalValue;
            tbCompanyPerson.PersonalSharePercentage = personalSharePercentage;
            tbCompanyPerson.OwnerValue = ownerValue;
            tbCompanyPerson.RepresentativePercentage = representativePercentage;
            tbCompanyPerson.Note = note;
            tbCompanyPerson.crt_date = crt_date;
            tbCompanyPerson.crt_user = crt_user;
            tbCompanyPerson.mod_date = mod_date;
            tbCompanyPerson.mod_user = mod_user;

            return await _tbCompanyPersonRepository.UpdateAsync(tbCompanyPerson);
        }

    }
}
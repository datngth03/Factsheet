using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyPersonTemps
{
    public abstract class TbCompanyPersonTempManagerBase : DomainService
    {
        public ITbCompanyPersonTempRepository _tbCompanyPersonTempRepository;

        public TbCompanyPersonTempManagerBase(ITbCompanyPersonTempRepository tbCompanyPersonTempRepository)
        {
            _tbCompanyPersonTempRepository = tbCompanyPersonTempRepository;
        }

        public virtual async Task<TbCompanyPersonTemp> CreateAsync(
        int companyId, int personId, bool isActive, bool isDeleted, int? idCompanyPerson = null, string? branchCode = null, int? positionId = null, DateTime? fromDate = null, DateTime? toDate = null, byte? positionType = null, string? positionCode = null, decimal? personalValue = null, decimal? personalSharePercentage = null, decimal? ownerValue = null, decimal? representativePercentage = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.Length(branchCode, nameof(branchCode), TbCompanyPersonTempConsts.BranchCodeMaxLength);
            Check.Length(positionCode, nameof(positionCode), TbCompanyPersonTempConsts.PositionCodeMaxLength);
            Check.Length(note, nameof(note), TbCompanyPersonTempConsts.NoteMaxLength);

            var tbCompanyPersonTemp = new TbCompanyPersonTemp(

             companyId, personId, isActive, isDeleted, idCompanyPerson, branchCode, positionId, fromDate, toDate, positionType, positionCode, personalValue, personalSharePercentage, ownerValue, representativePercentage, note, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbCompanyPersonTempRepository.InsertAsync(tbCompanyPersonTemp);
        }

        public virtual async Task<TbCompanyPersonTemp> UpdateAsync(
            int id,
            int companyId, int personId, bool isActive, bool isDeleted, int? idCompanyPerson = null, string? branchCode = null, int? positionId = null, DateTime? fromDate = null, DateTime? toDate = null, byte? positionType = null, string? positionCode = null, decimal? personalValue = null, decimal? personalSharePercentage = null, decimal? ownerValue = null, decimal? representativePercentage = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.Length(branchCode, nameof(branchCode), TbCompanyPersonTempConsts.BranchCodeMaxLength);
            Check.Length(positionCode, nameof(positionCode), TbCompanyPersonTempConsts.PositionCodeMaxLength);
            Check.Length(note, nameof(note), TbCompanyPersonTempConsts.NoteMaxLength);

            var tbCompanyPersonTemp = await _tbCompanyPersonTempRepository.GetAsync(id);

            tbCompanyPersonTemp.CompanyId = companyId;
            tbCompanyPersonTemp.PersonId = personId;
            tbCompanyPersonTemp.IsActive = isActive;
            tbCompanyPersonTemp.IsDeleted = isDeleted;
            tbCompanyPersonTemp.idCompanyPerson = idCompanyPerson;
            tbCompanyPersonTemp.BranchCode = branchCode;
            tbCompanyPersonTemp.PositionId = positionId;
            tbCompanyPersonTemp.FromDate = fromDate;
            tbCompanyPersonTemp.ToDate = toDate;
            tbCompanyPersonTemp.PositionType = positionType;
            tbCompanyPersonTemp.PositionCode = positionCode;
            tbCompanyPersonTemp.PersonalValue = personalValue;
            tbCompanyPersonTemp.PersonalSharePercentage = personalSharePercentage;
            tbCompanyPersonTemp.OwnerValue = ownerValue;
            tbCompanyPersonTemp.RepresentativePercentage = representativePercentage;
            tbCompanyPersonTemp.Note = note;
            tbCompanyPersonTemp.crt_date = crt_date;
            tbCompanyPersonTemp.crt_user = crt_user;
            tbCompanyPersonTemp.mod_date = mod_date;
            tbCompanyPersonTemp.mod_user = mod_user;

            return await _tbCompanyPersonTempRepository.UpdateAsync(tbCompanyPersonTemp);
        }

    }
}
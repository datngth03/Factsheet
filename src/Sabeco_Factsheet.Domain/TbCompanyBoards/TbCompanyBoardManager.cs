using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyBoards
{
    public abstract class TbCompanyBoardManagerBase : DomainService
    {
        public ITbCompanyBoardRepository _tbCompanyBoardRepository;

        public TbCompanyBoardManagerBase(ITbCompanyBoardRepository tbCompanyBoardRepository)
        {
            _tbCompanyBoardRepository = tbCompanyBoardRepository;
        }

        public virtual async Task<TbCompanyBoard> CreateAsync(
        string companyCode, string personCode, bool isActive, bool isDeleted, string? branchCode = null, DateTime? fromDate = null, DateTime? toDate = null, string? positionCode = null, int? personalValue = null, int? ownerValue = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.NotNullOrWhiteSpace(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), TbCompanyBoardConsts.CompanyCodeMaxLength);
            Check.NotNullOrWhiteSpace(personCode, nameof(personCode));
            Check.Length(personCode, nameof(personCode), TbCompanyBoardConsts.PersonCodeMaxLength);
            Check.Length(branchCode, nameof(branchCode), TbCompanyBoardConsts.BranchCodeMaxLength);
            Check.Length(positionCode, nameof(positionCode), TbCompanyBoardConsts.PositionCodeMaxLength);
            Check.Length(note, nameof(note), TbCompanyBoardConsts.NoteMaxLength);

            var tbCompanyBoard = new TbCompanyBoard(

             companyCode, personCode, isActive, isDeleted, branchCode, fromDate, toDate, positionCode, personalValue, ownerValue, note, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbCompanyBoardRepository.InsertAsync(tbCompanyBoard);
        }

        public virtual async Task<TbCompanyBoard> UpdateAsync(
            int id,
            string companyCode, string personCode, bool isActive, bool isDeleted, string? branchCode = null, DateTime? fromDate = null, DateTime? toDate = null, string? positionCode = null, int? personalValue = null, int? ownerValue = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.NotNullOrWhiteSpace(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), TbCompanyBoardConsts.CompanyCodeMaxLength);
            Check.NotNullOrWhiteSpace(personCode, nameof(personCode));
            Check.Length(personCode, nameof(personCode), TbCompanyBoardConsts.PersonCodeMaxLength);
            Check.Length(branchCode, nameof(branchCode), TbCompanyBoardConsts.BranchCodeMaxLength);
            Check.Length(positionCode, nameof(positionCode), TbCompanyBoardConsts.PositionCodeMaxLength);
            Check.Length(note, nameof(note), TbCompanyBoardConsts.NoteMaxLength);

            var tbCompanyBoard = await _tbCompanyBoardRepository.GetAsync(id);

            tbCompanyBoard.CompanyCode = companyCode;
            tbCompanyBoard.PersonCode = personCode;
            tbCompanyBoard.IsActive = isActive;
            tbCompanyBoard.IsDeleted = isDeleted;
            tbCompanyBoard.BranchCode = branchCode;
            tbCompanyBoard.FromDate = fromDate;
            tbCompanyBoard.ToDate = toDate;
            tbCompanyBoard.PositionCode = positionCode;
            tbCompanyBoard.PersonalValue = personalValue;
            tbCompanyBoard.OwnerValue = ownerValue;
            tbCompanyBoard.Note = note;
            tbCompanyBoard.crt_date = crt_date;
            tbCompanyBoard.crt_user = crt_user;
            tbCompanyBoard.mod_date = mod_date;
            tbCompanyBoard.mod_user = mod_user;

            return await _tbCompanyBoardRepository.UpdateAsync(tbCompanyBoard);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbInvests
{
    public abstract class TbInvestManagerBase : DomainService
    {
        public ITbInvestRepository _tbInvestRepository;

        public TbInvestManagerBase(ITbInvestRepository tbInvestRepository)
        {
            _tbInvestRepository = tbInvestRepository;
        }

        public virtual async Task<TbInvest> CreateAsync(
        string branchCode, string companyCode, bool isDeleted, int? branchId = null, int? companyId = null, int? shareNumTotal = null, decimal? shareValueTotal = null, string? note = null, byte? docStatus = null, bool? investGroup = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.NotNullOrWhiteSpace(branchCode, nameof(branchCode));
            Check.Length(branchCode, nameof(branchCode), TbInvestConsts.BranchCodeMaxLength);
            Check.NotNullOrWhiteSpace(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), TbInvestConsts.CompanyCodeMaxLength);
            Check.Length(note, nameof(note), TbInvestConsts.NoteMaxLength);

            var tbInvest = new TbInvest(

             branchCode, companyCode, isDeleted, branchId, companyId, shareNumTotal, shareValueTotal, note, docStatus, investGroup, isActive, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbInvestRepository.InsertAsync(tbInvest);
        }

        public virtual async Task<TbInvest> UpdateAsync(
            int id,
            string branchCode, string companyCode, bool isDeleted, int? branchId = null, int? companyId = null, int? shareNumTotal = null, decimal? shareValueTotal = null, string? note = null, byte? docStatus = null, bool? investGroup = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.NotNullOrWhiteSpace(branchCode, nameof(branchCode));
            Check.Length(branchCode, nameof(branchCode), TbInvestConsts.BranchCodeMaxLength);
            Check.NotNullOrWhiteSpace(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), TbInvestConsts.CompanyCodeMaxLength);
            Check.Length(note, nameof(note), TbInvestConsts.NoteMaxLength);

            var tbInvest = await _tbInvestRepository.GetAsync(id);

            tbInvest.BranchCode = branchCode;
            tbInvest.CompanyCode = companyCode;
            tbInvest.IsDeleted = isDeleted;
            tbInvest.BranchId = branchId;
            tbInvest.CompanyId = companyId;
            tbInvest.ShareNumTotal = shareNumTotal;
            tbInvest.ShareValueTotal = shareValueTotal;
            tbInvest.Note = note;
            tbInvest.DocStatus = docStatus;
            tbInvest.InvestGroup = investGroup;
            tbInvest.IsActive = isActive;
            tbInvest.crt_date = crt_date;
            tbInvest.crt_user = crt_user;
            tbInvest.mod_date = mod_date;
            tbInvest.mod_user = mod_user;

            return await _tbInvestRepository.UpdateAsync(tbInvest);
        }

    }
}
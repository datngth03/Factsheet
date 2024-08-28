using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyBranchs
{
    public abstract class TbCompanyBranchManagerBase : DomainService
    {
        public ITbCompanyBranchRepository _tbCompanyBranchRepository;

        public TbCompanyBranchManagerBase(ITbCompanyBranchRepository tbCompanyBranchRepository)
        {
            _tbCompanyBranchRepository = tbCompanyBranchRepository;
        }

        public virtual async Task<TbCompanyBranch> CreateAsync(
        int? companyId = null, string? branchName = null, string? branchAddress = null, string? branchCode = null, string? contactPerson = null, string? contactPhone = null, string? email = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            var tbCompanyBranch = new TbCompanyBranch(

             companyId, branchName, branchAddress, branchCode, contactPerson, contactPhone, email, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbCompanyBranchRepository.InsertAsync(tbCompanyBranch);
        }

        public virtual async Task<TbCompanyBranch> UpdateAsync(
            int id,
            int? companyId = null, string? branchName = null, string? branchAddress = null, string? branchCode = null, string? contactPerson = null, string? contactPhone = null, string? email = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {

            var tbCompanyBranch = await _tbCompanyBranchRepository.GetAsync(id);

            tbCompanyBranch.CompanyId = companyId;
            tbCompanyBranch.BranchName = branchName;
            tbCompanyBranch.BranchAddress = branchAddress;
            tbCompanyBranch.BranchCode = branchCode;
            tbCompanyBranch.ContactPerson = contactPerson;
            tbCompanyBranch.ContactPhone = contactPhone;
            tbCompanyBranch.Email = email;
            tbCompanyBranch.isActive = isActive;
            tbCompanyBranch.create_user = create_user;
            tbCompanyBranch.create_date = create_date;
            tbCompanyBranch.mod_user = mod_user;
            tbCompanyBranch.mod_date = mod_date;

            return await _tbCompanyBranchRepository.UpdateAsync(tbCompanyBranch);
        }

    }
}
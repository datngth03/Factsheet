using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyBranchTemps
{
    public abstract class TbCompanyBranchTempManagerBase : DomainService
    {
        public ITbCompanyBranchTempRepository _tbCompanyBranchTempRepository;

        public TbCompanyBranchTempManagerBase(ITbCompanyBranchTempRepository tbCompanyBranchTempRepository)
        {
            _tbCompanyBranchTempRepository = tbCompanyBranchTempRepository;
        }

        public virtual async Task<TbCompanyBranchTemp> CreateAsync(
        int? companyId = null, string? branchName = null, string? branchAddress = null, string? branchCode = null, string? contactPerson = null, string? contactPhone = null, string? email = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            var tbCompanyBranchTemp = new TbCompanyBranchTemp(

             companyId, branchName, branchAddress, branchCode, contactPerson, contactPhone, email, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbCompanyBranchTempRepository.InsertAsync(tbCompanyBranchTemp);
        }

        public virtual async Task<TbCompanyBranchTemp> UpdateAsync(
            int id,
            int? companyId = null, string? branchName = null, string? branchAddress = null, string? branchCode = null, string? contactPerson = null, string? contactPhone = null, string? email = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {

            var tbCompanyBranchTemp = await _tbCompanyBranchTempRepository.GetAsync(id);

            tbCompanyBranchTemp.CompanyId = companyId;
            tbCompanyBranchTemp.BranchName = branchName;
            tbCompanyBranchTemp.BranchAddress = branchAddress;
            tbCompanyBranchTemp.BranchCode = branchCode;
            tbCompanyBranchTemp.ContactPerson = contactPerson;
            tbCompanyBranchTemp.ContactPhone = contactPhone;
            tbCompanyBranchTemp.Email = email;
            tbCompanyBranchTemp.isActive = isActive;
            tbCompanyBranchTemp.create_user = create_user;
            tbCompanyBranchTemp.create_date = create_date;
            tbCompanyBranchTemp.mod_user = mod_user;
            tbCompanyBranchTemp.mod_date = mod_date;

            return await _tbCompanyBranchTempRepository.UpdateAsync(tbCompanyBranchTemp);
        }

    }
}
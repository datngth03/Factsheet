using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbBranchs
{
    public abstract class TbBranchManagerBase : DomainService
    {
        public ITbBranchRepository _tbBranchRepository;

        public TbBranchManagerBase(ITbBranchRepository tbBranchRepository)
        {
            _tbBranchRepository = tbBranchRepository;
        }

        public virtual async Task<TbBranch> CreateAsync(
        string code, string name, bool isActive, string? briefName = null, string? name_EN = null, string? companyCode = null, string? description = null, DateTime? crt_Date = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbBranchConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbBranchConsts.NameMaxLength);
            Check.Length(briefName, nameof(briefName), TbBranchConsts.BriefNameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TbBranchConsts.Name_ENMaxLength);
            Check.Length(companyCode, nameof(companyCode), TbBranchConsts.CompanyCodeMaxLength);
            Check.Length(description, nameof(description), TbBranchConsts.DescriptionMaxLength);

            var tbBranch = new TbBranch(

             code, name, isActive, briefName, name_EN, companyCode, description, crt_Date
             );

            return await _tbBranchRepository.InsertAsync(tbBranch);
        }

        public virtual async Task<TbBranch> UpdateAsync(
            int id,
            string code, string name, bool isActive, string? briefName = null, string? name_EN = null, string? companyCode = null, string? description = null, DateTime? crt_Date = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbBranchConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbBranchConsts.NameMaxLength);
            Check.Length(briefName, nameof(briefName), TbBranchConsts.BriefNameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TbBranchConsts.Name_ENMaxLength);
            Check.Length(companyCode, nameof(companyCode), TbBranchConsts.CompanyCodeMaxLength);
            Check.Length(description, nameof(description), TbBranchConsts.DescriptionMaxLength);

            var tbBranch = await _tbBranchRepository.GetAsync(id);

            tbBranch.Code = code;
            tbBranch.Name = name;
            tbBranch.IsActive = isActive;
            tbBranch.BriefName = briefName;
            tbBranch.Name_EN = name_EN;
            tbBranch.CompanyCode = companyCode;
            tbBranch.Description = description;
            tbBranch.Crt_Date = crt_Date;

            return await _tbBranchRepository.UpdateAsync(tbBranch);
        }

    }
}
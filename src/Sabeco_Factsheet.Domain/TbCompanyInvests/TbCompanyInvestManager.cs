using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyInvests
{
    public abstract class TbCompanyInvestManagerBase : DomainService
    {
        public ITbCompanyInvestRepository _tbCompanyInvestRepository;

        public TbCompanyInvestManagerBase(ITbCompanyInvestRepository tbCompanyInvestRepository)
        {
            _tbCompanyInvestRepository = tbCompanyInvestRepository;
        }

        public virtual async Task<TbCompanyInvest> CreateAsync(
        int companyId, bool isActive, bool isDeleted, string? companyName = null, decimal? shares = null, decimal? holding = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            var tbCompanyInvest = new TbCompanyInvest(

             companyId, isActive, isDeleted, companyName, shares, holding, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbCompanyInvestRepository.InsertAsync(tbCompanyInvest);
        }

        public virtual async Task<TbCompanyInvest> UpdateAsync(
            int id,
            int companyId, bool isActive, bool isDeleted, string? companyName = null, decimal? shares = null, decimal? holding = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {

            var tbCompanyInvest = await _tbCompanyInvestRepository.GetAsync(id);

            tbCompanyInvest.CompanyId = companyId;
            tbCompanyInvest.IsActive = isActive;
            tbCompanyInvest.IsDeleted = isDeleted;
            tbCompanyInvest.CompanyName = companyName;
            tbCompanyInvest.Shares = shares;
            tbCompanyInvest.Holding = holding;
            tbCompanyInvest.crt_date = crt_date;
            tbCompanyInvest.crt_user = crt_user;
            tbCompanyInvest.mod_date = mod_date;
            tbCompanyInvest.mod_user = mod_user;

            return await _tbCompanyInvestRepository.UpdateAsync(tbCompanyInvest);
        }

    }
}
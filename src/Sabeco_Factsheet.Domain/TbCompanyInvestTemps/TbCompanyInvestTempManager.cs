using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyInvestTemps
{
    public abstract class TbCompanyInvestTempManagerBase : DomainService
    {
        public ITbCompanyInvestTempRepository _tbCompanyInvestTempRepository;

        public TbCompanyInvestTempManagerBase(ITbCompanyInvestTempRepository tbCompanyInvestTempRepository)
        {
            _tbCompanyInvestTempRepository = tbCompanyInvestTempRepository;
        }

        public virtual async Task<TbCompanyInvestTemp> CreateAsync(
        int companyId, bool isActive, string? companyName = null, decimal? shares = null, decimal? holding = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            var tbCompanyInvestTemp = new TbCompanyInvestTemp(

             companyId, isActive, companyName, shares, holding, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbCompanyInvestTempRepository.InsertAsync(tbCompanyInvestTemp);
        }

        public virtual async Task<TbCompanyInvestTemp> UpdateAsync(
            int id,
            int companyId, bool isActive, string? companyName = null, decimal? shares = null, decimal? holding = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {

            var tbCompanyInvestTemp = await _tbCompanyInvestTempRepository.GetAsync(id);

            tbCompanyInvestTemp.CompanyId = companyId;
            tbCompanyInvestTemp.IsActive = isActive;
            tbCompanyInvestTemp.CompanyName = companyName;
            tbCompanyInvestTemp.Shares = shares;
            tbCompanyInvestTemp.Holding = holding;
            tbCompanyInvestTemp.crt_date = crt_date;
            tbCompanyInvestTemp.crt_user = crt_user;
            tbCompanyInvestTemp.mod_date = mod_date;
            tbCompanyInvestTemp.mod_user = mod_user;

            return await _tbCompanyInvestTempRepository.UpdateAsync(tbCompanyInvestTemp);
        }

    }
}
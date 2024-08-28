using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public abstract class TbUserMappingCompanyManagerBase : DomainService
    {
        public ITbUserMappingCompanyRepository _tbUserMappingCompanyRepository;

        public TbUserMappingCompanyManagerBase(ITbUserMappingCompanyRepository tbUserMappingCompanyRepository)
        {
            _tbUserMappingCompanyRepository = tbUserMappingCompanyRepository;
        }

        public virtual async Task<TbUserMappingCompany> CreateAsync(
        int? userid = null, int? companyid = null, bool? isActive = null)
        {

            var tbUserMappingCompany = new TbUserMappingCompany(

             userid, companyid, isActive
             );

            return await _tbUserMappingCompanyRepository.InsertAsync(tbUserMappingCompany);
        }

        public virtual async Task<TbUserMappingCompany> UpdateAsync(
            int id,
            int? userid = null, int? companyid = null, bool? isActive = null
        )
        {

            var tbUserMappingCompany = await _tbUserMappingCompanyRepository.GetAsync(id);

            tbUserMappingCompany.userid = userid;
            tbUserMappingCompany.companyid = companyid;
            tbUserMappingCompany.IsActive = isActive;

            return await _tbUserMappingCompanyRepository.UpdateAsync(tbUserMappingCompany);
        }

    }
}
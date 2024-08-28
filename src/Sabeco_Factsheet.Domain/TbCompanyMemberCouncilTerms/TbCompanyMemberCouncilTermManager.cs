using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public abstract class TbCompanyMemberCouncilTermManagerBase : DomainService
    {
        public ITbCompanyMemberCouncilTermRepository _tbCompanyMemberCouncilTermRepository;

        public TbCompanyMemberCouncilTermManagerBase(ITbCompanyMemberCouncilTermRepository tbCompanyMemberCouncilTermRepository)
        {
            _tbCompanyMemberCouncilTermRepository = tbCompanyMemberCouncilTermRepository;
        }

        public virtual async Task<TbCompanyMemberCouncilTerm> CreateAsync(
        int? companyId = null, int? termFrom = null, int? termEnd = null)
        {

            var tbCompanyMemberCouncilTerm = new TbCompanyMemberCouncilTerm(

             companyId, termFrom, termEnd
             );

            return await _tbCompanyMemberCouncilTermRepository.InsertAsync(tbCompanyMemberCouncilTerm);
        }

        public virtual async Task<TbCompanyMemberCouncilTerm> UpdateAsync(
            int id,
            int? companyId = null, int? termFrom = null, int? termEnd = null
        )
        {

            var tbCompanyMemberCouncilTerm = await _tbCompanyMemberCouncilTermRepository.GetAsync(id);

            tbCompanyMemberCouncilTerm.CompanyId = companyId;
            tbCompanyMemberCouncilTerm.TermFrom = termFrom;
            tbCompanyMemberCouncilTerm.TermEnd = termEnd;

            return await _tbCompanyMemberCouncilTermRepository.UpdateAsync(tbCompanyMemberCouncilTerm);
        }

    }
}
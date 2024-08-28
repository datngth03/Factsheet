using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbTerms
{
    public abstract class TbTermManagerBase : DomainService
    {
        public ITbTermRepository _tbTermRepository;

        public TbTermManagerBase(ITbTermRepository tbTermRepository)
        {
            _tbTermRepository = tbTermRepository;
        }

        public virtual async Task<TbTerm> CreateAsync(
        int branchId, string termCode, int? fromYear = null, int? toYear = null, string? description = null)
        {
            Check.NotNullOrWhiteSpace(termCode, nameof(termCode));
            Check.Length(termCode, nameof(termCode), TbTermConsts.TermCodeMaxLength);
            Check.Length(description, nameof(description), TbTermConsts.DescriptionMaxLength);

            var tbTerm = new TbTerm(

             branchId, termCode, fromYear, toYear, description
             );

            return await _tbTermRepository.InsertAsync(tbTerm);
        }

        public virtual async Task<TbTerm> UpdateAsync(
            int id,
            int branchId, string termCode, int? fromYear = null, int? toYear = null, string? description = null
        )
        {
            Check.NotNullOrWhiteSpace(termCode, nameof(termCode));
            Check.Length(termCode, nameof(termCode), TbTermConsts.TermCodeMaxLength);
            Check.Length(description, nameof(description), TbTermConsts.DescriptionMaxLength);

            var tbTerm = await _tbTermRepository.GetAsync(id);

            tbTerm.BranchId = branchId;
            tbTerm.TermCode = termCode;
            tbTerm.FromYear = fromYear;
            tbTerm.ToYear = toYear;
            tbTerm.Description = description;

            return await _tbTermRepository.UpdateAsync(tbTerm);
        }

    }
}
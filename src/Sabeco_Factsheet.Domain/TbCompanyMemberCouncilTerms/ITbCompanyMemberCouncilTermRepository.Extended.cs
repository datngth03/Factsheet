using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public partial interface ITbCompanyMemberCouncilTermRepository
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyMemberCouncilTerm>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    int? termFromMin = null,
                    int? termFromMax = null,
                    int? termEndMin = null,
                    int? termEndMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
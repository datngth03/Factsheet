using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbTerms
{
    public partial interface ITbTermRepository
    {
        //HQSOFT's generated code:
        Task<List<TbTerm>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? branchIdMin = null,
                    int? branchIdMax = null,
                    string? termCode = null,
                    int? fromYearMin = null,
                    int? fromYearMax = null,
                    int? toYearMin = null,
                    int? toYearMax = null,
                    string? description = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
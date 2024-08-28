using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbBranchs
{
    public partial interface ITbBranchRepository
    {
        //HQSOFT's generated code:
        Task<List<TbBranch>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? code = null,
                    string? briefName = null,
                    string? name = null,
                    string? name_EN = null,
                    string? companyCode = null,
                    string? description = null,
                    bool? isActive = null,
                    DateTime? crt_DateMin = null,
                    DateTime? crt_DateMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
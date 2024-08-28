using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbCompanyBranchs
{
    public partial interface ITbCompanyBranchRepository
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyBranch>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    string? branchName = null,
                    string? branchAddress = null,
                    string? branchCode = null,
                    string? contactPerson = null,
                    string? contactPhone = null,
                    string? email = null,
                    bool? isActive = null,
                    int? create_userMin = null,
                    int? create_userMax = null,
                    DateTime? create_dateMin = null,
                    DateTime? create_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbCompanyBoards
{
    public partial interface ITbCompanyBoardRepository
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyBoard>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? branchCode = null,
                    string? companyCode = null,
                    string? personCode = null,
                    DateTime? fromDateMin = null,
                    DateTime? fromDateMax = null,
                    DateTime? toDateMin = null,
                    DateTime? toDateMax = null,
                    string? positionCode = null,
                    int? personalValueMin = null,
                    int? personalValueMax = null,
                    int? ownerValueMin = null,
                    int? ownerValueMax = null,
                    string? note = null,
                    bool? isActive = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    bool? isDeleted = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
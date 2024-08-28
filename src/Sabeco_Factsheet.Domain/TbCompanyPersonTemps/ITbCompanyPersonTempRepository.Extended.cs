using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbCompanyPersonTemps
{
    public partial interface ITbCompanyPersonTempRepository
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyPersonTemp>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? idCompanyPersonMin = null,
                    int? idCompanyPersonMax = null,
                    string? branchCode = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    int? personIdMin = null,
                    int? personIdMax = null,
                    int? positionIdMin = null,
                    int? positionIdMax = null,
                    DateTime? fromDateMin = null,
                    DateTime? fromDateMax = null,
                    DateTime? toDateMin = null,
                    DateTime? toDateMax = null,
                    byte? positionTypeMin = null,
                    byte? positionTypeMax = null,
                    string? positionCode = null,
                    decimal? personalValueMin = null,
                    decimal? personalValueMax = null,
                    decimal? personalSharePercentageMin = null,
                    decimal? personalSharePercentageMax = null,
                    decimal? ownerValueMin = null,
                    decimal? ownerValueMax = null,
                    decimal? representativePercentageMin = null,
                    decimal? representativePercentageMax = null,
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
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbHisCompanyPersons
{
    public partial interface ITbHisCompanyPersonRepository
    {
        //HQSOFT's generated code:
        Task<List<TbHisCompanyPerson>> GetListNoPagedAsync(
                    string? filterText = null,
                    bool? isSendMail = null,
                    DateTime? dateSendMailMin = null,
                    DateTime? dateSendMailMax = null,
                    DateTime? insertDateMin = null,
                    DateTime? insertDateMax = null,
                    int? typeMin = null,
                    int? typeMax = null,
                    string? branchCode = null,
                    int? idCompanyPersonMin = null,
                    int? idCompanyPersonMax = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    int? personIdMin = null,
                    int? personIdMax = null,
                    DateTime? fromDateMin = null,
                    DateTime? fromDateMax = null,
                    DateTime? toDateMin = null,
                    DateTime? toDateMax = null,
                    int? positionIdMin = null,
                    int? positionIdMax = null,
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
            string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
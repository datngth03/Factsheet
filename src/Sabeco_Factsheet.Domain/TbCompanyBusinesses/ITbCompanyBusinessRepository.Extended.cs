using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbCompanyBusinesses
{
    public partial interface ITbCompanyBusinessRepository
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyBusiness>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    string? license = null,
                    byte? registrationNoMin = null,
                    byte? registrationNoMax = null,
                    DateTime? registrationDateMin = null,
                    DateTime? registrationDateMax = null,
                    string? companyName = null,
                    string? companyAddress = null,
                    string? legalRepresent = null,
                    string? companyType = null,
                    string? majorBusiness = null,
                    string? otherActivity = null,
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
                    DateTime? latestAmendmentMin = null,
                    DateTime? latestAmendmentMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
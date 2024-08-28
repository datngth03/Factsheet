using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbCompanyStockTemps
{
    public partial interface ITbCompanyStockTempRepository
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyStockTemp>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    string? companyCode = null,
                    bool? isPublicCompany = null,
                    string? stockExchange = null,
                    DateTime? registrationDateMin = null,
                    DateTime? registrationDateMax = null,
                    decimal? charteredCapitalMin = null,
                    decimal? charteredCapitalMax = null,
                    decimal? parValueMin = null,
                    decimal? parValueMax = null,
                    int? totalShareMin = null,
                    int? totalShareMax = null,
                    int? listedShareMin = null,
                    int? listedShareMax = null,
                    string? description = null,
                    bool? isActive = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
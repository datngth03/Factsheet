using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbCompanyMappingTemps
{
    public partial interface ITbCompanyMappingTempRepository
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyMappingTemp>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    string? companyTypeShareholdingCode = null,
                    string? companyTypesCode = null,
                    string? note = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    int? idCompanyTypeShareholdingCodeMin = null,
                    int? idCompanyTypeShareholdingCodeMax = null,
                    int? idCompanyTypesCodeMin = null,
                    int? idCompanyTypesCodeMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
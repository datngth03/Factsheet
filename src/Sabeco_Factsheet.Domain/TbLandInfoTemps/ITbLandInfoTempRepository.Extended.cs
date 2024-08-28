using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbLandInfoTemps
{
    public partial interface ITbLandInfoTempRepository
    {
        //HQSOFT's generated code:
        Task<List<TbLandInfoTemp>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    string? description = null,
                    string? address = null,
                    string? typeOfLand = null,
                    decimal? areaMin = null,
                    decimal? areaMax = null,
                    string? supportingDocument = null,
                    DateTime? issueDateMin = null,
                    DateTime? issueDateMax = null,
                    DateTime? expiryDateMin = null,
                    DateTime? expiryDateMax = null,
                    string? payment = null,
                    string? remark = null,
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
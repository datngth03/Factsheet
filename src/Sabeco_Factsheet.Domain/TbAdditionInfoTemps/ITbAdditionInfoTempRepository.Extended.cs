using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbAdditionInfoTemps
{
    public partial interface ITbAdditionInfoTempRepository
    {
        //HQSOFT's generated code:
        Task<List<TbAdditionInfoTemp>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    DateTime? docDateMin = null,
                    DateTime? docDateMax = null,
                    string? typeOfGroup = null,
                    string? typeOfEvent = null,
                    string? description = null,
                    string? noOfDocument = null,
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
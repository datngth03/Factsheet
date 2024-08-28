using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public partial interface ITbLogSendEmailRetirementRepository
    {
        //HQSOFT's generated code:
        Task<List<TbLogSendEmailRetirement>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? idCompanyMin = null,
                    int? idCompanyMax = null,
                    int? idPersonMin = null,
                    int? idPersonMax = null,
                    bool? isSendEmail = null,
                    DateTime? dateSendEmailMin = null,
                    DateTime? dateSendEmailMax = null,
                    int? typeMin = null,
                    int? typeMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
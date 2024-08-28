using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public partial interface ITbLogRefeshAccountRepository
    {
        //HQSOFT's generated code:
        Task<List<TbLogRefeshAccount>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? accessToken = null,
                    DateTime? timeRefeshMin = null,
                    DateTime? timeRefeshMax = null,
                    bool? isSuccess = null,
                    string? useRefesh = null,
                    string? failedReason = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
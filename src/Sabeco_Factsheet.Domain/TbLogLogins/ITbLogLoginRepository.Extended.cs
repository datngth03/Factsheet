using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbLogLogins
{
    public partial interface ITbLogLoginRepository
    {
        //HQSOFT's generated code:
        Task<List<TbLogLogin>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? userName = null,
                    DateTime? loginDateMin = null,
                    DateTime? loginDateMax = null,
                    string? iPTracking = null,
                    bool? statusLogin = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
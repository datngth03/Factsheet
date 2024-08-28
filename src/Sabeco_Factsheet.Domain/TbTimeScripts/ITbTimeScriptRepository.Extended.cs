using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbTimeScripts
{
    public partial interface ITbTimeScriptRepository
    {
        //HQSOFT's generated code:
        Task<List<TbTimeScript>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? code = null,
                    int? yearMin = null,
                    int? yearMax = null,
                    int? monthMin = null,
                    int? monthMax = null,
                    int? dayMin = null,
                    int? dayMax = null,
                    int? hourMin = null,
                    int? hourMax = null,
                    int? minuteMin = null,
                    int? minuteMax = null,
                    int? secondMin = null,
                    int? secondMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
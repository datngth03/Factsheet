using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbPositions
{
    public partial interface ITbPositionRepository
    {
        //HQSOFT's generated code:
        Task<List<TbPosition>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? code = null,
                    string? name = null,
                    string? name_EN = null,
                    byte? positionTypeMin = null,
                    byte? positionTypeMax = null,
                    bool? isActive = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? ctr_dateMin = null,
                    DateTime? ctr_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? orderNumbMin = null,
                    int? orderNumbMax = null,
                    bool? isDeleted = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
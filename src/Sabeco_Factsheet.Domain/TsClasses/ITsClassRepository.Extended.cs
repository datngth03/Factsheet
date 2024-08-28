using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TsClasses
{
    public partial interface ITsClassRepository
    {
        //HQSOFT's generated code:
        Task<List<TsClass>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? parentCode = null,
                    string? code = null,
                    string? name = null,
                    string? name_EN = null,
                    bool? isActive = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    string? code_Type = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );

        //Write your custom code here...
        Task<List<TsClass>> GetListByParentCode(
                    string? parentCode = null,
                    string? filterText = null,
                    string? code = null,
                    string? name = null,
                    string? name_EN = null,
                    bool? isActive = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    string? code_Type = null,
                    string? sorting = null,
                   CancellationToken cancellationToken = default
       );
    }
}
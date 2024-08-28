using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbInfoUpdates
{
    public partial interface ITbInfoUpdateRepository
    {
        //HQSOFT's generated code:
        Task<List<TbInfoUpdate>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? tableName = null,
                    string? columnName = null,
                    string? screenName = null,
                    int? screenIdMin = null,
                    int? screenIdMax = null,
                    int? rowIdMin = null,
                    int? rowIdMax = null,
                    string? command = null,
                    string? groupName = null,
                    string? lastValue = null,
                    string? newValue = null,
                    byte? docStatusMin = null,
                    byte? docStatusMax = null,
                    string? comment = null,
                    int? isActiveMin = null,
                    int? isActiveMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    Guid? changeSetId = null,
                    DateTime? timeAssessmentMin = null,
                    DateTime? timeAssessmentMax = null,
                    bool? isVisible = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
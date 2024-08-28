using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbLogSyncUats
{
    public partial interface ITbLogSyncUatRepository
    {
        //HQSOFT's generated code:
        Task<List<TbLogSyncUat>> GetListNoPagedAsync(
                    string? filterText = null,
                    DateTime? timeExportMin = null,
                    DateTime? timeExportMax = null,
                    bool? isSuccess = null,
                    int? userExportMin = null,
                    int? userExportMax = null,
                    string? reasonExportFailed = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
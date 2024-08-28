using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbLogErrors
{
    public partial interface ITbLogErrorRepository
    {
        //HQSOFT's generated code:
        Task<List<TbLogError>> GetListNoPagedAsync(
                    string? filterText = null,
                    DateTime? timeLogMin = null,
                    DateTime? timeLogMax = null,
                    int? userLogMin = null,
                    int? userLogMax = null,
                    string? iPAddress = null,
                    string? classLog = null,
                    string? functionLog = null,
                    string? reasonFailed = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
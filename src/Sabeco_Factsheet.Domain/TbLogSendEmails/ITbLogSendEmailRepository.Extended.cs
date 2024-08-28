using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbLogSendEmails
{
    public partial interface ITbLogSendEmailRepository
    {
        //HQSOFT's generated code:
        Task<List<TbLogSendEmail>> GetListNoPagedAsync(
                    string? filterText = null,
                    DateTime? timeSendMin = null,
                    DateTime? timeSendMax = null,
                    bool? isSuccess = null,
                    string? userSend = null,
                    string? typeEmail = null,
                    string? failedReason = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
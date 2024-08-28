using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbLogSendEmails
{
    public partial interface ITbLogSendEmailRepository : IRepository<TbLogSendEmail, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            DateTime? timeSendMin = null,
            DateTime? timeSendMax = null,
            bool? isSuccess = null,
            string? userSend = null,
            string? typeEmail = null,
            string? failedReason = null,
            CancellationToken cancellationToken = default);
        Task<List<TbLogSendEmail>> GetListAsync(
                    string? filterText = null,
                    DateTime? timeSendMin = null,
                    DateTime? timeSendMax = null,
                    bool? isSuccess = null,
                    string? userSend = null,
                    string? typeEmail = null,
                    string? failedReason = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            DateTime? timeSendMin = null,
            DateTime? timeSendMax = null,
            bool? isSuccess = null,
            string? userSend = null,
            string? typeEmail = null,
            string? failedReason = null,
            CancellationToken cancellationToken = default);
    }
}
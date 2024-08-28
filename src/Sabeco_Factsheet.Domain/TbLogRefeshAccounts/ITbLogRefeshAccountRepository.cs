using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public partial interface ITbLogRefeshAccountRepository : IRepository<TbLogRefeshAccount, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? accessToken = null,
            DateTime? timeRefeshMin = null,
            DateTime? timeRefeshMax = null,
            bool? isSuccess = null,
            string? useRefesh = null,
            string? failedReason = null,
            CancellationToken cancellationToken = default);
        Task<List<TbLogRefeshAccount>> GetListAsync(
                    string? filterText = null,
                    string? accessToken = null,
                    DateTime? timeRefeshMin = null,
                    DateTime? timeRefeshMax = null,
                    bool? isSuccess = null,
                    string? useRefesh = null,
                    string? failedReason = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? accessToken = null,
            DateTime? timeRefeshMin = null,
            DateTime? timeRefeshMax = null,
            bool? isSuccess = null,
            string? useRefesh = null,
            string? failedReason = null,
            CancellationToken cancellationToken = default);
    }
}
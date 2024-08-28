using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbLogLogins
{
    public partial interface ITbLogLoginRepository : IRepository<TbLogLogin, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? userName = null,
            DateTime? loginDateMin = null,
            DateTime? loginDateMax = null,
            string? iPTracking = null,
            bool? statusLogin = null,
            CancellationToken cancellationToken = default);
        Task<List<TbLogLogin>> GetListAsync(
                    string? filterText = null,
                    string? userName = null,
                    DateTime? loginDateMin = null,
                    DateTime? loginDateMax = null,
                    string? iPTracking = null,
                    bool? statusLogin = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? userName = null,
            DateTime? loginDateMin = null,
            DateTime? loginDateMax = null,
            string? iPTracking = null,
            bool? statusLogin = null,
            CancellationToken cancellationToken = default);
    }
}
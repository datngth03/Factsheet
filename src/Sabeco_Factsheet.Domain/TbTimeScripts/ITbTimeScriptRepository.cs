using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbTimeScripts
{
    public partial interface ITbTimeScriptRepository : IRepository<TbTimeScript, int>
    {

        Task DeleteAllAsync(
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
            CancellationToken cancellationToken = default);
        Task<List<TbTimeScript>> GetListAsync(
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
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}
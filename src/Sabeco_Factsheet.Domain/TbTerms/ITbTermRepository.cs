using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbTerms
{
    public partial interface ITbTermRepository : IRepository<TbTerm, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            string? termCode = null,
            int? fromYearMin = null,
            int? fromYearMax = null,
            int? toYearMin = null,
            int? toYearMax = null,
            string? description = null,
            CancellationToken cancellationToken = default);
        Task<List<TbTerm>> GetListAsync(
                    string? filterText = null,
                    int? branchIdMin = null,
                    int? branchIdMax = null,
                    string? termCode = null,
                    int? fromYearMin = null,
                    int? fromYearMax = null,
                    int? toYearMin = null,
                    int? toYearMax = null,
                    string? description = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            string? termCode = null,
            int? fromYearMin = null,
            int? fromYearMax = null,
            int? toYearMin = null,
            int? toYearMax = null,
            string? description = null,
            CancellationToken cancellationToken = default);
    }
}
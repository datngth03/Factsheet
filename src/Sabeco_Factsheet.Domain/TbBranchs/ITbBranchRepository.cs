using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbBranchs
{
    public partial interface ITbBranchRepository : IRepository<TbBranch, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? code = null,
            string? briefName = null,
            string? name = null,
            string? name_EN = null,
            string? companyCode = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_DateMin = null,
            DateTime? crt_DateMax = null,
            CancellationToken cancellationToken = default);
        Task<List<TbBranch>> GetListAsync(
                    string? filterText = null,
                    string? code = null,
                    string? briefName = null,
                    string? name = null,
                    string? name_EN = null,
                    string? companyCode = null,
                    string? description = null,
                    bool? isActive = null,
                    DateTime? crt_DateMin = null,
                    DateTime? crt_DateMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            string? briefName = null,
            string? name = null,
            string? name_EN = null,
            string? companyCode = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_DateMin = null,
            DateTime? crt_DateMax = null,
            CancellationToken cancellationToken = default);
    }
}
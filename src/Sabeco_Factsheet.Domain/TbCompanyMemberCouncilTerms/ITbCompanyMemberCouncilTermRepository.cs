using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public partial interface ITbCompanyMemberCouncilTermRepository : IRepository<TbCompanyMemberCouncilTerm, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? termFromMin = null,
            int? termFromMax = null,
            int? termEndMin = null,
            int? termEndMax = null,
            CancellationToken cancellationToken = default);
        Task<List<TbCompanyMemberCouncilTerm>> GetListAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    int? termFromMin = null,
                    int? termFromMax = null,
                    int? termEndMin = null,
                    int? termEndMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? termFromMin = null,
            int? termFromMax = null,
            int? termEndMin = null,
            int? termEndMax = null,
            CancellationToken cancellationToken = default);
    }
}
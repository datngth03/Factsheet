using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public partial interface ITbUserMappingCompanyRepository : IRepository<TbUserMappingCompany, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? companyidMin = null,
            int? companyidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default);
        Task<List<TbUserMappingCompany>> GetListAsync(
                    string? filterText = null,
                    int? useridMin = null,
                    int? useridMax = null,
                    int? companyidMin = null,
                    int? companyidMax = null,
                    bool? isActive = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? companyidMin = null,
            int? companyidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default);
    }
}
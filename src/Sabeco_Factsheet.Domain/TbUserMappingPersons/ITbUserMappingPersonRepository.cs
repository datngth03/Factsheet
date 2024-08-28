using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public partial interface ITbUserMappingPersonRepository : IRepository<TbUserMappingPerson, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? personidMin = null,
            int? personidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default);
        Task<List<TbUserMappingPerson>> GetListAsync(
                    string? filterText = null,
                    int? useridMin = null,
                    int? useridMax = null,
                    int? personidMin = null,
                    int? personidMax = null,
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
            int? personidMin = null,
            int? personidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default);
    }
}
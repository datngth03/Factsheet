using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public partial interface ITbUserMappingBreweryRepository : IRepository<TbUserMappingBrewery, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? breweryidMin = null,
            int? breweryidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default);
        Task<List<TbUserMappingBrewery>> GetListAsync(
                    string? filterText = null,
                    int? useridMin = null,
                    int? useridMax = null,
                    int? breweryidMin = null,
                    int? breweryidMax = null,
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
            int? breweryidMin = null,
            int? breweryidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default);
    }
}
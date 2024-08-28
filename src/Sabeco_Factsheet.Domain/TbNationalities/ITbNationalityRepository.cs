using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbNationalities
{
    public partial interface ITbNationalityRepository : IRepository<TbNationality, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? code = null,
            string? code2 = null,
            string? name_en = null,
            string? name_vn = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default);
        Task<List<TbNationality>> GetListAsync(
                    string? filterText = null,
                    string? code = null,
                    string? code2 = null,
                    string? name_en = null,
                    string? name_vn = null,
                    bool? isActive = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            string? code2 = null,
            string? name_en = null,
            string? name_vn = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default);
    }
}
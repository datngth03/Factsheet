using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbInvestPersons
{
    public partial interface ITbInvestPersonRepository : IRepository<TbInvestPerson, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            int? personalValueMin = null,
            int? personalValueMax = null,
            int? ownerValueMin = null,
            int? ownerValueMax = null,
            string? note = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default);
        Task<List<TbInvestPerson>> GetListAsync(
                    string? filterText = null,
                    int? parentIdMin = null,
                    int? parentIdMax = null,
                    int? personIdMin = null,
                    int? personIdMax = null,
                    DateTime? fromDateMin = null,
                    DateTime? fromDateMax = null,
                    int? personalValueMin = null,
                    int? personalValueMax = null,
                    int? ownerValueMin = null,
                    int? ownerValueMax = null,
                    string? note = null,
                    bool? isActive = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    bool? isDeleted = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            int? personalValueMin = null,
            int? personalValueMax = null,
            int? ownerValueMin = null,
            int? ownerValueMax = null,
            string? note = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default);
    }
}
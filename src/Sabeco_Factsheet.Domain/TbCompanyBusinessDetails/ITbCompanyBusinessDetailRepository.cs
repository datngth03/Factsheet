using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbCompanyBusinessDetails
{
    public partial interface ITbCompanyBusinessDetailRepository : IRepository<TbCompanyBusinessDetail, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            string? registrationCode = null,
            string? registrationName = null,
            string? registrationName_EN = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            CancellationToken cancellationToken = default);
        Task<List<TbCompanyBusinessDetail>> GetListAsync(
                    string? filterText = null,
                    int? parentIdMin = null,
                    int? parentIdMax = null,
                    string? registrationCode = null,
                    string? registrationName = null,
                    string? registrationName_EN = null,
                    bool? isActive = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            string? registrationCode = null,
            string? registrationName = null,
            string? registrationName_EN = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            CancellationToken cancellationToken = default);
    }
}
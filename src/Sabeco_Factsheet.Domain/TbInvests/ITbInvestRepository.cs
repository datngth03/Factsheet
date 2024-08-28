using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbInvests
{
    public partial interface ITbInvestRepository : IRepository<TbInvest, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? branchCode = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            int? shareNumTotalMin = null,
            int? shareNumTotalMax = null,
            decimal? shareValueTotalMin = null,
            decimal? shareValueTotalMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? investGroup = null,
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
        Task<List<TbInvest>> GetListAsync(
                    string? filterText = null,
                    string? branchCode = null,
                    int? branchIdMin = null,
                    int? branchIdMax = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    string? companyCode = null,
                    int? shareNumTotalMin = null,
                    int? shareNumTotalMax = null,
                    decimal? shareValueTotalMin = null,
                    decimal? shareValueTotalMax = null,
                    string? note = null,
                    byte? docStatusMin = null,
                    byte? docStatusMax = null,
                    bool? investGroup = null,
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
            string? branchCode = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            int? shareNumTotalMin = null,
            int? shareNumTotalMax = null,
            decimal? shareValueTotalMin = null,
            decimal? shareValueTotalMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? investGroup = null,
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
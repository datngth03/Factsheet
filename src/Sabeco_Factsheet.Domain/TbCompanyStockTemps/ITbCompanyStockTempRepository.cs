using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbCompanyStockTemps
{
    public partial interface ITbCompanyStockTempRepository : IRepository<TbCompanyStockTemp, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            bool? isPublicCompany = null,
            string? stockExchange = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            decimal? charteredCapitalMin = null,
            decimal? charteredCapitalMax = null,
            decimal? parValueMin = null,
            decimal? parValueMax = null,
            int? totalShareMin = null,
            int? totalShareMax = null,
            int? listedShareMin = null,
            int? listedShareMax = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            CancellationToken cancellationToken = default);
        Task<List<TbCompanyStockTemp>> GetListAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    string? companyCode = null,
                    bool? isPublicCompany = null,
                    string? stockExchange = null,
                    DateTime? registrationDateMin = null,
                    DateTime? registrationDateMax = null,
                    decimal? charteredCapitalMin = null,
                    decimal? charteredCapitalMax = null,
                    decimal? parValueMin = null,
                    decimal? parValueMax = null,
                    int? totalShareMin = null,
                    int? totalShareMax = null,
                    int? listedShareMin = null,
                    int? listedShareMax = null,
                    string? description = null,
                    bool? isActive = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            bool? isPublicCompany = null,
            string? stockExchange = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            decimal? charteredCapitalMin = null,
            decimal? charteredCapitalMax = null,
            decimal? parValueMin = null,
            decimal? parValueMax = null,
            int? totalShareMin = null,
            int? totalShareMax = null,
            int? listedShareMin = null,
            int? listedShareMax = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            CancellationToken cancellationToken = default);
    }
}
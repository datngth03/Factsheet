using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbBrewerySkus
{
    public partial interface ITbBrewerySkuRepository : IRepository<TbBrewerySku, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? yearMin = null,
            int? yearMax = null,
            string? breweryCode = null,
            string? sKUCode = null,
            decimal? productionVolumeMin = null,
            decimal? productionVolumeMax = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? breweryIdMin = null,
            int? breweryIdMax = null,
            int? sKUIdMin = null,
            int? sKUIdMax = null,
            CancellationToken cancellationToken = default);
        Task<List<TbBrewerySku>> GetListAsync(
                    string? filterText = null,
                    int? yearMin = null,
                    int? yearMax = null,
                    string? breweryCode = null,
                    string? sKUCode = null,
                    decimal? productionVolumeMin = null,
                    decimal? productionVolumeMax = null,
                    byte? docStatusMin = null,
                    byte? docStatusMax = null,
                    bool? isActive = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    int? breweryIdMin = null,
                    int? breweryIdMax = null,
                    int? sKUIdMin = null,
                    int? sKUIdMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? yearMin = null,
            int? yearMax = null,
            string? breweryCode = null,
            string? sKUCode = null,
            decimal? productionVolumeMin = null,
            decimal? productionVolumeMax = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? breweryIdMin = null,
            int? breweryIdMax = null,
            int? sKUIdMin = null,
            int? sKUIdMax = null,
            CancellationToken cancellationToken = default);
    }
}
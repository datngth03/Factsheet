using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbAssets
{
    public partial interface ITbAssetRepository : IRepository<TbAsset, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? assetType = null,
            string? assetItem = null,
            string? assetAddress = null,
            decimal? quantityMin = null,
            decimal? quantityMax = null,
            string? docNo = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            DateTime? expireDateMin = null,
            DateTime? expireDateMax = null,
            string? description = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            bool? isDeleted = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            CancellationToken cancellationToken = default);
        Task<List<TbAsset>> GetListAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    string? assetType = null,
                    string? assetItem = null,
                    string? assetAddress = null,
                    decimal? quantityMin = null,
                    decimal? quantityMax = null,
                    string? docNo = null,
                    DateTime? docDateMin = null,
                    DateTime? docDateMax = null,
                    DateTime? expireDateMin = null,
                    DateTime? expireDateMax = null,
                    string? description = null,
                    byte? docStatusMin = null,
                    byte? docStatusMax = null,
                    bool? isActive = null,
                    bool? isDeleted = null,
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
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? assetType = null,
            string? assetItem = null,
            string? assetAddress = null,
            decimal? quantityMin = null,
            decimal? quantityMax = null,
            string? docNo = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            DateTime? expireDateMin = null,
            DateTime? expireDateMax = null,
            string? description = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            bool? isDeleted = null,
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
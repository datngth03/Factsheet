using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbCompanyMajorTemps
{
    public partial interface ITbCompanyMajorTempRepository : IRepository<TbCompanyMajorTemp, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? shareHolderMajor = null,
            string? shareHolderType = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            decimal? shareHolderValueMin = null,
            decimal? shareHolderValueMax = null,
            decimal? shareHolderRateMin = null,
            decimal? shareHolderRateMax = null,
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
            int? classIdMin = null,
            int? classIdMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default);
        Task<List<TbCompanyMajorTemp>> GetListAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    string? shareHolderMajor = null,
                    string? shareHolderType = null,
                    DateTime? fromDateMin = null,
                    DateTime? fromDateMax = null,
                    DateTime? toDateMin = null,
                    DateTime? toDateMax = null,
                    decimal? shareHolderValueMin = null,
                    decimal? shareHolderValueMax = null,
                    decimal? shareHolderRateMin = null,
                    decimal? shareHolderRateMax = null,
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
                    int? classIdMin = null,
                    int? classIdMax = null,
                    bool? isDeleted = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? shareHolderMajor = null,
            string? shareHolderType = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            decimal? shareHolderValueMin = null,
            decimal? shareHolderValueMax = null,
            decimal? shareHolderRateMin = null,
            decimal? shareHolderRateMax = null,
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
            int? classIdMin = null,
            int? classIdMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default);
    }
}
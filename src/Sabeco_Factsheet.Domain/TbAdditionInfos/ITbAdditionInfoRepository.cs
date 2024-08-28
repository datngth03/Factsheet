using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbAdditionInfos
{
    public partial interface ITbAdditionInfoRepository : IRepository<TbAdditionInfo, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            string? typeOfGroup = null,
            string? typeOfEvent = null,
            string? description = null,
            string? noOfDocument = null,
            string? remark = null,
            bool? isActive = null,
            int? create_userMin = null,
            int? create_userMax = null,
            DateTime? create_dateMin = null,
            DateTime? create_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            CancellationToken cancellationToken = default);
        Task<List<TbAdditionInfo>> GetListAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    DateTime? docDateMin = null,
                    DateTime? docDateMax = null,
                    string? typeOfGroup = null,
                    string? typeOfEvent = null,
                    string? description = null,
                    string? noOfDocument = null,
                    string? remark = null,
                    bool? isActive = null,
                    int? create_userMin = null,
                    int? create_userMax = null,
                    DateTime? create_dateMin = null,
                    DateTime? create_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            string? typeOfGroup = null,
            string? typeOfEvent = null,
            string? description = null,
            string? noOfDocument = null,
            string? remark = null,
            bool? isActive = null,
            int? create_userMin = null,
            int? create_userMax = null,
            DateTime? create_dateMin = null,
            DateTime? create_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            CancellationToken cancellationToken = default);
    }
}
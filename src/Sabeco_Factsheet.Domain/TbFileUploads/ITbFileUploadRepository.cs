using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbFileUploads
{
    public partial interface ITbFileUploadRepository : IRepository<TbFileUpload, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            string? fileName = null,
            string? fullFileName = null,
            string? fileLink = null,
            DateTime? uploadDateMin = null,
            DateTime? uploadDateMax = null,
            int? userUploadMin = null,
            int? userUploadMax = null,
            string? note = null,
            bool? isActive = null,
            int? downloadCountMin = null,
            int? downloadCountMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            CancellationToken cancellationToken = default);
        Task<List<TbFileUpload>> GetListAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    int? personIdMin = null,
                    int? personIdMax = null,
                    string? fileName = null,
                    string? fullFileName = null,
                    string? fileLink = null,
                    DateTime? uploadDateMin = null,
                    DateTime? uploadDateMax = null,
                    int? userUploadMin = null,
                    int? userUploadMax = null,
                    string? note = null,
                    bool? isActive = null,
                    int? downloadCountMin = null,
                    int? downloadCountMax = null,
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
            int? personIdMin = null,
            int? personIdMax = null,
            string? fileName = null,
            string? fullFileName = null,
            string? fileLink = null,
            DateTime? uploadDateMin = null,
            DateTime? uploadDateMax = null,
            int? userUploadMin = null,
            int? userUploadMax = null,
            string? note = null,
            bool? isActive = null,
            int? downloadCountMin = null,
            int? downloadCountMax = null,
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
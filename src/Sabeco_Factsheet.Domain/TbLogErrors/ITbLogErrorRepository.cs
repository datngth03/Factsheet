using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbLogErrors
{
    public partial interface ITbLogErrorRepository : IRepository<TbLogError, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            DateTime? timeLogMin = null,
            DateTime? timeLogMax = null,
            int? userLogMin = null,
            int? userLogMax = null,
            string? iPAddress = null,
            string? classLog = null,
            string? functionLog = null,
            string? reasonFailed = null,
            CancellationToken cancellationToken = default);
        Task<List<TbLogError>> GetListAsync(
                    string? filterText = null,
                    DateTime? timeLogMin = null,
                    DateTime? timeLogMax = null,
                    int? userLogMin = null,
                    int? userLogMax = null,
                    string? iPAddress = null,
                    string? classLog = null,
                    string? functionLog = null,
                    string? reasonFailed = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            DateTime? timeLogMin = null,
            DateTime? timeLogMax = null,
            int? userLogMin = null,
            int? userLogMax = null,
            string? iPAddress = null,
            string? classLog = null,
            string? functionLog = null,
            string? reasonFailed = null,
            CancellationToken cancellationToken = default);
    }
}
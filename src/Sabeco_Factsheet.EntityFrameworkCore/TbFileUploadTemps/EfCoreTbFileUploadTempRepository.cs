using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Sabeco_Factsheet.EntityFrameworkCore;

namespace Sabeco_Factsheet.TbFileUploadTemps
{
    public abstract class EfCoreTbFileUploadTempRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbFileUploadTemp, int>
    {
        public EfCoreTbFileUploadTempRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
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
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, companyIdMin, companyIdMax, personIdMin, personIdMax, fileName, fullFileName, fileLink, uploadDateMin, uploadDateMax, userUploadMin, userUploadMax, note, isActive, downloadCountMin, downloadCountMax, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbFileUploadTemp>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, personIdMin, personIdMax, fileName, fullFileName, fileLink, uploadDateMin, uploadDateMax, userUploadMin, userUploadMax, note, isActive, downloadCountMin, downloadCountMax, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbFileUploadTempConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyIdMin, companyIdMax, personIdMin, personIdMax, fileName, fullFileName, fileLink, uploadDateMin, uploadDateMax, userUploadMin, userUploadMax, note, isActive, downloadCountMin, downloadCountMax, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbFileUploadTemp> ApplyFilter(
            IQueryable<TbFileUploadTemp> query,
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
            int? mod_userMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.fileName.ToLower().Contains(filterText.ToLower()) || e.fullFileName.ToLower().Contains(filterText.ToLower()) || e.fileLink.ToLower().Contains(filterText.ToLower()) || e.note.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.companyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.companyId <= companyIdMax!.Value)
                    .WhereIf(personIdMin.HasValue, e => e.personId >= personIdMin!.Value)
                    .WhereIf(personIdMax.HasValue, e => e.personId <= personIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(fileName), e => e.fileName.ToLower().Contains(fileName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(fullFileName), e => e.fullFileName.ToLower().Contains(fullFileName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(fileLink), e => e.fileLink.ToLower().Contains(fileLink.ToLower()))
                    .WhereIf(uploadDateMin.HasValue, e => e.uploadDate >= uploadDateMin!.Value)
                    .WhereIf(uploadDateMax.HasValue, e => e.uploadDate <= uploadDateMax!.Value)
                    .WhereIf(userUploadMin.HasValue, e => e.UserUpload >= userUploadMin!.Value)
                    .WhereIf(userUploadMax.HasValue, e => e.UserUpload <= userUploadMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.note.ToLower().Contains(note.ToLower()))
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(downloadCountMin.HasValue, e => e.DownloadCount >= downloadCountMin!.Value)
                    .WhereIf(downloadCountMax.HasValue, e => e.DownloadCount <= downloadCountMax!.Value)
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value);
        }
    }
}
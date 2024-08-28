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
    public class EfCoreTbFileUploadTempRepository : EfCoreTbFileUploadTempRepositoryBase, ITbFileUploadTempRepository
    {
        public EfCoreTbFileUploadTempRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbFileUploadTemp>> GetListNoPagedAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, personIdMin, personIdMax, fileName, fullFileName, fileLink, uploadDateMin, uploadDateMax, userUploadMin, userUploadMax, note, isActive, downloadCountMin, downloadCountMax, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbFileUploadTempConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}
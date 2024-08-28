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

namespace Sabeco_Factsheet.TbHisPersons
{
    public class EfCoreTbHisPersonRepository : EfCoreTbHisPersonRepositoryBase, ITbHisPersonRepository
    {
        public EfCoreTbHisPersonRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbHisPerson>> GetListNoPagedAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idPersonMin = null,
            int? idPersonMax = null,
            string? code = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? fullName = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string? birthPlace = null,
            string? address = null,
            string? iDCardNo = null,
            DateTime? iDCardDateMin = null,
            DateTime? iDCardDateMax = null,
            string? idCardIssuePlace = null,
            string? ethnicity = null,
            string? religion = null,
            string? nationalityCode = null,
            string? gender = null,
            string? phone = null,
            string? email = null,
            string? note = null,
            string? image = null,
            bool? isActive = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isCheckRetirement = null,
            bool? isCheckTermEnd = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            string? oldCode = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idPersonMin, idPersonMax, code, companyIdMin, companyIdMax, fullName, birthDateMin, birthDateMax, birthPlace, address, iDCardNo, iDCardDateMin, iDCardDateMax, idCardIssuePlace, ethnicity, religion, nationalityCode, gender, phone, email, note, image, isActive, docStatusMin, docStatusMax, isCheckRetirement, isCheckTermEnd, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, oldCode);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbHisPersonConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}
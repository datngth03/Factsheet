using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Sabeco_Factsheet.Permissions;
using Sabeco_Factsheet.TbCompanyMemberCouncilTerms;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public class TbCompanyMemberCouncilTermsAppService : TbCompanyMemberCouncilTermsAppServiceBase, ITbCompanyMemberCouncilTermsAppService
    {
        //<suite-custom-code-autogenerated>
        public TbCompanyMemberCouncilTermsAppService(ITbCompanyMemberCouncilTermRepository tbCompanyMemberCouncilTermRepository, TbCompanyMemberCouncilTermManager tbCompanyMemberCouncilTermManager, IDistributedCache<TbCompanyMemberCouncilTermDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbCompanyMemberCouncilTermRepository, tbCompanyMemberCouncilTermManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbCompanyMemberCouncilTermDto>> GetListNoPagedAsync(GetTbCompanyMemberCouncilTermsInput input)
        {
            var items = await _tbCompanyMemberCouncilTermRepository.GetListNoPagedAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.TermFromMin, input.TermFromMax, input.TermEndMin, input.TermEndMax, input.Sorting);

            return ObjectMapper.Map<List<TbCompanyMemberCouncilTerm>, List<TbCompanyMemberCouncilTermDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
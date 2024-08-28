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
using Sabeco_Factsheet.TbCompanyMappingTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMappingTemps
{
    public class TbCompanyMappingTempsAppService : TbCompanyMappingTempsAppServiceBase, ITbCompanyMappingTempsAppService
    {
        //<suite-custom-code-autogenerated>
        public TbCompanyMappingTempsAppService(ITbCompanyMappingTempRepository tbCompanyMappingTempRepository, TbCompanyMappingTempManager tbCompanyMappingTempManager, IDistributedCache<TbCompanyMappingTempDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbCompanyMappingTempRepository, tbCompanyMappingTempManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbCompanyMappingTempDto>> GetListNoPagedAsync(GetTbCompanyMappingTempsInput input)
        {
            var items = await _tbCompanyMappingTempRepository.GetListNoPagedAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.CompanyTypeShareholdingCode, input.CompanyTypesCode, input.Note, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.idCompanyTypeShareholdingCodeMin, input.idCompanyTypeShareholdingCodeMax, input.idCompanyTypesCodeMin, input.idCompanyTypesCodeMax, input.Sorting);

            return ObjectMapper.Map<List<TbCompanyMappingTemp>, List<TbCompanyMappingTempDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
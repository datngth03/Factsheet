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
using Sabeco_Factsheet.TbCompanyMajors;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMajors
{
    public class TbCompanyMajorsAppService : TbCompanyMajorsAppServiceBase, ITbCompanyMajorsAppService
    {
        //<suite-custom-code-autogenerated>
        public TbCompanyMajorsAppService(ITbCompanyMajorRepository tbCompanyMajorRepository, TbCompanyMajorManager tbCompanyMajorManager, IDistributedCache<TbCompanyMajorDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbCompanyMajorRepository, tbCompanyMajorManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbCompanyMajorDto>> GetListNoPagedAsync(GetTbCompanyMajorsInput input)
        {
            var items = await _tbCompanyMajorRepository.GetListNoPagedAsync(input.FilterText, input.CompanyIdMin, input.CompanyIdMax, input.ShareHolderMajor, input.ShareHolderType, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.ShareHolderValueMin, input.ShareHolderValueMax, input.ShareHolderRateMin, input.ShareHolderRateMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.ClassIdMin, input.ClassIdMax, input.IsDeleted, input.Sorting);

            return ObjectMapper.Map<List<TbCompanyMajor>, List<TbCompanyMajorDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
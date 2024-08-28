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
using Sabeco_Factsheet.TbLogRefeshAccounts;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public class TbLogRefeshAccountsAppService : TbLogRefeshAccountsAppServiceBase, ITbLogRefeshAccountsAppService
    {
        //<suite-custom-code-autogenerated>
        public TbLogRefeshAccountsAppService(ITbLogRefeshAccountRepository tbLogRefeshAccountRepository, TbLogRefeshAccountManager tbLogRefeshAccountManager, IDistributedCache<TbLogRefeshAccountDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbLogRefeshAccountRepository, tbLogRefeshAccountManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbLogRefeshAccountDto>> GetListNoPagedAsync(GetTbLogRefeshAccountsInput input)
        {
            var items = await _tbLogRefeshAccountRepository.GetListNoPagedAsync(input.FilterText, input.AccessToken, input.TimeRefeshMin, input.TimeRefeshMax, input.IsSuccess, input.UseRefesh, input.FailedReason, input.Sorting);

            return ObjectMapper.Map<List<TbLogRefeshAccount>, List<TbLogRefeshAccountDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
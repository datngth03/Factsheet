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
using Sabeco_Factsheet.TbLogSyncUats;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogSyncUats
{
    public class TbLogSyncUatsAppService : TbLogSyncUatsAppServiceBase, ITbLogSyncUatsAppService
    {
        //<suite-custom-code-autogenerated>
        public TbLogSyncUatsAppService(ITbLogSyncUatRepository tbLogSyncUatRepository, TbLogSyncUatManager tbLogSyncUatManager, IDistributedCache<TbLogSyncUatDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbLogSyncUatRepository, tbLogSyncUatManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbLogSyncUatDto>> GetListNoPagedAsync(GetTbLogSyncUatsInput input)
        {
            var items = await _tbLogSyncUatRepository.GetListNoPagedAsync(input.FilterText, input.TimeExportMin, input.TimeExportMax, input.IsSuccess, input.UserExportMin, input.UserExportMax, input.ReasonExportFailed, input.Sorting);

            return ObjectMapper.Map<List<TbLogSyncUat>, List<TbLogSyncUatDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
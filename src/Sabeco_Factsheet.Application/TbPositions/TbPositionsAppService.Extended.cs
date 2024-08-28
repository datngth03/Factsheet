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
using Sabeco_Factsheet.TbPositions;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbPositions
{
    public class TbPositionsAppService : TbPositionsAppServiceBase, ITbPositionsAppService
    {
        //<suite-custom-code-autogenerated>
        public TbPositionsAppService(ITbPositionRepository tbPositionRepository, TbPositionManager tbPositionManager, IDistributedCache<TbPositionDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbPositionRepository, tbPositionManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbPositionDto>> GetListNoPagedAsync(GetTbPositionsInput input)
        {
            var items = await _tbPositionRepository.GetListNoPagedAsync(input.FilterText, input.Code, input.Name, input.Name_EN, input.PositionTypeMin, input.PositionTypeMax, input.IsActive, input.crt_userMin, input.crt_userMax, input.ctr_dateMin, input.ctr_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.OrderNumbMin, input.OrderNumbMax, input.IsDeleted, input.Sorting);

            return ObjectMapper.Map<List<TbPosition>, List<TbPositionDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
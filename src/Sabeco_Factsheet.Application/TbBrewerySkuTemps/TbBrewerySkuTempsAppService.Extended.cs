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
using Sabeco_Factsheet.TbBrewerySkuTemps;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBrewerySkuTemps
{
    public class TbBrewerySkuTempsAppService : TbBrewerySkuTempsAppServiceBase, ITbBrewerySkuTempsAppService
    {
        //<suite-custom-code-autogenerated>
        public TbBrewerySkuTempsAppService(ITbBrewerySkuTempRepository tbBrewerySkuTempRepository, TbBrewerySkuTempManager tbBrewerySkuTempManager, IDistributedCache<TbBrewerySkuTempDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbBrewerySkuTempRepository, tbBrewerySkuTempManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbBrewerySkuTempDto>> GetListNoPagedAsync(GetTbBrewerySkuTempsInput input)
        {
            var items = await _tbBrewerySkuTempRepository.GetListNoPagedAsync(input.FilterText, input.idBrewerySKUMin, input.idBrewerySKUMax, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax, input.Sorting);

            return ObjectMapper.Map<List<TbBrewerySkuTemp>, List<TbBrewerySkuTempDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
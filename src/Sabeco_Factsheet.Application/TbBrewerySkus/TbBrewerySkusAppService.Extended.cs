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
using Sabeco_Factsheet.TbBrewerySkus;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;
using Sabeco_Factsheet.TbBreweryDeliveryVolumes;

namespace Sabeco_Factsheet.TbBrewerySkus
{
    public class TbBrewerySkusAppService : TbBrewerySkusAppServiceBase, ITbBrewerySkusAppService
    {
        //<suite-custom-code-autogenerated>
        public TbBrewerySkusAppService(ITbBrewerySkuRepository tbBrewerySkuRepository, TbBrewerySkuManager tbBrewerySkuManager, IDistributedCache<TbBrewerySkuDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbBrewerySkuRepository, tbBrewerySkuManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbBrewerySkuDto>> GetListNoPagedAsync(GetTbBrewerySkusInput input)
        {
            var items = await _tbBrewerySkuRepository.GetListNoPagedAsync(input.FilterText, input.YearMin, input.YearMax, input.BreweryCode, input.SKUCode, input.ProductionVolumeMin, input.ProductionVolumeMax, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.BreweryIdMin, input.BreweryIdMax, input.SKUIdMin, input.SKUIdMax, input.Sorting);

            return ObjectMapper.Map<List<TbBrewerySku>, List<TbBrewerySkuDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
        public virtual async Task<List<TbBrewerySkuDto>> GetListByBreweryId(int id)
        {
            var items = await _tbBrewerySkuRepository.GetListByBreweryId(id);
            return ObjectMapper.Map<List<TbBrewerySku>, List<TbBrewerySkuDto>>(items);
        }
    }
}
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
using Sabeco_Factsheet.TbBreweries;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweries
{
    public class TbBreweriesAppService : TbBreweriesAppServiceBase, ITbBreweriesAppService
    {
        //<suite-custom-code-autogenerated>
        public TbBreweriesAppService(ITbBreweryRepository tbBreweryRepository, TbBreweryManager tbBreweryManager, IDistributedCache<TbBreweryDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbBreweryRepository, tbBreweryManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbBreweryDto>> GetListNoPagedAsync(GetTbBreweriesInput input)
        {
            var items = await _tbBreweryRepository.GetListNoPagedAsync(input.FilterText, input.BreweryCode, input.BreweryName, input.BreweryName_EN, input.BriefName, input.BreweryAdress, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting);

            return ObjectMapper.Map<List<TbBrewery>, List<TbBreweryDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
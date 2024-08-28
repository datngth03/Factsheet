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
using Sabeco_Factsheet.TbBreweryDeliveryVolumes;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumes
{
    public class TbBreweryDeliveryVolumesAppService : TbBreweryDeliveryVolumesAppServiceBase, ITbBreweryDeliveryVolumesAppService
    {
        //<suite-custom-code-autogenerated>
        public TbBreweryDeliveryVolumesAppService(ITbBreweryDeliveryVolumeRepository tbBreweryDeliveryVolumeRepository, TbBreweryDeliveryVolumeManager tbBreweryDeliveryVolumeManager, IDistributedCache<TbBreweryDeliveryVolumeDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbBreweryDeliveryVolumeRepository, tbBreweryDeliveryVolumeManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbBreweryDeliveryVolumeDto>> GetListNoPagedAsync(GetTbBreweryDeliveryVolumesInput input)
        {
            var items = await _tbBreweryDeliveryVolumeRepository.GetListNoPagedAsync(input.FilterText, input.BreweryIdMin, input.BreweryIdMax, input.BreweryCode, input.YearMin, input.YearMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.isActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting);

            return ObjectMapper.Map<List<TbBreweryDeliveryVolume>, List<TbBreweryDeliveryVolumeDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
        public virtual async Task<List<TbBreweryDeliveryVolumeDto>> GetListByBreweryId(int id)
        {
            var items = await _tbBreweryDeliveryVolumeRepository.GetListByBreweryId(id);
            return ObjectMapper.Map<List<TbBreweryDeliveryVolume>, List<TbBreweryDeliveryVolumeDto>>(items);
        }
    }
}
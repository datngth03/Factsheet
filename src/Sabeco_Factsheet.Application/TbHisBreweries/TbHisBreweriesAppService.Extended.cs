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
using Sabeco_Factsheet.TbHisBreweries;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisBreweries
{
    public class TbHisBreweriesAppService : TbHisBreweriesAppServiceBase, ITbHisBreweriesAppService
    {
        //<suite-custom-code-autogenerated>
        public TbHisBreweriesAppService(ITbHisBreweryRepository tbHisBreweryRepository, TbHisBreweryManager tbHisBreweryManager, IDistributedCache<TbHisBreweryDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbHisBreweryRepository, tbHisBreweryManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbHisBreweryDto>> GetListNoPagedAsync(GetTbHisBreweriesInput input)
        {
            var items = await _tbHisBreweryRepository.GetListNoPagedAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdBreweryMin, input.IdBreweryMax, input.BreweryName, input.BreweryName_EN, input.BreweryAdress, input.BriefName, input.CompanyIdMin, input.CompanyIdMax, input.CapacityVolumeMin, input.CapacityVolumeMax, input.DeliveryVolumeMin, input.DeliveryVolumeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.IsActive, input.create_userMin, input.create_userMax, input.create_dateMin, input.create_dateMax, input.mod_userMin, input.mod_userMax, input.mod_dateMin, input.mod_dateMax, input.Sorting);

            return ObjectMapper.Map<List<TbHisBrewery>, List<TbHisBreweryDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
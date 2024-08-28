using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public abstract class TbUserMappingBreweryManagerBase : DomainService
    {
        public ITbUserMappingBreweryRepository _tbUserMappingBreweryRepository;

        public TbUserMappingBreweryManagerBase(ITbUserMappingBreweryRepository tbUserMappingBreweryRepository)
        {
            _tbUserMappingBreweryRepository = tbUserMappingBreweryRepository;
        }

        public virtual async Task<TbUserMappingBrewery> CreateAsync(
        int? userid = null, int? breweryid = null, bool? isActive = null)
        {

            var tbUserMappingBrewery = new TbUserMappingBrewery(

             userid, breweryid, isActive
             );

            return await _tbUserMappingBreweryRepository.InsertAsync(tbUserMappingBrewery);
        }

        public virtual async Task<TbUserMappingBrewery> UpdateAsync(
            int id,
            int? userid = null, int? breweryid = null, bool? isActive = null
        )
        {

            var tbUserMappingBrewery = await _tbUserMappingBreweryRepository.GetAsync(id);

            tbUserMappingBrewery.userid = userid;
            tbUserMappingBrewery.breweryid = breweryid;
            tbUserMappingBrewery.IsActive = isActive;

            return await _tbUserMappingBreweryRepository.UpdateAsync(tbUserMappingBrewery);
        }

    }
}
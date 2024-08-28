using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbBreweryImages
{
    public abstract class TbBreweryImageManagerBase : DomainService
    {
        public ITbBreweryImageRepository _tbBreweryImageRepository;

        public TbBreweryImageManagerBase(ITbBreweryImageRepository tbBreweryImageRepository)
        {
            _tbBreweryImageRepository = tbBreweryImageRepository;
        }

        public virtual async Task<TbBreweryImage> CreateAsync(
        int? companyId = null, string? breweryImage = null, string? imageLink = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            var tbBreweryImage = new TbBreweryImage(

             companyId, breweryImage, imageLink, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbBreweryImageRepository.InsertAsync(tbBreweryImage);
        }

        public virtual async Task<TbBreweryImage> UpdateAsync(
            int id,
            int? companyId = null, string? breweryImage = null, string? imageLink = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {

            var tbBreweryImage = await _tbBreweryImageRepository.GetAsync(id);

            tbBreweryImage.CompanyId = companyId;
            tbBreweryImage.BreweryImage = breweryImage;
            tbBreweryImage.ImageLink = imageLink;
            tbBreweryImage.isActive = isActive;
            tbBreweryImage.create_user = create_user;
            tbBreweryImage.create_date = create_date;
            tbBreweryImage.mod_user = mod_user;
            tbBreweryImage.mod_date = mod_date;

            return await _tbBreweryImageRepository.UpdateAsync(tbBreweryImage);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyBranchImages
{
    public abstract class TbCompanyBranchImageManagerBase : DomainService
    {
        public ITbCompanyBranchImageRepository _tbCompanyBranchImageRepository;

        public TbCompanyBranchImageManagerBase(ITbCompanyBranchImageRepository tbCompanyBranchImageRepository)
        {
            _tbCompanyBranchImageRepository = tbCompanyBranchImageRepository;
        }

        public virtual async Task<TbCompanyBranchImage> CreateAsync(
        int? companyId = null, string? branchImage = null, string? imageLink = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            var tbCompanyBranchImage = new TbCompanyBranchImage(

             companyId, branchImage, imageLink, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbCompanyBranchImageRepository.InsertAsync(tbCompanyBranchImage);
        }

        public virtual async Task<TbCompanyBranchImage> UpdateAsync(
            int id,
            int? companyId = null, string? branchImage = null, string? imageLink = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {

            var tbCompanyBranchImage = await _tbCompanyBranchImageRepository.GetAsync(id);

            tbCompanyBranchImage.CompanyId = companyId;
            tbCompanyBranchImage.BranchImage = branchImage;
            tbCompanyBranchImage.ImageLink = imageLink;
            tbCompanyBranchImage.isActive = isActive;
            tbCompanyBranchImage.create_user = create_user;
            tbCompanyBranchImage.create_date = create_date;
            tbCompanyBranchImage.mod_user = mod_user;
            tbCompanyBranchImage.mod_date = mod_date;

            return await _tbCompanyBranchImageRepository.UpdateAsync(tbCompanyBranchImage);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbLandInfos
{
    public abstract class TbLandInfoManagerBase : DomainService
    {
        public ITbLandInfoRepository _tbLandInfoRepository;

        public TbLandInfoManagerBase(ITbLandInfoRepository tbLandInfoRepository)
        {
            _tbLandInfoRepository = tbLandInfoRepository;
        }

        public virtual async Task<TbLandInfo> CreateAsync(
        int companyId, string typeOfLand, string? description = null, string? address = null, decimal? area = null, string? supportingDocument = null, DateTime? issueDate = null, DateTime? expiryDate = null, string? payment = null, string? remark = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.NotNullOrWhiteSpace(typeOfLand, nameof(typeOfLand));

            var tbLandInfo = new TbLandInfo(

             companyId, typeOfLand, description, address, area, supportingDocument, issueDate, expiryDate, payment, remark, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbLandInfoRepository.InsertAsync(tbLandInfo);
        }

        public virtual async Task<TbLandInfo> UpdateAsync(
            int id,
            int companyId, string typeOfLand, string? description = null, string? address = null, decimal? area = null, string? supportingDocument = null, DateTime? issueDate = null, DateTime? expiryDate = null, string? payment = null, string? remark = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.NotNullOrWhiteSpace(typeOfLand, nameof(typeOfLand));

            var tbLandInfo = await _tbLandInfoRepository.GetAsync(id);

            tbLandInfo.CompanyId = companyId;
            tbLandInfo.TypeOfLand = typeOfLand;
            tbLandInfo.Description = description;
            tbLandInfo.Address = address;
            tbLandInfo.Area = area;
            tbLandInfo.SupportingDocument = supportingDocument;
            tbLandInfo.IssueDate = issueDate;
            tbLandInfo.ExpiryDate = expiryDate;
            tbLandInfo.Payment = payment;
            tbLandInfo.Remark = remark;
            tbLandInfo.IsActive = isActive;
            tbLandInfo.create_user = create_user;
            tbLandInfo.create_date = create_date;
            tbLandInfo.mod_user = mod_user;
            tbLandInfo.mod_date = mod_date;

            return await _tbLandInfoRepository.UpdateAsync(tbLandInfo);
        }

    }
}
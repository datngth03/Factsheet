using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbLandInfoTemps
{
    public abstract class TbLandInfoTempManagerBase : DomainService
    {
        public ITbLandInfoTempRepository _tbLandInfoTempRepository;

        public TbLandInfoTempManagerBase(ITbLandInfoTempRepository tbLandInfoTempRepository)
        {
            _tbLandInfoTempRepository = tbLandInfoTempRepository;
        }

        public virtual async Task<TbLandInfoTemp> CreateAsync(
        int companyId, string typeOfLand, string? description = null, string? address = null, decimal? area = null, string? supportingDocument = null, DateTime? issueDate = null, DateTime? expiryDate = null, string? payment = null, string? remark = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.NotNullOrWhiteSpace(typeOfLand, nameof(typeOfLand));

            var tbLandInfoTemp = new TbLandInfoTemp(

             companyId, typeOfLand, description, address, area, supportingDocument, issueDate, expiryDate, payment, remark, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbLandInfoTempRepository.InsertAsync(tbLandInfoTemp);
        }

        public virtual async Task<TbLandInfoTemp> UpdateAsync(
            int id,
            int companyId, string typeOfLand, string? description = null, string? address = null, decimal? area = null, string? supportingDocument = null, DateTime? issueDate = null, DateTime? expiryDate = null, string? payment = null, string? remark = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.NotNullOrWhiteSpace(typeOfLand, nameof(typeOfLand));

            var tbLandInfoTemp = await _tbLandInfoTempRepository.GetAsync(id);

            tbLandInfoTemp.CompanyId = companyId;
            tbLandInfoTemp.TypeOfLand = typeOfLand;
            tbLandInfoTemp.Description = description;
            tbLandInfoTemp.Address = address;
            tbLandInfoTemp.Area = area;
            tbLandInfoTemp.SupportingDocument = supportingDocument;
            tbLandInfoTemp.IssueDate = issueDate;
            tbLandInfoTemp.ExpiryDate = expiryDate;
            tbLandInfoTemp.Payment = payment;
            tbLandInfoTemp.Remark = remark;
            tbLandInfoTemp.IsActive = isActive;
            tbLandInfoTemp.create_user = create_user;
            tbLandInfoTemp.create_date = create_date;
            tbLandInfoTemp.mod_user = mod_user;
            tbLandInfoTemp.mod_date = mod_date;

            return await _tbLandInfoTempRepository.UpdateAsync(tbLandInfoTemp);
        }

    }
}
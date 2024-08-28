using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbAdditionInfoTemps
{
    public abstract class TbAdditionInfoTempManagerBase : DomainService
    {
        public ITbAdditionInfoTempRepository _tbAdditionInfoTempRepository;

        public TbAdditionInfoTempManagerBase(ITbAdditionInfoTempRepository tbAdditionInfoTempRepository)
        {
            _tbAdditionInfoTempRepository = tbAdditionInfoTempRepository;
        }

        public virtual async Task<TbAdditionInfoTemp> CreateAsync(
        int companyId, DateTime? docDate = null, string? typeOfGroup = null, string? typeOfEvent = null, string? description = null, string? noOfDocument = null, string? remark = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.Length(typeOfGroup, nameof(typeOfGroup), TbAdditionInfoTempConsts.TypeOfGroupMaxLength);

            var tbAdditionInfoTemp = new TbAdditionInfoTemp(

             companyId, docDate, typeOfGroup, typeOfEvent, description, noOfDocument, remark, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbAdditionInfoTempRepository.InsertAsync(tbAdditionInfoTemp);
        }

        public virtual async Task<TbAdditionInfoTemp> UpdateAsync(
            int id,
            int companyId, DateTime? docDate = null, string? typeOfGroup = null, string? typeOfEvent = null, string? description = null, string? noOfDocument = null, string? remark = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.Length(typeOfGroup, nameof(typeOfGroup), TbAdditionInfoTempConsts.TypeOfGroupMaxLength);

            var tbAdditionInfoTemp = await _tbAdditionInfoTempRepository.GetAsync(id);

            tbAdditionInfoTemp.CompanyId = companyId;
            tbAdditionInfoTemp.DocDate = docDate;
            tbAdditionInfoTemp.TypeOfGroup = typeOfGroup;
            tbAdditionInfoTemp.TypeOfEvent = typeOfEvent;
            tbAdditionInfoTemp.Description = description;
            tbAdditionInfoTemp.NoOfDocument = noOfDocument;
            tbAdditionInfoTemp.Remark = remark;
            tbAdditionInfoTemp.IsActive = isActive;
            tbAdditionInfoTemp.create_user = create_user;
            tbAdditionInfoTemp.create_date = create_date;
            tbAdditionInfoTemp.mod_user = mod_user;
            tbAdditionInfoTemp.mod_date = mod_date;

            return await _tbAdditionInfoTempRepository.UpdateAsync(tbAdditionInfoTemp);
        }

    }
}
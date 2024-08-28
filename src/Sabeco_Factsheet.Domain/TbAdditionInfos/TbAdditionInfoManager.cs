using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbAdditionInfos
{
    public abstract class TbAdditionInfoManagerBase : DomainService
    {
        public ITbAdditionInfoRepository _tbAdditionInfoRepository;

        public TbAdditionInfoManagerBase(ITbAdditionInfoRepository tbAdditionInfoRepository)
        {
            _tbAdditionInfoRepository = tbAdditionInfoRepository;
        }

        public virtual async Task<TbAdditionInfo> CreateAsync(
        int companyId, DateTime? docDate = null, string? typeOfGroup = null, string? typeOfEvent = null, string? description = null, string? noOfDocument = null, string? remark = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.Length(typeOfGroup, nameof(typeOfGroup), TbAdditionInfoConsts.TypeOfGroupMaxLength);

            var tbAdditionInfo = new TbAdditionInfo(

             companyId, docDate, typeOfGroup, typeOfEvent, description, noOfDocument, remark, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbAdditionInfoRepository.InsertAsync(tbAdditionInfo);
        }

        public virtual async Task<TbAdditionInfo> UpdateAsync(
            int id,
            int companyId, DateTime? docDate = null, string? typeOfGroup = null, string? typeOfEvent = null, string? description = null, string? noOfDocument = null, string? remark = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.Length(typeOfGroup, nameof(typeOfGroup), TbAdditionInfoConsts.TypeOfGroupMaxLength);

            var tbAdditionInfo = await _tbAdditionInfoRepository.GetAsync(id);

            tbAdditionInfo.CompanyId = companyId;
            tbAdditionInfo.DocDate = docDate;
            tbAdditionInfo.TypeOfGroup = typeOfGroup;
            tbAdditionInfo.TypeOfEvent = typeOfEvent;
            tbAdditionInfo.Description = description;
            tbAdditionInfo.NoOfDocument = noOfDocument;
            tbAdditionInfo.Remark = remark;
            tbAdditionInfo.IsActive = isActive;
            tbAdditionInfo.create_user = create_user;
            tbAdditionInfo.create_date = create_date;
            tbAdditionInfo.mod_user = mod_user;
            tbAdditionInfo.mod_date = mod_date;

            return await _tbAdditionInfoRepository.UpdateAsync(tbAdditionInfo);
        }

    }
}
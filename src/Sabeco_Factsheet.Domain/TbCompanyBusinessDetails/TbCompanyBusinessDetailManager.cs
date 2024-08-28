using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyBusinessDetails
{
    public abstract class TbCompanyBusinessDetailManagerBase : DomainService
    {
        public ITbCompanyBusinessDetailRepository _tbCompanyBusinessDetailRepository;

        public TbCompanyBusinessDetailManagerBase(ITbCompanyBusinessDetailRepository tbCompanyBusinessDetailRepository)
        {
            _tbCompanyBusinessDetailRepository = tbCompanyBusinessDetailRepository;
        }

        public virtual async Task<TbCompanyBusinessDetail> CreateAsync(
        int parentId, string registrationCode, string? registrationName = null, string? registrationName_EN = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.NotNullOrWhiteSpace(registrationCode, nameof(registrationCode));
            Check.Length(registrationCode, nameof(registrationCode), TbCompanyBusinessDetailConsts.RegistrationCodeMaxLength);
            Check.Length(registrationName, nameof(registrationName), TbCompanyBusinessDetailConsts.RegistrationNameMaxLength);
            Check.Length(registrationName_EN, nameof(registrationName_EN), TbCompanyBusinessDetailConsts.RegistrationName_ENMaxLength);

            var tbCompanyBusinessDetail = new TbCompanyBusinessDetail(

             parentId, registrationCode, registrationName, registrationName_EN, isActive, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbCompanyBusinessDetailRepository.InsertAsync(tbCompanyBusinessDetail);
        }

        public virtual async Task<TbCompanyBusinessDetail> UpdateAsync(
            int id,
            int parentId, string registrationCode, string? registrationName = null, string? registrationName_EN = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.NotNullOrWhiteSpace(registrationCode, nameof(registrationCode));
            Check.Length(registrationCode, nameof(registrationCode), TbCompanyBusinessDetailConsts.RegistrationCodeMaxLength);
            Check.Length(registrationName, nameof(registrationName), TbCompanyBusinessDetailConsts.RegistrationNameMaxLength);
            Check.Length(registrationName_EN, nameof(registrationName_EN), TbCompanyBusinessDetailConsts.RegistrationName_ENMaxLength);

            var tbCompanyBusinessDetail = await _tbCompanyBusinessDetailRepository.GetAsync(id);

            tbCompanyBusinessDetail.ParentId = parentId;
            tbCompanyBusinessDetail.RegistrationCode = registrationCode;
            tbCompanyBusinessDetail.RegistrationName = registrationName;
            tbCompanyBusinessDetail.RegistrationName_EN = registrationName_EN;
            tbCompanyBusinessDetail.IsActive = isActive;
            tbCompanyBusinessDetail.crt_date = crt_date;
            tbCompanyBusinessDetail.crt_user = crt_user;
            tbCompanyBusinessDetail.mod_date = mod_date;
            tbCompanyBusinessDetail.mod_user = mod_user;

            return await _tbCompanyBusinessDetailRepository.UpdateAsync(tbCompanyBusinessDetail);
        }

    }
}
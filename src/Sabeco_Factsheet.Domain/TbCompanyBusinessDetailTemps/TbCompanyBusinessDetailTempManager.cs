using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyBusinessDetailTemps
{
    public abstract class TbCompanyBusinessDetailTempManagerBase : DomainService
    {
        public ITbCompanyBusinessDetailTempRepository _tbCompanyBusinessDetailTempRepository;

        public TbCompanyBusinessDetailTempManagerBase(ITbCompanyBusinessDetailTempRepository tbCompanyBusinessDetailTempRepository)
        {
            _tbCompanyBusinessDetailTempRepository = tbCompanyBusinessDetailTempRepository;
        }

        public virtual async Task<TbCompanyBusinessDetailTemp> CreateAsync(
        int parentId, string registrationCode, string? registrationName = null, string? registrationName_EN = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.NotNullOrWhiteSpace(registrationCode, nameof(registrationCode));
            Check.Length(registrationCode, nameof(registrationCode), TbCompanyBusinessDetailTempConsts.RegistrationCodeMaxLength);
            Check.Length(registrationName, nameof(registrationName), TbCompanyBusinessDetailTempConsts.RegistrationNameMaxLength);
            Check.Length(registrationName_EN, nameof(registrationName_EN), TbCompanyBusinessDetailTempConsts.RegistrationName_ENMaxLength);

            var tbCompanyBusinessDetailTemp = new TbCompanyBusinessDetailTemp(

             parentId, registrationCode, registrationName, registrationName_EN, isActive, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbCompanyBusinessDetailTempRepository.InsertAsync(tbCompanyBusinessDetailTemp);
        }

        public virtual async Task<TbCompanyBusinessDetailTemp> UpdateAsync(
            int id,
            int parentId, string registrationCode, string? registrationName = null, string? registrationName_EN = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.NotNullOrWhiteSpace(registrationCode, nameof(registrationCode));
            Check.Length(registrationCode, nameof(registrationCode), TbCompanyBusinessDetailTempConsts.RegistrationCodeMaxLength);
            Check.Length(registrationName, nameof(registrationName), TbCompanyBusinessDetailTempConsts.RegistrationNameMaxLength);
            Check.Length(registrationName_EN, nameof(registrationName_EN), TbCompanyBusinessDetailTempConsts.RegistrationName_ENMaxLength);

            var tbCompanyBusinessDetailTemp = await _tbCompanyBusinessDetailTempRepository.GetAsync(id);

            tbCompanyBusinessDetailTemp.ParentId = parentId;
            tbCompanyBusinessDetailTemp.RegistrationCode = registrationCode;
            tbCompanyBusinessDetailTemp.RegistrationName = registrationName;
            tbCompanyBusinessDetailTemp.RegistrationName_EN = registrationName_EN;
            tbCompanyBusinessDetailTemp.IsActive = isActive;
            tbCompanyBusinessDetailTemp.crt_date = crt_date;
            tbCompanyBusinessDetailTemp.crt_user = crt_user;
            tbCompanyBusinessDetailTemp.mod_date = mod_date;
            tbCompanyBusinessDetailTemp.mod_user = mod_user;

            return await _tbCompanyBusinessDetailTempRepository.UpdateAsync(tbCompanyBusinessDetailTemp);
        }

    }
}
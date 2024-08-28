using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyMappingTemps
{
    public abstract class TbCompanyMappingTempManagerBase : DomainService
    {
        public ITbCompanyMappingTempRepository _tbCompanyMappingTempRepository;

        public TbCompanyMappingTempManagerBase(ITbCompanyMappingTempRepository tbCompanyMappingTempRepository)
        {
            _tbCompanyMappingTempRepository = tbCompanyMappingTempRepository;
        }

        public virtual async Task<TbCompanyMappingTemp> CreateAsync(
        int? companyId = null, string? companyTypeShareholdingCode = null, string? companyTypesCode = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? idCompanyTypeShareholdingCode = null, int? idCompanyTypesCode = null)
        {

            var tbCompanyMappingTemp = new TbCompanyMappingTemp(

             companyId, companyTypeShareholdingCode, companyTypesCode, note, crt_date, crt_user, mod_date, mod_user, idCompanyTypeShareholdingCode, idCompanyTypesCode
             );

            return await _tbCompanyMappingTempRepository.InsertAsync(tbCompanyMappingTemp);
        }

        public virtual async Task<TbCompanyMappingTemp> UpdateAsync(
            int id,
            int? companyId = null, string? companyTypeShareholdingCode = null, string? companyTypesCode = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? idCompanyTypeShareholdingCode = null, int? idCompanyTypesCode = null
        )
        {

            var tbCompanyMappingTemp = await _tbCompanyMappingTempRepository.GetAsync(id);

            tbCompanyMappingTemp.CompanyId = companyId;
            tbCompanyMappingTemp.CompanyTypeShareholdingCode = companyTypeShareholdingCode;
            tbCompanyMappingTemp.CompanyTypesCode = companyTypesCode;
            tbCompanyMappingTemp.Note = note;
            tbCompanyMappingTemp.crt_date = crt_date;
            tbCompanyMappingTemp.crt_user = crt_user;
            tbCompanyMappingTemp.mod_date = mod_date;
            tbCompanyMappingTemp.mod_user = mod_user;
            tbCompanyMappingTemp.idCompanyTypeShareholdingCode = idCompanyTypeShareholdingCode;
            tbCompanyMappingTemp.idCompanyTypesCode = idCompanyTypesCode;

            return await _tbCompanyMappingTempRepository.UpdateAsync(tbCompanyMappingTemp);
        }

    }
}
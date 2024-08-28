using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyMappings
{
    public abstract class TbCompanyMappingManagerBase : DomainService
    {
        public ITbCompanyMappingRepository _tbCompanyMappingRepository;

        public TbCompanyMappingManagerBase(ITbCompanyMappingRepository tbCompanyMappingRepository)
        {
            _tbCompanyMappingRepository = tbCompanyMappingRepository;
        }

        public virtual async Task<TbCompanyMapping> CreateAsync(
        int? companyId = null, string? companyTypeShareholdingCode = null, string? companyTypesCode = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? idCompanyTypeShareholdingCode = null, int? idCompanyTypesCode = null)
        {

            var tbCompanyMapping = new TbCompanyMapping(

             companyId, companyTypeShareholdingCode, companyTypesCode, note, crt_date, crt_user, mod_date, mod_user, idCompanyTypeShareholdingCode, idCompanyTypesCode
             );

            return await _tbCompanyMappingRepository.InsertAsync(tbCompanyMapping);
        }

        public virtual async Task<TbCompanyMapping> UpdateAsync(
            int id,
            int? companyId = null, string? companyTypeShareholdingCode = null, string? companyTypesCode = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? idCompanyTypeShareholdingCode = null, int? idCompanyTypesCode = null
        )
        {

            var tbCompanyMapping = await _tbCompanyMappingRepository.GetAsync(id);

            tbCompanyMapping.CompanyId = companyId;
            tbCompanyMapping.CompanyTypeShareholdingCode = companyTypeShareholdingCode;
            tbCompanyMapping.CompanyTypesCode = companyTypesCode;
            tbCompanyMapping.Note = note;
            tbCompanyMapping.crt_date = crt_date;
            tbCompanyMapping.crt_user = crt_user;
            tbCompanyMapping.mod_date = mod_date;
            tbCompanyMapping.mod_user = mod_user;
            tbCompanyMapping.idCompanyTypeShareholdingCode = idCompanyTypeShareholdingCode;
            tbCompanyMapping.idCompanyTypesCode = idCompanyTypesCode;

            return await _tbCompanyMappingRepository.UpdateAsync(tbCompanyMapping);
        }

    }
}
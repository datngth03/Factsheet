using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyMajorTemps
{
    public abstract class TbCompanyMajorTempManagerBase : DomainService
    {
        public ITbCompanyMajorTempRepository _tbCompanyMajorTempRepository;

        public TbCompanyMajorTempManagerBase(ITbCompanyMajorTempRepository tbCompanyMajorTempRepository)
        {
            _tbCompanyMajorTempRepository = tbCompanyMajorTempRepository;
        }

        public virtual async Task<TbCompanyMajorTemp> CreateAsync(
        int companyId, string shareHolderMajor, string shareHolderType, bool isActive, bool isDeleted, DateTime? fromDate = null, DateTime? toDate = null, decimal? shareHolderValue = null, decimal? shareHolderRate = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? classId = null)
        {
            Check.NotNullOrWhiteSpace(shareHolderMajor, nameof(shareHolderMajor));
            Check.NotNullOrWhiteSpace(shareHolderType, nameof(shareHolderType));
            Check.Length(shareHolderType, nameof(shareHolderType), TbCompanyMajorTempConsts.ShareHolderTypeMaxLength);
            Check.Length(note, nameof(note), TbCompanyMajorTempConsts.NoteMaxLength);

            var tbCompanyMajorTemp = new TbCompanyMajorTemp(

             companyId, shareHolderMajor, shareHolderType, isActive, isDeleted, fromDate, toDate, shareHolderValue, shareHolderRate, note, crt_date, crt_user, mod_date, mod_user, classId
             );

            return await _tbCompanyMajorTempRepository.InsertAsync(tbCompanyMajorTemp);
        }

        public virtual async Task<TbCompanyMajorTemp> UpdateAsync(
            int id,
            int companyId, string shareHolderMajor, string shareHolderType, bool isActive, bool isDeleted, DateTime? fromDate = null, DateTime? toDate = null, decimal? shareHolderValue = null, decimal? shareHolderRate = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? classId = null
        )
        {
            Check.NotNullOrWhiteSpace(shareHolderMajor, nameof(shareHolderMajor));
            Check.NotNullOrWhiteSpace(shareHolderType, nameof(shareHolderType));
            Check.Length(shareHolderType, nameof(shareHolderType), TbCompanyMajorTempConsts.ShareHolderTypeMaxLength);
            Check.Length(note, nameof(note), TbCompanyMajorTempConsts.NoteMaxLength);

            var tbCompanyMajorTemp = await _tbCompanyMajorTempRepository.GetAsync(id);

            tbCompanyMajorTemp.CompanyId = companyId;
            tbCompanyMajorTemp.ShareHolderMajor = shareHolderMajor;
            tbCompanyMajorTemp.ShareHolderType = shareHolderType;
            tbCompanyMajorTemp.IsActive = isActive;
            tbCompanyMajorTemp.IsDeleted = isDeleted;
            tbCompanyMajorTemp.FromDate = fromDate;
            tbCompanyMajorTemp.ToDate = toDate;
            tbCompanyMajorTemp.ShareHolderValue = shareHolderValue;
            tbCompanyMajorTemp.ShareHolderRate = shareHolderRate;
            tbCompanyMajorTemp.Note = note;
            tbCompanyMajorTemp.crt_date = crt_date;
            tbCompanyMajorTemp.crt_user = crt_user;
            tbCompanyMajorTemp.mod_date = mod_date;
            tbCompanyMajorTemp.mod_user = mod_user;
            tbCompanyMajorTemp.ClassId = classId;

            return await _tbCompanyMajorTempRepository.UpdateAsync(tbCompanyMajorTemp);
        }

    }
}
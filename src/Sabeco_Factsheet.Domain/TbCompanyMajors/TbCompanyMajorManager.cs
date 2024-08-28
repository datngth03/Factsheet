using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyMajors
{
    public abstract class TbCompanyMajorManagerBase : DomainService
    {
        public ITbCompanyMajorRepository _tbCompanyMajorRepository;

        public TbCompanyMajorManagerBase(ITbCompanyMajorRepository tbCompanyMajorRepository)
        {
            _tbCompanyMajorRepository = tbCompanyMajorRepository;
        }

        public virtual async Task<TbCompanyMajor> CreateAsync(
        int companyId, string shareHolderMajor, string shareHolderType, bool isActive, bool isDeleted, DateTime? fromDate = null, DateTime? toDate = null, decimal? shareHolderValue = null, decimal? shareHolderRate = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? classId = null)
        {
            Check.NotNullOrWhiteSpace(shareHolderMajor, nameof(shareHolderMajor));
            Check.NotNullOrWhiteSpace(shareHolderType, nameof(shareHolderType));
            Check.Length(shareHolderType, nameof(shareHolderType), TbCompanyMajorConsts.ShareHolderTypeMaxLength);
            Check.Length(note, nameof(note), TbCompanyMajorConsts.NoteMaxLength);

            var tbCompanyMajor = new TbCompanyMajor(

             companyId, shareHolderMajor, shareHolderType, isActive, isDeleted, fromDate, toDate, shareHolderValue, shareHolderRate, note, crt_date, crt_user, mod_date, mod_user, classId
             );

            return await _tbCompanyMajorRepository.InsertAsync(tbCompanyMajor);
        }

        public virtual async Task<TbCompanyMajor> UpdateAsync(
            int id,
            int companyId, string shareHolderMajor, string shareHolderType, bool isActive, bool isDeleted, DateTime? fromDate = null, DateTime? toDate = null, decimal? shareHolderValue = null, decimal? shareHolderRate = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? classId = null
        )
        {
            Check.NotNullOrWhiteSpace(shareHolderMajor, nameof(shareHolderMajor));
            Check.NotNullOrWhiteSpace(shareHolderType, nameof(shareHolderType));
            Check.Length(shareHolderType, nameof(shareHolderType), TbCompanyMajorConsts.ShareHolderTypeMaxLength);
            Check.Length(note, nameof(note), TbCompanyMajorConsts.NoteMaxLength);

            var tbCompanyMajor = await _tbCompanyMajorRepository.GetAsync(id);

            tbCompanyMajor.CompanyId = companyId;
            tbCompanyMajor.ShareHolderMajor = shareHolderMajor;
            tbCompanyMajor.ShareHolderType = shareHolderType;
            tbCompanyMajor.IsActive = isActive;
            tbCompanyMajor.IsDeleted = isDeleted;
            tbCompanyMajor.FromDate = fromDate;
            tbCompanyMajor.ToDate = toDate;
            tbCompanyMajor.ShareHolderValue = shareHolderValue;
            tbCompanyMajor.ShareHolderRate = shareHolderRate;
            tbCompanyMajor.Note = note;
            tbCompanyMajor.crt_date = crt_date;
            tbCompanyMajor.crt_user = crt_user;
            tbCompanyMajor.mod_date = mod_date;
            tbCompanyMajor.mod_user = mod_user;
            tbCompanyMajor.ClassId = classId;

            return await _tbCompanyMajorRepository.UpdateAsync(tbCompanyMajor);
        }

    }
}
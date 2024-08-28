using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbInvestPersons
{
    public abstract class TbInvestPersonManagerBase : DomainService
    {
        public ITbInvestPersonRepository _tbInvestPersonRepository;

        public TbInvestPersonManagerBase(ITbInvestPersonRepository tbInvestPersonRepository)
        {
            _tbInvestPersonRepository = tbInvestPersonRepository;
        }

        public virtual async Task<TbInvestPerson> CreateAsync(
        int parentId, int personId, DateTime fromDate, bool isDeleted, int? personalValue = null, int? ownerValue = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.NotNull(fromDate, nameof(fromDate));
            Check.Length(note, nameof(note), TbInvestPersonConsts.NoteMaxLength);

            var tbInvestPerson = new TbInvestPerson(

             parentId, personId, fromDate, isDeleted, personalValue, ownerValue, note, isActive, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbInvestPersonRepository.InsertAsync(tbInvestPerson);
        }

        public virtual async Task<TbInvestPerson> UpdateAsync(
            int id,
            int parentId, int personId, DateTime fromDate, bool isDeleted, int? personalValue = null, int? ownerValue = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.NotNull(fromDate, nameof(fromDate));
            Check.Length(note, nameof(note), TbInvestPersonConsts.NoteMaxLength);

            var tbInvestPerson = await _tbInvestPersonRepository.GetAsync(id);

            tbInvestPerson.ParentId = parentId;
            tbInvestPerson.PersonId = personId;
            tbInvestPerson.FromDate = fromDate;
            tbInvestPerson.IsDeleted = isDeleted;
            tbInvestPerson.PersonalValue = personalValue;
            tbInvestPerson.OwnerValue = ownerValue;
            tbInvestPerson.Note = note;
            tbInvestPerson.IsActive = isActive;
            tbInvestPerson.crt_date = crt_date;
            tbInvestPerson.crt_user = crt_user;
            tbInvestPerson.mod_date = mod_date;
            tbInvestPerson.mod_user = mod_user;

            return await _tbInvestPersonRepository.UpdateAsync(tbInvestPerson);
        }

    }
}
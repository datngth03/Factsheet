using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbContacts
{
    public abstract class TbContactManagerBase : DomainService
    {
        public ITbContactRepository _tbContactRepository;

        public TbContactManagerBase(ITbContactRepository tbContactRepository)
        {
            _tbContactRepository = tbContactRepository;
        }

        public virtual async Task<TbContact> CreateAsync(
        int companyid, string contactName, bool isActive, bool isDeleted, string? contactDept = null, string? contactPosition = null, string? contactEmail = null, string? contactPhone = null, string? note = null, byte? docStatus = null, int? crt_user = null, DateTime? crt_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.NotNullOrWhiteSpace(contactName, nameof(contactName));
            Check.Length(contactName, nameof(contactName), TbContactConsts.ContactNameMaxLength);
            Check.Length(contactDept, nameof(contactDept), TbContactConsts.ContactDeptMaxLength);
            Check.Length(contactPosition, nameof(contactPosition), TbContactConsts.ContactPositionMaxLength);
            Check.Length(contactEmail, nameof(contactEmail), TbContactConsts.ContactEmailMaxLength);
            Check.Length(contactPhone, nameof(contactPhone), TbContactConsts.ContactPhoneMaxLength);
            Check.Length(note, nameof(note), TbContactConsts.NoteMaxLength);

            var tbContact = new TbContact(

             companyid, contactName, isActive, isDeleted, contactDept, contactPosition, contactEmail, contactPhone, note, docStatus, crt_user, crt_date, mod_user, mod_date
             );

            return await _tbContactRepository.InsertAsync(tbContact);
        }

        public virtual async Task<TbContact> UpdateAsync(
            int id,
            int companyid, string contactName, bool isActive, bool isDeleted, string? contactDept = null, string? contactPosition = null, string? contactEmail = null, string? contactPhone = null, string? note = null, byte? docStatus = null, int? crt_user = null, DateTime? crt_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.NotNullOrWhiteSpace(contactName, nameof(contactName));
            Check.Length(contactName, nameof(contactName), TbContactConsts.ContactNameMaxLength);
            Check.Length(contactDept, nameof(contactDept), TbContactConsts.ContactDeptMaxLength);
            Check.Length(contactPosition, nameof(contactPosition), TbContactConsts.ContactPositionMaxLength);
            Check.Length(contactEmail, nameof(contactEmail), TbContactConsts.ContactEmailMaxLength);
            Check.Length(contactPhone, nameof(contactPhone), TbContactConsts.ContactPhoneMaxLength);
            Check.Length(note, nameof(note), TbContactConsts.NoteMaxLength);

            var tbContact = await _tbContactRepository.GetAsync(id);

            tbContact.companyid = companyid;
            tbContact.ContactName = contactName;
            tbContact.IsActive = isActive;
            tbContact.IsDeleted = isDeleted;
            tbContact.ContactDept = contactDept;
            tbContact.ContactPosition = contactPosition;
            tbContact.ContactEmail = contactEmail;
            tbContact.ContactPhone = contactPhone;
            tbContact.Note = note;
            tbContact.DocStatus = docStatus;
            tbContact.crt_user = crt_user;
            tbContact.crt_date = crt_date;
            tbContact.mod_user = mod_user;
            tbContact.mod_date = mod_date;

            return await _tbContactRepository.UpdateAsync(tbContact);
        }

    }
}
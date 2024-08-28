using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbContactTemps
{
    public abstract class TbContactTempManagerBase : DomainService
    {
        public ITbContactTempRepository _tbContactTempRepository;

        public TbContactTempManagerBase(ITbContactTempRepository tbContactTempRepository)
        {
            _tbContactTempRepository = tbContactTempRepository;
        }

        public virtual async Task<TbContactTemp> CreateAsync(
        int companyid, string contactName, bool isActive, bool isDeleted, string? contactDept = null, string? contactPosition = null, string? contactEmail = null, string? contactPhone = null, string? note = null, byte? docStatus = null, int? crt_user = null, DateTime? crt_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.NotNullOrWhiteSpace(contactName, nameof(contactName));
            Check.Length(contactName, nameof(contactName), TbContactTempConsts.ContactNameMaxLength);
            Check.Length(contactDept, nameof(contactDept), TbContactTempConsts.ContactDeptMaxLength);
            Check.Length(contactPosition, nameof(contactPosition), TbContactTempConsts.ContactPositionMaxLength);
            Check.Length(contactEmail, nameof(contactEmail), TbContactTempConsts.ContactEmailMaxLength);
            Check.Length(contactPhone, nameof(contactPhone), TbContactTempConsts.ContactPhoneMaxLength);
            Check.Length(note, nameof(note), TbContactTempConsts.NoteMaxLength);

            var tbContactTemp = new TbContactTemp(

             companyid, contactName, isActive, isDeleted, contactDept, contactPosition, contactEmail, contactPhone, note, docStatus, crt_user, crt_date, mod_user, mod_date
             );

            return await _tbContactTempRepository.InsertAsync(tbContactTemp);
        }

        public virtual async Task<TbContactTemp> UpdateAsync(
            int id,
            int companyid, string contactName, bool isActive, bool isDeleted, string? contactDept = null, string? contactPosition = null, string? contactEmail = null, string? contactPhone = null, string? note = null, byte? docStatus = null, int? crt_user = null, DateTime? crt_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.NotNullOrWhiteSpace(contactName, nameof(contactName));
            Check.Length(contactName, nameof(contactName), TbContactTempConsts.ContactNameMaxLength);
            Check.Length(contactDept, nameof(contactDept), TbContactTempConsts.ContactDeptMaxLength);
            Check.Length(contactPosition, nameof(contactPosition), TbContactTempConsts.ContactPositionMaxLength);
            Check.Length(contactEmail, nameof(contactEmail), TbContactTempConsts.ContactEmailMaxLength);
            Check.Length(contactPhone, nameof(contactPhone), TbContactTempConsts.ContactPhoneMaxLength);
            Check.Length(note, nameof(note), TbContactTempConsts.NoteMaxLength);

            var tbContactTemp = await _tbContactTempRepository.GetAsync(id);

            tbContactTemp.companyid = companyid;
            tbContactTemp.ContactName = contactName;
            tbContactTemp.IsActive = isActive;
            tbContactTemp.IsDeleted = isDeleted;
            tbContactTemp.ContactDept = contactDept;
            tbContactTemp.ContactPosition = contactPosition;
            tbContactTemp.ContactEmail = contactEmail;
            tbContactTemp.ContactPhone = contactPhone;
            tbContactTemp.Note = note;
            tbContactTemp.DocStatus = docStatus;
            tbContactTemp.crt_user = crt_user;
            tbContactTemp.crt_date = crt_date;
            tbContactTemp.mod_user = mod_user;
            tbContactTemp.mod_date = mod_date;

            return await _tbContactTempRepository.UpdateAsync(tbContactTemp);
        }

    }
}
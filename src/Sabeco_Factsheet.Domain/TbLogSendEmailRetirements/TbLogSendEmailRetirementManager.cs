using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public abstract class TbLogSendEmailRetirementManagerBase : DomainService
    {
        public ITbLogSendEmailRetirementRepository _tbLogSendEmailRetirementRepository;

        public TbLogSendEmailRetirementManagerBase(ITbLogSendEmailRetirementRepository tbLogSendEmailRetirementRepository)
        {
            _tbLogSendEmailRetirementRepository = tbLogSendEmailRetirementRepository;
        }

        public virtual async Task<TbLogSendEmailRetirement> CreateAsync(
        int? idCompany = null, int? idPerson = null, bool? isSendEmail = null, DateTime? dateSendEmail = null, int? type = null)
        {

            var tbLogSendEmailRetirement = new TbLogSendEmailRetirement(

             idCompany, idPerson, isSendEmail, dateSendEmail, type
             );

            return await _tbLogSendEmailRetirementRepository.InsertAsync(tbLogSendEmailRetirement);
        }

        public virtual async Task<TbLogSendEmailRetirement> UpdateAsync(
            int id,
            int? idCompany = null, int? idPerson = null, bool? isSendEmail = null, DateTime? dateSendEmail = null, int? type = null
        )
        {

            var tbLogSendEmailRetirement = await _tbLogSendEmailRetirementRepository.GetAsync(id);

            tbLogSendEmailRetirement.idCompany = idCompany;
            tbLogSendEmailRetirement.idPerson = idPerson;
            tbLogSendEmailRetirement.IsSendEmail = isSendEmail;
            tbLogSendEmailRetirement.DateSendEmail = dateSendEmail;
            tbLogSendEmailRetirement.Type = type;

            return await _tbLogSendEmailRetirementRepository.UpdateAsync(tbLogSendEmailRetirement);
        }

    }
}
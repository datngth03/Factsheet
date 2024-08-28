using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbHisLogPrintings
{
    public abstract class TbHisLogPrintingManagerBase : DomainService
    {
        public ITbHisLogPrintingRepository _tbHisLogPrintingRepository;

        public TbHisLogPrintingManagerBase(ITbHisLogPrintingRepository tbHisLogPrintingRepository)
        {
            _tbHisLogPrintingRepository = tbHisLogPrintingRepository;
        }

        public virtual async Task<TbHisLogPrinting> CreateAsync(
        DateTime insertDate, bool? isSendMail = null, DateTime? dateSendMail = null, int? type = null, string? userName = null, string? companyCode = null, string? fileLanguage = null, bool? isPrinting = null)
        {
            Check.NotNull(insertDate, nameof(insertDate));
            Check.Length(userName, nameof(userName), TbHisLogPrintingConsts.UserNameMaxLength);
            Check.Length(companyCode, nameof(companyCode), TbHisLogPrintingConsts.CompanyCodeMaxLength);
            Check.Length(fileLanguage, nameof(fileLanguage), TbHisLogPrintingConsts.FileLanguageMaxLength);

            var tbHisLogPrinting = new TbHisLogPrinting(

             insertDate, isSendMail, dateSendMail, type, userName, companyCode, fileLanguage, isPrinting
             );

            return await _tbHisLogPrintingRepository.InsertAsync(tbHisLogPrinting);
        }

        public virtual async Task<TbHisLogPrinting> UpdateAsync(
            int id,
            DateTime insertDate, bool? isSendMail = null, DateTime? dateSendMail = null, int? type = null, string? userName = null, string? companyCode = null, string? fileLanguage = null, bool? isPrinting = null
        )
        {
            Check.NotNull(insertDate, nameof(insertDate));
            Check.Length(userName, nameof(userName), TbHisLogPrintingConsts.UserNameMaxLength);
            Check.Length(companyCode, nameof(companyCode), TbHisLogPrintingConsts.CompanyCodeMaxLength);
            Check.Length(fileLanguage, nameof(fileLanguage), TbHisLogPrintingConsts.FileLanguageMaxLength);

            var tbHisLogPrinting = await _tbHisLogPrintingRepository.GetAsync(id);

            tbHisLogPrinting.InsertDate = insertDate;
            tbHisLogPrinting.IsSendMail = isSendMail;
            tbHisLogPrinting.DateSendMail = dateSendMail;
            tbHisLogPrinting.Type = type;
            tbHisLogPrinting.UserName = userName;
            tbHisLogPrinting.CompanyCode = companyCode;
            tbHisLogPrinting.FileLanguage = fileLanguage;
            tbHisLogPrinting.IsPrinting = isPrinting;

            return await _tbHisLogPrintingRepository.UpdateAsync(tbHisLogPrinting);
        }

    }
}
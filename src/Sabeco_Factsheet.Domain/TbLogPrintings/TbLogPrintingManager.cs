using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbLogPrintings
{
    public abstract class TbLogPrintingManagerBase : DomainService
    {
        public ITbLogPrintingRepository _tbLogPrintingRepository;

        public TbLogPrintingManagerBase(ITbLogPrintingRepository tbLogPrintingRepository)
        {
            _tbLogPrintingRepository = tbLogPrintingRepository;
        }

        public virtual async Task<TbLogPrinting> CreateAsync(
        string? userName = null, string? companyCode = null, string? fileLanguage = null, bool? isPrinting = null, DateTime? printTime = null)
        {
            Check.Length(userName, nameof(userName), TbLogPrintingConsts.userNameMaxLength);
            Check.Length(companyCode, nameof(companyCode), TbLogPrintingConsts.companyCodeMaxLength);
            Check.Length(fileLanguage, nameof(fileLanguage), TbLogPrintingConsts.fileLanguageMaxLength);

            var tbLogPrinting = new TbLogPrinting(

             userName, companyCode, fileLanguage, isPrinting, printTime
             );

            return await _tbLogPrintingRepository.InsertAsync(tbLogPrinting);
        }

        public virtual async Task<TbLogPrinting> UpdateAsync(
            int id,
            string? userName = null, string? companyCode = null, string? fileLanguage = null, bool? isPrinting = null, DateTime? printTime = null
        )
        {
            Check.Length(userName, nameof(userName), TbLogPrintingConsts.userNameMaxLength);
            Check.Length(companyCode, nameof(companyCode), TbLogPrintingConsts.companyCodeMaxLength);
            Check.Length(fileLanguage, nameof(fileLanguage), TbLogPrintingConsts.fileLanguageMaxLength);

            var tbLogPrinting = await _tbLogPrintingRepository.GetAsync(id);

            tbLogPrinting.userName = userName;
            tbLogPrinting.companyCode = companyCode;
            tbLogPrinting.fileLanguage = fileLanguage;
            tbLogPrinting.isPrinting = isPrinting;
            tbLogPrinting.printTime = printTime;

            return await _tbLogPrintingRepository.UpdateAsync(tbLogPrinting);
        }

    }
}
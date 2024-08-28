using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogPrintings
{
    public abstract class TbLogPrintingUpdateDtoBase : AuditedEntityDto<int>
    {
        [StringLength(TbLogPrintingConsts.userNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? userName { get; set; }
        [StringLength(TbLogPrintingConsts.companyCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? companyCode { get; set; }
        [StringLength(TbLogPrintingConsts.fileLanguageMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? fileLanguage { get; set; }
        public bool? isPrinting { get; set; }
        public DateTime? printTime { get; set; }

    }
}
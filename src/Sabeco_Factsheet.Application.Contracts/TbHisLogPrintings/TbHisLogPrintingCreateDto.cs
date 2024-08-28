using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbHisLogPrintings
{
    public abstract class TbHisLogPrintingCreateDtoBase
    {
        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMail { get; set; }
        public int? Type { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public DateTime InsertDate { get; set; }
        [StringLength(TbHisLogPrintingConsts.UserNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? UserName { get; set; }
        [StringLength(TbHisLogPrintingConsts.CompanyCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? CompanyCode { get; set; }
        [StringLength(TbHisLogPrintingConsts.FileLanguageMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? FileLanguage { get; set; }
        public bool? IsPrinting { get; set; }
    }
}
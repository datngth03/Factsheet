using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Sabeco_Factsheet.Validation;

namespace Sabeco_Factsheet.TbCompanyMajorTemps
{
    public abstract class TbCompanyMajorTempUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public string ShareHolderMajor { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbCompanyMajorTempConsts.ShareHolderTypeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string ShareHolderType { get; set; } = null!;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? ShareHolderValue { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? ShareHolderRate { get; set; }
        [StringLength(TbCompanyMajorTempConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public int? ClassId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbInvests
{
    public abstract class TbInvestUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbInvestConsts.BranchCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string BranchCode { get; set; } = null!;
        public int? BranchId { get; set; }
        public int? CompanyId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbInvestConsts.CompanyCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string CompanyCode { get; set; } = null!;
        public int? ShareNumTotal { get; set; }
        public decimal? ShareValueTotal { get; set; }
        [StringLength(TbInvestConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        public byte? DocStatus { get; set; }
        public bool? InvestGroup { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public bool IsDeleted { get; set; }

    }
}
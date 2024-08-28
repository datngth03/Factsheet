using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbInvestDetails
{
    public abstract class TbInvestDetailUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        public int ParentId { get; set; }
        public DateTime? DocDate { get; set; }
        [StringLength(TbInvestDetailConsts.DocNoMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? DocNo { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int InvestType { get; set; }
        public int? ShareNum { get; set; }
        public decimal? ShareValue { get; set; }
        [StringLength(TbInvestDetailConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public bool IsDeleted { get; set; }

    }
}
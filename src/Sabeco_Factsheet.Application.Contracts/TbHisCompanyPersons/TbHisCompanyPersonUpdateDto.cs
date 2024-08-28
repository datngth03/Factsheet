using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbHisCompanyPersons
{
    public abstract class TbHisCompanyPersonUpdateDtoBase : AuditedEntityDto<int>
    {
        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMail { get; set; }
        public DateTime? InsertDate { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int Type { get; set; }
        [StringLength(TbHisCompanyPersonConsts.BranchCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BranchCode { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int IdCompanyPerson { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int PersonId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? PositionId { get; set; }
        [StringLength(TbHisCompanyPersonConsts.PositionCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? PositionCode { get; set; }
        public decimal? PersonalValue { get; set; }
        public decimal? PersonalSharePercentage { get; set; }
        public decimal? OwnerValue { get; set; }
        public decimal? RepresentativePercentage { get; set; }
        [StringLength(TbHisCompanyPersonConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }

    }
}
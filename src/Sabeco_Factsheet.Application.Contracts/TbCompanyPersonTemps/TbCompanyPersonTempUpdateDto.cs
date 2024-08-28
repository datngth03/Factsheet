using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbCompanyPersonTemps
{
    public abstract class TbCompanyPersonTempUpdateDtoBase : AuditedEntityDto<int>
    {
        public int? idCompanyPerson { get; set; }
        [StringLength(TbCompanyPersonTempConsts.BranchCodeMaxLength)]
        public string? BranchCode { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int PersonId { get; set; }
        public int? PositionId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public byte? PositionType { get; set; }
        [StringLength(TbCompanyPersonTempConsts.PositionCodeMaxLength)]
        public string? PositionCode { get; set; }
        public decimal? PersonalValue { get; set; }
        public decimal? PersonalSharePercentage { get; set; }
        public decimal? OwnerValue { get; set; }
        public decimal? RepresentativePercentage { get; set; }
        [StringLength(TbCompanyPersonTempConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public bool IsDeleted { get; set; }

    }
}
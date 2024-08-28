using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Sabeco_Factsheet.Validation;

namespace Sabeco_Factsheet.TbLandInfos
{
    public abstract class TbLandInfoUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public string? Description { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public string TypeOfLand { get; set; } = null!;

        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? Area { get; set; } = 0;
        public string? SupportingDocument { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Payment { get; set; }
        public string? Remark { get; set; }
        public bool? IsActive { get; set; }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }

    }
}
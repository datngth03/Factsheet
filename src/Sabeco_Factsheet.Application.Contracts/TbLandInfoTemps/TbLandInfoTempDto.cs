using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLandInfoTemps
{
    public abstract class TbLandInfoTempDtoBase : AuditedEntityDto<int>
    {
        public int CompanyId { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string TypeOfLand { get; set; } = null!;
        public decimal? Area { get; set; }
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
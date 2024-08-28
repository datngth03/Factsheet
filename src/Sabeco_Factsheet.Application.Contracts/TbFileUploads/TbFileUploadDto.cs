using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbFileUploads
{
    public abstract class TbFileUploadDtoBase : AuditedEntityDto<int>
    {
        public int? companyId { get; set; }
        public int? personId { get; set; }
        public string? fileName { get; set; }
        public string? fullFileName { get; set; }
        public string? fileLink { get; set; }
        public DateTime? uploadDate { get; set; }
        public int? UserUpload { get; set; }
        public string? note { get; set; }
        public bool? IsActive { get; set; }
        public int DownloadCount { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }

    }
}
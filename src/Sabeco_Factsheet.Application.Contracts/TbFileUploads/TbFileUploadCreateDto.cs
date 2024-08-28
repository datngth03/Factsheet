using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbFileUploads
{
    public abstract class TbFileUploadCreateDtoBase
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
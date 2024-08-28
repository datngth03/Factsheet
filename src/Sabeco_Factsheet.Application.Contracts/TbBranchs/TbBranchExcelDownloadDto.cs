using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbBranchs
{
    public abstract class TbBranchExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public string? BriefName { get; set; }
        public string? Name { get; set; }
        public string? Name_EN { get; set; }
        public string? CompanyCode { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? Crt_DateMin { get; set; }
        public DateTime? Crt_DateMax { get; set; }

        public TbBranchExcelDownloadDtoBase()
        {

        }
    }
}
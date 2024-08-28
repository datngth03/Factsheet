using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbNationalities
{
    public abstract class TbNationalityExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public string? Code2 { get; set; }
        public string? Name_en { get; set; }
        public string? Name_vn { get; set; }
        public bool? IsActive { get; set; }

        public TbNationalityExcelDownloadDtoBase()
        {

        }
    }
}
using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public abstract class TbUserMappingCompanyExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? useridMin { get; set; }
        public int? useridMax { get; set; }
        public int? companyidMin { get; set; }
        public int? companyidMax { get; set; }
        public bool? IsActive { get; set; }

        public TbUserMappingCompanyExcelDownloadDtoBase()
        {

        }
    }
}
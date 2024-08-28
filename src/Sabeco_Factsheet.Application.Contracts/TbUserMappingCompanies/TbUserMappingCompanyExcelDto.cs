using System;

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public abstract class TbUserMappingCompanyExcelDtoBase
    {
        public int? userid { get; set; }
        public int? companyid { get; set; }
        public bool? IsActive { get; set; }
    }
}
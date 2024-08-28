using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public abstract class TbUserMappingCompanyCreateDtoBase
    {
        public int? userid { get; set; }
        public int? companyid { get; set; }
        public bool? IsActive { get; set; }
    }
}
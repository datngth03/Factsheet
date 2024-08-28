using System;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public abstract class TbUserMappingPersonExcelDtoBase
    {
        public int? userid { get; set; }
        public int? personid { get; set; }
        public bool? IsActive { get; set; }
    }
}
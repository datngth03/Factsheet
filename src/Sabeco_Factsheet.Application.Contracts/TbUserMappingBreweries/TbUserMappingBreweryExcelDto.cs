using System;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public abstract class TbUserMappingBreweryExcelDtoBase
    {
        public int? userid { get; set; }
        public int? breweryid { get; set; }
        public bool? IsActive { get; set; }
    }
}
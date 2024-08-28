using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public abstract class TbUserMappingBreweryCreateDtoBase
    {
        public int? userid { get; set; }
        public int? breweryid { get; set; }
        public bool? IsActive { get; set; }
    }
}
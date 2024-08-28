using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public abstract class TbUserMappingBreweryDtoBase : AuditedEntityDto<int>
    {
        public int? userid { get; set; }
        public int? breweryid { get; set; }
        public bool? IsActive { get; set; }

    }
}
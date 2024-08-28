using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public abstract class TbUserMappingPersonDtoBase : AuditedEntityDto<int>
    {
        public int? userid { get; set; }
        public int? personid { get; set; }
        public bool? IsActive { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public abstract class TbUserMappingPersonUpdateDtoBase : AuditedEntityDto<int>
    {
        public int? userid { get; set; }
        public int? personid { get; set; }
        public bool? IsActive { get; set; }

    }
}
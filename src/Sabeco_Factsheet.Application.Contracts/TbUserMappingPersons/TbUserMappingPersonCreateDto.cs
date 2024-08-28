using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public abstract class TbUserMappingPersonCreateDtoBase
    {
        public int? userid { get; set; }
        public int? personid { get; set; }
        public bool? IsActive { get; set; }
    }
}
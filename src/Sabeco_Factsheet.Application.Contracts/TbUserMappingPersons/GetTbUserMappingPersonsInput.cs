using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public abstract class GetTbUserMappingPersonsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? useridMin { get; set; }
        public int? useridMax { get; set; }
        public int? personidMin { get; set; }
        public int? personidMax { get; set; }
        public bool? IsActive { get; set; }

        public GetTbUserMappingPersonsInputBase()
        {

        }
    }
}
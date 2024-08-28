using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbTerms
{
    public abstract class GetTbTermsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? BranchIdMin { get; set; }
        public int? BranchIdMax { get; set; }
        public string? TermCode { get; set; }
        public int? FromYearMin { get; set; }
        public int? FromYearMax { get; set; }
        public int? ToYearMin { get; set; }
        public int? ToYearMax { get; set; }
        public string? Description { get; set; }

        public GetTbTermsInputBase()
        {

        }
    }
}
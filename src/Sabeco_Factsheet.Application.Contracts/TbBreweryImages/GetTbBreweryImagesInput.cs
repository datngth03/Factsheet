using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbBreweryImages
{
    public abstract class GetTbBreweryImagesInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public string? BreweryImage { get; set; }
        public string? ImageLink { get; set; }
        public bool? isActive { get; set; }
        public int? create_userMin { get; set; }
        public int? create_userMax { get; set; }
        public DateTime? create_dateMin { get; set; }
        public DateTime? create_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }

        public GetTbBreweryImagesInputBase()
        {

        }
    }
}
using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public abstract class TbUserMappingBreweryExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? useridMin { get; set; }
        public int? useridMax { get; set; }
        public int? breweryidMin { get; set; }
        public int? breweryidMax { get; set; }
        public bool? IsActive { get; set; }

        public TbUserMappingBreweryExcelDownloadDtoBase()
        {

        }
    }
}
using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbHisBrewerySkus
{
    public abstract class TbHisBrewerySkuExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMailMin { get; set; }
        public DateTime? DateSendMailMax { get; set; }
        public DateTime? InsertDateMin { get; set; }
        public DateTime? InsertDateMax { get; set; }
        public int? TypeMin { get; set; }
        public int? TypeMax { get; set; }
        public int? IdBrewerySKUMin { get; set; }
        public int? IdBrewerySKUMax { get; set; }
        public int? YearMin { get; set; }
        public int? YearMax { get; set; }
        public string? BreweryCode { get; set; }
        public string? SKUCode { get; set; }
        public decimal? ProductionVolumeMin { get; set; }
        public decimal? ProductionVolumeMax { get; set; }
        public byte? DocStatusMin { get; set; }
        public byte? DocStatusMax { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public int? BreweryIdMin { get; set; }
        public int? BreweryIdMax { get; set; }
        public int? SKUIdMin { get; set; }
        public int? SKUIdMax { get; set; }

        public TbHisBrewerySkuExcelDownloadDtoBase()
        {

        }
    }
}
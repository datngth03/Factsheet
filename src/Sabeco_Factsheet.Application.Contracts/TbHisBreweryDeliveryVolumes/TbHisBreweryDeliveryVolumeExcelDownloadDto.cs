using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbHisBreweryDeliveryVolumes
{
    public abstract class TbHisBreweryDeliveryVolumeExcelDownloadDtoBase
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
        public int? IdBreweryDeliveryVolumeMin { get; set; }
        public int? IdBreweryDeliveryVolumeMax { get; set; }
        public int? BreweryIdMin { get; set; }
        public int? BreweryIdMax { get; set; }
        public string? BreweryCode { get; set; }
        public int? YearMin { get; set; }
        public int? YearMax { get; set; }
        public decimal? DeliveryVolumeMin { get; set; }
        public decimal? DeliveryVolumeMax { get; set; }
        public bool? isActive { get; set; }
        public int? create_userMin { get; set; }
        public int? create_userMax { get; set; }
        public DateTime? create_dateMin { get; set; }
        public DateTime? create_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }

        public TbHisBreweryDeliveryVolumeExcelDownloadDtoBase()
        {

        }
    }
}
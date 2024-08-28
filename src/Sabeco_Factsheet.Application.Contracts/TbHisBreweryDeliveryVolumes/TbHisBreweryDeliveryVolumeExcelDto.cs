using System;

namespace Sabeco_Factsheet.TbHisBreweryDeliveryVolumes
{
    public abstract class TbHisBreweryDeliveryVolumeExcelDtoBase
    {
        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMail { get; set; }
        public DateTime? InsertDate { get; set; }
        public int Type { get; set; }
        public int IdBreweryDeliveryVolume { get; set; }
        public int? BreweryId { get; set; }
        public string? BreweryCode { get; set; }
        public int? Year { get; set; }
        public decimal? DeliveryVolume { get; set; }
        public bool? isActive { get; set; }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
    }
}
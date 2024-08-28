using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbHisBreweryDeliveryVolumes
{
    public abstract class TbHisBreweryDeliveryVolumeUpdateDtoBase : AuditedEntityDto<int>
    {
        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMail { get; set; }
        public DateTime? InsertDate { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int Type { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int IdBreweryDeliveryVolume { get; set; }
        public int? BreweryId { get; set; }
        [StringLength(TbHisBreweryDeliveryVolumeConsts.BreweryCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
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
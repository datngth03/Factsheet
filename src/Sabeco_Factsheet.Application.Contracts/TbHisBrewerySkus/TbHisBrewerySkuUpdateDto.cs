using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbHisBrewerySkus
{
    public abstract class TbHisBrewerySkuUpdateDtoBase : AuditedEntityDto<int>
    {
        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMail { get; set; }
        public DateTime? InsertDate { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int Type { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int IdBrewerySKU { get; set; }
        public int? Year { get; set; }
        [StringLength(TbHisBrewerySkuConsts.BreweryCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BreweryCode { get; set; }
        [StringLength(TbHisBrewerySkuConsts.SKUCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? SKUCode { get; set; }
        public decimal? ProductionVolume { get; set; }
        public byte? DocStatus { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public int? BreweryId { get; set; }
        public int? SKUId { get; set; }

    }
}
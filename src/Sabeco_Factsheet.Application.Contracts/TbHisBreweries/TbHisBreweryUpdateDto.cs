using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbHisBreweries
{
    public abstract class TbHisBreweryUpdateDtoBase : AuditedEntityDto<int>
    {
        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMail { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public DateTime InsertDate { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int Type { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int IdBrewery { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbHisBreweryConsts.BreweryNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string BreweryName { get; set; } = null!;
        [StringLength(TbHisBreweryConsts.BreweryName_ENMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BreweryName_EN { get; set; }
        public string? BreweryAdress { get; set; }
        public string? BriefName { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }
        public decimal? CapacityVolume { get; set; }
        public decimal? DeliveryVolume { get; set; }
        public string? Note { get; set; }
        public byte? DocStatus { get; set; }
        public bool? IsActive { get; set; }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }

    }
}
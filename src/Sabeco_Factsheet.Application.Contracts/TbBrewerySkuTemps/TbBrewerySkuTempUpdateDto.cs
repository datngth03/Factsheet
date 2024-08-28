using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Sabeco_Factsheet.Validation;

namespace Sabeco_Factsheet.TbBrewerySkuTemps
{
    public abstract class TbBrewerySkuTempUpdateDtoBase : AuditedEntityDto<int>
    {
        public int? idBrewerySKU { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [Range(1800, 2900, ErrorMessage = "Please enter a valid year (1800 - 2900).")]
        public int Year { get; set; }
        [StringLength(TbBrewerySkuTempConsts.BreweryCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BreweryCode { get; set; }
        [StringLength(TbBrewerySkuTempConsts.SKUCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? SKUCode { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal ProductionVolume { get; set; } = 0;
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
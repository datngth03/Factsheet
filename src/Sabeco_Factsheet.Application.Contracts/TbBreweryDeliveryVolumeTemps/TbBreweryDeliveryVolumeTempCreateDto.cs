using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Sabeco_Factsheet.Validation;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps
{
    public abstract class TbBreweryDeliveryVolumeTempCreateDtoBase
    {
        public int? idBreweryDeliveryVolume { get; set; }
        public int? BreweryId { get; set; }
        [StringLength(TbBreweryDeliveryVolumeTempConsts.BreweryCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BreweryCode { get; set; }
        [Range(1800, 2900, ErrorMessage = "Please enter a valid year (1800 - 2900).")]
        public int? Year { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal DeliveryVolume { get; set; } = 0;
        public bool? isActive { get; set; }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
    }
}
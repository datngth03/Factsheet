using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Sabeco_Factsheet.Validation;

namespace Sabeco_Factsheet.TbBreweries
{
    public abstract class TbBreweryCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbBreweryConsts.BreweryCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string BreweryCode { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbBreweryConsts.BreweryNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string BreweryName { get; set; } = null!;
        [StringLength(TbBreweryConsts.BreweryName_ENMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BreweryName_EN { get; set; }
        public string? BriefName { get; set; }
        public string? BreweryAdress { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal CapacityVolume { get; set; } = 0;

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal DeliveryVolume { get; set; } = 0;
        public string? Note { get; set; }
        public byte? DocStatus { get; set; }
        public bool? isActive { get; set; }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
    }
}
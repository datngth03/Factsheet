using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumes
{
    public abstract class TbBreweryDeliveryVolumeDtoBase : AuditedEntityDto<int>
    {
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
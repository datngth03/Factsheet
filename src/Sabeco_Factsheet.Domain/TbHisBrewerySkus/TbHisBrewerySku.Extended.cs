using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbHisBrewerySkus
{
    public class TbHisBrewerySku : TbHisBrewerySkuBase
    {
        //<suite-custom-code-autogenerated>
        public TbHisBrewerySku()
        {

        }

        public TbHisBrewerySku(int type, int idBrewerySKU, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, int? year = null, string? breweryCode = null, string? sKUCode = null, decimal? productionVolume = null, byte? docStatus = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? breweryId = null, int? sKUId = null)
            : base(type, idBrewerySKU, isSendMail, dateSendMail, insertDate, year, breweryCode, sKUCode, productionVolume, docStatus, isActive, crt_date, crt_user, mod_date, mod_user, breweryId, sKUId)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
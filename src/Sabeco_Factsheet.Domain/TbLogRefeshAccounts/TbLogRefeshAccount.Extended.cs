using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public class TbLogRefeshAccount : TbLogRefeshAccountBase
    {
        //<suite-custom-code-autogenerated>
        public TbLogRefeshAccount()
        {

        }

        public TbLogRefeshAccount(string accessToken, DateTime timeRefesh, bool isSuccess, string? useRefesh = null, string? failedReason = null)
            : base(accessToken, timeRefesh, isSuccess, useRefesh, failedReason)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
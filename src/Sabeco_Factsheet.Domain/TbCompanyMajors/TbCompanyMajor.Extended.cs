using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyMajors
{
    public class TbCompanyMajor : TbCompanyMajorBase
    {
        //<suite-custom-code-autogenerated>
        public TbCompanyMajor()
        {

        }

        public TbCompanyMajor(int companyId, string shareHolderMajor, string shareHolderType, bool isActive, bool isDeleted, DateTime? fromDate = null, DateTime? toDate = null, decimal? shareHolderValue = null, decimal? shareHolderRate = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? classId = null)
            : base(companyId, shareHolderMajor, shareHolderType, isActive, isDeleted, fromDate, toDate, shareHolderValue, shareHolderRate, note, crt_date, crt_user, mod_date, mod_user, classId)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
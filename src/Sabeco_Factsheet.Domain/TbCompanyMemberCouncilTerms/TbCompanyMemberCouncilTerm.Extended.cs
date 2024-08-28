using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public class TbCompanyMemberCouncilTerm : TbCompanyMemberCouncilTermBase
    {
        //<suite-custom-code-autogenerated>
        public TbCompanyMemberCouncilTerm()
        {

        }

        public TbCompanyMemberCouncilTerm(int? companyId = null, int? termFrom = null, int? termEnd = null)
            : base(companyId, termFrom, termEnd)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
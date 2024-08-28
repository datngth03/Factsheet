using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbPersonTemps
{
    public class TbPersonTemp : TbPersonTempBase
    {
        //<suite-custom-code-autogenerated>
        public TbPersonTemp()
        {

        }

        public TbPersonTemp(string code, string fullName, DateTime birthDate, int? idPerson = null, int? companyId = null, string? birthPlace = null, string? address = null, string? iDCardNo = null, DateTime? iDCardDate = null, string? idCardIssuePlace = null, string? ethnicity = null, string? religion = null, string? nationalityCode = null, string? gender = null, string? phone = null, string? email = null, string? note = null, string? image = null, bool? isActive = null, byte? docStatus = null, bool? isCheckRetirement = null, bool? isCheckTermEnd = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? oldCode = null)
            : base(code, fullName, birthDate, idPerson, companyId, birthPlace, address, iDCardNo, iDCardDate, idCardIssuePlace, ethnicity, religion, nationalityCode, gender, phone, email, note, image, isActive, docStatus, isCheckRetirement, isCheckTermEnd, crt_date, crt_user, mod_date, mod_user, oldCode)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
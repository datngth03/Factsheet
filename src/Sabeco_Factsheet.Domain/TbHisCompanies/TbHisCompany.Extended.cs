using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbHisCompanies
{
    public class TbHisCompany : TbHisCompanyBase
    {
        //<suite-custom-code-autogenerated>
        public TbHisCompany()
        {

        }

        public TbHisCompany(int type, int idCompany, int parentId, bool isGroup, string code, string name, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, string? name_EN = null, string? briefName = null, string? contactInfo_01 = null, string? contactInfo_02 = null, string? contactInfo_03 = null, string? contactInfo_04 = null, string? contactInfo_05 = null, string? contactInfo_06 = null, string? stockCode = null, string? stockExchange = null, DateTime? stockRegistrationDate = null, bool? isPublicCompany = null, string? licenseNo = null, string? license = null, byte? registrationOrder = null, DateTime? registrationDate0 = null, DateTime? registrationDate = null, DateTime? latestAmendment = null, string? legalRepresent = null, string? companyType = null, decimal? charteredCapital = null, decimal? totalShare = null, decimal? listedShare = null, int? parValue = null, string? contactName1 = null, string? contactDept1 = null, string? contactMail1 = null, string? contactPosition1 = null, string? contactPhone1 = null, string? contactName2 = null, string? contactDept2 = null, string? contactMail2 = null, string? contactPosition2 = null, string? contactPhone2 = null, double? longtitude = null, double? latitude = null, string? note = null, byte? docStatus = null, decimal? directShareholding = null, decimal? consolidatedShareholding = null, string? consolidateNoted = null, decimal? votingRightDirect = null, decimal? votingRightTotal = null, string? image = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
            : base(type, idCompany, parentId, isGroup, code, name, isSendMail, dateSendMail, insertDate, name_EN, briefName, contactInfo_01, contactInfo_02, contactInfo_03, contactInfo_04, contactInfo_05, contactInfo_06, stockCode, stockExchange, stockRegistrationDate, isPublicCompany, licenseNo, license, registrationOrder, registrationDate0, registrationDate, latestAmendment, legalRepresent, companyType, charteredCapital, totalShare, listedShare, parValue, contactName1, contactDept1, contactMail1, contactPosition1, contactPhone1, contactName2, contactDept2, contactMail2, contactPosition2, contactPhone2, longtitude, latitude, note, docStatus, directShareholding, consolidatedShareholding, consolidateNoted, votingRightDirect, votingRightTotal, image, isActive, crt_date, crt_user, mod_date, mod_user)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
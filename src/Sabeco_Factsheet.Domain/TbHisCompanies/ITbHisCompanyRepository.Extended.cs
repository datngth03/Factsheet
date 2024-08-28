using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbHisCompanies
{
    public partial interface ITbHisCompanyRepository
    {
        //HQSOFT's generated code:
        Task<List<TbHisCompany>> GetListNoPagedAsync(
                    string? filterText = null,
                    bool? isSendMail = null,
                    DateTime? dateSendMailMin = null,
                    DateTime? dateSendMailMax = null,
                    DateTime? insertDateMin = null,
                    DateTime? insertDateMax = null,
                    int? typeMin = null,
                    int? typeMax = null,
                    int? idCompanyMin = null,
                    int? idCompanyMax = null,
                    int? parentIdMin = null,
                    int? parentIdMax = null,
                    bool? isGroup = null,
                    string? code = null,
                    string? name = null,
                    string? name_EN = null,
                    string? briefName = null,
                    string? contactInfo_01 = null,
                    string? contactInfo_02 = null,
                    string? contactInfo_03 = null,
                    string? contactInfo_04 = null,
                    string? contactInfo_05 = null,
                    string? contactInfo_06 = null,
                    string? stockCode = null,
                    string? stockExchange = null,
                    DateTime? stockRegistrationDateMin = null,
                    DateTime? stockRegistrationDateMax = null,
                    bool? isPublicCompany = null,
                    string? licenseNo = null,
                    string? license = null,
                    byte? registrationOrderMin = null,
                    byte? registrationOrderMax = null,
                    DateTime? registrationDate0Min = null,
                    DateTime? registrationDate0Max = null,
                    DateTime? registrationDateMin = null,
                    DateTime? registrationDateMax = null,
                    DateTime? latestAmendmentMin = null,
                    DateTime? latestAmendmentMax = null,
                    string? legalRepresent = null,
                    string? companyType = null,
                    decimal? charteredCapitalMin = null,
                    decimal? charteredCapitalMax = null,
                    decimal? totalShareMin = null,
                    decimal? totalShareMax = null,
                    decimal? listedShareMin = null,
                    decimal? listedShareMax = null,
                    int? parValueMin = null,
                    int? parValueMax = null,
                    string? contactName1 = null,
                    string? contactDept1 = null,
                    string? contactMail1 = null,
                    string? contactPosition1 = null,
                    string? contactPhone1 = null,
                    string? contactName2 = null,
                    string? contactDept2 = null,
                    string? contactMail2 = null,
                    string? contactPosition2 = null,
                    string? contactPhone2 = null,
                    double? longtitudeMin = null,
                    double? longtitudeMax = null,
                    double? latitudeMin = null,
                    double? latitudeMax = null,
                    string? note = null,
                    byte? docStatusMin = null,
                    byte? docStatusMax = null,
                    decimal? directShareholdingMin = null,
                    decimal? directShareholdingMax = null,
                    decimal? consolidatedShareholdingMin = null,
                    decimal? consolidatedShareholdingMax = null,
                    string? consolidateNoted = null,
                    decimal? votingRightDirectMin = null,
                    decimal? votingRightDirectMax = null,
                    decimal? votingRightTotalMin = null,
                    decimal? votingRightTotalMax = null,
                    string? image = null,
                    bool? isActive = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Sabeco_Factsheet.Permissions;
using Sabeco_Factsheet.TbHisCompanies;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisCompanies
{
    public class TbHisCompaniesAppService : TbHisCompaniesAppServiceBase, ITbHisCompaniesAppService
    {
        //<suite-custom-code-autogenerated>
        public TbHisCompaniesAppService(ITbHisCompanyRepository tbHisCompanyRepository, TbHisCompanyManager tbHisCompanyManager, IDistributedCache<TbHisCompanyDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbHisCompanyRepository, tbHisCompanyManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbHisCompanyDto>> GetListNoPagedAsync(GetTbHisCompaniesInput input)
        {
            var items = await _tbHisCompanyRepository.GetListNoPagedAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdCompanyMin, input.IdCompanyMax, input.ParentIdMin, input.ParentIdMax, input.IsGroup, input.Code, input.Name, input.Name_EN, input.BriefName, input.ContactInfo_01, input.ContactInfo_02, input.ContactInfo_03, input.ContactInfo_04, input.ContactInfo_05, input.ContactInfo_06, input.StockCode, input.StockExchange, input.StockRegistrationDateMin, input.StockRegistrationDateMax, input.IsPublicCompany, input.LicenseNo, input.License, input.RegistrationOrderMin, input.RegistrationOrderMax, input.RegistrationDate0Min, input.RegistrationDate0Max, input.RegistrationDateMin, input.RegistrationDateMax, input.LatestAmendmentMin, input.LatestAmendmentMax, input.LegalRepresent, input.CompanyType, input.CharteredCapitalMin, input.CharteredCapitalMax, input.TotalShareMin, input.TotalShareMax, input.ListedShareMin, input.ListedShareMax, input.ParValueMin, input.ParValueMax, input.ContactName1, input.ContactDept1, input.ContactMail1, input.ContactPosition1, input.ContactPhone1, input.ContactName2, input.ContactDept2, input.ContactMail2, input.ContactPosition2, input.ContactPhone2, input.longtitudeMin, input.longtitudeMax, input.latitudeMin, input.latitudeMax, input.Note, input.DocStatusMin, input.DocStatusMax, input.DirectShareholdingMin, input.DirectShareholdingMax, input.ConsolidatedShareholdingMin, input.ConsolidatedShareholdingMax, input.ConsolidateNoted, input.VotingRightDirectMin, input.VotingRightDirectMax, input.VotingRightTotalMin, input.VotingRightTotalMax, input.Image, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.Sorting);

            return ObjectMapper.Map<List<TbHisCompany>, List<TbHisCompanyDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
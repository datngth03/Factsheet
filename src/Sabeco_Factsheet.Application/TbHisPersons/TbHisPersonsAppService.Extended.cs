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
using Sabeco_Factsheet.TbHisPersons;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisPersons
{
    public class TbHisPersonsAppService : TbHisPersonsAppServiceBase, ITbHisPersonsAppService
    {
        //<suite-custom-code-autogenerated>
        public TbHisPersonsAppService(ITbHisPersonRepository tbHisPersonRepository, TbHisPersonManager tbHisPersonManager, IDistributedCache<TbHisPersonDownloadTokenCacheItem, string> downloadTokenCache)
            : base(tbHisPersonRepository, tbHisPersonManager, downloadTokenCache)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbHisPersonDto>> GetListNoPagedAsync(GetTbHisPersonsInput input)
        {
            var items = await _tbHisPersonRepository.GetListNoPagedAsync(input.FilterText, input.IsSendMail, input.DateSendMailMin, input.DateSendMailMax, input.InsertDateMin, input.InsertDateMax, input.TypeMin, input.TypeMax, input.IdPersonMin, input.IdPersonMax, input.Code, input.CompanyIdMin, input.CompanyIdMax, input.FullName, input.BirthDateMin, input.BirthDateMax, input.BirthPlace, input.Address, input.IDCardNo, input.IDCardDateMin, input.IDCardDateMax, input.IdCardIssuePlace, input.Ethnicity, input.Religion, input.NationalityCode, input.Gender, input.Phone, input.Email, input.Note, input.Image, input.IsActive, input.DocStatusMin, input.DocStatusMax, input.IsCheckRetirement, input.IsCheckTermEnd, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.OldCode, input.Sorting);

            return ObjectMapper.Map<List<TbHisPerson>, List<TbHisPersonDto>>(items);
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbContacts
{
    public partial interface ITbContactsAppService : IApplicationService
    {

        Task<PagedResultDto<TbContactDto>> GetListAsync(GetTbContactsInput input);

        Task<TbContactDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbContactDto> CreateAsync(TbContactCreateDto input);

        Task<TbContactDto> UpdateAsync(int id, TbContactUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbContactExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcontactIds);

        Task DeleteAllAsync(GetTbContactsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}
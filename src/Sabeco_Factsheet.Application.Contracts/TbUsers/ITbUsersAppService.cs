using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbUsers
{
    public partial interface ITbUsersAppService : IApplicationService
    {

        Task<PagedResultDto<TbUserDto>> GetListAsync(GetTbUsersInput input);

        Task<TbUserDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbUserDto> CreateAsync(TbUserCreateDto input);

        Task<TbUserDto> UpdateAsync(int id, TbUserUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbUserExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbuserIds);

        Task DeleteAllAsync(GetTbUsersInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}
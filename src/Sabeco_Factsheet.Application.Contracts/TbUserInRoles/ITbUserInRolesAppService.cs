using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbUserInRoles
{
    public partial interface ITbUserInRolesAppService : IApplicationService
    {

        Task<PagedResultDto<TbUserInRoleDto>> GetListAsync(GetTbUserInRolesInput input);

        Task<TbUserInRoleDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbUserInRoleDto> CreateAsync(TbUserInRoleCreateDto input);

        Task<TbUserInRoleDto> UpdateAsync(int id, TbUserInRoleUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbUserInRoleExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbuserinroleIds);

        Task DeleteAllAsync(GetTbUserInRolesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}